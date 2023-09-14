using Bogus;
using NerdStore.Catalog.Domain.Entities;

namespace NerdStore.Catalog.Domain.Tests.Fakers
{
    public class CategoryFaker : Faker<Category>
    {
        public CategoryFaker()
        {
            CustomInstantiator(f => new(
                f.Commerce.Department(),
                f.Random.Int(1, 999999)));
        }
    }
}
