using NerdStore.Core.Messages;

namespace NerdStore.Core.DomainObjects
{
    public abstract class Entity
    {
        private readonly List<Event> _events = new();

        public Guid Id { get; private set; }

        public Entity() => Id = Guid.NewGuid();

        public override bool Equals(object? obj) => obj is Entity entity && ReferenceEquals(this, entity) && Id.Equals(entity.Id);

        public override int GetHashCode() => HashCode.Combine(Id);

        public override string ToString() => $"{GetType().Name} [Id={Id}]";

        public static bool operator ==(Entity? entityA, Entity? entityB)
        {
            if (entityA is null)
            {
                if (entityB is null)
                {
                    return true;
                }

                return false;
            }

            return entityA.Equals(entityB);
        }

        public static bool operator !=(Entity? entityA, Entity? entityB) => !(entityA == entityB);

        public virtual bool IsValid() => throw new NotImplementedException();

        public void AddEvent(Event @event)
        {
            _events.Add(@event);
        }

        public void RemoveEvent(Event @event)
        {
            _events.Remove(@event);
        }

        public IReadOnlyList<Event> GetEvents()
        {
            return _events.AsReadOnly();
        }

        public void RemoveEvents()
        {
            _events.Clear();
        }

        public bool HasEvents()
        {
            return _events.Any();
        }
    }
}
