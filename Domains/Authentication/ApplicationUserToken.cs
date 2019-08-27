using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Domains
{
	public class ApplicationUserToken: IdentityUserToken<long>
	{
		public virtual ApplicationUser User { get; set; }
	}
}
