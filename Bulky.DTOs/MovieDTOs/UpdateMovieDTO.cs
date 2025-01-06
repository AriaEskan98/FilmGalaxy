using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmGalaxy.DTOs.MovieDTOs
{
    public class UpdateMovieDTO
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        [Range(1, 200)]
        public double ListPrice { get; set; }

        [Required]
        [Range(1, 200)]
        public double Price { get; set; }

        [Required]
        [Range(1, 200)]
        public double Price50 { get; set; }

        [Required]
        [Range(1, 200)]
        public double Price100 { get; set; }
        [Required]
        public required GetCategoryDTO Category { get; set; }
    }
}
