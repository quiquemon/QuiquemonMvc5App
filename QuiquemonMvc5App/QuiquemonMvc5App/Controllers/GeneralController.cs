using System.Web.Mvc;

namespace QuiquemonMvc5App.Controllers
{
	[AllowAnonymous]
	public class GeneralController : Controller
	{
		[HttpGet]
		public ActionResult Forbidden()
		{
			return View();
		}
	}
}