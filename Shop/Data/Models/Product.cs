using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
	public class Product
	{
		public uint Id { get; set; }
		public string Name { get; set; }
		public string ImageSrc { get; set; }
		public double Price { get; set; }
		public string Description { get; set; }
		public uint CategoryId { get; set; }
	}
}
