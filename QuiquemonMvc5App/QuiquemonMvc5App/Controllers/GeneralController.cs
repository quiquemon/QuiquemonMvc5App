using System.Web.Mvc;

namespace QuiquemonMvc5App.Controllers
{
	public class GeneralController : Controller
	{
		[HttpGet]
		public ActionResult Forbidden()
		{
			return View();
		}
	}
}