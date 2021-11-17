using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
	public class CartController : Controller
	{
		private readonly IEnumerable<Product> _productService;
		private readonly IEnumerable<Category> _categoryService;

		public CartController(IEnumerable<Product> productService, IEnumerable<Category> categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;
		}
	}
}
