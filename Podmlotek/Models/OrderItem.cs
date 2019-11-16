using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podmlotek.Models
{
	public class OrderItem
	{
		public int OrderItemId { get; set; }
		public int OrdersId { get; set; }
		public int ProductsId { get; set; }
		public int Pieces { get; set; }
		public int OrderPrice { get; set; }
		public virtual Products Product { get; set; }
		public virtual Orders Order { get; set; }



	}
}