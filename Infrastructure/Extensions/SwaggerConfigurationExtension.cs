using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Infrastructure
{
	public static class SwaggerConfigurationExtension
	{
		public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "Copa de Filmes", Version = "v1" });
			});

			return services;
		}

		public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("swagger/v1/swagger.json", "Copa de Filmes v1");
				c.RoutePrefix = string.Empty;
			});

			return app;
		}
	}
}
