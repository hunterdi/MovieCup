using System.Collections.Generic;
using AutoMapper;
using Domains;

namespace Mappings
{
	public class FilmeMapper: Profile
	{
		public FilmeMapper()
		{
			CreateMap<Filme, FilmeDto>().ReverseMap();
			CreateMap<FilmeResponseSeed, Filme>()
				.ForMember(dest => dest.codigo, src => src.MapFrom(e => e.id))
				.ForMember(dest => dest.Id, src => src.Ignore()).ReverseMap();
		}
	}
}
