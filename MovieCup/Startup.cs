using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infrastructure;
using Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Repository;
using Seed;
using Services;

namespace MovieCup
{
	public class Startup
	{
		public IConfiguration _configuration { get; }

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddOptionsConfiguration(this._configuration);
			services.AddCorsConfiguration(this._configuration);
			services.AddMapperConfiguration();
			services.AddValidators();
			services.AddErrorHandler();
			services.AddDbContextConfiguration(this._configuration);
			services.AddIdentityConfiguration();
			services.AddTokenConfiguration(this._configuration);
			services.AddMvcCoreConfiguration();
			services.AddSwaggerConfiguration();

			var builder = new ContainerBuilder();
			builder.RegisterModule<RepositoryModule>();
			builder.RegisterModule<ServiceModule>();
			builder.Populate(services);

			return new AutofacServiceProvider(builder.Build());
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			var logger = loggerFactory.CreateLogger("MovieCup");

			app.UseStaticFiles();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseErrorHandler();
			app.UseCors(SystemConstants.Cors.FrontMovieCup.ToDescription());
			//app.UseCookiePolicy();
			app.UseAuthentication();
			app.UseSwaggerConfiguration();

			SeedInitializer.Seed(app, _configuration);

			app.UseMvcConfiguration();
		}
	}
}
