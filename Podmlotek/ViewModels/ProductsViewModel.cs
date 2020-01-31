using Podmlotek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podmlotek.ViewModels
{
	public class ProductsViewModel
	{
		public IEnumerable<Products> Products { get; set; }
		public IEnumerable<Subcategories> Subcategories { get; set; }
		public IEnumerable<Categories> Categories { get; set; }
	}
}