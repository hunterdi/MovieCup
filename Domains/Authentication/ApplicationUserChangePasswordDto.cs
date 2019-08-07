using System;
using System.Collections.Generic;
using System.Text;
using Domains;

namespace Domains
{
	public class ApplicationUserChangePasswordDto: BaseDto
	{
		public string Email { get; set; }
		public string CurrentPassword { get; set; }
		public string NewPassword { get; set; }
	}
}
