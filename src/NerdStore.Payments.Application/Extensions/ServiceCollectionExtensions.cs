using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Core.Messages.Common.IntegrationEvents;
using NerdStore.Payments.AntiCorruption.Configuration;
using NerdStore.Payments.AntiCorruption.Facades;
using NerdStore.Payments.AntiCorruption.Gateways;
using NerdStore.Payments.AntiCorruption.Interfaces.Configuration;
using NerdStore.Payments.AntiCorruption.Interfaces.Gateways;
using NerdStore.Payments.Data.Context;
using NerdStore.Payments.Data.Repositories;
using NerdStore.Payments.Domain.Events.Handlers;
using NerdStore.Payments.Domain.Interfaces.Facades;
using NerdStore.Payments.Domain.Interfaces.Repositories;
using NerdStore.Payments.Domain.Interfaces.Services;
using NerdStore.Payments.Domain.Services;

namespace NerdStore.Payments.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPayments(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentCreditCardFacade, PaymentCreditCardFacade>();
            services.AddScoped<IPayPalGateway, PayPalGateway>();
            services.AddScoped<IConfigurationManager, ConfigurationManager>();

            services.AddScoped<INotificationHandler<OrderStockConfirmedEvent>, PaymentEventHandler>();

            services.AddDbContext<PaymentContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });
        }
    }
}
