using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podmlotek.Models
{
	public class Subcategories
	{
		public int SubcategoriesId { get; set; }
		public int CategoriesId { get; set; }		
		public string Name { get; set; }
		public virtual Categories Categories { get; set; }		
	}
}