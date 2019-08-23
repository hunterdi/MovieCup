using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domains;
using Infrastructure;
using Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Seed
{
	public static class FilmeSeed
	{
		public static async Task Initialize(DbContext dbContext, IConfiguration configuration, IApplicationBuilder applicationBuilder)
		{
			if (!dbContext.Database.EnsureCreated())
			{
				//var response = await WebClient.GetAsync(configuration.GetSection("HostMovies").Value);
				//var moviesResponse = JsonConvert.DeserializeObject<List<FilmeResponseSeed>>(response);

				//var mapper = applicationBuilder.ApplicationServices.GetRequiredService<IMapper>();
				//var movies = mapper.Map<List<FilmeResponseSeed>, List<Filme>>(moviesResponse);

				//await dbContext.AddRangeAsync(movies);
			}
			await Task.CompletedTask;
		}
	}
}
