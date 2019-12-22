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
		HomeViewModel hvm = new HomeViewModel();
		CategoriesViewModel cvm = new CategoriesViewModel();
		public ActionResult Index()
		{
			var bestseller = db.Product.Where(p => p.Bestseller && !p.Hidden).Take(3);
			var nowosci = db.Product.Where(p => !p.Hidden).OrderByDescending(p => p.DateAdded).Take(3);

			hvm.Bestsellers = bestseller;
			hvm.News = nowosci;

			return View(hvm);
		}
		
		[ChildActionOnly]
		public ActionResult SubcategoryList(int categoryId)
		{
			var subcategories = db.Subcategory.Where(s => s.CategoriesId == categoryId).ToList();
			return PartialView("_SubcategoryList", subcategories);
		}

		public ActionResult PorductList(int? subcategoryId)
		{
			var products = db.Product.Where(p => p.SubcategoriesId == subcategoryId).ToList();
			return View(products);
		}

		[ChildActionOnly]
		public ActionResult Categories()
		{
			var categories = db.Category;
			cvm.Categories = categories;
			return PartialView("_Categories", cvm);
		}

	}

} 