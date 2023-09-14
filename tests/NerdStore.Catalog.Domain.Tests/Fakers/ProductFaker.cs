using Bogus;
using NerdStore.Catalog.Domain.Entities;
using NerdStore.Catalog.Domain.Tests.Extensions;

namespace NerdStore.Catalog.Domain.Tests.Fakers
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            CustomInstantiator(f => new(
                f.Random.Guid(),
                f.Commerce.ProductName(),
                f.Commerce.ProductDescription(),
                f.Image.PicsumUrl(),
                f.Random.Double(0.01, 999999.99, 2),
                f.Random.Int(0, 999999),
                f.Random.Int(0, 999999),
                f.Random.Bool(),
                new DimensionFaker().Generate()
                ));
        }
    }
}
