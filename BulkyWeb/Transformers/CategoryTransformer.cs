
namespace FilmGalaxyWeb.Transformers
{
    using FilmGalaxy.Models;
    using FilmGalaxy.DTOs;


    public static class CategoryTransformer
    {
        public static GetCategoryDTO ToGetDTO(this Category category)
        {
            return new GetCategoryDTO(category.CategoryId, category.Name, category.DisplayOrder);

        }

        public static UpdateCategoryDTO ToUpdateDTO(this Category category)
        {
            return new UpdateCategoryDTO()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                DisplayOrder = category.DisplayOrder
            };

        }

        public static Category ToModel(this CreateCategoryDTO createCategoryDTO)
        {
            return new Category
            {
                Name = createCategoryDTO.Name,
                DisplayOrder = createCategoryDTO.DisplayOrder
            };
        }

        public static Category ToModel(this UpdateCategoryDTO updateCategoryDTO)
        {
            ArgumentException.ThrowIfNullOrEmpty(updateCategoryDTO.Name);
            ArgumentNullException.ThrowIfNull(updateCategoryDTO.DisplayOrder);
            return new Category
            {
                

                CategoryId=updateCategoryDTO.CategoryId,
                Name = updateCategoryDTO.Name,
                DisplayOrder = (int)updateCategoryDTO.DisplayOrder
            }; 
        }

        public static Category UpdateModel(Category category, UpdateCategoryDTO updateCategoryDTO)
        {
            if (!string.IsNullOrEmpty(updateCategoryDTO.Name))
                category.Name = updateCategoryDTO.Name;

            if (updateCategoryDTO.DisplayOrder.HasValue)
                category.DisplayOrder = updateCategoryDTO.DisplayOrder.Value;

            return category;
        }
    }
}
