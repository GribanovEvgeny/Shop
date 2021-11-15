using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProduct _products;
		private readonly ICategory _categories;

		public ProductController(IProduct products, ICategory categories)
		{
			_products = products;
			_categories = categories;
		}

		public ViewResult Products()
		{
			var products = _products.Products;
			ViewBag.Title = "Каталог товаров";
			ViewBag.Categories = _categories;
			return View(products);
		}
	}
}
