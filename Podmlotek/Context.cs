namespace Podmlotek
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Podmlotek.Models;
    using System;
	using System.Data.Entity;
	using System.Linq;

	public class Context : IdentityDbContext<ApplicationUser>
	{
		
		public Context()
			: base("name=Context")
		{
			
		}
		public static Context Create()
		{
			return new Context();
		}

		static Context()
		{
			Database.SetInitializer<Context>(new Initializer());
		}

		public virtual DbSet<Categories> Category { get; set; }
		public virtual DbSet<Subcategories> Subcategory { get; set; }
		public virtual DbSet<Products> Product { get; set; }
		public virtual DbSet<OrderItem> OrderItem { get; set; }
		public virtual DbSet<Orders> Order { get; set; }

	}

}