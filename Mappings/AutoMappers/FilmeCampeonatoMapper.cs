using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domains;

namespace Mappings
{
	public class FilmeCampeonatoMapper: Profile
	{
		public FilmeCampeonatoMapper()
		{
			CreateMap<FilmeCampeonato, FilmeCampeonatoDto>().ReverseMap();
		}
	}
}
