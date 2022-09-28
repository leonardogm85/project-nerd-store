using System.ComponentModel.DataAnnotations;

namespace NerdStore.Catalog.Application.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "The name must be provided.")]
        [StringLength(100, ErrorMessage = "The name must be a maximum of 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The description must be provided.")]
        [StringLength(500, ErrorMessage = "The description must be a maximum of 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The price must be provided.")]
        [Range(0.01, 999999.99, ErrorMessage = "The price must be greater than 0 and less than 1,000,000.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "The image must be provided.")]
        [StringLength(500, ErrorMessage = "The image must be a maximum of 250 characters.")]
        public string Image { get; set; }

        [Required(ErrorMessage = "The quantity in stock must be provided.")]
        [Range(0, 999999, ErrorMessage = "The quantity in stock must be greater than or equal to 0 and less than 1,000,000.")]
        public int QuantityInStock { get; set; }

        [Required(ErrorMessage = "The minimum stock must be provided.")]
        [Range(0, 999999, ErrorMessage = "The minimum stock must be greater than or equal to 0 and less than 1,000,000.")]
        public int MinimumStock { get; set; }

        [Required(ErrorMessage = "The category must be provided.")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "The width must be provided.")]
        [Range(1, 999999, ErrorMessage = "The width must be greater than 0 and less than 1,000,000.")]
        public double Width { get; set; }

        [Required(ErrorMessage = "The height must be provided.")]
        [Range(1, 999999, ErrorMessage = "The height must be greater than 0 and less than 1,000,000.")]
        public double Height { get; set; }

        [Required(ErrorMessage = "The depth must be provided.")]
        [Range(1, 999999, ErrorMessage = "The depth must be greater than 0 and less than 1,000,000.")]
        public double Depth { get; set; }

        [Required(ErrorMessage = "The active must be provided.")]
        public bool Active { get; set; }
    }
}
