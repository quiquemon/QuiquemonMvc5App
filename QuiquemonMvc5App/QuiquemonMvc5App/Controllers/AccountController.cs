using System.Web.Mvc;
using QuiquemonMvc5App.Models;
using QuiquemonMvc5App.Models.ViewModels.Account;
using QuiquemonMvc5App.Models.DAL;

namespace QuiquemonMvc5App.Controllers
{
	public class AccountController : Controller
	{
		private MyDbContext db = new MyDbContext();

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
			if (!ModelState.IsValid)
				return View(model);


			return View(new RegisterViewModel());
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