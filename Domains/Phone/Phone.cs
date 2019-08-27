using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
	public class Phone: BaseDomain
	{
		public int Number { get; set; }
		public int Area_code { get; set; }
		public string Country_code { get; set; }
		public virtual long UsersId { get; set; }
		public virtual ApplicationUser Users { get; set; }
	}
}
