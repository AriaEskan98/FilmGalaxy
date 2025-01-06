
using FilmGalaxy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilmGalaxy.DataAccess.Data
{
    public class DataDbContext : IdentityDbContext<IdentityUser>
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) :base(options) 
        {
                    
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, Name = "Action", DisplayOrder = 1 },
                    new Category { CategoryId = 2, Name = "Sci-Fi", DisplayOrder = 2 },
                    new Category { CategoryId = 3, Name = "History", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Movie>().HasData(
               new Movie
               {
                   MovieId = 1,
                   Name = "Inception",
                   Description = "A mind-bending thriller by Christopher Nolan.",
                   Director = "Christopher Nolan",
                   Date = new DateOnly(2010, 7, 16),
                   ListPrice = 14.99,
                   Price = 9.99,
                   Price50 = 8.99,
                   Price100 = 7.99,
                   CategoryId = 1,
                   ImgURL = ""
               },
                new Movie
                {
                    MovieId = 2,
                    Name = "The Dark Knight",
                    Description = "The second installment in the Batman trilogy by Nolan.",
                    Director = "Christopher Nolan",
                    Date = new DateOnly(2008, 7, 18),
                    ListPrice = 16.99,
                    Price = 11.99,
                    Price50 = 10.99,
                    Price100 = 9.99,
                    CategoryId = 1,
                    ImgURL = ""
                },
                new Movie
                {
                    MovieId = 3,
                    Name = "The Matrix",
                    Description = "A science fiction classic about simulated reality.",
                    Director = "The Wachowskis",
                    Date = new DateOnly(1999, 3, 31),
                    ListPrice = 12.99,
                    Price = 8.99,
                    Price50 = 7.99,
                    Price100 = 6.99,
                    CategoryId = 2,
                    ImgURL = ""
                },
                new Movie
                {
                    MovieId = 4,
                    Name = "Avengers: Endgame",
                    Description = "The epic conclusion to the Infinity Saga.",
                    Director = "Anthony and Joe Russo",
                    Date = new DateOnly(2019, 4, 26),
                    ListPrice = 19.99,
                    Price = 14.99,
                    Price50 = 13.99,
                    Price100 = 12.99,
                    CategoryId = 1,
                    ImgURL = ""
                },
                new Movie
                {
                    MovieId = 5,
                    Name = "Titanic",
                    Description = "A love story set during the ill-fated voyage of the Titanic.",
                    Director = "James Cameron",
                    Date = new DateOnly(1997, 12, 19),
                    ListPrice = 18.99,
                    Price = 13.99,
                    Price50 = 12.99,
                    Price100 = 11.99,
                    CategoryId = 3,
                    ImgURL = ""
                },
                new Movie
                {
                    MovieId = 6,
                    Name = "The Godfather",
                    Description = "A powerful family drama set in the world of organized crime.",
                    Director = "Francis Ford Coppola",
                    Date = new DateOnly(1972, 3, 24),
                    ListPrice = 15.99,
                    Price = 10.99,
                    Price50 = 9.99,
                    Price100 = 8.99,
                    CategoryId = 2,
                    ImgURL = ""
                },
                new Movie
                {
                    MovieId = 7,
                    Name = "Forrest Gump",
                    Description = "The life story of a man with a low IQ but a big heart.",
                    Director = "Robert Zemeckis",
                    Date = new DateOnly(1994, 7, 6),
                    ListPrice = 13.99,
                    Price = 9.99,
                    Price50 = 8.99,
                    Price100 = 7.99,
                    CategoryId = 3,
                    ImgURL = ""
                },
                new Movie
                {
                    MovieId = 8,
                    Name = "Jurassic Park",
                    Description = "A groundbreaking film about a dinosaur theme park gone wrong.",
                    Director = "Steven Spielberg",
                    Date = new DateOnly(1993, 6, 11),
                    ListPrice = 14.99,
                    Price = 10.99,
                    Price50 = 9.99,
                    Price100 = 8.99,
                    CategoryId = 2,
                    ImgURL = ""
                },
                new Movie
                {
                    MovieId = 9,
                    Name = "Pulp Fiction",
                    Description = "A unique and nonlinear crime drama by Quentin Tarantino.",
                    Director = "Quentin Tarantino",
                    Date = new DateOnly(1994, 10, 14),
                    ListPrice = 17.99,
                    Price = 12.99,
                    Price50 = 11.99,
                    Price100 = 10.99,
                    CategoryId = 2,
                    ImgURL = ""
                },
                new Movie
                {
                    MovieId = 10,
                    Name = "The Shawshank Redemption",
                    Description = "A man wrongfully convicted of murder forms a friendship in prison.",
                    Director = "Frank Darabont",
                    Date = new DateOnly(1994, 9, 22),
                    ListPrice = 16.99,
                    Price = 11.99,
                    Price50 = 10.99,
                    Price100 = 9.99,
                    CategoryId = 3,
                    ImgURL = ""
                }
            );
        }
    }
}
