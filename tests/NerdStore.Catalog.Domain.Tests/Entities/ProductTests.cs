using NerdStore.Catalog.Domain.Entities;
using NerdStore.Core.Domain;

namespace NerdStore.Catalog.Domain.Tests.Entities
{
    public class ProductTests
    {
        [Fact]
        public void Constructor_GivenAnEmptyProductCategoryId_WhenConstructingTheProduct_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Product(
                    Guid.Empty,
                    "Shirt Software Developer",
                    "Shirt 100% cotton, resistant to washing and high temperatures.",
                    "shirt1.png",
                    4.56,
                    50,
                    10,
                    true,
                    GetDimension());
            });

            Assert.Equal("The category must be provided.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenANullProductName_WhenConstructingTheProduct_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Product(
                    Guid.NewGuid(),
                    null!,
                    "Shirt 100% cotton, resistant to washing and high temperatures.",
                    "shirt1.png",
                    4.56,
                    50,
                    10,
                    true,
                    GetDimension());
            });

            Assert.Equal("The name must be provided.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenAnEmptyProductName_WhenConstructingTheProduct_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Product(
                    Guid.NewGuid(),
                    string.Empty,
                    "Shirt 100% cotton, resistant to washing and high temperatures.",
                    "shirt1.png",
                    4.56,
                    50,
                    10,
                    true,
                    GetDimension());
            });

            Assert.Equal("The name must be provided.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenAProductNameWithMoreCharactersThanAllowed_WhenConstructingTheProduct_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Product(
                    Guid.NewGuid(),
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus a scelerisque neque. Aliquam placerat.",
                    "Shirt 100% cotton, resistant to washing and high temperatures.",
                    "shirt1.png",
                    4.56,
                    50,
                    10,
                    true,
                    GetDimension());
            });

            Assert.Equal("The name must be a maximum of 100 characters.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenANullProductDescription_WhenConstructingTheProduct_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Product(
                    Guid.NewGuid(),
                    "Shirt Software Developer",
                    null!,
                    "shirt1.png",
                    4.56,
                    50,
                    10,
                    true,
                    GetDimension());
            });

            Assert.Equal("The description must be provided.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenAnEmptyProductDescription_WhenConstructingTheProduct_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Product(
                    Guid.NewGuid(),
                    "Shirt Software Developer",
                    string.Empty,
                    "shirt1.png",
                    4.56,
                    50,
                    10,
                    true,
                    GetDimension());
            });

            Assert.Equal("The description must be provided.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenAProductDescriptionWithMoreCharactersThanAllowed_WhenConstructingTheProduct_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Product(
                    Guid.NewGuid(),
                    "Shirt Software Developer",
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer dapibus diam " +
                    "at congue mattis. Fusce tristique molestie leo sit amet ultrices. Duis eu purus " +
                    "a urna ornare pretium. Pellentesque tempor eros sit amet facilisis lacinia. " +
                    "Vivamus euismod eu turpis vitae eleifend. Vivamus quis ante eget enim porttitor " +
                    "sollicitudin. Proin ullamcorper bibendum est, eget egestas dolor semper tempor. " +
                    "Donec porta rhoncus arcu et facilisis. Vivamus dapibus malesuada tellus, et " +
                    "pulvinar ex porttitor sed placerat.",
                    "shirt1.png",
                    4.56,
                    50,
                    10,
                    true,
                    GetDimension());
            });

            Assert.Equal("The description must be a maximum of 500 characters.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenANegativeProductPrice_WhenConstructingTheProduct_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Product(
                    Guid.NewGuid(),
                    "Shirt Software Developer",
                    "Shirt 100% cotton, resistant to washing and high temperatures.",
                    "shirt1.png",
                    -1,
                    50,
                    10,
                    true,
                    GetDimension());
            });

            Assert.Equal("The price must be greater than 0.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenAProductPriceEqualToZero_WhenConstructingTheProduct_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Product(
                    Guid.NewGuid(),
                    "Shirt Software Developer",
                    "Shirt 100% cotton, resistant to washing and high temperatures.",
                    "shirt1.png",
                    0,
                    50,
                    10,
                    true,
                    GetDimension());
            });

            Assert.Equal("The price must be greater than 0.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenANullProductImage_WhenConstructingTheProduct_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Product(
                    Guid.NewGuid(),
                    "Shirt Software Developer",
                    "Shirt 100% cotton, resistant to washing and high temperatures.",
                    null!,
                    4.56,
                    50,
                    10,
                    true,
                    GetDimension());
            });

            Assert.Equal("The image must be provided.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenAnEmptyProductImage_WhenConstructingTheProduct_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Product(
                    Guid.NewGuid(),
                    "Shirt Software Developer",
                    "Shirt 100% cotton, resistant to washing and high temperatures.",
                    string.Empty,
                    4.56,
                    50,
                    10,
                    true,
                    GetDimension());
            });

            Assert.Equal("The image must be provided.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenAProductImageWithMoreCharactersThanAllowed_WhenConstructingTheProduct_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Product(
                    Guid.NewGuid(),
                    "Shirt Software Developer",
                    "Shirt 100% cotton, resistant to washing and high temperatures.",
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque et diam nec " +
                    "est blandit mollis quis eget sapien. Proin egestas risus at lobortis sagittis. " +
                    "Vivamus laoreet dolor a accumsan luctus. Vivamus a suscipit leo. Proin non " +
                    "aliquam tortor accumsan.",
                    4.56,
                    50,
                    10,
                    true,
                    GetDimension());
            });

            Assert.Equal("The image must be a maximum of 250 characters.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenANegativeQuantityOfProductsInStock_WhenConstructingTheProduct_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Product(
                    Guid.NewGuid(),
                    "Shirt Software Developer",
                    "Shirt 100% cotton, resistant to washing and high temperatures.",
                    "shirt1.png",
                    4.56,
                    -1,
                    10,
                    true,
                    GetDimension());
            });

            Assert.Equal("The quantity in stock must be greater than or equal to 0.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenANegativeMinimumStockOfProducts_WhenConstructingTheProduct_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Product(
                    Guid.NewGuid(),
                    "Shirt Software Developer",
                    "Shirt 100% cotton, resistant to washing and high temperatures.",
                    "shirt1.png",
                    4.56,
                    50,
                    -1,
                    true,
                    GetDimension());
            });

            Assert.Equal("The minimum stock must be greater than or equal to 0.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenANullProductDimension_WhenConstructingTheProduct_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Product(
                    Guid.NewGuid(),
                    "Shirt Software Developer",
                    "Shirt 100% cotton, resistant to washing and high temperatures.",
                    "shirt1.png",
                    4.56,
                    50,
                    10,
                    true,
                    null!);
            });

            Assert.Equal("The dimension must be provided.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenAValidProduct_WhenConstructingTheProduct_ThenTheProductWillBeConstructed()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var name = "Shirt Software Developer";
            var description = "Shirt 100% cotton; resistant to washing and high temperatures.";
            var image = "shirt1.png";
            var price = 4.56;
            var quantityInStock = 50;
            var minimumStock = 10;
            var active = true;
            var dimension = GetDimension();

            // Act
            var product = new Product(
                categoryId,
                name,
                description,
                image,
                price,
                quantityInStock,
                minimumStock,
                active,
                dimension);

            // Assert
            Assert.Equal(categoryId, product.CategoryId);
            Assert.Equal(name, product.Name);
            Assert.Equal(description, product.Description);
            Assert.Equal(image, product.Image);
            Assert.Equal(price, product.Price);
            Assert.Equal(quantityInStock, product.QuantityInStock);
            Assert.Equal(minimumStock, product.MinimumStock);
            Assert.Equal(active, product.Active);
            Assert.Equal(dimension, product.Dimension);

            Assert.NotEqual(default, product.CreatedAt);

            Assert.Null(product.Category);
        }

        [Fact]
        public void Activate_GivenADeactivatedProduct_WhenActivatingTheProduct_ThenTheProductWillBeActivated()
        {
            // Arrange
            var product = GetProduct();

            // Act
            product.Activate();

            // Assert
            Assert.True(product.Active);
        }

        [Fact]
        public void Deactivate_GivenAnActivatedProduct_WhenDeactivatingTheProduct_ThenTheProductWillBeDeactivated()
        {
            // Arrange
            var product = GetProduct();

            // Act
            product.Deactivate();

            // Assert
            Assert.False(product.Active);
        }

        [Fact]
        public void ChangeName_GivenANullProductName_WhenChangingTheProductName_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.ChangeName(null!);
            });

            Assert.Equal("The name must be provided.", exception.Message);
        }

        [Fact]
        public void ChangeName_GivenAnEmptyProductName_WhenChangingTheProductName_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.ChangeName(string.Empty);
            });

            Assert.Equal("The name must be provided.", exception.Message);
        }

        [Fact]
        public void ChangeName_GivenAProductNameWithMoreCharactersThanAllowed_WhenChangingTheProductName_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.ChangeName("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus a scelerisque neque. Aliquam placerat.");
            });

            Assert.Equal("The name must be a maximum of 100 characters.", exception.Message);
        }

        [Fact]
        public void ChangeName_GivenAValidProductName_WhenChangingTheProductName_ThenTheProductNameWillBeChanged()
        {
            // Arrange
            var product = GetProduct();

            var expected = "Shirt Code Life";

            // Act
            product.ChangeName(expected);

            // Assert
            Assert.Equal(expected, product.Name);
        }

        [Fact]
        public void ChangeDescription_GivenANullProductDescription_WhenChangingTheProductDescription_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.ChangeDescription(null!);
            });

            Assert.Equal("The description must be provided.", exception.Message);
        }

        [Fact]
        public void ChangeDescription_GivenAnEmptyProductDescription_WhenChangingTheProductDescription_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.ChangeDescription(string.Empty);
            });

            Assert.Equal("The description must be provided.", exception.Message);
        }

        [Fact]
        public void ChangeDescription_GivenAProductDescriptionWithMoreCharactersThanAllowed_WhenChangingTheProductDescription_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.ChangeDescription("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer dapibus diam " +
                    "at congue mattis. Fusce tristique molestie leo sit amet ultrices. Duis eu purus " +
                    "a urna ornare pretium. Pellentesque tempor eros sit amet facilisis lacinia. " +
                    "Vivamus euismod eu turpis vitae eleifend. Vivamus quis ante eget enim porttitor " +
                    "sollicitudin. Proin ullamcorper bibendum est, eget egestas dolor semper tempor. " +
                    "Donec porta rhoncus arcu et facilisis. Vivamus dapibus malesuada tellus, et " +
                    "pulvinar ex porttitor sed placerat.");
            });

            Assert.Equal("The description must be a maximum of 500 characters.", exception.Message);
        }

        [Fact]
        public void ChangeDescription_GivenAValidProductDescription_WhenChangingTheProductDescription_ThenTheProductDescriptionWillBeChanged()
        {
            // Arrange
            var product = GetProduct();

            var expected = "Shirt Code Life";

            // Act
            product.ChangeDescription(expected);

            // Assert
            Assert.Equal(expected, product.Description);
        }

        [Fact]
        public void ChangePrice_GivenANegativeProductPrice_WhenChangingTheProductPrice_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.ChangePrice(-1);
            });

            Assert.Equal("The price must be greater than 0.", exception.Message);
        }

        [Fact]
        public void ChangePrice_GivenAProductPriceEqualToZero_WhenChangingTheProductPrice_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.ChangePrice(0);
            });

            Assert.Equal("The price must be greater than 0.", exception.Message);
        }

        [Fact]
        public void ChangePrice_GivenAValidProductPrice_WhenChangingTheProductPrice_ThenTheProductPriceWillBeChanged()
        {
            // Arrange
            var product = GetProduct();

            var expected = 7.89;

            // Act
            product.ChangePrice(expected);

            // Assert
            Assert.Equal(expected, product.Price);
        }

        [Fact]
        public void ChangeImage_GivenANullProductImage_WhenChangingTheProductImage_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.ChangeImage(null!);
            });

            Assert.Equal("The image must be provided.", exception.Message);
        }

        [Fact]
        public void ChangeImage_GivenAnEmptyProductImage_WhenChangingTheProductImage_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.ChangeImage(string.Empty);
            });

            Assert.Equal("The image must be provided.", exception.Message);
        }

        [Fact]
        public void ChangeImage_GivenAProductImageWithMoreCharactersThanAllowed_WhenChangingTheProductImage_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.ChangeImage("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque et diam nec " +
                    "est blandit mollis quis eget sapien. Proin egestas risus at lobortis sagittis. " +
                    "Vivamus laoreet dolor a accumsan luctus. Vivamus a suscipit leo. Proin non " +
                    "aliquam tortor accumsan.");
            });

            Assert.Equal("The image must be a maximum of 250 characters.", exception.Message);
        }

        [Fact]
        public void ChangeImage_GivenAValidProductImage_WhenChangingTheProductImage_ThenTheProductImageWillBeChanged()
        {
            // Arrange
            var product = GetProduct();

            var expected = "shirt2.png";

            // Act
            product.ChangeImage(expected);

            // Assert
            Assert.Equal(expected, product.Image);
        }

        [Fact]
        public void ChangeQuantityInStock_GivenANegativeQuantityOfProductsInStock_WhenChangingTheQuantityInStock_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.ChangeQuantityInStock(-1);
            });

            Assert.Equal("The quantity in stock must be greater than or equal to 0.", exception.Message);
        }

        [Fact]
        public void ChangeQuantityInStock_GivenAQuantityOfProductsInStockEqualToZero_WhenChangingTheQuantityInStock_ThenTheQuantityOfProductsInStockWillBeChanged()
        {
            // Arrange
            var product = GetProduct();

            var expected = 0;

            // Act
            product.ChangeQuantityInStock(expected);

            // Assert
            Assert.Equal(expected, product.QuantityInStock);
        }

        [Fact]
        public void ChangeQuantityInStock_GivenAQuantityOfProductsInStockGreaterThanZero_WhenChangingTheQuantityInStock_ThenTheQuantityOfProductsInStockWillBeChanged()
        {
            // Arrange
            var product = GetProduct();

            var expected = 20;

            // Act
            product.ChangeQuantityInStock(expected);

            // Assert
            Assert.Equal(expected, product.QuantityInStock);
        }

        [Fact]
        public void ChangeMinimumStock_GivenANegativeMinimumStockOfProducts_WhenChangingTheMinimumStock_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.ChangeMinimumStock(-1);
            });

            Assert.Equal("The minimum stock must be greater than or equal to 0.", exception.Message);
        }

        [Fact]
        public void ChangeMinimumStock_GivenAMinimumStockOfProductsEqualToZero_WhenChangingTheMinimumStock_ThenTheMinimumStockOfProducstWillBeChanged()
        {
            // Arrange
            var product = GetProduct();

            var expected = 0;

            // Act
            product.ChangeMinimumStock(expected);

            // Assert
            Assert.Equal(expected, product.MinimumStock);
        }

        [Fact]
        public void ChangeMinimumStock_GivenAMinimumStockOfProductsGreaterThanZero_WhenChangingTheMinimumStock_ThenTheMinimumStockOfProducstWillBeChanged()
        {
            // Arrange
            var product = GetProduct();

            var expected = 20;

            // Act
            product.ChangeMinimumStock(expected);

            // Assert
            Assert.Equal(expected, product.MinimumStock);
        }

        [Fact]
        public void ChangeCategory_GivenAnEmptyProductCategoryId_WhenChangingTheProductCategory_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.ChangeCategory(Guid.Empty);
            });

            Assert.Equal("The category must be provided.", exception.Message);
        }

        [Fact]
        public void ChangeCategory_GivenAValidProductCategoryId_WhenChangingTheProductCategory_ThenTheProductCategoryWillBeChanged()
        {
            // Arrange
            var product = GetProduct();

            var expected = Guid.NewGuid();

            // Act
            product.ChangeCategory(expected);

            // Assert
            Assert.Equal(expected, product.CategoryId);
        }

        [Fact]
        public void ChangeDimension_GivenANullProductDimension_WhenChangingTheProductDimension_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.ChangeDimension(null!);
            });

            Assert.Equal("The dimension must be provided.", exception.Message);
        }

        [Fact]
        public void ChangeDimension_GivenAValidProductDimension_WhenChangingTheProductDimension_ThenTheProductDimensionWillBeChanged()
        {
            // Arrange
            var product = GetProduct();

            var expected = new Dimension(
                1,
                2,
                3);

            // Act
            product.ChangeDimension(expected);

            // Assert
            Assert.Equal(expected.Width, product.Dimension.Width);
            Assert.Equal(expected.Height, product.Dimension.Height);
            Assert.Equal(expected.Depth, product.Dimension.Depth);
        }

        [Fact]
        public void AddToStock_GivenANegativeQuantityOfProducts_WhenAddingTheQuantityOfProductsToStock_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.AddToStock(-1);
            });

            Assert.Equal("The quantity must be greater than 0.", exception.Message);
        }

        [Fact]
        public void AddToStock_GivenAQuantityOfProductsEqualToZero_WhenAddingTheQuantityOfProductsToStock_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.AddToStock(0);
            });

            Assert.Equal("The quantity must be greater than 0.", exception.Message);
        }

        [Fact]
        public void AddToStock_GivenAQuantityOfProductsGreaterThanZero_WhenAddingTheQuantityOfProductsToStockOnce_ThenTheQuantityOfProductsWillBeAdded()
        {
            // Arrange
            var product = GetProduct();

            var addToStock = 5;

            var expected = product.QuantityInStock + addToStock;

            // Act
            product.AddToStock(addToStock);

            // Assert
            Assert.Equal(expected, product.QuantityInStock);
        }

        [Fact]
        public void AddToStock_GivenAQuantityOfProductsGreaterThanZero_WhenAddingTheQuantityOfProductsToStockTwice_ThenTheQuantityOfProductsWillBeAdded()
        {
            // Arrange
            var product = GetProduct();

            var first = 5;
            var second = 2;

            var expected = product.QuantityInStock + first + second;

            // Act
            product.AddToStock(first);
            product.AddToStock(second);

            // Assert
            Assert.Equal(expected, product.QuantityInStock);
        }

        [Fact]
        public void RemoveFromStock_GivenANegativeQuantityOfProducts_WhenRemovingTheQuantityOfProductsFromStock_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.RemoveFromStock(-1);
            });

            Assert.Equal("The quantity must be greater than 0.", exception.Message);
        }

        [Fact]
        public void RemoveFromStock_GivenAQuantityOfProductsEqualToZero_WhenRemovingTheQuantityOfProductsFromStock_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.RemoveFromStock(0);
            });

            Assert.Equal("The quantity must be greater than 0.", exception.Message);
        }

        [Fact]
        public void RemoveFromStock_GivenAQuantityOfProductsGreaterThanTheQuantityInStock_WhenRemovingTheQuantityOfProductsFromStock_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            product.ChangeQuantityInStock(0);

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.RemoveFromStock(1);
            });

            Assert.Equal("Insufficient stock.", exception.Message);
        }

        [Fact]
        public void RemoveFromStock_GivenAQuantityOfProductsEqualToTheQuantityInStock_WhenRemovingTheQuantityOfProductsFromStock_ThenTheQuantityOfProductsWillBeRemoved()
        {
            // Arrange
            var product = GetProduct();

            var quantityInStock = 5;

            var expected = 0;

            product.ChangeQuantityInStock(quantityInStock);

            // Act
            product.RemoveFromStock(quantityInStock);

            // Assert
            Assert.Equal(expected, product.QuantityInStock);
        }

        [Fact]
        public void RemoveFromStock_GivenAQuantityOfProductsGreaterThanZero_WhenRemovingTheQuantityOfProductsFromStockOnce_ThenTheQuantityOfProductsWillBeRemoved()
        {
            // Arrange
            var product = GetProduct();

            var quantityInStock = 5;
            var removeFromStock = 2;

            var expected = quantityInStock - removeFromStock;

            product.ChangeQuantityInStock(quantityInStock);

            // Act
            product.RemoveFromStock(removeFromStock);

            // Assert
            Assert.Equal(expected, product.QuantityInStock);
        }

        [Fact]
        public void RemoveFromStock_GivenAQuantityOfProductsGreaterThanZero_WhenRemovingTheQuantityOfProductsFromStockTwice_ThenTheQuantityOfProductsWillBeRemoved()
        {
            // Arrange
            var product = GetProduct();

            var quantityInStock = 5;

            var first = 2;
            var second = 1;

            var expected = quantityInStock - (first + second);

            product.ChangeQuantityInStock(quantityInStock);

            // Act
            product.RemoveFromStock(first);
            product.RemoveFromStock(second);

            // Assert
            Assert.Equal(expected, product.QuantityInStock);
        }

        [Fact]
        public void HasStock_GivenANegativeQuantityOfProducts_WhenCheckingTheQuantityOfProductsInStock_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.HasStock(-1);
            });

            Assert.Equal("The quantity must be greater than 0.", exception.Message);
        }

        [Fact]
        public void HasStock_GivenAQuantityOfProductsEqualToZero_WhenCheckingTheQuantityOfProductsInStock_ThenValidationWillThrowAnException()
        {
            // Arrange
            var product = GetProduct();

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
            {
                product.HasStock(0);
            });

            Assert.Equal("The quantity must be greater than 0.", exception.Message);
        }

        [Fact]
        public void HasStock_GivenAQuantityOfProductsEqualToTheQuantityInStock_WhenCheckingTheQuantityOfProductsInStock_ThenTheQuantityOfProductsWillBeChecked()
        {
            // Arrange
            var product = GetProduct();

            var quantityInStock = 5;
            var toBeChecked = 5;

            var expected = quantityInStock >= toBeChecked;

            product.ChangeQuantityInStock(quantityInStock);

            // Act
            var hasStock = product.HasStock(toBeChecked);

            // Assert
            Assert.Equal(expected, hasStock);
        }

        [Fact]
        public void HasStock_GivenAQuantityOfProductsLowerThanTheQuantityInStock_WhenCheckingTheQuantityOfProductsInStock_ThenTheQuantityOfProductsWillBeChecked()
        {
            // Arrange
            var product = GetProduct();

            var quantityInStock = 5;
            var toBeChecked = 4;

            var expected = quantityInStock >= toBeChecked;

            product.ChangeQuantityInStock(quantityInStock);

            // Act
            var hasStock = product.HasStock(toBeChecked);

            // Assert
            Assert.Equal(expected, hasStock);
        }

        [Fact]
        public void HasStock_GivenAQuantityOfProductsGreaterThanTheQuantityInStock_WhenCheckingTheQuantityOfProductsInStock_ThenTheQuantityOfProductsWillBeChecked()
        {
            // Arrange
            var product = GetProduct();

            var quantityInStock = 5;
            var toBeChecked = 6;

            var expected = quantityInStock >= toBeChecked;

            product.ChangeQuantityInStock(quantityInStock);

            // Act
            var hasStock = product.HasStock(toBeChecked);

            // Assert
            Assert.Equal(expected, hasStock);
        }

        [Fact]
        public void LowStock_GivenAQuantityInStockLowerThanTheMinimumStockOfProducts_WhenCheckingTheMinimumStockOfProducts_ThenTheMinimumStockOfProductsWillBeChecked()
        {
            // Arrange
            var product = GetProduct();

            var quantityInStock = 5;
            var minimumStock = 10;

            var expected = quantityInStock < minimumStock;

            product.ChangeQuantityInStock(quantityInStock);
            product.ChangeMinimumStock(minimumStock);

            // Act
            var lowStock = product.LowStock();

            // Assert
            Assert.Equal(expected, lowStock);
        }

        [Fact]
        public void LowStock_GivenAQuantityInStockEqualToTheMinimumStockOfProducts_WhenCheckingTheMinimumStockOfProducts_ThenTheMinimumStockOfProductsWillBeChecked()
        {
            // Arrange
            var product = GetProduct();

            var quantityInStock = 10;
            var minimumStock = 10;

            var expected = quantityInStock < minimumStock;

            product.ChangeQuantityInStock(quantityInStock);
            product.ChangeMinimumStock(minimumStock);

            // Act
            var lowStock = product.LowStock();

            // Assert
            Assert.Equal(expected, lowStock);
        }

        [Fact]
        public void LowStock_GivenAQuantityInStockGreaterThanTheMinimumStockOfProducts_WhenCheckingTheMinimumStockOfProducts_ThenTheMinimumStockOfProductsWillBeChecked()
        {
            // Arrange
            var product = GetProduct();

            var quantityInStock = 10;
            var minimumStock = 5;

            var expected = quantityInStock < minimumStock;

            product.ChangeQuantityInStock(quantityInStock);
            product.ChangeMinimumStock(minimumStock);

            // Act
            var lowStock = product.LowStock();

            // Assert
            Assert.Equal(expected, lowStock);
        }

        private static Dimension GetDimension()
        {
            return new(
                1,
                2,
                3);
        }

        private static Product GetProduct()
        {
            return new(
                Guid.NewGuid(),
                "Shirt Software Developer",
                "Shirt 100% cotton; resistant to washing and high temperatures.",
                "shirt1.png",
                4.56,
                50,
                10,
                true,
                GetDimension());
        }
    }
}
