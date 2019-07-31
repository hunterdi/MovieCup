using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domains;

namespace Mappings
{
	public class DisputaMapper: Profile
	{
		public DisputaMapper()
		{
			CreateMap<Disputa, DisputaDto>().ReverseMap();
		}
	}
}
