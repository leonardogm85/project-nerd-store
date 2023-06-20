using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages.Common.DomainNotifications;
using NerdStore.Orders.Application.Queries;

namespace NerdStore.WebApp.Mvc.Controllers
{
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderQuery _orderQuery;

        public OrdersController(
            IOrderQuery orderQuery,
            IMediatorHandler mediatorHandler,
            INotificationHandler<DomainNotification> domainNotificationHandler)
            : base(mediatorHandler, domainNotificationHandler)
        {
            _orderQuery = orderQuery;
        }

        [HttpGet("my-orders")]
        public async Task<IActionResult> Index()
        {
            return View(await _orderQuery.GetPaidAndCanceledOrdersByClientIdAsync(ClientId));
        }
    }
}
