using AutoMapper;
using NerdStore.Catalog.Application.Interfaces;
using NerdStore.Catalog.Application.ViewModels;
using NerdStore.Catalog.Domain.Entities;
using NerdStore.Catalog.Domain.Interfaces.Repositories;
using NerdStore.Catalog.Domain.Interfaces.Services;
using NerdStore.Core.Domain;

namespace NerdStore.Catalog.Application.Services
{
    public sealed class ProductAppService : IProductAppService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IStockService _stockService;

        public ProductAppService(IMapper mapper, IProductRepository productRepository, IStockService stockService)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _stockService = stockService;
        }

        public async Task<ProductViewModel?> GetProductByIdAsync(Guid productId)
        {
            return _mapper.Map<ProductViewModel?>(await _productRepository.GetProductByIdAsync(productId));
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetAllProductsAsync());
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProductsByCategoryCodeAsync(int categoryCode)
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetAllProductsByCategoryCodeAsync(categoryCode));
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            return _mapper.Map<IEnumerable<CategoryViewModel>>(await _productRepository.GetAllCategoriesAsync());
        }

        public async Task AddProductAsync(ProductViewModel productViewModel)
        {
            var dimension = new Dimension(
                productViewModel.Width,
                productViewModel.Height,
                productViewModel.Depth);

            var product = new Product(
                productViewModel.CategoryId,
                productViewModel.Name,
                productViewModel.Description,
                productViewModel.Price,
                productViewModel.Image,
                productViewModel.QuantityInStock,
                productViewModel.MinimumStock,
                productViewModel.Active,
                dimension);

            _productRepository.AddProduct(product);

            await _productRepository.UnitOfWork.CommitAsync();
        }

        public async Task UpdateProductAsync(ProductViewModel productViewModel)
        {
            var product = await _productRepository.GetProductByIdAsync(productViewModel.Id)
                ??
                throw new DomainException("Product not found.");

            var dimension = new Dimension(
                productViewModel.Width,
                productViewModel.Height,
                productViewModel.Depth);

            product.ChangeName(productViewModel.Name);
            product.ChangeDescription(productViewModel.Description);
            product.ChangePrice(productViewModel.Price);
            product.ChangeImage(productViewModel.Image);
            product.ChangeQuantityInStock(productViewModel.QuantityInStock);
            product.ChangeMinimumStock(productViewModel.MinimumStock);
            product.ChangeCategory(productViewModel.CategoryId);
            product.ChangeDimension(dimension);

            if (productViewModel.Active)
            {
                product.Activate();
            }
            else
            {
                product.Deactivate();
            }

            _productRepository.UpdateProduct(product);

            await _productRepository.UnitOfWork.CommitAsync();
        }

        public async Task<ProductViewModel> AddToStockAsync(Guid productId, int quantity)
        {
            if (await _stockService.AddToStockAsync(productId, quantity))
            {
                return _mapper.Map<ProductViewModel>(await _productRepository.GetProductByIdAsync(productId));
            }

            throw new DomainException("Failed to add to stock.");
        }

        public async Task<ProductViewModel> RemoveFromStockAsync(Guid productId, int quantity)
        {
            if (await _stockService.RemoveFromStockAsync(productId, quantity))
            {
                return _mapper.Map<ProductViewModel>(await _productRepository.GetProductByIdAsync(productId));
            }

            throw new DomainException("Failed to remove from stock.");
        }

        public void Dispose()
        {
            _productRepository.Dispose();
            _stockService.Dispose();
        }
    }
}
