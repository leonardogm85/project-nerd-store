using NerdStore.Core.Domain;

namespace NerdStore.Catalog.Domain.Entities
{
    public class Category : Entity
    {
        private readonly List<Product> _products = new();

        public string Name { get; private set; } = null!;
        public int Code { get; private set; }

        public IReadOnlyCollection<Product> Products
        {
            get
            {
                return _products.AsReadOnly();
            }
        }

        protected Category()
        {
        }

        public Category(string name, int code)
        {
            Name = name;
            Code = code;

            Validate();
        }

        private void Validate()
        {
            AssertionConcern.AssertArgumentNotEmpty(
                Name,
                "The name must be provided.");

            AssertionConcern.AssertArgumentLength(
                Name,
                100,
                "The name must be a maximum of 100 characters.");

            AssertionConcern.AssertArgumentGreaterThan(
                Code,
                0,
                "The code must be greater than 0.");
        }

        public override string ToString()
        {
            return $"{Name} ({Code})";
        }
    }
}
