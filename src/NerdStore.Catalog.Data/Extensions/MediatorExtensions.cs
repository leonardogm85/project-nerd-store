﻿using NerdStore.Core.Mediator;
using NerdStore.Core.Domain;
using NerdStore.Catalog.Data.Context;

namespace NerdStore.Catalog.Data.Extensions
{
    public static class MediatorExtensions
    {
        public static async Task PublishEventsAsync(this IMediatorHandler mediator, CatalogContext context)
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
                .ForEach(e => e.Entity.ClearEvents());

            context
                .ChangeTracker
                .Clear();

            var taskEvents = domainEvents
                .Select(async e => await mediator.PublishEventAsync(e));

            await Task.WhenAll(taskEvents);
        }
    }
}
