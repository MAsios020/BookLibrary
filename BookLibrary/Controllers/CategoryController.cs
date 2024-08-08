using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess.Repository;
using DataAccess.Repository.IRepository;

namespace BookLibrary.Controllers
{
    public class CategoryController : Controller
    {

        ICategoryRepository categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            categoryRepo = db;       
        }
        public IActionResult Index()
        {
			List<Category> categories = categoryRepo.GetAll().ToList();
            return View(categories);
        }

        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepo.Add(category);
                categoryRepo.Save();
				TempData["Success"] = "Category Created Successfuly";
				return RedirectToAction("index");
            }
            else { return View(); }
        }

		

		
		public IActionResult Edit(int? CategoryID)
		{
            if (CategoryID == null || CategoryID == 0)
            {
                return NotFound();
            }
            Category category = categoryRepo.Get(i=>i.Id==CategoryID);
			if (category==null  )
			{
				return NotFound();
			}
			return View(category);
		}


		[HttpPost]
		public IActionResult Edit(Category obj)
		{
			if (ModelState.IsValid)
			{

                categoryRepo.Udate(obj);
                categoryRepo.Save();
				TempData["Success"] = "Category Updated Successfuly";
				return RedirectToAction("index");
			}
			else { return View(); }
		}



		
		//public IActionResult Delete(int? CategoryID)
		//{
		//	if (CategoryID == null || CategoryID == 0)
		//	{
		//		return NotFound();
		//	}
		//	Category category = _dbContext.Categories.Find(CategoryID);
		//	if (category == null)
		//	{
		//		return NotFound();
		//	}
		//return	RedirectToAction("index");
		//}

		
		public IActionResult Delete(int? CategoryID)
		{
			if (ModelState.IsValid)
			{
				Category category = categoryRepo.Get(i => i.Id == CategoryID);
                categoryRepo.Remove(category);
                categoryRepo.Save();
				TempData["Success"] = "Category Deleted Successfuly";
				return RedirectToAction("index");
			}
			else { return View(); }
		}

	}
}
