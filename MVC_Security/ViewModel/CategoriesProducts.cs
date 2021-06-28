using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Security.Models;

namespace MVC_Security.ViewModel
{
	public class CategoriesProducts
	{
		public List<Categories> Categories { get; set; }
		public List<Products> Products { get; set; }
	}
}
