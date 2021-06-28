using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Security.Models;
using MVC_Security.SessionExtension;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Diagnostics;
using MVC_Security.Services;

namespace MVC_Security.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IService<Categories, int> catService;

		const string SessionId = "_Id";
		public CategoryController(IService<Categories, int> s)
		{
			catService = s;
		}

		public async Task<IActionResult> Index()
		{
			
			var res = await catService.GetAsync();
			ViewData["CategoryRowId"] = new SelectList(catService.GetAsync().Result.ToList(), "CategoryRowId", "CategoryName");
			return View(res);
		}

		public IActionResult Create()
		{
			ViewBag.CategoryId = HttpContext.Session.GetString("CategoryId");
			ViewBag.CategoryName = HttpContext.Session.GetString("CategoryName");
			ViewBag.BasePrice = HttpContext.Session.GetInt32("BasePrice");
			ViewBag.SubCategoryName = HttpContext.Session.GetString("SubCategoryName");
		
			// Debug.Write(ViewBag.CategoryId);
			return View(new Categories());
		}

		[HttpPost]
		public async Task<IActionResult> Create(Categories data)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var res = await catService.CreateAsync(data);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(data);
                }
            }
            catch (Exception ex)
            {

				HttpContext.Session.SetString("CategoryId", data.CategoryId);
				HttpContext.Session.SetString("CategoryName", data.CategoryName);
				HttpContext.Session.SetInt32("BasePrice", data.BasePrice);
				HttpContext.Session.SetString("SubCategoryName", data.SubCategoryName);

				var cat = catService.GetAsync(ViewBag.CategoryId).Result;
				// HttpContext.Session.SetObject<Categories>("cat", cat);

				return View("Error", new ErrorViewModel()
				{
					ControllerName = RouteData.Values["controller"].ToString(),
					ActionName = RouteData.Values["action"].ToString(),
					ErrorMessage = $"{ex.Message} \n Detailed Exception {ex.InnerException.Message}"

				});
            }
		}


		public async Task<IActionResult> Edit(int id)
		{
		
			var res = await catService.GetAsync(id);
			return View(res);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, Categories data)
		{
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await catService.UpdateAsync(id, data);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(data);
                }
            }
            catch (Exception)
            {
				return View("Index");
            }
		}

		public async Task<IActionResult> Delete(int id)
		{
			var res = await catService.DeleteAsync(id);
			return RedirectToAction("Index");
		}

		public IActionResult ShowProducts(int id)
		{
			HttpContext.Session.SetInt32("CatRowId", id);
			var cat = catService.GetAsync(id).Result;
			HttpContext.Session.SetObject<Categories>("Cat", cat);
			return RedirectToAction("Index", "Product");
		}

		
	}
}
