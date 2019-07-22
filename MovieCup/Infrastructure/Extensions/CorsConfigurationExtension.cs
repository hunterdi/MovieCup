using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class CorsConfigurationExtension
	{
		public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddCors(options =>
			{
				options.AddPolicy(SystemConstants.Cors.FrontMovieCup.ToDescription(), builderPolicy =>
				{
					builderPolicy.WithOrigins(configuration.GetSection(SystemConstants.AppSettings.AllowedHosts.ToDescription()).Value)
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials();
				});
			});

			return services;
		}
	}
}
