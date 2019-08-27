using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Domains
{
	public class ApplicationRole: IdentityRole<long>
	{
		public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
		public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
	}
}
