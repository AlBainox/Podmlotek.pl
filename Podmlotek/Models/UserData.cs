using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Podmlotek.Models
{
	public class UserData
	{
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Adres { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
		[RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Błędny format numeru telefonu.")]
		public string Phone { get; set; }

		[EmailAddress(ErrorMessage = "Błędny format adresu e-mail.")]
		public string Email { get; set; }
	}
}