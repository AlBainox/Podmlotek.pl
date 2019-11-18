using Podmlotek.Migrations;
using Podmlotek.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Podmlotek
{
	public class Initializer : MigrateDatabaseToLatestVersion<Context, Configuration>
	{
		
		public static void SeedProductData(Context context)
		{
			var categories = new List<Categories>
			{
				new Categories() { CategoriesId=1, Name = "Dom i ogrod" },
				new Categories() { CategoriesId=2, Name = "Elektronika"},
				new Categories() { CategoriesId=3, Name = "Ksiazki" },
				new Categories() { CategoriesId=4, Name = "Moda"},
				new Categories() { CategoriesId=5, Name = "Motoryzacja" },
				new Categories() { CategoriesId=6, Name = "Nieruchomosci" },
				new Categories() { CategoriesId=7, Name = "Sport" },
				new Categories() { CategoriesId=8, Name = "Supermarket" }
			};

			categories.ForEach(c => context.Category.AddOrUpdate(c));
			context.SaveChanges();

			var subcategories = new List<Subcategories>
			{
				new Subcategories() { SubcategoriesId=1, CategoriesId=1, Name= "Meble"},
				new Subcategories() { SubcategoriesId=2, CategoriesId=1, Name= "Wyposażenie"},
				new Subcategories() { SubcategoriesId=3, CategoriesId=1, Name= "Oświetlenie"},
				new Subcategories() { SubcategoriesId=4, CategoriesId=1, Name= "Narzędzia"},
				new Subcategories() { SubcategoriesId=5, CategoriesId=1, Name= "Budownictwo i akcesoria"},
				new Subcategories() { SubcategoriesId=6, CategoriesId=1, Name= "Ogród"},
				new Subcategories() { SubcategoriesId=7, CategoriesId=1, Name= "Łazienka i kuchnia"},
				new Subcategories() { SubcategoriesId=8, CategoriesId=1, Name= "Firma"},
				new Subcategories() { SubcategoriesId=9, CategoriesId=2, Name= "Telefony"},
				new Subcategories() { SubcategoriesId=10, CategoriesId=2, Name= "Komputery"},
				new Subcategories() { SubcategoriesId=11, CategoriesId=2, Name= "Tablety"},
				new Subcategories() { SubcategoriesId=12, CategoriesId=2, Name= "Telewizory"},
				new Subcategories() { SubcategoriesId=13, CategoriesId=2, Name= "Fotografia"},
				new Subcategories() { SubcategoriesId=14, CategoriesId=2, Name= "Gry i konsole"},
				new Subcategories() { SubcategoriesId=15, CategoriesId=2, Name= "Sprzęt audio"},
				new Subcategories() { SubcategoriesId=16, CategoriesId=2, Name= "Sprzęt car-audio"},
				new Subcategories() { SubcategoriesId=17, CategoriesId=3, Name= "Biografie"},
				new Subcategories() { SubcategoriesId=18, CategoriesId=3, Name= "Fantasy"},
				new Subcategories() { SubcategoriesId=19, CategoriesId=3, Name= "Sensacja"},
				new Subcategories() { SubcategoriesId=20, CategoriesId=3, Name= "Dla dzieci"},
				new Subcategories() { SubcategoriesId=21, CategoriesId=3, Name= "Obcojęzyczne"},
				new Subcategories() { SubcategoriesId=22, CategoriesId=3, Name= "Popularnonaukowe"},
				new Subcategories() { SubcategoriesId=23, CategoriesId=3, Name= "Podręczniki"},
				new Subcategories() { SubcategoriesId=24, CategoriesId=3, Name= "Książki kucharskie"},
				new Subcategories() { SubcategoriesId=25, CategoriesId=4, Name= "Obuwie męskie"},
				new Subcategories() { SubcategoriesId=26, CategoriesId=4, Name= "Obuwie damskie"},
				new Subcategories() { SubcategoriesId=27, CategoriesId=4, Name= "Kurtki męskie"},
				new Subcategories() { SubcategoriesId=28, CategoriesId=4, Name= "Kurtki damskie"},
				new Subcategories() { SubcategoriesId=29, CategoriesId=4, Name= "Bluzy męskie"},
				new Subcategories() { SubcategoriesId=30, CategoriesId=4, Name= "Bluzki damskie"},
				new Subcategories() { SubcategoriesId=31, CategoriesId=4, Name= "Spodnie męskie"},
				new Subcategories() { SubcategoriesId=32, CategoriesId=4, Name= "Spodnie damskie"},
				new Subcategories() { SubcategoriesId=33, CategoriesId=5, Name= "Części"},
				new Subcategories() { SubcategoriesId=34, CategoriesId=5, Name= "Akcesoria"},
				new Subcategories() { SubcategoriesId=35, CategoriesId=5, Name= "Warsztat"},
				new Subcategories() { SubcategoriesId=36, CategoriesId=5, Name= "Chemia"},
				new Subcategories() { SubcategoriesId=37, CategoriesId=5, Name= "Opony i felgi"},
				new Subcategories() { SubcategoriesId=38, CategoriesId=5, Name= "Do motocykli"},
				new Subcategories() { SubcategoriesId=39, CategoriesId=5, Name= "Gadżety motoryzacyjne"},
				new Subcategories() { SubcategoriesId=40, CategoriesId=5, Name= "Części do maszyn"},
				new Subcategories() { SubcategoriesId=41, CategoriesId=6, Name= "Mieszkania"},
				new Subcategories() { SubcategoriesId=42, CategoriesId=6, Name= "Biura i lokale"},
				new Subcategories() { SubcategoriesId=43, CategoriesId=6, Name= "Domy"},
				new Subcategories() { SubcategoriesId=44, CategoriesId=6, Name= "Garaże i parkingi"},
				new Subcategories() { SubcategoriesId=45, CategoriesId=6, Name= "Hale"},
				new Subcategories() { SubcategoriesId=46, CategoriesId=6, Name= "Działki"},
				new Subcategories() { SubcategoriesId=47, CategoriesId=6, Name= "Pozostałe nieruchomości"},
				new Subcategories() { SubcategoriesId=48, CategoriesId=7, Name= "Rowery i akcesoria"},
				new Subcategories() { SubcategoriesId=49, CategoriesId=7, Name= "Turystyka"},
				new Subcategories() { SubcategoriesId=50, CategoriesId=7, Name= "Siłownia i fitness"},
				new Subcategories() { SubcategoriesId=51, CategoriesId=7, Name= "Sporty wodne"},
				new Subcategories() { SubcategoriesId=52, CategoriesId=7, Name= "Bieganie"},
				new Subcategories() { SubcategoriesId=53, CategoriesId=7, Name= "Wędkarstwo"},
				new Subcategories() { SubcategoriesId=54, CategoriesId=7, Name= "Militaria"},
				new Subcategories() { SubcategoriesId=55, CategoriesId=7, Name= "Pozostałe"},
				new Subcategories() { SubcategoriesId=56, CategoriesId=8, Name= "Produkty spożywcze"},
				new Subcategories() { SubcategoriesId=57, CategoriesId=8, Name= "Artykuły dla zwierząt"},
				new Subcategories() { SubcategoriesId=58, CategoriesId=8, Name= "Utrzymanie czystości"},			
				
			};
			subcategories.ForEach(s => context.Subcategory.AddOrUpdate(s));
			context.SaveChanges();
		}
	}
}