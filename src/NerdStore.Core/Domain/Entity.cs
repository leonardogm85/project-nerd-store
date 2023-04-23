using NerdStore.Core.Messages;

namespace NerdStore.Core.Domain
{
    public abstract class Entity : INotifiable
    {
        private readonly List<Event> _events = new();

        public Guid Id { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object? obj)
        {
            return obj is Entity entity
                &&
                ReferenceEquals(this, entity)
                &&
                Id.Equals(entity.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        public IReadOnlyCollection<Event> GetEvents()
        {
            return _events;
        }

        public bool HasEvents()
        {
            return _events.Any();
        }

        public void AddEvent(Event @event)
        {
            _events.Add(@event);
        }

        public void RemoveEvent(Event @event)
        {
            _events.Remove(@event);
        }

        public void ClearEvents()
        {
            _events.Clear();
        }
    }
}
