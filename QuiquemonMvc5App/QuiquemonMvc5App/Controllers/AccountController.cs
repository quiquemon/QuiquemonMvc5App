using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
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
			if (ModelState.IsValid) {
				if (!db.Users.Any(u => u.Email == model.Email)) {
					var user = new User {
						Name = model.Name,
						Lastname = model.Lastname,
						Birthday = (DateTime)model.Birthday,
						Email = model.Email,
						Password = model.Password,
						Newsletter = Convert.ToBoolean(model.Newsletter),
						Logo = new Logo { Name = "glyphicon glyphicon-user" }
					};

					db.Users.Add(user);
					db.SaveChanges();
					//Session["User"] = user;
					return RedirectToAction("Register");
				} else {
					ModelState.AddModelError("Email", "Ese correo electrónico ya fue utilizado. Por favor, elija otro.");
				}
			}

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginViewModel model)
		{
			if (!ModelState.IsValid) {
				return View(model);
			}

			// Generate a new Session.
			return View(new LoginViewModel());
		}
	}
}