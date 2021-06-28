using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Security.Controllers
{
	[Authorize(Roles ="Admin")]
	public class RoleController : Controller
	{
		private readonly RoleManager<IdentityRole> roleManager;

		public RoleController(RoleManager<IdentityRole> role)
		{
			roleManager = role;
		}

		public IActionResult Index()
		{
			var roles = roleManager.Roles.ToList();
			return View(roles);
		}

		public IActionResult Create()
		{
			var role = new IdentityRole();
			return View(role);
		}
		[HttpPost]
		[Authorize(Policy  = "AdminCreatePolicy")]
		public async Task<IActionResult> Create(IdentityRole role)
		{
			if (role.Name == "Admin")
			{
				await roleManager.CreateAsync(role);
				return RedirectToAction("Index");
			}
			return RedirectToAction("/Identity/Account/Login");
		}
	}
}
