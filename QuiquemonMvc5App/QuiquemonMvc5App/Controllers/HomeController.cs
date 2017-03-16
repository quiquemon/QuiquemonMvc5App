using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuiquemonMvc5App.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ActionResult Index()
		{
			return View();
		}

		// GET: AboutUs
		public ActionResult AboutUs()
		{
			ViewBag.Title = "Acerca de nosotros";
			ViewBag.Message = "Este es un mensaje creado por <code>HomeController::AboutUs()</code>.";
			ViewBag.Tests = Test.GetTests();
			return View();
		}

		// GET: Contact
		public ActionResult Contact()
		{
			ViewBag.Title = "Contáctanos";
			ViewBag.Message = "Este es un mensaje creado por <code>HomeController::Contact()</code>.";
			return View();
		}
	}

	public sealed class Test
	{
		public string Name { get; }
		public string Url { get; }

		private Test(string name, string url)
		{
			Name = name;
			Url = url;
		}

		public static List<Test> GetTests()
		{
			return new List<Test> {
				new Test("First Test - 1", "https://stackoverflow.com"),
				new Test("Second Test - 2", null),
				new Test("Third Test - 3", "https://stackoverflow.com"),
				new Test("Fourth Test - 4", null),
				new Test("Fifth Test - 5", "https://stackoverflow.com"),
				new Test("Sixth Test - 6", null),
				new Test("Seventh Test - 7", "https://stackoverflow.com"),
				new Test("Eighth Test - 8", null),
				new Test("Ninth Test - 9", "https://stackoverflow.com"),
				new Test("Tenth Test - 10", null),
			};
		}
	}
}