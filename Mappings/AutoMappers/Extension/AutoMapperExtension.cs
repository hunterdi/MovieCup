using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Mappings
{
	public static class AutoMapperExtension
	{
		public static IServiceCollection AddMapperConfiguration(this IServiceCollection services)
		{
			var configMapper = new MapperConfiguration(configuration =>
			{
				configuration.AddProfile(new FilmeMapper());
				configuration.AddProfile(new CampeonatoMapper());
				configuration.AddProfile(new ClassificacaoMapper());
				configuration.AddProfile(new DisputaMapper());
				configuration.AddProfile(new FilmeCampeonatoMapper());
			});

			services.AddSingleton(configMapper.CreateMapper());
			
			return services;
		}

		public static List<TDestination> MapList<TSource, TDestination>(this IMapper mapper, List<TSource> source)
		{
			return source.Select(x => mapper.Map<TDestination>(x)).ToList();
		}
	}
}
