using Podmlotek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podmlotek.ViewModels
{
	public class CategoriesViewModel
	{
		public IEnumerable<Categories> Categories { get; set; }
	}
}