namespace Podmlotek
{
    using Podmlotek.Models;
    using System;
	using System.Data.Entity;
	using System.Linq;

	public class Context : DbContext
	{
		
		public Context()
			: base("name=Context")
		{
			
		}
	
		static Context()
		{
			Database.SetInitializer<Context>(new Initializer());
		}

		public virtual DbSet<Users> User { get; set; }
		public virtual DbSet<Categories> Category { get; set; }
		public virtual DbSet<Subcategories> Subcategory { get; set; }
		public virtual DbSet<Products> Product { get; set; }
		public virtual DbSet<OrderItem> OrderItem { get; set; }
		public virtual DbSet<Orders> Order { get; set; }

	}

}