using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Podmlotek.Models
{
	public class Users
	{
		public int UsersId { get; set; }
		[Required(ErrorMessage = "Wprowadź login")]		
		public Role role { get; set; }
		[Required(ErrorMessage = "Wprowadź hasło")]
		[StringLength(30, ErrorMessage = "{0} musi mieć co najmniej {2} znaków.", MinimumLength = 2)]
		[DataType(DataType.Password)]
		[Display(Name = "Hasło")]
		public string Password { get; set; }		
		[Compare("Password", ErrorMessage ="Powtórz hasło")]
		public string ConfirmPassword { get; set; }
		[Required(ErrorMessage = "Wprowadz imie")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Wprowadz nazwisko")]
		public string Surname { get; set; }
		public int Phone { get; set; }
		[EmailAddress(ErrorMessage = "Proszę wpisać adres e-mail")]
		public string Email { get; set; }
		public string Address { get; set; }
		public string PostalCode { get; set; }
	}
	public enum Role
	{
		User,
		Admin
	}
}
