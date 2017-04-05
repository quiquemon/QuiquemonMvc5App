using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QuiquemonMvc5App.Models.Validations;

namespace QuiquemonMvc5App.Models.ViewModels.Account
{
	public class BasePersonalInfo
	{
		[Required(ErrorMessage = "El nombre es obligatorio.")]
		[MaxLength(100, ErrorMessage = "El nombre tiene un máximo de 100 caracteres.")]
		[Display(Name = "Nombre:")]
		public string Name { get; set; }

		[MaxLength(100, ErrorMessage = "Los apellidos tienen un máximo de 100 caracteres.")]
		[Display(Name = "Apellidos:")]
		public string Lastname { get; set; }

		[Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[MinimumAge(18, ErrorMessage = "Debes ser mayor de 18 años para registrarte.")]
		[Display(Name = "Fecha de nacimiento:")]
		public DateTime? Birthday { get; set; }

		[Required(ErrorMessage = "El correo electrónico es obligatorio.")]
		[MaxLength(70, ErrorMessage = "El correo electrónico tiene un máximo de 70 caracteres.")]
		[EmailAddress(ErrorMessage = "Ingrese una dirección de correo válida.")]
		[Display(Name = "Correo electrónico:")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Debe elegir una de las dos opciones.")]
		[BooleanString(ErrorMessage = "El boletín solo puede contener los valores 'True' o 'False'.")]
		[Display(Name = "¿Inscribirse al boletín?")]
		public string Newsletter { get; set; }
	}

	public class RegisterViewModel : BasePersonalInfo
	{
		[Required(ErrorMessage = "La contraseña es obligatoria.")]
		[StringLength(72, MinimumLength = 10, ErrorMessage = "La contraseña debe tener entre 10 y 72 caracteres.")]
		[Display(Name = "Contraseña:")]
		public string Password { get; set; }
	}

	public class LoginViewModel
	{
		[Required(ErrorMessage = "El correo electrónico es obligatorio.")]
		[MaxLength(70, ErrorMessage = "El correo electrónico tiene un máximo de 70 caracteres.")]
		[EmailAddress(ErrorMessage = "Ingrese una dirección de correo válida.")]
		[Display(Name = "Correo electrónico:")]
		public string Email { get; set; }

		[Required(ErrorMessage = "La contraseña es obligatoria.")]
		[StringLength(72, MinimumLength = 10, ErrorMessage = "La contraseña debe tener entre 10 y 72 caracteres.")]
		[Display(Name = "Contraseña:")]
		public string Password { get; set; }
	}

	public class ProfileViewModel : BasePersonalInfo
	{
		[Display(Name = "Seleccione un logo:")]
		public string Logo { get; set; }

		public IEnumerable<SelectListItem> Logos {
			get {
				return new List<SelectListItem> {
					new SelectListItem { Text = "Nube",               Value = "glyphicon glyphicon-cloud" },
					new SelectListItem { Text = "Usuario",            Value = "glyphicon glyphicon-user" },
					new SelectListItem { Text = "Música",             Value = "glyphicon glyphicon-music" },
					new SelectListItem { Text = "Copa",               Value = "glyphicon glyphicon-glass" },
					new SelectListItem { Text = "Filme",              Value = "glyphicon glyphicon-film" },
					new SelectListItem { Text = "Corazón",            Value = "glyphicon glyphicon-heart" },
					new SelectListItem { Text = "Sobre",              Value = "glyphicon glyphicon-envelope" },
					new SelectListItem { Text = "Botón de Encendido", Value = "glyphicon glyphicon-off" },
					new SelectListItem { Text = "Señal",              Value = "glyphicon glyphicon-signal" },
					new SelectListItem { Text = "Bote de Basura",     Value = "glyphicon glyphicon-trash" },
					new SelectListItem { Text = "Reloj",              Value = "glyphicon glyphicon-time" },
					new SelectListItem { Text = "Inbox",              Value = "glyphicon glyphicon-inbox" },
					new SelectListItem { Text = "Candado",            Value = "glyphicon glyphicon-lock" },
					new SelectListItem { Text = "Bandera",            Value = "glyphicon glyphicon-flag" },
					new SelectListItem { Text = "Audífonos",          Value = "glyphicon glyphicon-headphones" },
					new SelectListItem { Text = "Volumen",            Value = "glyphicon glyphicon-volume-up" },
					new SelectListItem { Text = "Código QR",          Value = "glyphicon glyphicon-qrcode" },
					new SelectListItem { Text = "Código de Barras",   Value = "glyphicon glyphicon-barcode" },
					new SelectListItem { Text = "Libro",              Value = "glyphicon glyphicon-book" },
					new SelectListItem { Text = "Impresora",          Value = "glyphicon glyphicon-print" },
					new SelectListItem { Text = "Cámara",             Value = "glyphicon glyphicon-camera" },
					new SelectListItem { Text = "Retrato",            Value = "glyphicon glyphicon-picture" },
					new SelectListItem { Text = "Tinta",              Value = "glyphicon glyphicon-tint" },
					new SelectListItem { Text = "Mira",               Value = "glyphicon glyphicon-screenshot" },
					new SelectListItem { Text = "Regalo",             Value = "glyphicon glyphicon-gift" },
					new SelectListItem { Text = "Hoja",               Value = "glyphicon glyphicon-leaf" },
					new SelectListItem { Text = "Flama",              Value = "glyphicon glyphicon-fire" },
					new SelectListItem { Text = "Ojo",                Value = "glyphicon glyphicon-eye-open" },
					new SelectListItem { Text = "Avión",              Value = "glyphicon glyphicon-plane" },
					new SelectListItem { Text = "Pizarrón",           Value = "glyphicon glyphicon-blackboard" }
				}.Select(item => new SelectListItem {
					Text = item.Text,
					Value = item.Value,
					Selected = (item.Value == Logo)
				});
			}
		}
	}

	public class EditPasswordViewModel
	{
		[Required(ErrorMessage = "Su vieja contraseña es obligatoria.")]
		[StringLength(72, MinimumLength = 10, ErrorMessage = "La vieja contraseña debe tener entre 10 y 72 caracteres.")]
		[Display(Name = "Escriba su vieja contraseña:")]
		public string OldPassword { get; set; }

		[Required(ErrorMessage = "Su nueva contraseña es obligatoria.")]
		[StringLength(72, MinimumLength = 10, ErrorMessage = "La nueva contraseña debe tener entre 10 y 72 caracteres.")]
		[Display(Name = "Escriba su nueva contraseña:")]
		public string NewPassword { get; set; }
	}
}