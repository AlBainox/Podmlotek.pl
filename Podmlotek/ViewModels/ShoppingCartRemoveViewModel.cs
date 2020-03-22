using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podmlotek.ViewModels
{
	public class ShoppingCartRemoveViewModel
	{
		public decimal ShoppingCartTotalAmount { get; set; }
		public int ItemQuantity { get; set; }
		public int ShoppingCartQuantityItems { get; set; }
		public int RemoveItemId { get; set; }
	}
}