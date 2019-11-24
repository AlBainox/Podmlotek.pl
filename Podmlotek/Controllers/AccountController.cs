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
        public ActionResult Logining()
        {
            return View();
        }
		public ActionResult Register()
		{
			return View();
		}
	}
}