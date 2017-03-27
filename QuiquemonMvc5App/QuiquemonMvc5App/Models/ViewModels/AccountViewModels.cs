using System;
using System.ComponentModel.DataAnnotations;
using QuiquemonMvc5App.Models.Validations;

namespace QuiquemonMvc5App.Models.ViewModels.Account
{
	public class RegisterViewModel
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

		[Required(ErrorMessage = "La contraseña es obligatoria.")]
		[StringLength(72, MinimumLength = 10, ErrorMessage = "La contraseña debe tener entre 10 y 72 caracteres.")]
		[Display(Name = "Contraseña:")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Debe elegir una de las dos opciones.")]
		[BooleanString(ErrorMessage = "El boletín solo puede contener los valores 'True' o 'False'.")]
		[Display(Name = "¿Inscribirse al boletín?")]
		public string Newsletter { get; set; }
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
}