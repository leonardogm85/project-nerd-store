using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Core.Messages.Common.IntegrationEvents;
using NerdStore.Orders.Application.Commands;
using NerdStore.Orders.Application.Events;
using NerdStore.Orders.Application.Queries;
using NerdStore.Orders.Data.Context;
using NerdStore.Orders.Data.Repositories;
using NerdStore.Orders.Domain.Interfaces.Repositories;

namespace NerdStore.Orders.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddOrders(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderQuery, OrderQuery>();

            services.AddScoped<IRequestHandler<AddItemCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateItemCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveItemCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<SetVoucherCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<StartOrderCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<FinalizeOrderCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<CancelOrderCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<RestartOrderCommand, bool>, OrderCommandHandler>();

            services.AddScoped<INotificationHandler<DraftOrderStartedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<DraftOrderUpdatedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderItemAddedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderItemUpdatedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderItemRemovedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<SetVoucherEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderStockRejectedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<PaymentConfirmedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<PaymentRejectedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderFinishedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderRestartedEvent>, OrderEventHandler>();

            services.AddDbContext<OrderContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });
        }
    }
}
