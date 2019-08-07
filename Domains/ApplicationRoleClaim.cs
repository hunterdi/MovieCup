using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Domains
{
	public class ApplicationRoleClaim: IdentityRoleClaim<long>
	{
		public virtual ApplicationRole Role { get; set; }
	}
}
