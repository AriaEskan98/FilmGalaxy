using System.ComponentModel.DataAnnotations;

namespace FilmGalaxy.DTOs
{
    public record CreateCategoryDTO(
            [Required(ErrorMessage = "Name is required.")]
            string Name,
            [Required]
            [Range(1, 100, ErrorMessage = "DisplayOrder must be between 1 and 100.")]
            int DisplayOrder
        );
}
