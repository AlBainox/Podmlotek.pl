using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Podmlotek.Models
{
	public class Products
	{
		public int ProductsId { get; set; }
		public int SubcategoriesId { get; set; }
		public int CategoriesId { get; set; }
		public int UsersId { get; set; }
		public string Item { get; set; }
		public DateTime DateAdded { get; set; }
		public string Picture { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public bool Bestseller { get; set; }
		public bool Hidden { get; set; }
		[StringLength(300)]
		public string ShortDescription { get; set; }


		public virtual Subcategories Subcategories { get; set; }
		public virtual Users Users { get; set; }
		
	}
	
}
