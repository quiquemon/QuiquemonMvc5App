//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
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
			ViewBag.Title = "Regístrate";
			ViewBag.Message = "Ingresa tus datos para registrarte en el sistema.";
			return View(new RegisterViewModel());
		}

		[HttpPost]
		public ActionResult Register(RegisterViewModel model)
		{
			return View();
		}

		[HttpGet]
		public ActionResult Login()
		{
			ViewBag.Title = "Inicia Sesión";
			ViewBag.Message = "Ingresa tus credenciales para acceder al sistema.";
			return View(new LoginViewModel());
		}

		[HttpPost]
		public ActionResult Login(LoginViewModel model)
		{
			return View();
		}
    }
}