﻿using System.Web;
using System.Web.Optimization;

namespace CollectorApp.WebUI
{
	public class BundleConfig
	{
		// Aby uzyskać więcej informacji o grupowaniu, odwiedź stronę https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));


			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate.js",
						"~/Scripts/jquery.validate.unobtrusive.js"));


			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					   "~/Scripts/bootstrap.js",
					   "~/Scripts/respond.js"));

			// Użyj wersji deweloperskiej biblioteki Modernizr do nauki i opracowywania rozwiązań. Następnie, kiedy wszystko będzie
			// gotowe do produkcji, użyj narzędzia do kompilowania ze strony https://modernizr.com, aby wybrać wyłącznie potrzebne testy.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));


			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap-Cosmo.css",
					  "~/Content/site.css"));
		}
	}
}
