using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalog.Application.Interfaces;
using NerdStore.Catalog.Application.ViewModels;

namespace NerdStore.WebApp.Mvc.Controllers
{
    [Route("products")]
    public class ProductsController : Controller
    {
        private readonly IProductAppService _productAppService;

        public ProductsController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet("product-list")]
        public async Task<IActionResult> Index()
        {
            return View(await _productAppService.GetAllProductsAsync());
        }

        [HttpGet("add-product")]
        public async Task<IActionResult> AddProduct()
        {
            ViewData["Categories"] = await _productAppService.GetAllCategoriesAsync();
            return View();
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                await _productAppService.AddProductAsync(productViewModel);
                return RedirectToAction("Index");
            }

            ViewData["Categories"] = await _productAppService.GetAllCategoriesAsync();
            return View(productViewModel);
        }

        [HttpGet("update-product/{productId}")]
        public async Task<IActionResult> UpdateProduct(Guid productId)
        {
            ViewData["Categories"] = await _productAppService.GetAllCategoriesAsync();
            return View(await _productAppService.GetProductByIdAsync(productId));
        }

        [HttpPost("update-product/{productId}")]
        public async Task<IActionResult> UpdateProduct(Guid productId, ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                await _productAppService.UpdateProductAsync(productViewModel);
                return RedirectToAction("Index");
            }

            ViewData["Categories"] = await _productAppService.GetAllCategoriesAsync();
            return View(productViewModel);
        }

        [HttpGet("change-stock/{productId}")]
        public async Task<IActionResult> ChangeStock(Guid productId)
        {
            return View(await _productAppService.GetProductByIdAsync(productId));
        }

        [HttpPost("change-stock/{productId}")]
        public async Task<IActionResult> ChangeStock(Guid productId, int quantity)
        {
            if (quantity > 0)
            {
                await _productAppService.AddToStockAsync(productId, Math.Abs(quantity));
            }
            else if (quantity < 0)
            {
                await _productAppService.RemoveFromStockAsync(productId, Math.Abs(quantity));
            }

            return View("Index", await _productAppService.GetAllProductsAsync());
        }
    }
}
