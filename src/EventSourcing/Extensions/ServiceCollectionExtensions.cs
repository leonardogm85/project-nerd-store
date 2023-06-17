using EventSourcing.Interfaces;
using EventSourcing.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EventSourcing.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEventSourcing(this IServiceCollection services)
        {
            services.AddSingleton<IEventStoreService, EventStoreService>();
        }
    }
}
