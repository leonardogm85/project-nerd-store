using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalog.Application.Interfaces;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.DomainNotifications;
using NerdStore.Orders.Application.Commands;

namespace NerdStore.WebApp.Mvc.Controllers
{
    [Route("cart")]
    public class CartController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        private readonly IMediatorHandler _mediatorHandler;

        public CartController(
            IProductAppService productAppService,
            IMediatorHandler mediatorHandler,
            INotificationHandler<DomainNotification> domainNotificationHandler) : base(mediatorHandler, domainNotificationHandler)
        {
            _mediatorHandler = mediatorHandler;
            _productAppService = productAppService;
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost("my-cart")]
        public async Task<IActionResult> AddItem(Guid productId, int quantity)
        {
            var product = await _productAppService.GetProductByIdAsync(productId);

            if (product is null)
            {
                return BadRequest();
            }

            if (product.QuantityInStock < quantity)
            {
                TempData["Error"] = "Insufficient stock.";
                return RedirectToAction(
                    "ProductDetails",
                    "Showcase",
                    new { productId });
            }

            var command = new AddItemCommand(
                ClientId,
                product.Id,
                product.Name,
                quantity,
                product.Price);

            await _mediatorHandler.SendCommandAsync(command);

            if (IsValid())
            {
                return RedirectToAction(
                    "Index",
                    "Cart");
            }

            TempData["Errors"] = GetErrorMessages();
            return RedirectToAction(
                "ProductDetails",
                "Showcase",
                new { productId });
        }
    }
}
