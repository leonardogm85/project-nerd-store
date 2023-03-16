using MediatR;

namespace NerdStore.Core.Messages.CommonMessages.DomainNotifications
{
    public class DomainNotification : Message, INotification
    {
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }
        public DateTime Timestamp { get; private set; }

        public DomainNotification(string key, string value) : base(Guid.NewGuid())
        {
            DomainNotificationId = AggregateId;
            Version = 1;
            Key = key;
            Value = value;
            Timestamp = DateTime.Now;
        }
    }
}
