using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podmlotek.Models
{
	public class ShoppingCartItems
	{
		public Products Product { get; set; }	
		public int Pieces { get; set; }
		public decimal OrderValue { get; set; }
	}
}