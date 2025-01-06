using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FilmGalaxy.DataAccess.Data;
using FilmGalaxy.DataAccess.Repository.IRepository;
using FilmGalaxy.Models;

namespace FilmGalaxy.DataAccess.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private DataDbContext _db;

        public MovieRepository(DataDbContext db) : base(db)
        {
            _db = db;

        }



        public void Update(Movie movie)
        {
            var existingMovie = _db.Movies.FirstOrDefault(m => m.MovieId == movie.MovieId);
            if (existingMovie != null)
            {
                var movieInDb = _db.Movies.FirstOrDefault(m => m.MovieId == movie.MovieId);
                if (movieInDb != null)
                {
                    movieInDb.Name = movie.Name!; // Example fields; update all necessary fields
                    movieInDb.CategoryId = movie.CategoryId;
                    movieInDb.Price = movie.Price;
                    movieInDb.Director = movie.Director;
                    movieInDb.Date = movie.Date;
                    movieInDb.Description = movie.Description;
                    movieInDb.Price50 = movie.Price50;
                    movieInDb.Price100 = movie.Price100;
                    if(movie.ImgURL != null)
                    {
                         movieInDb.ImgURL = movie.ImgURL;

                    }
                    // Add other fields to update

                }
            }
        }
    }
}
