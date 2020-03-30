using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Podmlotek.Infrastructure;
using Podmlotek.Models;
using Podmlotek.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Podmlotek.Controllers
{
	public class ShoppingCartController : Controller
	{
		// GET: ShoppingCart

		private ISessionManager session { get; set; }
		private Context db;
		private ShoppingCartManager scm;

		public ShoppingCartController()
		{
			db = new Context();
			session = new SessionManager();
			scm = new ShoppingCartManager(session, db);
		}
		
		public ActionResult Index()
		{
			var shoppingCartItem = scm.GetShoppingCart();
			var totalPrice = scm.GetShoppingCartValue();
			ShoppingCartViewModel CartVM = new ShoppingCartViewModel()
			{
				ShoppingCartItems = shoppingCartItem,
				TotalPrice = totalPrice
			};
			return View(CartVM);
		}
		public ActionResult AddTo(int id)
		{
			scm.AddToShoppingCart(id);
			return RedirectToAction("Index");
		}
		public int GetQuantityOfShoppingCartItems()
		{
			return scm.GetQuantityOfShoppingCartItems();
		}

		public ActionResult RemoveFromShoppingCart(int id)
		{
			int itemsQuantityAfterRemove = scm.RemoveFromShoppingCart(id);
			int shoppingCartItemsQuantity = scm.GetQuantityOfShoppingCartItems();
			decimal shoppingCartAmount = scm.GetShoppingCartValue();

			var result = new ShoppingCartRemoveViewModel
			{
				RemoveItemId = id,
				ItemQuantity = itemsQuantityAfterRemove,
				ShoppingCartQuantityItems = shoppingCartItemsQuantity,
				ShoppingCartTotalAmount = shoppingCartAmount
			};

			return Json(result);
		}

		public async Task<ActionResult> Pay()
		{
			if (Request.IsAuthenticated)
			{
				var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
				var order = new Orders
				{
					Imie = user.UserData.Imie,
					Nazwisko = user.UserData.Nazwisko,
					Adres = user.UserData.Adres,
					Miasto = user.UserData.Miasto,
					KodPocztowy = user.UserData.KodPocztowy,
					Email = user.UserData.Email,
					Telefon = user.UserData.Telefon
				};
				return View(order);
			}
			else
			{
				return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Pay", "ShoppingCart") });
			}
		}
		[HttpPost]
		public async Task<ActionResult> Pay(Orders order)
		{
			if (ModelState.IsValid)
			{
				var userId = User.Identity.GetUserId();
				var newOrder = scm.CreateNewOrder(order, userId);
				var user = await UserManager.FindByIdAsync(userId);
				TryUpdateModel(user.UserData);
				await UserManager.UpdateAsync(user);
				scm.EmptyShoppingCart();
				return RedirectToAction("OrderConfirmation");
			}
			return View();
		}
		public ActionResult OrderConfirmation()
		{
			var name = User.Identity.Name;
			return View();
		}
		private ApplicationUserManager _userManager;
		public ApplicationUserManager UserManager
		{
			get
			{
				return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}

	}
}