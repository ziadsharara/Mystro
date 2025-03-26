using Microsoft.AspNetCore.Mvc;
using Mystro.DataAccess.Data;
using Mystro.Models.Models;

namespace MystroWeb.Controllers
{ 
  public class CategoryController : Controller
  {
    private readonly ApplicationDbContext _db;
		public CategoryController(ApplicationDbContext db)
		{
      _db = db;
		}
		public IActionResult Index()
    {
      List<Category> objCategoryList = _db.Categories.ToList();
      return View(objCategoryList);
    } 
     // CRUD Opreations
		 // Create
		 // GET Method
    public IActionResult Create()
    {
      return View();
    }

		// POST Method
    [HttpPost] // to do action on click on click on the button
    public IActionResult Create(Category obj)
    {
      if(obj.Name == obj.DisplayOrder.ToString())
      {
        ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");

			}
			if (ModelState.IsValid) // check the validation
      {
        _db.Categories.Add(obj); // to add to catergory table
        _db.SaveChanges(); // (required line) to save changes in database
				TempData["success"] = "Category Created Successfully!";
				return RedirectToAction("Index"); // to go to index view after submit the changes
			}
      return View();
		}

		// Update / Edit
		// GET Method
		public IActionResult Edit(int? id)
		{
			if(id == null || id == 0)
			{
				return NotFound();
			}

			Category? categoryFromDb = _db.Categories.FirstOrDefault(u => u.Id == id);

			if(categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}

		// POST Method
		[HttpPost] // to do action on click on click on the button
		public IActionResult Edit(Category obj)
		{
			
			if (ModelState.IsValid) // check the validation
			{
				_db.Categories.Update(obj); // to update the catergory properties in database
				_db.SaveChanges(); // (required line) to save changes in database 
				TempData["success"] = "Category Updated Successfully!";
				return RedirectToAction("Index"); // to go to index view after submit the changes
			}
			return View();
		}

		// Delete
		// GET Method
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Category? categoryFromDb = _db.Categories.FirstOrDefault(u => u.Id == id);

			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}

		// POST Method
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Category obj = _db.Categories.Find(id); 
			if(obj == null)
			{
				return NotFound();
			}
			_db.Categories.Remove(obj);
			_db.SaveChanges(); // (required line) to save changes in database 
			TempData["success"] = "Category Deleted Successfully!";
			return RedirectToAction("Index"); // to go to index view after submit the changes
		}
	} 
}
