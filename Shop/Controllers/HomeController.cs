using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
	public class HomeController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;
		private IEnumerable<Product> products;

		public HomeController(IProductService productService, ICategoryService categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;
			products = productService.Products;
		}

		public ViewResult Index()
		{
			ViewBag.Title = "Каталог товаров";
			ViewBag.Categories = _categoryService;
			return View(products);
		}

		public ActionResult SortAndFilter(string methodSort, uint? categoryId)
		{
			if (categoryId == null)
				products = _productService.Products;
			else
				products = _productService.Products.Where(i => i.CategoryId == categoryId);
			switch (methodSort)
			{
				case "none":
					products = products.OrderBy(i => i.Id);
					break;
				case "PriceUp":
					products = products.OrderBy(i => i.Price);
					break;
				case "PriceDown":
					products = products.OrderByDescending(i => i.Price);
					break;
			}
			return Json(products);
		}
	}
}
