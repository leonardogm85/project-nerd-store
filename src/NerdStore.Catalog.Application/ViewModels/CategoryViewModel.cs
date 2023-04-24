using System.ComponentModel.DataAnnotations;

namespace NerdStore.Catalog.Application.ViewModels
{
    public class CategoryViewModel
    {
        public required Guid Id { get; init; }

        [Required(ErrorMessage = "The name must be provided.")]
        [StringLength(100, ErrorMessage = "The name must be a maximum of 100 characters.")]
        public required string Name { get; init; }

        [Required(ErrorMessage = "The code must be provided.")]
        [Range(1, 999999, ErrorMessage = "The code stock must be greater than 0.")]
        public required int Code { get; init; }
    }
}
