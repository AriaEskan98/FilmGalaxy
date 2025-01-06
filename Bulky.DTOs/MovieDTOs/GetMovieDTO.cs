using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmGalaxy.DTOs.MovieDTOs
{
    public class GetMovieDTO
    {
        public int MovieId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public double ListPrice { get; set; }
        public string? ImgURL { get; set; }

        [Required]
        public required GetCategoryDTO Category { get; set; }
    }
}
