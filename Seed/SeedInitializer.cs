using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Seed
{
	public static class SeedInitializer
	{
		public static void Seed(IApplicationBuilder applicationBuilder, IConfiguration configuration)
		{
			DbContext dbContext = applicationBuilder.ApplicationServices.GetRequiredService<DbContext>();
			dbContext.Database.EnsureCreatedAsync();

			Task.Run(async () =>
			{
				await FilmeSeed.Initialize(dbContext, configuration, applicationBuilder);
			})
			.GetAwaiter()
			.GetResult();

			dbContext.SaveChanges();
		}
	}
}
