using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Podmlotek.ViewModels
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Proszę podać adres e-mail")]
		[EmailAddress]
		public string Email { get; set; }

		[Required(ErrorMessage = "Prosze wprowadzić hasło")]
		[DataType(DataType.Password)]
		[Display(Name = "Hasło")]
		public string Password { get; set; }
	}
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Proszę podać adres e-mail")]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[StringLength(30, ErrorMessage = "{0} musi mieć co najmniej {2} znaków.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Hasło")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Potwierdź hasło")]
		[Compare("Password", ErrorMessage = "Podane hasła nie pasują do siebie")]
		public string ConfirmPassword { get; set; }
	}
}