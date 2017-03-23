using System;
using System.ComponentModel.DataAnnotations;

namespace QuiquemonMvc5App.Models.Validations
{
	public class MinimumAgeAttribute : ValidationAttribute
	{
		private int age;

		public MinimumAgeAttribute(int age)
		{
			this.age = age;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			DateTime? birthday = value as DateTime?;
			return (birthday?.AddYears(age) < DateTime.Now)
				? ValidationResult.Success
				: new ValidationResult(ErrorMessage);
		}
	}

	public class BooleanStringAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			string choice = (string)value;
			return (choice?.ToLower() == "true" || choice?.ToLower() == "false")
				? ValidationResult.Success
				: new ValidationResult(ErrorMessage);
		}
	}
}