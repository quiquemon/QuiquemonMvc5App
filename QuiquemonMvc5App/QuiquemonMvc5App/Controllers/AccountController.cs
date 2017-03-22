using System.Web.Mvc;
using QuiquemonMvc5App.Models.ViewModels.Account;

namespace QuiquemonMvc5App.Controllers
{
	public class AccountController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Register()
		{
			return View(new RegisterViewModel());
		}

		[HttpGet]
		public ActionResult Login()
		{
			return View(new LoginViewModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Register(RegisterViewModel model)
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			return View(new LoginViewModel());
		}
	}
}