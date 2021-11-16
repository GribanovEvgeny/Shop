using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
	public class ShopCartItem
	{
		public uint Id { get; set; }
		public uint ProductId { get; set; }
		public uint CountProduct { get; set; }
	}
}
