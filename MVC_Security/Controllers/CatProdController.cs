using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Security.Models;
using MVC_Security.Services;
using MVC_Security.ViewModel;

namespace MVC_Security.Controllers
{
	public class CatesPrdsController : Controller
	{
		private IService<Categories, int> catService;
		private IService<Products, int> prdService;
		public CatesPrdsController(IService<Categories, int> cat, IService<Products, int> prd)
		{
			catService = cat;
			prdService = prd;
		}
		/// <summary>
		/// Index method with default parameters C# 4.0+
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public IActionResult Index(int id = 0)
		{
			var catprds = new CategoriesProducts();

			if (id == 0)
			{
				catprds.Categories = catService.GetAsync().Result.ToList();
				catprds.Products = prdService.GetAsync().Result.ToList();
			}
			else
			{
				catprds.Categories = catService.GetAsync().Result.ToList();
				catprds.Products = prdService.GetAsync().Result.ToList().Where(p => p.CategoryRowId == id).ToList();
			}
			return View(catprds);
		}

		/// <summary>
		/// The ShowProducts contains repeatative code for filtration
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public IActionResult ShowProducts(int id)
		{
			var catsprds = new CategoriesProducts()
			{
				Categories = catService.GetAsync().Result.ToList(),
				Products = prdService.GetAsync().Result.ToList().Where(p => p.CategoryRowId == id).ToList()
			};
			return View("Index", catsprds);
		}

		public IActionResult ShowProductsNew(int id)
		{
			// navifate to Index page with Route Value

			return RedirectToAction("Index", new { id = id });
		}
	}
}
