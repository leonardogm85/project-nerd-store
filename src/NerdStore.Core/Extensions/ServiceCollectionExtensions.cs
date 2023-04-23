using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages.Common.DomainNotifications.Handlers;
using NerdStore.Core.Messages.Common.DomainNotifications;

namespace NerdStore.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCore(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddMediatR(c =>
            {
                c.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
            });
        }
    }
}
