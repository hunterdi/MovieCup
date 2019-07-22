using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using FluentValidation;
using Infrastructure;

namespace Services
{
	public class DisputaValidator: AbstractValidator<Disputa>, IValidatorBase
	{
		public DisputaValidator()
		{
			RuleFor(e => e.vencedor).NotNull().WithMessage("Deve-se informar o vencedor.");
		}
	}
}
