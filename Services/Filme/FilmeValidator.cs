using Domains;
using FluentValidation;
using Infrastructure;

namespace Services
{
	public class FilmeValidator: AbstractValidator<Filme>, IValidatorBase
	{
		public FilmeValidator()
		{
			RuleFor(v => v.nota).GreaterThan(-1).WithMessage("A nota deve ser maior que 0.");
			RuleFor(v => v.titulo).NotEmpty().WithMessage("O título deve ser preenchido.");
			RuleFor(v => v.ano).GreaterThan(1894).WithMessage("O ano do filme deve ser maior que 1894. \nNOTA: O primeiro filme feito na historia do mundo, é um filme chamado L'Arrivée d'un Train à La Ciotat. o filme foi feito pelos irmaos Lumiere em uma estaçao de trem de Paris e foi apresentado no salão Grand Café no dia 28 de Dezembro de 1895.");
			RuleFor(v => v.ano).NotNull().WithMessage("Deve-se preencher o ano do filme.");
		}
	}
}
