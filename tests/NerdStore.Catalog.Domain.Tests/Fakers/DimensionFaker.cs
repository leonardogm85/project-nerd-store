using Bogus;
using NerdStore.Catalog.Domain.Entities;
using NerdStore.Catalog.Domain.Tests.Extensions;

namespace NerdStore.Catalog.Domain.Tests.Fakers
{
    public class DimensionFaker : Faker<Dimension>
    {
        public DimensionFaker()
        {
            CustomInstantiator(f => new(
                f.Random.Double(0.01, 999999.99, 2),
                f.Random.Double(0.01, 999999.99, 2),
                f.Random.Double(0.01, 999999.99, 2)));
        }
    }
}
