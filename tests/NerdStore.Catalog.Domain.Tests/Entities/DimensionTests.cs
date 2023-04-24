using NerdStore.Catalog.Domain.Entities;
using NerdStore.Core.Domain;

namespace NerdStore.Catalog.Domain.Tests.Entities
{
    public class DimensionTests
    {
        [Fact]
        public void Constructor_GivenAWidthEqualToZero_WhenConstructingTheDimension_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Dimension(
                    0,
                    1,
                    1);
            });

            Assert.Equal("The width must be greater than 0.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenANegativeWidth_WhenConstructingTheDimension_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Dimension(
                    -1,
                    1,
                    1);
            });

            Assert.Equal("The width must be greater than 0.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenAHeightEqualToZero_WhenConstructingTheDimension_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Dimension(
                    1,
                    0,
                    1);
            });

            Assert.Equal("The height must be greater than 0.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenANegativeHeight_WhenConstructingTheDimension_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Dimension(
                    1,
                    -1,
                    1);
            });

            Assert.Equal("The height must be greater than 0.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenADepthEqualToZero_WhenConstructingTheDimension_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Dimension(
                    1,
                    1,
                    0);
            });

            Assert.Equal("The depth must be greater than 0.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenANegativeDepth_WhenConstructingTheDimension_ThenValidationWillThrowAnException()
        {
            // Arrange, Act & Assert

            var exception = Assert.Throws<DomainException>(() =>
            {
                new Dimension(
                    1,
                    1,
                    -1);
            });

            Assert.Equal("The depth must be greater than 0.", exception.Message);
        }

        [Fact]
        public void Constructor_GivenAValidDimension_WhenConstructingTheDimension_ThenTheDimensionWillBeConstructed()
        {
            // Arrange
            var width = 1;
            var height = 2;
            var depth = 3;

            // Act
            var dimension = new Dimension(
                width,
                height,
                depth);

            // Assert
            Assert.Equal(width, dimension.Width);
            Assert.Equal(height, dimension.Height);
            Assert.Equal(depth, dimension.Depth);
        }

        [Fact]
        public void ToString_GivenAValidDimension_WhenGettingAStringThatRepresentsTheCurrentDimension_ThenRetunsAStringThatRepresentsTheCurrentDimension()
        {
            // Arrange
            var width = 1;
            var height = 2;
            var depth = 3;

            var expected = $"{width}w x {height}h x {depth}d";

            // Act
            var dimension = new Dimension(
                width,
                height,
                depth);
            var toString = dimension.ToString();

            // Assert
            Assert.Equal(expected, toString);
        }
    }
}
