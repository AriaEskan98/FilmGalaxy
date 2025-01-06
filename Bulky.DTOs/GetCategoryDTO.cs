namespace FilmGalaxy.DTOs
{
    public record GetCategoryDTO(
            int CategoryId,
            string Name,
            int DisplayOrder
        );
}
