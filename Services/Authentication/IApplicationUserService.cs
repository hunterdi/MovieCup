using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domains;
using Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace Services
{
	public interface IApplicationUserService: IServiceBase<ApplicationUser>
	{
		Task<IdentityResult> CreateUserAsync(ApplicationUser user);

		Task<SignInResult> SignInAsync(string email, string password);

		Task<ApplicationUser> ChangePasswordAsync(string email, string currentpassword, string newPassword);

		Task<ApplicationUser> ChangeEmailAsync(string currentEmail, string newEmail);
	}
}
