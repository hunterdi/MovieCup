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
				options.AddPolicy("Itau.Gateway", builderPolicy =>
				{
					builderPolicy.WithOrigins(configuration.GetSection("ConnectionString").Value)
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials();
				});
			});

			return services;
		}
	}
}
