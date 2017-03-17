using System.Web.Optimization;

namespace QuiquemonMvc5App
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
				"~/Scripts/jquery-3.1.1.min.js",
				"~/Scripts/jquery.validate.min.js"
			));
			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
				"~/Scripts/moment-with-locales.min.js",
				"~/Scripts/bootstrap.min.js",
				"~/Scripts/bootstrap-dialog.js",
				"~/Scripts/bootstrap-datetimepicker.min.js"
			));
			bundles.Add(new StyleBundle("~/Content/css").Include(
				"~/Content/bootstrap.min.css",
				"~/Content/bootstrap-theme.min.css",
				"~/Content/bootstrap-dialog.css",
				"~/Content/bootstrap-datetimepicker.min.css"
			));
		}
	}
}