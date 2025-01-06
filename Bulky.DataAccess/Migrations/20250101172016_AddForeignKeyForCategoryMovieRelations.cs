using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmGalaxy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyForCategoryMovieRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Action" },
                    { 2, 2, "Sci-Fi" },
                    { 3, 3, "History" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "CategoryId", "Date", "Description", "Director", "ListPrice", "Name", "Price", "Price100", "Price50" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2010, 7, 16), "A mind-bending thriller by Christopher Nolan.", "Christopher Nolan", 14.99, "Inception", 9.9900000000000002, 7.9900000000000002, 8.9900000000000002 },
                    { 2, 1, new DateOnly(2008, 7, 18), "The second installment in the Batman trilogy by Nolan.", "Christopher Nolan", 16.989999999999998, "The Dark Knight", 11.99, 9.9900000000000002, 10.99 },
                    { 3, 2, new DateOnly(1999, 3, 31), "A science fiction classic about simulated reality.", "The Wachowskis", 12.99, "The Matrix", 8.9900000000000002, 6.9900000000000002, 7.9900000000000002 },
                    { 4, 1, new DateOnly(2019, 4, 26), "The epic conclusion to the Infinity Saga.", "Anthony and Joe Russo", 19.989999999999998, "Avengers: Endgame", 14.99, 12.99, 13.99 },
                    { 5, 3, new DateOnly(1997, 12, 19), "A love story set during the ill-fated voyage of the Titanic.", "James Cameron", 18.989999999999998, "Titanic", 13.99, 11.99, 12.99 },
                    { 6, 2, new DateOnly(1972, 3, 24), "A powerful family drama set in the world of organized crime.", "Francis Ford Coppola", 15.99, "The Godfather", 10.99, 8.9900000000000002, 9.9900000000000002 },
                    { 7, 3, new DateOnly(1994, 7, 6), "The life story of a man with a low IQ but a big heart.", "Robert Zemeckis", 13.99, "Forrest Gump", 9.9900000000000002, 7.9900000000000002, 8.9900000000000002 },
                    { 8, 2, new DateOnly(1993, 6, 11), "A groundbreaking film about a dinosaur theme park gone wrong.", "Steven Spielberg", 14.99, "Jurassic Park", 10.99, 8.9900000000000002, 9.9900000000000002 },
                    { 9, 2, new DateOnly(1994, 10, 14), "A unique and nonlinear crime drama by Quentin Tarantino.", "Quentin Tarantino", 17.989999999999998, "Pulp Fiction", 12.99, 10.99, 11.99 },
                    { 10, 3, new DateOnly(1994, 9, 22), "A man wrongfully convicted of murder forms a friendship in prison.", "Frank Darabont", 16.989999999999998, "The Shawshank Redemption", 11.99, 9.9900000000000002, 10.99 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
