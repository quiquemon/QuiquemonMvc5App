using System;
using System.ComponentModel.DataAnnotations;

namespace QuiquemonMvc5App.Models.ViewModels.Account
{
	public class RegisterViewModel
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Lastname { get; set; }

		[Required]
		public DateTime Birthday { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		public bool Newsletter { get; set; }
	}

	public class LoginViewModel
	{
		[Required(ErrorMessage = "El correo electrónico es obligatorio.")]
		[MaxLength(70, ErrorMessage = "El correo electrónico tiene un máximo de 72 caracteres.")]
		[EmailAddress(ErrorMessage = "Ingrese una dirección de correo válida.")]
		[Display(Name = "Correo electrónico:")]
		public string Email { get; set; }

		[Required(ErrorMessage = "La contraseña es obligatoria.")]
		[StringLength(72, MinimumLength = 10, ErrorMessage = "La contraseña debe tener entre 10 y 72 caracteres.")]
		[Display(Name = "Contraseña:")]
		public string Password { get; set; }
	}
}