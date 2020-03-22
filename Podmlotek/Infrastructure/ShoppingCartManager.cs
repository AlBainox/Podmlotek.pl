using Podmlotek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podmlotek.Infrastructure
{
	public class ShoppingCartManager
	{
		private ISessionManager session;
		private Context db;

		public ShoppingCartManager(ISessionManager session, Context db)
		{
			this.db = db;
			this.session = session;
		}
		public List<ShoppingCartItems> GetShoppingCart()
		{
			List<ShoppingCartItems> shoppingCarts;
			if (session.Get<List<ShoppingCartItems>>(Consts.KoszykSessionKey) == null) 
			{
				shoppingCarts = new List<ShoppingCartItems>();
			}
			else
			{
				shoppingCarts = session.Get<List<ShoppingCartItems>>(Consts.KoszykSessionKey) as List<ShoppingCartItems>;
			}
			return shoppingCarts;
		}
		public void AddToShoppingCart(int id)
		{
			var shoppingCart = GetShoppingCart();
			var product = shoppingCart.Find(i => i.Product.ProductsId == id);
			if (product != null)  
			{
				product.Pieces++;
			}
			else
			{
				var toAdd = db.Product.Where(i => i.ProductsId == id).SingleOrDefault();

				var NewItem = new ShoppingCartItems
				{
					Product = toAdd,
					Pieces = 1,
					OrderValue = toAdd.Price
				};
				shoppingCart.Add(NewItem);
			}
			session.Set<List<ShoppingCartItems>>(Consts.KoszykSessionKey, shoppingCart);
		}
		public int RemoveFromShoppingCart(int id)
		{
			var shoppingCart = GetShoppingCart();
			var toRemove = shoppingCart.Find(i => i.Product.ProductsId == id);
			if (toRemove.Pieces > 1)
			{
				toRemove.Pieces--;
				return toRemove.Pieces;
			}
			else
			{
				shoppingCart.Remove(toRemove);
			}
			
			session.Set(Consts.KoszykSessionKey, shoppingCart);
			return 0;
		}
		public decimal GetShoppingCartValue()
		{
			var shoppingCart = GetShoppingCart();
			decimal value = shoppingCart.Sum(i => (i.Pieces * i.OrderValue));
			return value;
		}
		public int GetQuantityOfShoppingCartItems()
		{
			var shoppingCart = GetShoppingCart();
			var value = shoppingCart.Sum(i => i.Pieces);
			return value;
		}
		public Orders CreateNewOrder(Orders newOrder, string userId)
		{
			var shoppingCart = GetShoppingCart();
			newOrder.OrderDate = DateTime.Now;
			newOrder.UserId = userId;

			if (newOrder.OrderItem==null)
			{
				newOrder.OrderItem = new List<OrderItem>();
			}
			decimal value = 0;
			foreach (var item in shoppingCart)
			{			
				var newItem = new OrderItem
				{
					Products = item.Product,
					Pieces=item.Pieces,
					OrderValue=item.OrderValue
				};
				newOrder.OrderItem.Add(newItem);
				value += (item.OrderValue * item.Pieces);
			}
			newOrder.OrderValue = value;
			db.SaveChanges();
			return newOrder;
		}

		public void EmptyShoppingCart()
		{
			session.Set<List<ShoppingCartItems>>(Consts.KoszykSessionKey, null);
		}

	}
}