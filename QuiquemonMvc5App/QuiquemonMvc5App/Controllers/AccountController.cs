using System;
using System.Linq;
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
			ViewBag.User = Session["User"] as User;
			return View();
		}

		[HttpGet]
		public ActionResult Logout()
		{
			Session.Clear();
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		[AllowAnonymous]
		public ActionResult Register()
		{
			return View(new RegisterViewModel());
		}

		[HttpGet]
		[AllowAnonymous]
		public ActionResult Login()
		{
			return View(new LoginViewModel());
		}

		[HttpPost]
		[AllowAnonymous]
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
						Password = BCrypt.Net.BCrypt.HashPassword(model.Password, 14),
						Newsletter = Convert.ToBoolean(model.Newsletter),
						Logo = new Logo { Name = "glyphicon glyphicon-user" }
					};

					db.Users.Add(user);
					db.SaveChanges();
					Session["User"] = user;
					return RedirectToAction("Index");
				} else {
					ModelState.AddModelError("Email", "Ese correo electrónico ya fue utilizado. Por favor, elija otro.");
				}
			}

			return View(model);
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginViewModel model)
		{
			if (ModelState.IsValid) {
				if (db.Users.Any(u => u.Email == model.Email)) {
					var user = db.Users.Where(u => u.Email == model.Email).Single();

					if (BCrypt.Net.BCrypt.Verify(model.Password, user.Password)) {
						Session["User"] = user;
						return RedirectToAction("Index");
					}
				}

				ModelState.AddModelError("Password", "El correo electrónico o la contraseña son erróneos.");
			}

			return View(model);
		}
	}
}