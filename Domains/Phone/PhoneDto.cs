using System;
using System.Collections.Generic;
using System.Text;
using Domains;

namespace Domains
{
	public class PhoneDto: BaseDto
	{
		public int Number { get; set; }
		public int Area_code { get; set; }
		public string Country_code { get; set; }
		public virtual ApplicationUserDto User { get; set; }
	}
}
