using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using FluentValidation;
using Infrastructure;

namespace Services
{
	public class ApplicationUserValidator: AbstractValidator<ApplicationUser>, IValidatorBase
	{
		public ApplicationUserValidator(IValidator<Phone> validator)
		{
			RuleFor(v => v.Email).NotEmpty().WithMessage("Missing fields").WithErrorCode("422").EmailAddress().WithMessage("Invalid fields").WithErrorCode("422");
			RuleFor(v => v.FirstName).NotEmpty().WithMessage("Missing fields").WithErrorCode("422");
			RuleFor(v => v.LastName).NotEmpty().WithMessage("Missing fields").WithErrorCode("422");
			RuleFor(v => v.Phones).NotNull().WithMessage("Missing fields").WithErrorCode("422");
			RuleForEach(v => v.Phones).SetValidator(validator);
		}
	}
}
