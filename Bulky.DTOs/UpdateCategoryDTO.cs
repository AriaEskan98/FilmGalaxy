using System.ComponentModel.DataAnnotations;

namespace FilmGalaxy.DTOs
{
    public class UpdateCategoryDTO
    {
        [Required(ErrorMessage = "CategoryId is required.")]
        public int CategoryId { get; set; }
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [Range(1, 100, ErrorMessage = "DisplayOrder must be between 1 and 100.")]
        public int? DisplayOrder { get; set; }
    }
}
