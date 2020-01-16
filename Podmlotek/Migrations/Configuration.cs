namespace Podmlotek.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Podmlotek.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
			
		}

        protected override void Seed(Podmlotek.Context context)
        {
			Initializer.SeedProductData(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
