using MediatR;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommonMessages.DomainNotifications;
using NerdStore.Orders.Application.Events;
using NerdStore.Orders.Domain.Entities;
using NerdStore.Orders.Domain.Interfaces.Repositories;

namespace NerdStore.Orders.Application.Commands
{
    public class OrderCommandHandler
        : IRequestHandler<AddItemCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public OrderCommandHandler(IOrderRepository orderRepository, IMediatorHandler mediatorHandler)
        {
            _orderRepository = orderRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Handle(AddItemCommand command, CancellationToken cancellationToken)
        {
            if (!await IsValidAsync(command))
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

                order.AddEvent(new DraftOrderStartedEvent(
                    order.Id,
                    order.ClientId));
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

                order.AddEvent(new OrderUpdatedEvent(
                    order.Id,
                    order.ClientId,
                    order.Total));
            }

            order.AddEvent(new OrderItemAddedEvent(
                order.Id,
                order.ClientId,
                command.ProductId,
                command.ProductName,
                command.Quantity,
                command.Price));

            return await _orderRepository.UnitOfWork.CommitAsync();
        }

        private async Task<bool> IsValidAsync(Command command)
        {
            if (command.IsValid())
            {
                return true;
            }

            foreach (var error in command.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishNotificationAsync(new DomainNotification(command.MessageType, error.ErrorMessage));
            }

            return false;
        }
    }
}
