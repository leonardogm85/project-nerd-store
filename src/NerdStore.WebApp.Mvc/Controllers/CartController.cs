using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalog.Application.Interfaces;
using NerdStore.Core.Mediator;
using NerdStore.Orders.Application.Commands;

namespace NerdStore.WebApp.Mvc.Controllers
{
    [Route("carts")]
    public class CartController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProductAppService _productAppService;

        public CartController(IMediatorHandler mediatorHandler, IProductAppService productAppService)
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
                ViewData["Error"] = "Insufficient stock.";
                return RedirectToAction(
                    nameof(ShowcaseController.ProductDetails),
                    nameof(ShowcaseController),
                    new { productId });
            }

            var command = new AddItemCommand(
                ClientId,
                product.Id,
                product.Name,
                quantity,
                product.Price);

            await _mediatorHandler.SendCommandAsync(command);

            // TODO: Get result

            ViewData["Error"] = "Insufficient Unavailable.";
            return RedirectToAction(
                nameof(ShowcaseController.ProductDetails),
                nameof(ShowcaseController),
                new { productId });
        }
    }
}
