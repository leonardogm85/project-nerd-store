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
using NerdStore.Core.Mediator;
using NerdStore.Orders.Application.Commands;

namespace NerdStore.WebApp.Mvc.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            // Core
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Catalog
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<CatalogContext>();
            services.AddScoped<INotificationHandler<ProductWithLowStockEvent>, ProductEventHandler>();

            // Order
            services.AddScoped<IRequestHandler<AddItemCommand, bool>, OrderCommandHandler>();
        }
    }
}
