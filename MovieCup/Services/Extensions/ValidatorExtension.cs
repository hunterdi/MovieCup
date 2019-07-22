using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Services
{
	public static class ValidatorExtension
	{
		public static IServiceCollection AddValidators(this IServiceCollection services)
		{
			services.AddTransient<IValidator<Filme>, FilmeValidator>();
			services.AddTransient<IValidator<Campeonato>, CampeonatoValidator>();
			services.AddTransient<IValidator<CampeonatoDto>, CampeonatoDtoValidator>();
			services.AddTransient<IValidator<Classificacao>, ClassificacaoValidator>();
			services.AddTransient<IValidator<Disputa>, DisputaValidator>();

			return services;
		}
	}
}
