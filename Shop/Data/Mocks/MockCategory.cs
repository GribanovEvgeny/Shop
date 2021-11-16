using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
	public class MockCategory : ICategoryService
	{
		public IEnumerable<Category> Categories
		{
			get {
				return new List<Category> {
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
			}
		}
	}
}
