using NerdStore.Catalog.Domain.Entities;
using NerdStore.Core.Domain;

namespace NerdStore.Catalog.Domain.Tests.Entities
{
    public class CategoryTests
    {
        [Fact]
        public void Constructor_GivenANullCategoryName_WhenConstructingTheCategory_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Category(
                    null!,
                    12345);
            });

            Assert.Equal("The name must be provided.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenAnEmptyCategoryName_WhenConstructingTheCategory_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Category(
                    string.Empty,
                    12345);
            });

            Assert.Equal("The name must be provided.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenACategoryNameWithMoreCharactersThanAllowed_WhenConstructingTheCategory_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Category(
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus a scelerisque neque. Aliquam placerat.",
                    12345);
            });

            Assert.Equal("The name must be a maximum of 100 characters.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenACategoryCodeEqualToZero_WhenConstructingTheCategory_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Category(
                    "Shirt",
                    0);
            });

            Assert.Equal("The code must be greater than 0.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenANegativeCategoryCode_WhenConstructingTheCategory_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Category(
                    "Shirt",
                    -1);
            });

            Assert.Equal("The code must be greater than 0.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenAValidCategory_WhenConstructingTheCategory_ThenTheCategoryWillBeConstructed()
        {
            // Arrange
            var name = "Shirt";
            var code = 12345;

            // Act
            var category = new Category(
                name,
                code);

            // Assert
            Assert.Equal(name, category.Name);
            Assert.Equal(code, category.Code);

            Assert.Empty(category.Products);
        }

        [Fact]
        public void ToString_GivenAValidCategory_WhenGettingAStringThatRepresentsTheCurrentCategory_ThenRetunsAStringThatRepresentsTheCurrentCategory()
        {
            // Arrange
            var name = "Shirt";
            var code = 12345;

            var category = new Category(
                name,
                code);

            var expected = $"{name} ({code})";

            // Act
            var toString = category.ToString();

            // Assert
            Assert.Equal(expected, toString);
        }
    }
}
