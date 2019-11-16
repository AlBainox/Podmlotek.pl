using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Podmlotek.Models
{
	public class Users
	{
		public int UserId { get; set; }
		[Required(ErrorMessage = "Wprowadź login")]
		public string Login { get; set; }
		[Required(ErrorMessage = "Wprowadź hasło")]
		public string Password { get; set; }
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
