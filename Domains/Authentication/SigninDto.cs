using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
	public class SigninDto: BaseDto
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
