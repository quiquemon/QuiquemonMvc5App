using System;
//using System.Collections.Generic;
//using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace QuiquemonMvc5App.Models.ViewModels.Account
{
	public class RegisterViewModel
	{
		[Required]
		public string name { get; set; }

		[Required]
		public string lastname { get; set; }

		[Required]
		public DateTime birthday { get; set; }

		[Required]
		public string email { get; set; }

		[Required]
		public string password { get; set; }

		[Required]
		public bool newsletter { get; set; }
	}

	public class LoginViewModel
	{
		[Required]
		public string email { get; set; }

		[Required]
		public string password { get; set; }
	}
}