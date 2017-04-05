using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Collections.Generic;
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
			return View(new ProfileViewModel {
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
						Name       = model.Name.Trim(),
						Lastname   = model.Lastname.Trim(),
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
					var user = db.Users.Include(u => u.Logo).Single(u => u.Email == model.Email);

					if (BCrypt.Net.BCrypt.Verify(model.Password, user.Password)) {
						Session["User"] = user;
						return RedirectToAction("Index");
					}
				}

				ModelState.AddModelError("Email", "El correo electrónico o la contraseña son erróneos.");
				ModelState.AddModelError("Password", " ");
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
			user.Logo.Name = name.Trim();
			db.Entry(user.Logo).State = EntityState.Modified;
			db.SaveChanges();
			Session["User"] = db.Users.Include(u => u.Logo).Single(u => u.ID == user.ID);

			return Json(new SuccessMessageWithValue<string>("Su logo se ha actualizado con éxito.", name));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public JsonResult EditPersonalInfo([Bind(Include = "Name,Lastname,Birthday,Email,Newsletter")] BasePersonalInfo model)
		{
			if (ModelState.IsValid) {
				var user = Session["User"] as User;

				if (!db.Users.Any(u => u.Email == model.Email && u.ID != user.ID)) {
					user.Name = model.Name.Trim();
					user.Lastname = model.Lastname.Trim();
					user.Birthday = (DateTime)model.Birthday;
					user.Email = model.Email;
					user.Newsletter = Convert.ToBoolean(model.Newsletter);
					db.Entry(user).State = EntityState.Modified;
					db.SaveChanges();
					Session["User"] = db.Users.Include(u => u.Logo).Single(u => u.ID == user.ID);

					return Json(
						new SuccessMessageWithValue<string>("Sus datos se han actualizado con éxito.", user.GetFullName())
					);
				} else {
					ModelState.AddModelError("Email", "Ese correo electrónico ya fue utilizado. Por favor, elija otro.");
				}
			}

			return Json(new ErrorMessageWithValue<Dictionary<string, string>>("", GetModelErrors(ModelState)));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public JsonResult EditPassword([Bind(Include = "OldPassword,NewPassword")] EditPasswordViewModel model)
		{
			if (ModelState.IsValid) {
				var user = Session["User"] as User;

				if (BCrypt.Net.BCrypt.Verify(model.OldPassword, user.Password)) {
					user.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPassword, 14);
					db.Entry(user).State = EntityState.Modified;
					db.SaveChanges();
					Session["User"] = db.Users.Include(u => u.Logo).Single(u => u.ID == user.ID);
					return Json(new SuccessMessage("Su contraseña se ha actualizado con éxito."));
				} else {
					ModelState.AddModelError("OldPassword", "Su vieja contraseña no concuerda. Escríbala de nuevo.");
				}
			}

			return Json(new ErrorMessageWithValue<Dictionary<string, string>>("", GetModelErrors(ModelState)));
		}

		private Dictionary<string, string> GetModelErrors(ModelStateDictionary dict)
		{
			return dict.ToDictionary(
				pair => pair.Key,
				pair => pair.Value.Errors.FirstOrDefault()?.ErrorMessage
			);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
				db.Dispose();

			base.Dispose(disposing);
		}
	}
}