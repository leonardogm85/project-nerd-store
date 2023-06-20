using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.EventSourcing;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages.Common.DomainNotifications;

namespace NerdStore.WebApp.Mvc.Controllers
{
    [Route("events")]
    public class EventsController : ControllerBase
    {
        private readonly IEventSourcingRepository _eventSourcingRepository;

        public EventsController(
            IEventSourcingRepository eventSourcingRepository,
            IMediatorHandler mediatorHandler,
            INotificationHandler<DomainNotification> domainNotificationHandler)
            : base(mediatorHandler, domainNotificationHandler)
        {
            _eventSourcingRepository = eventSourcingRepository;
        }

        [HttpGet("history/{aggregateId}")]
        public async Task<IActionResult> Index(Guid aggregateId)
        {
            return View(await _eventSourcingRepository.GetEventsByAggregateIdAsync(aggregateId));
        }
    }
}
