using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Podmlotek.Infrastructure
{
	public class AppConfig
	{
		private static string _relativeFolderOfPictures = ConfigurationManager.AppSettings["PicturesFolder"];
		public static string RelativeFolderOfPictures
		{
			get
			{
				return _relativeFolderOfPictures;
			}
		}
	}
}