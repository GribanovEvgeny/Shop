using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
	public class CartItem
	{
		public uint Id { get; set; }
		public uint ProductId { get; set; }
		public uint CartId { get; set; }
		public uint CountProduct { get; set; }
		public string ProductName { get; set; }
		public double ProductPrice { get; set; }
	}
}
