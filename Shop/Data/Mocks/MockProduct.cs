using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
	public class MockProduct : IProduct
	{
		readonly ICategory _categories = new MockCategory();
		public IEnumerable<Product> Products {
			get
			{
				return new List<Product> { 
					new Product{
						Name = "Морковь", 
						ImageSrc = "/img/carrot.jpg", 
						Price = 20, 
						Category = _categories.AllCategories.ToList()[1], 
						Description = "Двулетнее растение,овощная культура,подвид вида морковь дикая."
					},
					new Product{
						Name = "Кукуруза", 
						ImageSrc = "/img/corn.jpg", 
						Price = 40, 
						Category = _categories.AllCategories.ToList()[2], 
						Description = "Однолетнее травянистое культурное растение,единственный культурный представитель рода Кукуруза семейства Злаки."
					},
					new Product{
						Name = "Огурец", 
						ImageSrc = "/img/cucumber.jpg", 
						Price = 60, 
						Category = _categories.AllCategories.ToList()[0], 
						Description = "Однолетнее травянистое растение, вид рода Огурец семейства Тыквенные, овощная культура."
					},
					new Product{
						Name = "Укроп", 
						ImageSrc = "/img/dill.jpg", 
						Price = 30, 
						Category = _categories.AllCategories.ToList()[0], 
						Description = "Монотипный род короткоживущих однолетних травянистых растений семейства Зонтичные."
					},
					new Product{
						Name = "Перец", 
						ImageSrc = "/img/pepper.jpg", 
						Price = 50, 
						Category = _categories.AllCategories.ToList()[2], 
						Description = "Популярная овощная культура с насыщенным своеобразным вкусом и приятным ароматом."
					},
					new Product{
						Name = "Помидор", 
						ImageSrc = "/img/tomato.jpg", 
						Price = 10, 
						Category = _categories.AllCategories.ToList()[1], 
						Description = "Однолетнее или многолетнее травянистое растение,вид рода Паслён семейства Паслёновые."
					}
				};
			}
		}

		public Product GetProduct(int ProductId)
		{
			throw new NotImplementedException();
		}
	}
}
