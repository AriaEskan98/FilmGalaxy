using FilmGalaxyWeb.Transformers;
using Microsoft.AspNetCore.Mvc;
using FilmGalaxy.DataAccess.Data;
using FilmGalaxy.DataAccess.Repository.IRepository;
using FilmGalaxy.DTOs;
using FilmGalaxy.DTOs.MovieDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using FilmGalaxy.Models;
using FilmGalaxy.Utility;
using Microsoft.AspNetCore.Authorization;

namespace FilmGalaxyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class MovieController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        public MovieController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var movies = (await _unitOfWork.Movie.GetAllAsync(includeProps: "Category"))
                         .Select(m => m.ToGetDTO())
                         .ToList();

            return View(movies);
        }

        public async Task<IActionResult> UpsertAsync(int? id)
        {
            IEnumerable<SelectListItem> CategoryList = (await _unitOfWork.Category.GetAllAsync())
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()
                });
            ViewData["CategoryList"] = CategoryList;
            var createMovieDto = new CreateMovieDTO
            {
                CategoryList = CategoryList
            };
            if (id == null)
            {
                return View(createMovieDto);
            }
            else
            {
                var movieEntity = (await _unitOfWork.Movie.GetAsync(m => m.MovieId == id, "Category"));


                CreateMovieDTO? movie = movieEntity?.ToCreateDTO();
                movie!.CategoryList = CategoryList;
                return View(movie);
            }


        }

        [HttpPost]
        public IActionResult UpsertAsnyc(CreateMovieDTO obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"Images\movies");

                    if (!obj.ImgURL.IsNullOrEmpty())
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.ImgURL.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);

                        }
                    }
                    using(var FileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(FileStream);
                    }
                    obj.ImgURL= @"\images\movies\" +fileName;
                }
                if(obj.MovieId == 0)
                {
                    _unitOfWork.Movie.Add(obj.ToModel());
                }
                else
                {
                    
                    _unitOfWork.Movie.Update(obj.ToModel());
                }
                _unitOfWork.Save();
                TempData["success"] = "Movie Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        //public IActionResult Update(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    UpdateMovieDTO? movie = _unitOfWork.Movie.Get(m => m.MovieId == id)?
        //        .Include(m=>m.Category)
        //        .FirstOrDefault()?
        //        .ToUpdateDTO();
           
        //    ArgumentNullException.ThrowIfNull(movie);
        //    return View(movie);
        //}

        //[HttpPost]
        //public IActionResult Update(UpdateMovieDTO obj)
        //{
        //    if (obj.Name == obj.Description)
        //    {
        //        ModelState.AddModelError("", "Name cannot be the same as the Description");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        ArgumentException.ThrowIfNullOrEmpty(obj.Name);
        //        ArgumentNullException.ThrowIfNull(obj.Description);
        //        _unitOfWork.Movie.Update(obj.ToModel());
        //        _unitOfWork.Save();
        //        TempData["success"] = "Movie Updated Successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    CreateMovieDTO? movie = _unitOfWork.Movie.Get(m => m.CategoryId == id)?
        //        .Include(m => m.Category)
        //        .FirstOrDefault()?
        //        .ToCreateDTO();
        //    ArgumentNullException.ThrowIfNull(movie);
        //    return View(movie);
        //}

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePOSTAsync(int? id)
        {
            var obj =await _unitOfWork.Movie.GetAsync(m => m.CategoryId == id, includeProps: "Category");
            ArgumentNullException.ThrowIfNull(obj);
            _unitOfWork.Movie.Delete(obj);
            _unitOfWork.Save();
            TempData["success"] = "Movie Deleted Successfully";
            return RedirectToAction("Index");
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<GetMovieDTO> movieList =(await _unitOfWork.Movie.GetAllAsync(includeProps: "Category"))
                .Select(m => m.ToGetDTO())
                .ToList();
            return Json(new { data = movieList });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            var prodoctToDelete =await _unitOfWork.Movie.GetAsync(m => m.MovieId == id);
            if(prodoctToDelete == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }
            if (!prodoctToDelete.ImgURL.IsNullOrEmpty())
            {

                var oldImgPath = Path.Combine(_webHostEnvironment.WebRootPath, prodoctToDelete.ImgURL!.TrimStart('\\'));
                if (System.IO.File.Exists(oldImgPath))
                {
                    System.IO.File.Delete(oldImgPath);

                }
            }
            _unitOfWork.Movie.Delete(prodoctToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion

    }
}
