using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using FluentValidation;
using Infrastructure;

namespace Services
{
	public class CampeonatoValidator: AbstractValidator<Campeonato>, IValidatorBase
	{
		public CampeonatoValidator()
		{
			RuleFor(e => e.nome).NotEmpty().WithMessage("Deve-se preencher o nome do campeonato.");
			RuleFor(e => e.campeonatoFilmes).Must(e => e.Count == 8).WithMessage("Deve-se selecionar 8 filmes.");
		}
	}
}
