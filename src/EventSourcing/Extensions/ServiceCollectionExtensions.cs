using EventSourcing.Interfaces;
using EventSourcing.Repositories;
using EventSourcing.Services;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Core.EventSourcing;

namespace EventSourcing.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEventSourcing(this IServiceCollection services)
        {
            services.AddSingleton<IEventStoreService, EventStoreService>();
            services.AddSingleton<IEventSourcingRepository, EventSourcingRepository>();
        }
    }
}
