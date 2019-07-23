using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using FluentValidation;
using Infrastructure;

namespace Services
{
	public class ClassificacaoValidator: AbstractValidator<Classificacao>, IValidatorBase
	{
		public ClassificacaoValidator()
		{
			RuleFor(e => e.campeonato).NotNull().WithMessage("Deve-se informar o campeonato.");
		}
	}
}
