using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podmlotek.Models
{
	public class Orders
	{
		public int OrdersId { get; set; }
		public DateTime OrderDate { get; set; }
		public OrderStatus OrderStatus { get; set; }
		public decimal OrderValue { get; set; }
		public List<OrderItem> OrderItems { get; set; }
		public virtual Users Users { get; set; }

	}
	public enum OrderStatus
	{ 
		New,
		Completed
	}
}