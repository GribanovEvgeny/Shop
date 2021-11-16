using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
	public class MockProduct : IProductService
	{
		readonly ICategoryService _categoriesService = new MockCategory();
		public IEnumerable<Product> Products {
			get
			{
				return new List<Product> { 
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
			}
		}

		public Product GetProduct(int ProductId)
		{
			throw new NotImplementedException();
		}
	}
}
