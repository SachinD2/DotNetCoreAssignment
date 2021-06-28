using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_WebApi.Models;
using Core_WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
	// [ApiController]
	public class BinderController : ControllerBase
	{
		private readonly IService<Category, int> catServ;
		public BinderController(IService<Category, int> service)
		{
			catServ = service;
		}

		[HttpPost]
		[ActionName("PostFromBodyAsync")]
		public async Task<IActionResult> PostFromBodyAsync([FromBody] Category categories)
		{
			if (ModelState.IsValid)
			{
				var result = await catServ.CreateAsync(categories);
				return Ok(result);
			}
			else
			{
				return BadRequest(ModelState);
			}

		}

		[HttpPost]
		[ActionName("PostQueryStringAsync")]
		//public async Task<IActionResult> PostQueryStringAsync(string CategoryId, string CategoryName, int BasePrice,string SubCategoryName)
		public async Task<IActionResult> PostQueryStringAsync([FromQuery] Category cat)
		{
			//Categories cat = new Categories()
			//{
			//	 CategoryId = CategoryId,
			//	 CategoryName = CategoryName,
			//	 BasePrice = BasePrice,
			//	 SubCategoryName = SubCategoryName
			//};
			await catServ.CreateAsync(cat);
			return Ok(cat);
		}


		[HttpPost("{CategoryId}/{CategoryName}/{BasePrice}/{SubCategoryName}")]
		[ActionName("PostRouteAsync")]
		//public async Task<IActionResult> PostRouteAsync(string CategoryId, string CategoryName, int BasePrice,string SubCategoryName)
		public async Task<IActionResult> PostRouteAsync([FromRoute] Category cat)
		{
			//Categories cat = new Categories()
			//{
			//	CategoryId = CategoryId,
			//	CategoryName = CategoryName,
			//	BasePrice = BasePrice,
			//	SubCategoryName = SubCategoryName
			//};
			await catServ.CreateAsync(cat);
			return Ok(cat);
		}


		[HttpPost]
		[ActionName("PostFormAsync")]
		//public async Task<IActionResult> PostRouteAsync(string CategoryId, string CategoryName, int BasePrice,string SubCategoryName)
		public async Task<IActionResult> PostFormAsync([FromForm] Category cat)
		{
			//Categories cat = new Categories()
			//{
			//	CategoryId = CategoryId,
			//	CategoryName = CategoryName,
			//	BasePrice = BasePrice,
			//	SubCategoryName = SubCategoryName
			//};
			await catServ.CreateAsync(cat);
			return Ok(cat);
		}

	}
}
