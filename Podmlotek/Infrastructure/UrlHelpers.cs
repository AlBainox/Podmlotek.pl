using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Podmlotek.Infrastructure
{
	public static class UrlHelpers
	{
		public static string PicturesPath(this UrlHelper helper, string nameOfPictures)
		{
			var picturesFolder = AppConfig.RelativeFolderOfPictures;
			var path = Path.Combine(picturesFolder, nameOfPictures);
			var absolutePath = helper.Content(path);
			return absolutePath;
		}
	}
}