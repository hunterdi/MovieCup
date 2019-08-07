using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using FluentValidation;
using Infrastructure;

namespace Services
{
	public class SigninDtoValidator: AbstractValidator<SigninDto>, IValidatorBase
	{
		public SigninDtoValidator()
		{
			RuleFor(v => v.Email).NotEmpty().WithMessage("Missing fields").WithErrorCode("422").EmailAddress().WithMessage("Invalid fields").WithErrorCode("422");
			RuleFor(v => v.Password).NotEmpty().WithMessage("Missing fields").WithErrorCode("422");
		}
	}
}
