using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
	public class CartItem
	{
		public uint Id { get; set; }
		public uint ProductId { get; set; }
		public uint CartId { get; set; }
		public uint CountProduct { get; set; }
	}
}
