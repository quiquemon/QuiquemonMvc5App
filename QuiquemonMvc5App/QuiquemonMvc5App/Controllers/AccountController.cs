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

		[HttpGet]
		public new ActionResult Profile()
		{
			var user = Session["User"] as User;
			ViewBag.User = user;
			return View(new UpdateInfoViewModel {
				Name       = user.Name,
				Lastname   = user.Lastname,
				Birthday   = user.Birthday,
				Email      = user.Email,
				Newsletter = user.Newsletter.ToString(),
				Logo       = user.Logo.Name
			});
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Register(RegisterViewModel model)
		{
			if (ModelState.IsValid) {
				if (!db.Users.Any(u => u.Email == model.Email)) {
					var user = new User {
						Name       = model.Name,
						Lastname   = model.Lastname,
						Birthday   = (DateTime)model.Birthday,
						Email      = model.Email,
						Password   = BCrypt.Net.BCrypt.HashPassword(model.Password, 14),
						Newsletter = Convert.ToBoolean(model.Newsletter),
						Logo       = new Logo { Name = "glyphicon glyphicon-user" }
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

		[HttpPost]
		[ValidateAntiForgeryToken]
		public JsonResult EditLogo(string name) {
			if (string.IsNullOrWhiteSpace(name)) {
				return Json(new ErrorMessage("Elija un logo válido."));
			} else if (name.Length > 50) {
				return Json(new ErrorMessage("El nombre del logo no puede tener más de 50 caracteres."));
			}

			var user = Session["User"] as User;
			var logo = db.Logos.Find(user.Logo.ID);
			logo.Name = name;
			db.Entry(logo).State = EntityState.Modified;
			db.SaveChanges();
			Session["User"] = db.Users.Find(user.ID);

			return Json(new SuccessMessageWithValue<string>("Su logo se ha actualizado con éxito.", logo.Name));
		}
	}
}