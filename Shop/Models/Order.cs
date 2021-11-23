using System;

namespace Shop.Models
{
	public class Order
	{
		public int Id { get; set; }
		public string CartItemJson { get; set; }    // так как строится не полная БД, а только таблица с заказами
		public DateTime DateCreate { get; set; }
		public string CountryName { get; set; }	// по идее нужен id города, но их нет
	}
}
