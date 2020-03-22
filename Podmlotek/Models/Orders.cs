using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Podmlotek.Models
{
	public class Orders
	{
		public int OrdersId { get; set; }
		public string UserId { get; set; }

		public virtual ApplicationUser User { get; set; }
		[Required(ErrorMessage = "Wprowadz imie")]
		[StringLength(50)]
		public string Imie { get; set; }
		[Required(ErrorMessage = "Wprowadz nazwisko")]
		[StringLength(50)]
		public string Nazwisko { get; set; }
		[Required(ErrorMessage = "Wprowadz ulice")]
		[StringLength(100)]
		public string Adres { get; set; }
		[Required(ErrorMessage = "Wprowadz miasto")]
		[StringLength(100)]
		public string Miasto { get; set; }
		[Required(ErrorMessage = "kod pocztowy")]
		[StringLength(6)]
		public string KodPocztowy { get; set; }
		public string Telefon { get; set; }
		public string Email { get; set; }
		public string Komentarz { get; set; }
		public DateTime OrderDate { get; set; }
		public OrderStatus OrderStatus { get; set; }
		public decimal OrderValue { get; set; }
		public List<OrderItem> OrderItem { get; set; }
	}
	public enum OrderStatus
	{ 
		New,
		Completed
	}
}