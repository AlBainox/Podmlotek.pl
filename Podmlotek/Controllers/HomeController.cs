﻿using Podmlotek.ViewModels;
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
			var bestseller = db.Product.Where(p => p.Bestseller && !p.Hidden).Take(3);
			var nowosci = db.Product.Where(p => !p.Hidden).OrderByDescending(p=>p.DateAdded).Take(3);

			HomeViewModel vm = new HomeViewModel()
			{
				Bestsellers = bestseller,
				News = nowosci,
			};

			return View(vm);
		}

		public ActionResult CategoryList(int categoryId, int subcategoryId)
		{
			var subcategories = db.Subcategory.Where(s => s.CategoriesId == categoryId);
			var products = db.Product.Where(p => p.SubcategoriesId == subcategoryId);

			CategoryListViewModel cl = new CategoryListViewModel()
			{
				Subcategories = subcategories,
				Products = products
			};
			return View(cl);
		}
		

	}

}