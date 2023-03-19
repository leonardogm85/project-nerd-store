using MediatR;
using NerdStore.Catalog.Application.Interfaces;
using NerdStore.Catalog.Application.Services;
using NerdStore.Catalog.Data.Context;
using NerdStore.Catalog.Data.Repositories;
using NerdStore.Catalog.Domain.EventHandlers;
using NerdStore.Catalog.Domain.Events;
using NerdStore.Catalog.Domain.Interfaces.Repositories;
using NerdStore.Catalog.Domain.Interfaces.Services;
using NerdStore.Catalog.Domain.Services;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.DomainNotifications;
using NerdStore.Orders.Application.Commands;
using NerdStore.Orders.Application.Events;
using NerdStore.Orders.Data.Context;
using NerdStore.Orders.Data.Repositories;
using NerdStore.Orders.Domain.Interfaces.Repositories;

namespace NerdStore.WebApp.Mvc.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            // Core
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Catalog
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<CatalogContext>();
            services.AddScoped<INotificationHandler<ProductWithLowStockEvent>, ProductEventHandler>();

            // Order
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<OrderContext>();
            services.AddScoped<IRequestHandler<AddItemCommand, bool>, OrderCommandHandler>();
            services.AddScoped<INotificationHandler<DraftOrderStartedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderUpdatedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderItemAddedEvent>, OrderEventHandler>();
        }
    }
}
