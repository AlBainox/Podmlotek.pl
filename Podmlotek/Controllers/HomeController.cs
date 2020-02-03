using Podmlotek.Infrastructure;
using Podmlotek.Models;
using Podmlotek.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Podmlotek.Controllers
{
	public class HomeController : Controller
	{
		Context db = new Context();
		
		public ActionResult Index()
		{
			HomeViewModel hvm = new HomeViewModel();

			var bestseller = db.Product.Where(p => p.Bestseller && !p.Hidden).Take(3);
			var nowosci = db.Product.Where(p => !p.Hidden).OrderByDescending(p => p.DateAdded).Take(3);

			hvm.Bestsellers = bestseller;
			hvm.News = nowosci;


			return View(hvm);
		}
		[ChildActionOnly]
		public ActionResult Categories()
		{
			ProductsViewModel pvm = new ProductsViewModel();
			var categories = db.Category;
			pvm.Categories = categories;
			return PartialView("_Categories", pvm);
		}

		public ActionResult ProductList(int categoryId, int? subcategoryId)
		{
			ProductsViewModel pvm = new ProductsViewModel();

			List<int> subcategoriesId= new List<int>();

			var subcategories = db.Subcategory.Where(i => i.CategoriesId == categoryId);

			foreach ( var item in subcategories)
			{
				var newId = item.SubcategoriesId;
				subcategoriesId.Add(newId);
			}

			List<Products> products = new List<Products>();
			foreach (var item in subcategoriesId)
			{
				var productsToAdd = db.Product.Where(i => i.SubcategoriesId == item).ToList();
				products.AddRange(productsToAdd);
			}
			pvm.Subcategories = subcategories;
			pvm.Products = products;

			if (subcategoryId.HasValue)
			{
				var newProducts = db.Product.Where(i => i.SubcategoriesId == subcategoryId);
				pvm.Products = null;
				pvm.Products = newProducts;
				return View(pvm);
			}

			return View(pvm);
		}
	}
}