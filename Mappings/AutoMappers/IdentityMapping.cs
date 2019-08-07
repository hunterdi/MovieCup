using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domains;

namespace Mappings
{
	public class IdentityMapping: Profile
	{
		public IdentityMapping()
		{
			CreateMap<ApplicationUserDto, ApplicationUser>()
				.IncludeAllDerived().ReverseMap();
			CreateMap<PhoneDto, Phone>().ReverseMap();
			CreateMap<SignupDto, ApplicationUser>()
				.IncludeAllDerived().ReverseMap();
		}
	}
}
