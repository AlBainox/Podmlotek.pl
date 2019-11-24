using Podmlotek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podmlotek.ViewModels
{
	public class HomeViewModel
	{
		public IEnumerable<Products> News { get; set; }
		public IEnumerable<Products> Bestsellers { get; set; }
	}
}