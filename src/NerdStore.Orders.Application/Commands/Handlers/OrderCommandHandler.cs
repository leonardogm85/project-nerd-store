﻿using MediatR;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages;
using NerdStore.Orders.Application.Events;
using NerdStore.Orders.Domain.Entities;
using NerdStore.Orders.Domain.Interfaces.Repositories;

namespace NerdStore.Orders.Application.Commands
{
    public class OrderCommandHandler :
        IRequestHandler<AddItemCommand, bool>,
        IRequestHandler<UpdateItemCommand, bool>,
        IRequestHandler<RemoveItemCommand, bool>,
        IRequestHandler<SetVoucherCommand, bool>
    {

        // TODO: StartOrder, FinalizeOrder and CancelOrder Handlers

        private readonly IMediatorHandler _mediatorHandler;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(IMediatorHandler mediatorHandler, IOrderRepository orderRepository)
        {
            _mediatorHandler = mediatorHandler;
            _orderRepository = orderRepository;
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
                order = new Order(command.ClientId);

                var item = new Item(
                    order.Id,
                    command.ProductId,
                    command.ProductName,
                    command.Quantity,
                    command.Price);

                order.AddItem(item);

                _orderRepository.AddOrder(order);
                _orderRepository.AddItem(item);

                order.AddEvent(new DraftOrderStartedEvent(
                    order.Id,
                    order.ClientId,
                    order.Total));
            }
            else
            {
                var item = new Item(
                    order.Id,
                    command.ProductId,
                    command.ProductName,
                    command.Quantity,
                    command.Price);

                var existingItem = order.GetItemByProductId(command.ProductId);

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

        public async Task<bool> Handle(UpdateItemCommand command, CancellationToken cancellationToken)
        {
            if (!await IsValidAsync(command))
            {
                return false;
            }

            var order = await _orderRepository.GetDraftOrderByClientIdAsync(command.ClientId);

            if (order is null)
            {
                await _mediatorHandler.PublishDomainNotificationAsync(new(nameof(Order), "Order not found."));

                return false;
            }

            var existingItem = order.GetItemByProductId(command.ProductId);

            if (existingItem is null)
            {
                await _mediatorHandler.PublishDomainNotificationAsync(new(nameof(Item), "Item not found."));

                return false;
            }

            existingItem.ChangeQuantity(command.Quantity);

            order.UpdateItem(existingItem);

            _orderRepository.UpdateOrder(order);
            _orderRepository.UpdateItem(existingItem);

            order.AddEvent(new OrderUpdatedEvent(
                order.Id,
                order.ClientId,
                order.Total));

            order.AddEvent(new OrderItemUpdatedEvent(
                order.Id,
                order.ClientId,
                command.ProductId,
                command.ProductName,
                command.Quantity,
                command.Price));

            return await _orderRepository.UnitOfWork.CommitAsync();
        }

        public async Task<bool> Handle(RemoveItemCommand command, CancellationToken cancellationToken)
        {
            if (!await IsValidAsync(command))
            {
                return false;
            }

            var order = await _orderRepository.GetDraftOrderByClientIdAsync(command.ClientId);

            if (order is null)
            {
                await _mediatorHandler.PublishDomainNotificationAsync(new(nameof(Order), "Order not found."));

                return false;
            }

            var existingItem = order.GetItemByProductId(command.ProductId);

            if (existingItem is null)
            {
                await _mediatorHandler.PublishDomainNotificationAsync(new(nameof(Item), "Item not found."));

                return false;
            }

            order.RemoveItem(existingItem);

            _orderRepository.UpdateOrder(order);
            _orderRepository.RemoveItem(existingItem);

            order.AddEvent(new OrderUpdatedEvent(
                order.Id,
                order.ClientId,
                order.Total));

            order.AddEvent(new OrderItemRemovedEvent(
                order.Id,
                order.ClientId,
                command.ProductId));

            return await _orderRepository.UnitOfWork.CommitAsync();
        }

        public async Task<bool> Handle(SetVoucherCommand command, CancellationToken cancellationToken)
        {
            if (!await IsValidAsync(command))
            {
                return false;
            }

            var order = await _orderRepository.GetDraftOrderByClientIdAsync(command.ClientId);

            if (order is null)
            {
                await _mediatorHandler.PublishDomainNotificationAsync(new(nameof(Order), "Order not found."));

                return false;
            }

            var voucher = await _orderRepository.GetVoucherByCodeAsync(command.VoucherCode);

            if (voucher is null)
            {
                await _mediatorHandler.PublishDomainNotificationAsync(new(nameof(Voucher), "Voucher not found."));

                return false;
            }

            var useVoucherValidation = order.UseVoucher(voucher);

            if (useVoucherValidation.IsValid)
            {
                _orderRepository.UpdateOrder(order);

                order.AddEvent(new OrderUpdatedEvent(
                    order.Id,
                    order.ClientId,
                    order.Total));

                order.AddEvent(new SetVoucherEvent(
                    order.Id,
                    order.ClientId,
                    command.VoucherCode));

                return await _orderRepository.UnitOfWork.CommitAsync();
            }

            foreach (var error in useVoucherValidation.Errors)
            {
                await _mediatorHandler.PublishDomainNotificationAsync(new(nameof(Voucher), error.ErrorMessage));
            }

            return false;
        }

        private async Task<bool> IsValidAsync(Command command)
        {
            var validationResult = command.GetValidationResult();

            if (validationResult.IsValid)
            {
                return true;
            }

            foreach (var error in validationResult.Errors)
            {
                await _mediatorHandler.PublishDomainNotificationAsync(new(command.MessageType, error.ErrorMessage));
            }

            return false;
        }
    }
}
