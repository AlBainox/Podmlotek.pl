using Podmlotek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podmlotek.ViewModels
{
	public class CategoryListViewModel
	{
		public IEnumerable<Subcategories> Subcategories { get; set; }
		public IEnumerable<Products> Products { get; set; }
	}
}