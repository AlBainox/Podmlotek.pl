using Podmlotek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podmlotek.Infrastructure
{
	public static class UserManager
	{
		private static Users user { get; set; }
		

		public static Users Get()
		{
			return user;
		}

		public static void Set(Users newUser)
		{
			user = newUser;
		}
		public static Users LogOut()
		{
			if (user!=null)
			{
				user = null;
			}			
			return user;
		}
			

	}
}