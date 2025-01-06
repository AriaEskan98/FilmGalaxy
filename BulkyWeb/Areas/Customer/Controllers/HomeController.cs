using System.Diagnostics;
using FilmGalaxy.DataAccess.Repository.IRepository;
using FilmGalaxy.DTOs.MovieDTOs;
using FilmGalaxy.Models;
using FilmGalaxyWeb.Transformers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmGalaxyWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> IndexAsync()
        {
            List<GetMovieDTO>? movies =(await _unitOfWork.Movie.GetAllAsync(includeProps:"Category"))
              .Select(m => m.ToGetDTO())
              .ToList();
            return View(movies);
        }

        public async Task<IActionResult> DetailsAsync(int? id)
        {
            var movie =(await _unitOfWork.Movie.GetAsync(u => u.MovieId == id, includeProps:"Category"))
              .ToCreateDTO();
            ArgumentNullException.ThrowIfNull(movie);
            return View(movie);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
