using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class OptionsConfigurationExtension
	{
		public static IServiceCollection AddOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.InvalidModelStateResponseFactory = context => new ValidationProblemDetailsResult();
			});

			services.Configure<Tenant>(options => configuration.GetSection("Tenant").Bind(options));
			
			return services;
		}
	}
}
