using FluentValidation.Results;
using MediatR;

namespace NerdStore.Core.Messages
{
    public abstract class Command : Message, IRequest<bool>
    {
        public DateTime Timestamp { get; }

        protected Command(Guid aggregateId) : base(aggregateId)
        {
            Timestamp = DateTime.UtcNow;
        }

        public abstract ValidationResult GetValidationResult();
    }
}
