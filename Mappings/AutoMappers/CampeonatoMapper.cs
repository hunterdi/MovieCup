using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domains;

namespace Mappings
{
	public class CampeonatoMapper: Profile
	{
		public CampeonatoMapper()
		{
			CreateMap<Campeonato, CampeonatoDto>().ReverseMap();
		}
	}
}
