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
		public ActionResult SubcategoryList(int? categoryId)
		{
			var subcategories = db.Subcategory.Where(s => s.CategoriesId == categoryId).ToList();
			return PartialView("_SubcategoryList", subcategories);
		}

		public ActionResult PorductList()
		{
			return View();
		}
		[ChildActionOnly]
		public ActionResult ProductItems(int? subcategoryId, int? categoryId)
		{
			ProductsViewModel pvm = new ProductsViewModel();

			if (subcategoryId == null)
			{
				var products = db.Product.Where(p => p.CategoriesId == categoryId).ToList();
				pvm.Products = products;
			}
			else if (categoryId == null)
			{
				var products = db.Product.Where(p => p.SubcategoriesId == subcategoryId).ToList();
				pvm.Products = products;
			}
			return PartialView("_ProductItems", pvm);
		}

		[ChildActionOnly]
		public ActionResult Categories()
		{
			CategoriesViewModel cvm = new CategoriesViewModel();

			var categories = db.Category;
			cvm.Categories = categories;
			return PartialView("_Categories", cvm);
		}

	}

} 