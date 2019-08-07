using System;
using System.Collections.Generic;
using System.Text;
using Domains;

namespace Domains
{
	public class ApplicationUserChangeEmailDto: BaseDto
	{
		public string CurrentEmail { get; set; }
		public string NewEmail { get; set; }
	}
}
