using NerdStore.Core.Messages;

namespace NerdStore.Core.Domain
{
    public interface INotifiable
    {
        IReadOnlyCollection<Event> GetEvents();
        bool HasEvents();
        void AddEvent(Event @event);
        void RemoveEvent(Event @event);
        void ClearEvents();
    }
}
