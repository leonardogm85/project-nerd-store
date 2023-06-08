using NerdStore.Core.Messages;

namespace NerdStore.Orders.Application.Events
{
    public class SetVoucherEvent : Event
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }
        public string VoucherCode { get; }

        public SetVoucherEvent(Guid orderId, Guid clientId, string voucherCode)
            : base(orderId)
        {
            OrderId = orderId;
            ClientId = clientId;
            VoucherCode = voucherCode;
        }
    }
}
