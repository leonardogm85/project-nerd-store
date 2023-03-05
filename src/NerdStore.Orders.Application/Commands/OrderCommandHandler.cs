using MediatR;
using NerdStore.Core.Messages;

namespace NerdStore.Orders.Application.Commands
{
    public class OrderCommandHandler
        : IRequestHandler<AddItemCommand, bool>
    {
        public async Task<bool> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            if (!IsValid(request))
            {
                return false;
            }

            return true;
        }

        private bool IsValid(Command request)
        {
            if (request.IsValid())
            {
                return true;
            }

            foreach (var error in request.ValidationResult.Errors)
            {
                // TODO: Throw event
            }

            return false;
        }
    }
}
