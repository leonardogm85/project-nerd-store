using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalog.Domain.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public string Image { get; private set; }
        public int QuantityInStock { get; private set; }
        public int MinimumStock { get; private set; }
        public bool Active { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid CategoryId { get; private set; }
        public Dimension Dimension { get; private set; }

        public virtual Category Category { get; private set; }

        protected Product()
        {
        }

        public Product(string name, string description, double price, string image, int quantityInStock, int minimumStock, bool active, Guid categoryId, Dimension dimension)
        {
            Name = name;
            Description = description;
            Price = price;
            Image = image;
            QuantityInStock = quantityInStock;
            MinimumStock = minimumStock;
            Active = active;
            CategoryId = categoryId;
            Dimension = dimension;

            CreatedAt = DateTime.Now;

            Validate();
        }

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;

        public void ChangeName(string name)
        {
            AssertionConcern.AssertArgumentNotEmpty(
                name,
                "The name must be provided.");

            AssertionConcern.AssertArgumentLength(
                name,
                100,
                "The name must be a maximum of 100 characters.");

            Name = name;
        }

        public void ChangeDescription(string description)
        {
            AssertionConcern.AssertArgumentNotEmpty(
                description,
                "The description must be provided.");

            AssertionConcern.AssertArgumentLength(
                description,
                500,
                "The description must be a maximum of 500 characters.");

            Description = description;
        }

        public void ChangePrice(double price)
        {
            AssertionConcern.AssertArgumentGreaterThan(
                price,
                0,
                "The price must be greater than 0.");

            Price = price;
        }

        public void ChangeImage(string image)
        {
            AssertionConcern.AssertArgumentNotEmpty(
                image,
                "The image must be provided.");

            AssertionConcern.AssertArgumentLength(
                image,
                250,
                "The image must be a maximum of 250 characters.");

            Image = image;
        }

        public void ChangeCategory(Guid categoryId)
        {
            AssertionConcern.AssertArgumentNotEquals(
                categoryId,
                Guid.Empty,
                "The category must be provided.");

            CategoryId = categoryId;
        }

        public void ChangeDimension(Dimension dimension)
        {
            AssertionConcern.AssertArgumentNotNull(
                dimension,
                "The dimension must be provided.");

            Dimension = dimension;
        }

        public void ChangeQuantityInStock(int quantityInStock)
        {
            AssertionConcern.AssertArgumentGreaterOrEqualsThan(
                quantityInStock,
                0,
                "The quantity in stock must be greater than or equal to 0.");

            QuantityInStock = quantityInStock;
        }

        public void ChangeMinimumStock(int minimumStock)
        {
            AssertionConcern.AssertArgumentGreaterOrEqualsThan(
                minimumStock,
                0,
                "The minimum stock must be greater than or equal to 0.");

            MinimumStock = minimumStock;
        }

        public void AddToStock(int quantity)
        {
            AssertionConcern.AssertArgumentGreaterThan(
                quantity,
                0,
                "The quantity must be greater than 0.");

            QuantityInStock += quantity;
        }

        public void RemoveFromStock(int quantity)
        {
            AssertionConcern.AssertArgumentGreaterThan(
                quantity,
                0,
                "The quantity must be greater than 0.");

            AssertionConcern.AssertArgumentFalse(
                !HasStock(quantity),
                "Insufficient stock.");

            QuantityInStock -= quantity;
        }

        public bool HasStock(int quantity)
        {
            AssertionConcern.AssertArgumentGreaterThan(
                quantity,
                0,
                "The quantity must be greater than 0.");

            return QuantityInStock >= quantity;
        }

        public bool LowStock() => QuantityInStock < MinimumStock;

        private void Validate()
        {
            AssertionConcern.AssertArgumentNotEmpty(
                Name,
                "The name must be provided.");

            AssertionConcern.AssertArgumentLength(
                Name,
                100,
                "The name must be a maximum of 100 characters.");

            AssertionConcern.AssertArgumentNotEmpty(
                Description,
                "The description must be provided.");

            AssertionConcern.AssertArgumentLength(
                Description,
                500,
                "The description must be a maximum of 500 characters.");

            AssertionConcern.AssertArgumentGreaterThan(
                Price,
                0,
                "The price must be greater than 0.");

            AssertionConcern.AssertArgumentNotEmpty(
                Image,
                "The image must be provided.");

            AssertionConcern.AssertArgumentLength(
                Image,
                250,
                "The image must be a maximum of 250 characters.");

            AssertionConcern.AssertArgumentGreaterOrEqualsThan(
                QuantityInStock,
                0,
                "The quantity in stock must be greater than or equal to 0.");

            AssertionConcern.AssertArgumentGreaterOrEqualsThan(
                MinimumStock,
                0,
                "The minimum stock must be greater than or equal to 0.");

            AssertionConcern.AssertArgumentNotEquals(
                CategoryId,
                Guid.Empty,
                "The category must be provided.");

            AssertionConcern.AssertArgumentNotNull(
                Dimension,
                "The dimension must be provided.");
        }
    }
}
