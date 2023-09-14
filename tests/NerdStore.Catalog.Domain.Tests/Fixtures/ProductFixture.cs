using NerdStore.Catalog.Domain.Entities;
using NerdStore.Catalog.Domain.Tests.Fakers;

namespace NerdStore.Catalog.Domain.Tests.Fixtures
{
    public class ProductFixture
    {
        private readonly ProductFaker _productFaker = new();
        private readonly CategoryFaker _categoryFaker = new();
        private readonly DimensionFaker _dimensionFaker = new();

        public Product GetProduct()
        {
            return _productFaker.Generate();
        }

        public IEnumerable<Product> GetProducts(int count)
        {
            return _productFaker.Generate(count);
        }

        public Category GetCategory()
        {
            return _categoryFaker.Generate();
        }

        public IEnumerable<Category> GetCategories(int count)
        {
            return _categoryFaker.Generate(count);
        }

        public Dimension GetDimension()
        {
            return _dimensionFaker.Generate();
        }

        public IEnumerable<Dimension> GetDimensions(int count)
        {
            return _dimensionFaker.Generate(count);
        }
    }
}
