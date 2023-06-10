using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalog.Application.Interfaces;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages.Common.DomainNotifications;
using NerdStore.Orders.Application.Commands;
using NerdStore.Orders.Application.Queries;
using NerdStore.Orders.Application.Queries.ViewModels;

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
            INotificationHandler<DomainNotification> domainNotificationHandler)
            : base(mediatorHandler, domainNotificationHandler)
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
                TempData["Errors"] = new List<string>
                {
                    "Insufficient stock."
                };

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

            if (HasNotification())
            {
                TempData["Errors"] = GetNotifications();

                return RedirectToAction(
                    "ProductDetails",
                    "Showcase",
                    new { productId });
            }

            return RedirectToAction(
                "Index",
                "Cart");
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
                TempData["Errors"] = new List<string>
                {
                    "Insufficient stock."
                };

                return View(
                    "Index",
                    await _orderQuery.GetDraftOrderByClientIdAsync(ClientId));
            }

            var command = new UpdateItemCommand(
                ClientId,
                product.Id,
                product.Name,
                quantity,
                product.Price);

            await _mediatorHandler.SendCommandAsync(command);

            if (HasNotification())
            {
                return View(
                    "Index",
                    await _orderQuery.GetDraftOrderByClientIdAsync(ClientId));
            }

            return RedirectToAction(
                "Index",
                "Cart");
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

            if (HasNotification())
            {
                return View(
                    "Index",
                    await _orderQuery.GetDraftOrderByClientIdAsync(ClientId));
            }

            return RedirectToAction(
                "Index",
                "Cart");
        }

        [HttpPost("set-voucher")]
        public async Task<IActionResult> SetVoucher(string voucherCode)
        {
            var command = new SetVoucherCommand(
                ClientId,
                voucherCode);

            await _mediatorHandler.SendCommandAsync(command);

            if (HasNotification())
            {
                return View(
                    "Index",
                    await _orderQuery.GetDraftOrderByClientIdAsync(ClientId));
            }

            return RedirectToAction(
                "Index",
                "Cart");
        }

        [HttpGet("summarize-order")]
        public async Task<IActionResult> SummarizeOrder()
        {
            return View(await _orderQuery.GetDraftOrderByClientIdAsync(ClientId));
        }

        [HttpGet("start-order")]
        public async Task<IActionResult> StartOrder(CartPaymentViewModel cartPaymentViewModel)
        {
            var command = new StartOrderCommand(
                ClientId,
                cartPaymentViewModel.CardHolder,
                cartPaymentViewModel.CardNumber,
                cartPaymentViewModel.CardExpiresOn,
                cartPaymentViewModel.CardCvv);

            await _mediatorHandler.SendCommandAsync(command);

            if (HasNotification())
            {
                return View(
                    "SummarizeOrder",
                    await _orderQuery.GetDraftOrderByClientIdAsync(ClientId));
            }

            return RedirectToAction(
                "Index",
                "Order");
        }
    }
}
