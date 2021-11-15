using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
	public class MockCategory : ICategory
	{
		public IEnumerable<Category> AllCategories
		{
			get {
				return new List<Category> {
					new Category{ Name = "Зеленые" },
					new Category{ Name = "Красные" },
					new Category{ Name = "Желтые" }
				};
			}
		}
	}
}
