using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
	public class ApplicationUserPhones: BaseDomain
	{
		public virtual long UserId { get; set; }
		public virtual ApplicationUser User { get; set; }
		public virtual long PhonesId { get; set; }
		public virtual Phone Phones { get; set; }
	}
}
