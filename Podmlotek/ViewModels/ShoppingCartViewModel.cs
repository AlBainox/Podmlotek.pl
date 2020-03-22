using Podmlotek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podmlotek.ViewModels
{
	public class ShoppingCartViewModel
	{
		public List<ShoppingCartItems> ShoppingCartItems { get; set; }
		public decimal TotalPrice { get; set; }		
	}
}