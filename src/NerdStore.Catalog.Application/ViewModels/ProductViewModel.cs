using System.ComponentModel.DataAnnotations;

namespace NerdStore.Catalog.Application.ViewModels
{
    public class ProductViewModel
    {
        public required Guid Id { get; init; }

        public required DateTime CreatedAt { get; init; }

        [Required(ErrorMessage = "The category must be provided.")]
        public required Guid CategoryId { get; init; }

        [Required(ErrorMessage = "The name must be provided.")]
        [StringLength(100, ErrorMessage = "The name must be a maximum of 100 characters.")]
        public required string Name { get; init; }

        [Required(ErrorMessage = "The description must be provided.")]
        [StringLength(500, ErrorMessage = "The description must be a maximum of 500 characters.")]
        public required string Description { get; init; }

        [Required(ErrorMessage = "The price must be provided.")]
        [Range(0.01, 999999.99, ErrorMessage = "The price must be greater than 0 and less than 1,000,000.")]
        public required double Price { get; init; }

        [Required(ErrorMessage = "The image must be provided.")]
        [StringLength(500, ErrorMessage = "The image must be a maximum of 250 characters.")]
        public required string Image { get; init; }

        [Required(ErrorMessage = "The quantity in stock must be provided.")]
        [Range(0, 999999, ErrorMessage = "The quantity in stock must be greater than or equal to 0 and less than 1,000,000.")]
        public required int QuantityInStock { get; init; }

        [Required(ErrorMessage = "The minimum stock must be provided.")]
        [Range(0, 999999, ErrorMessage = "The minimum stock must be greater than or equal to 0 and less than 1,000,000.")]
        public required int MinimumStock { get; init; }

        [Required(ErrorMessage = "The width must be provided.")]
        [Range(1, 999999, ErrorMessage = "The width must be greater than 0 and less than 1,000,000.")]
        public required double Width { get; init; }

        [Required(ErrorMessage = "The height must be provided.")]
        [Range(1, 999999, ErrorMessage = "The height must be greater than 0 and less than 1,000,000.")]
        public required double Height { get; init; }

        [Required(ErrorMessage = "The depth must be provided.")]
        [Range(1, 999999, ErrorMessage = "The depth must be greater than 0 and less than 1,000,000.")]
        public required double Depth { get; init; }

        [Required(ErrorMessage = "The active must be provided.")]
        public required bool Active { get; init; }
    }
}
