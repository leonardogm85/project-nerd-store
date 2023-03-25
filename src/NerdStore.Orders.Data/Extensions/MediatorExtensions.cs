﻿using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.DomainObjects;
using NerdStore.Orders.Data.Context;

namespace NerdStore.Orders.Data.Extensions
{
    public static class MediatorExtensions
    {
        public static async Task PublishEventsAsync(this IMediatorHandler mediator, OrderContext context)
        {
            var domainEntities = context
                .ChangeTracker
                .Entries<Entity>()
                .Where(e => e.Entity.HasEvents())
                .ToList();

            var domainEvents = domainEntities
                .SelectMany(e => e.Entity.GetEvents())
                .ToList();

            domainEntities
                .ForEach(e => e.Entity.RemoveEvents());

            var taskEvents = domainEvents
                .Select(async e => await mediator.PublishEventAsync(e));

            await Task.WhenAll(taskEvents);
        }
    }
}