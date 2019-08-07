using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
	public class SignupDto: BaseDto
	{
		public string UserName { get { return this.Email; } }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public ICollection<PhoneDto> Phones { get; set; }
	}
}
