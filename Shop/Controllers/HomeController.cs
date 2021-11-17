using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
	public class HomeController : Controller
	{
		private readonly IEnumerable<Product> _productService;       // типо данные из БД
		private readonly IEnumerable<Category> _categoryService;    // типо данные из БД
		private static IEnumerable<Product> products;
		private static Cart cart;                                          // типо данные из БД
		private static List<CartItem> cartItems;					// типо данные из БД

		public HomeController()
		{
			_productService = new List<Product> {
					new Product{
						Id = 0,
						Name = "Морковь",
						ImageSrc = "/img/carrot.jpg",
						Price = 20,
						CategoryId = 1,
						Description = "Двулетнее растение,овощная культура,подвид вида морковь дикая."
					},
					new Product{
						Id = 1,
						Name = "Кукуруза",
						ImageSrc = "/img/corn.jpg",
						Price = 40,
						CategoryId = 2,
						Description = "Однолетнее травянистое культурное растение,единственный культурный представитель рода Кукуруза семейства Злаки."
					},
					new Product{
						Id = 2,
						Name = "Огурец",
						ImageSrc = "/img/cucumber.jpg",
						Price = 60,
						CategoryId = 0,
						Description = "Однолетнее травянистое растение, вид рода Огурец семейства Тыквенные, овощная культура."
					},
					new Product{
						Id = 3,
						Name = "Укроп",
						ImageSrc = "/img/dill.jpg",
						Price = 30,
						CategoryId = 0,
						Description = "Монотипный род короткоживущих однолетних травянистых растений семейства Зонтичные."
					},
					new Product{
						Id = 4,
						Name = "Перец",
						ImageSrc = "/img/pepper.jpg",
						Price = 50,
						CategoryId = 2,
						Description = "Популярная овощная культура с насыщенным своеобразным вкусом и приятным ароматом."
					},
					new Product{
						Id = 5,
						Name = "Помидор",
						ImageSrc = "/img/tomato.jpg",
						Price = 10,
						CategoryId = 1,
						Description = "Однолетнее или многолетнее травянистое растение,вид рода Паслён семейства Паслёновые."
					}
				};
			_categoryService = new List<Category> {
					new Category{
						Id = 0,
						Name = "Зеленые"
					},
					new Category{
						Id = 1,
						Name = "Красные"
					},
					new Category{
						Id = 2,
						Name = "Желтые"
					}
				}; 
			cart = new Cart(){Id = 1};
			products = _productService;
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
				products = _productService;
			else
				products = _productService.Where(i => i.CategoryId == categoryId);
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

		public ActionResult PutInCart(uint productId)
		{
			if(cartItems != null)
			{
				List<CartItem> productsInCart = cartItems.Where(i => i.CartId == cart.Id && i.ProductId == productId).ToList();
				if (productsInCart.Count == 0)
					cartItems.Add(new CartItem()
					{
						Id = (uint)cartItems.Count(),
						CartId = cart.Id,
						ProductId = productId,
						CountProduct = 1
					});
				else
					productsInCart[0].CountProduct++;
				uint countItemInCart = 0;
				cartItems.Where(i => i.CartId == cart.Id).ToList().ForEach(i => countItemInCart += i.CountProduct);
				return Json(countItemInCart);
			}
			else
			{
				cartItems = new List<CartItem>()
				{
					new CartItem(){
					Id = 0,
					CartId = cart.Id,
					ProductId = productId,
					CountProduct = 1
				}};
				return Json(1);
			}
		}
	}
}
