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
			var bestseller = db.Product.Where(p => p.Bestseller && !p.Hidden).Take(3);
			var nowosci = db.Product.Where(p => !p.Hidden).OrderByDescending(p=>p.DateAdded).Take(3);

			HomeViewModel vm = new HomeViewModel()
			{
				Bestsellers = bestseller,
				News = nowosci,
			};

			return View(vm);
		}		
	}
}