using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class DbContextConfigurationExtension
	{
		public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContextPool<ApplicationMemoryDbContext>(option =>
			{
				option.UseInMemoryDatabase(configuration.GetSection("ConnectionString").Value);
			});
			services.AddScoped<DbContext, ApplicationMemoryDbContext>();

			return services;
		}

	}
}
