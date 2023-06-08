using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Catalog.Application.Interfaces;
using NerdStore.Catalog.Application.Mappings;
using NerdStore.Catalog.Application.Services;
using NerdStore.Catalog.Data.Context;
using NerdStore.Catalog.Data.Repositories;
using NerdStore.Catalog.Domain.Events;
using NerdStore.Catalog.Domain.Events.Handlers;
using NerdStore.Catalog.Domain.Interfaces.Repositories;
using NerdStore.Catalog.Domain.Interfaces.Services;
using NerdStore.Catalog.Domain.Services;

namespace NerdStore.Catalog.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCatalog(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<INotificationHandler<ProductWithLowStockEvent>, ProductEventHandler>();

            services.AddDbContext<CatalogContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });

            services.AddAutoMapper(c =>
            {
                c.AddProfile<DomainToViewModelMappingProfile>();
                c.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}
