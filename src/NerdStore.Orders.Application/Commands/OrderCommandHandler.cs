using MediatR;
using NerdStore.Core.Messages;
using NerdStore.Orders.Domain.Entities;
using NerdStore.Orders.Domain.Interfaces.Repositories;

namespace NerdStore.Orders.Application.Commands
{
    public class OrderCommandHandler
        : IRequestHandler<AddItemCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(AddItemCommand command, CancellationToken cancellationToken)
        {
            if (!IsValid(command))
            {
                return false;
            }

            var order = await _orderRepository.GetDraftOrderByClientIdAsync(command.ClientId);

            if (order is null)
            {
                order = Order.Factory.NewDraftOrder(command.ClientId);

                var item = new Item(
                    order.Id,
                    command.ProductId,
                    command.ProductName,
                    command.Quantity,
                    command.Price);

                order.AddItem(item);

                _orderRepository.AddOrder(order);
            }
            else
            {
                var item = new Item(
                    order.Id,
                    command.ProductId,
                    command.ProductName,
                    command.Quantity,
                    command.Price);

                var existingItem = order.Items
                    .FirstOrDefault(i => i.ProductId == item.ProductId);

                order.AddItem(item);

                if (existingItem is null)
                {
                    _orderRepository.AddItem(item);
                }
                else
                {
                    _orderRepository.UpdateItem(existingItem);
                }

                _orderRepository.UpdateOrder(order);
            }

            return await _orderRepository.UnitOfWork.CommitAsync();
        }

        private bool IsValid(Command command)
        {
            if (command.IsValid())
            {
                return true;
            }

            foreach (var error in command.ValidationResult.Errors)
            {
                // TODO: Throw event
            }

            return false;
        }
    }
}
