using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class ErrorHandlerConfigurationExtension
	{
		public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder app)
		{
			app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

			return app;
		}

		public static IServiceCollection AddErrorHandler(this IServiceCollection services)
		{
			services.AddTransient<GlobalExceptionHandlerMiddleware>();

			return services;
		}
	}
}
