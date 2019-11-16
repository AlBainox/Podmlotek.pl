using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podmlotek.Models
{
	public class Categories
	{
		public int CategoryId { get; set; }
		public string Name { get; set; }

		public virtual ICollection<Products> Product { get; set; }
	}
}