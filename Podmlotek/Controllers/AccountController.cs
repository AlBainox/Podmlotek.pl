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
    public class AccountController : Controller
    {
		// GET: Account
		Context db = new Context();

		public ActionResult Logining()
		{			
			return View();
		}
		[HttpPost]
		public ActionResult Logining(Users user)
		{
			var usr = db.User.Single(u => u.Email == user.Email && u.Password == user.Password);
			
			if (usr != null)
			{
				UserManager.Set(usr);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ModelState.AddModelError("", "Login lub hasło jest nie poprawne");
			}

			return View();
		}

		
		public ActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Register(Users user)
		{
			if (ModelState.IsValid)
			{
				db.User.Add(user);
				db.SaveChanges();				
				UserManager.Set(user);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ModelState.Clear();
				return View();
			}

			
		}
	}
}