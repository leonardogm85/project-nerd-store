using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalog.Application.Interfaces;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.DomainNotifications;
using NerdStore.Orders.Application.Commands;
using NerdStore.Orders.Application.Queries;

namespace NerdStore.WebApp.Mvc.Controllers
{
    [Route("cart")]
    public class CartController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        private readonly IOrderQuery _orderQuery;
        private readonly IMediatorHandler _mediatorHandler;

        public CartController(
            IProductAppService productAppService,
            IOrderQuery orderQuery,
            IMediatorHandler mediatorHandler,
            INotificationHandler<DomainNotification> domainNotificationHandler) : base(mediatorHandler, domainNotificationHandler)
        {
            _productAppService = productAppService;
            _orderQuery = orderQuery;
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("my-cart")]
        public async Task<IActionResult> Index()
        {
            return View(await _orderQuery.GetDraftOrderByClientIdAsync(ClientId));
        }

        [HttpPost("add-item")]
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

        [HttpPost("remove-item")]
        public async Task<IActionResult> RemoveItem(Guid productId)
        {
            var product = await _productAppService.GetProductByIdAsync(productId);

            if (product is null)
            {
                return BadRequest();
            }

            var command = new RemoveItemCommand(
                ClientId,
                product.Id);

            await _mediatorHandler.SendCommandAsync(command);

            if (IsValid())
            {
                return RedirectToAction(
                    "Index",
                    "Cart");
            }

            return View(
                "Index",
                await _orderQuery.GetDraftOrderByClientIdAsync(ClientId));
        }

        [HttpPost("update-item")]
        public async Task<IActionResult> UpdateItem(Guid productId, int quantity)
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

            var command = new UpdateItemCommand(
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

            return View(
                "Index",
                await _orderQuery.GetDraftOrderByClientIdAsync(ClientId));
        }

        [HttpPost("set-voucher")]
        public async Task<IActionResult> SetVoucher(string voucherCode)
        {
            var command = new SetVoucherCommand(
                ClientId,
                voucherCode);

            await _mediatorHandler.SendCommandAsync(command);

            if (IsValid())
            {
                return RedirectToAction(
                    "Index",
                    "Cart");
            }

            return View(
                "Index",
                await _orderQuery.GetDraftOrderByClientIdAsync(ClientId));
        }
    }
}
