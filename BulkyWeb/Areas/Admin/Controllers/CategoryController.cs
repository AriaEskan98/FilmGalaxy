
using FilmGalaxyWeb.Transformers;
using Microsoft.AspNetCore.Mvc;
using FilmGalaxy.DataAccess.Data;
using FilmGalaxy.DataAccess.Repository.IRepository;
using FilmGalaxy.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using FilmGalaxy.Utility;

namespace FilmGalaxyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var categories =(await _unitOfWork.Category.GetAllAsync())
               .Select(c => c.ToGetDTO())
               .ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCategoryDTO obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("", "Name cannot be the same as the Display Order");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj.ToModel());
                _unitOfWork.Save();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        public async Task<IActionResult> UpdateAsync(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            UpdateCategoryDTO? category =(await _unitOfWork.Category.GetAsync(u => u.CategoryId == id))
                .ToUpdateDTO();
            ArgumentNullException.ThrowIfNull(category);
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(UpdateCategoryDTO obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("", "Name cannot be the same as the Display Order");
            }
            if (ModelState.IsValid)
            {
                // Retrieve the existing entity
                //var category = _categoryRepo.Get(u => u.CategoryId == obj.CategoryId);

                //if (category == null)
                //{
                //    return NotFound(); // Handle case where category doesn't exist
                //}
                ArgumentException.ThrowIfNullOrEmpty(obj.Name);
                ArgumentNullException.ThrowIfNull(obj.DisplayOrder!.Value);
                // Update properties
                _unitOfWork.Category.Update(obj.ToModel());


                // Save changes
                _unitOfWork.Save();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            UpdateCategoryDTO? category =(await _unitOfWork.Category.GetAsync(u => u.CategoryId == id))
                .ToUpdateDTO();
            ArgumentNullException.ThrowIfNull(category);
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePOSTAsync(int? id)
        {
            var obj =await _unitOfWork.Category.GetAsync(u => u.CategoryId == id);
            ArgumentNullException.ThrowIfNull(obj);
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("", "Name cannot be the same as the Display Order");
            }
            _unitOfWork.Category.Delete(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");


        }
    }
}
