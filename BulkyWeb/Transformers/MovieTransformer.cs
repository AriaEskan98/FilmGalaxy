namespace FilmGalaxyWeb.Transformers
{
    using FilmGalaxy.Models;
    using FilmGalaxy.DTOs;
    using FilmGalaxy.DTOs.MovieDTOs;

    public static class MovieTransformer
    {
        public static GetMovieDTO ToGetDTO(this Movie movie)
        {
            return new GetMovieDTO
            {
                MovieId = movie.MovieId,
                Name = movie.Name,
                Description = movie.Description,
                Director = movie.Director,
                Date = movie.Date,
                ListPrice = movie.ListPrice,
                Category = new GetCategoryDTO
                (
                     movie.Category.CategoryId, // Assuming the Category navigation property is populated
                   movie.Category.Name, // Replace with the actual property name if different
                   movie.Category.DisplayOrder
                ),
                ImgURL = movie.ImgURL,
            };
        }

        public static CreateMovieDTO ToCreateDTO(this Movie movie)
        {
            return new CreateMovieDTO
            {
                MovieId = movie.MovieId,
                Name = movie.Name,
                Description = movie.Description,
                Director = movie.Director,
                Date = movie.Date,
                ListPrice = movie.ListPrice,
                Price = movie.Price,
                Price50 = movie.Price50,
                Price100 = movie.Price100,
                Category = new GetCategoryDTO
                (
                     movie.Category.CategoryId, // Assuming the Category navigation property is populated
                   movie.Category.Name, // Replace with the actual property name if different
                   movie.Category.DisplayOrder
                ),
                ImgURL = movie.ImgURL
            };
        }

        public static Movie ToModel(this CreateMovieDTO createMovieDTO)
        {
            return new Movie
            {
                MovieId = createMovieDTO.MovieId,
                Name = createMovieDTO.Name,
                Description = createMovieDTO.Description,
                Director = createMovieDTO.Director,
                Date = createMovieDTO.Date,
                ListPrice = createMovieDTO.ListPrice,
                Price = createMovieDTO.Price,
                Price50 = createMovieDTO.Price50,
                Price100 = createMovieDTO.Price100,
                CategoryId = createMovieDTO.Category.CategoryId,
                ImgURL = createMovieDTO.ImgURL
            };
        }

        public static Movie ToModel(this UpdateMovieDTO updateMovieDTO)
        {
            ArgumentException.ThrowIfNullOrEmpty(updateMovieDTO.Name);
            ArgumentNullException.ThrowIfNull(updateMovieDTO.Description);
            ArgumentNullException.ThrowIfNull(updateMovieDTO.Director);
            return new Movie
            {
                MovieId = updateMovieDTO.MovieId,
                Name = updateMovieDTO.Name,
                Description = updateMovieDTO.Description,
                Director = updateMovieDTO.Director,
                Date = updateMovieDTO.Date,
                ListPrice = updateMovieDTO.ListPrice,
                Price = updateMovieDTO.Price,
                Price50 = updateMovieDTO.Price50,
                Price100 = updateMovieDTO.Price100,
                CategoryId = updateMovieDTO.Category.CategoryId
            };
        }

        public static Movie UpdateModel(this Movie movie, UpdateMovieDTO updateMovieDTO)
        {
            if (!string.IsNullOrEmpty(updateMovieDTO.Name))
                movie.Name = updateMovieDTO.Name;

            if (!string.IsNullOrEmpty(updateMovieDTO.Description))
                movie.Description = updateMovieDTO.Description;

            if (!string.IsNullOrEmpty(updateMovieDTO.Director))
                movie.Director = updateMovieDTO.Director;

            movie.Date = updateMovieDTO.Date != default ? updateMovieDTO.Date : movie.Date;

            if (updateMovieDTO.ListPrice > 0)
                movie.ListPrice = updateMovieDTO.ListPrice;

            if (updateMovieDTO.Price > 0)
                movie.Price = updateMovieDTO.Price;

            if (updateMovieDTO.Price50 > 0)
                movie.Price50 = updateMovieDTO.Price50;

            if (updateMovieDTO.Price100 > 0)
                movie.Price100 = updateMovieDTO.Price100;

            return movie;
        }
    }
}
