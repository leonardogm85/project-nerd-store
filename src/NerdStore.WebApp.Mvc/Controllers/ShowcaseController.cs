using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalog.Application.Interfaces;

namespace NerdStore.WebApp.Mvc.Controllers
{
    public class ShowcaseController : Controller
    {
        private readonly IProductAppService _productAppService;

        public ShowcaseController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            return View(await _productAppService.GetAllProductsAsync());
        }

        [HttpGet("product-details/{productId}")]
        public async Task<IActionResult> ProductDetails(Guid productId)
        {
            return View(await _productAppService.GetProductByIdAsync(productId));
        }
    }
}
