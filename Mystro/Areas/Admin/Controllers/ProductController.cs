using Microsoft.AspNetCore.Mvc;
using Mystro.DataAccess.Data;
using Mystro.DataAccess.Repository.IRepository;
using Mystro.Models;

namespace Mystro.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public ProductController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
			return View(objProductList);
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
		public IActionResult Create(Product obj)
		{
			if (ModelState.IsValid) // check the validation
			{
				_unitOfWork.Product.Add(obj); // to add to catergory table
				_unitOfWork.Save(); // (required line) to save changes in database
				TempData["success"] = "Product Created Successfully!";
				return RedirectToAction("Index"); // to go to index view after submit the changes
			}
			return View();
		}

		// Update / Edit
		// GET Method
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);

			if (productFromDb == null)
			{
				return NotFound();
			}
			return View(productFromDb);
		}

		// POST Method
		[HttpPost] // to do action on click on click on the button
		public IActionResult Edit(Product obj)
		{

			if (ModelState.IsValid) // check the validation
			{
				_unitOfWork.Product.Update(obj); // to update to catergory table
				_unitOfWork.Save(); // (required line) to save changes in database
				TempData["success"] = "Product Updated Successfully!";
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

			Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);

			if (productFromDb == null)
			{
				return NotFound();
			}
			return View(productFromDb);
		}

		// POST Method
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Product obj = _unitOfWork.Product.Get(u => u.Id == id);
			if (obj == null)
			{
				return NotFound();
			}
			_unitOfWork.Product.Remove(obj);
			_unitOfWork.Save(); // (required line) to save changes in database 
			TempData["success"] = "Product Deleted Successfully!";
			return RedirectToAction("Index"); // to go to index view after submit the changes
		}
	}
}
