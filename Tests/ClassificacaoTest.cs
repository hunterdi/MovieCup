using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domains;
using Infrastructure;
using Mappings;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
using Repository;
using Services;
using Xunit;

namespace Tests
{
	public class ClassificacaoTest
	{
		[Fact]
		public async Task Validar_criacao_da_classificacao()
		{
			var filmes = await this.GetFilmes();

			Assert.True(filmes.GetType() == typeof(List<Filme>));
			Assert.NotNull(filmes);
			Assert.True(filmes.Count == 16);

			var serviceClassificacao = this.GetMockClassificacaoService();

			var filmesSelecinados = filmes.Take(8).ToList();
			var campeonato = new Campeonato();
			campeonato.campeonatoFilmes = filmesSelecinados.Select(e => new FilmeCampeonato
			{
				campeonato = campeonato,
				filme = e
			}).ToList();

			var classificacoes = await serviceClassificacao.GerarClassificacoes(campeonato, filmesSelecinados);

			Assert.True(classificacoes.Count == 4);
			Assert.True(classificacoes.ElementAt(0).disputa.Count == 1);
			Assert.True(classificacoes.ElementAt(0).disputa.Count(e => e.desafiante == null && e.desafiado == null && e.vencedor != null) == 1);
			Assert.Equal("Vingadores: Guerra Infinita", classificacoes.ElementAt(0).disputa.Select(e => e.vencedor).First().titulo);
		}

		private async Task<IList<Filme>> GetFilmes()
		{
			var response = await WebClient.GetAsync("https://copadosfilmes.azurewebsites.net/api/filmes");
			var moviesResponse = JsonConvert.DeserializeObject<List<FilmeResponseSeed>>(response);
			var mapper = GetMockMapper();

			var movies = mapper.Map<List<FilmeResponseSeed>, List<Filme>>(moviesResponse);

			return movies;
		}

		private IMapper GetMockMapper()
		{
			var mockMapper = new MapperConfiguration(configuration =>
			{
				configuration.AddProfile(new FilmeMapper());
				configuration.AddProfile(new CampeonatoMapper());
				configuration.AddProfile(new ClassificacaoMapper());
				configuration.AddProfile(new DisputaMapper());
			});

			return mockMapper.CreateMapper();
		}

		private ClassificacaoService GetMockClassificacaoService()
		{
			var dbContext = this.GetDbContext();

			var classificacaoRepository = new ClassificacaoRepository(dbContext);
			var disputaServiceMocked = new Mock<IDisputaService>();

			var retorno = new ClassificacaoService(classificacaoRepository, disputaServiceMocked.Object);

			return retorno;
		}

		private DbContext GetDbContext()
		{
			Mock<DbSet<Campeonato>> dbCampeonato = new Mock<DbSet<Campeonato>>();
			Mock<DbSet<Classificacao>> dbClassificacao = new Mock<DbSet<Classificacao>>();
			Mock<DbSet<Disputa>> dbDisputa = new Mock<DbSet<Disputa>>();
			Mock<DbSet<Filme>> dbFilme = new Mock<DbSet<Filme>>();

			var optionsBuilder = new DbContextOptionsBuilder<DbContext>()
				.UseInMemoryDatabase("MovieCup").Options;
			var dbContext = new DbContext(optionsBuilder);

			//dbContext.SetupGet(e => e.Campeonatos).Returns(dbCampeonato.Object);
			//dbContext.SetupGet(e => e.Classificacoes).Returns(dbClassificacao.Object);
			//dbContext.SetupGet(e => e.Disputas).Returns(dbDisputa.Object);
			//dbContext.SetupGet(e => e.Filmes).Returns(dbFilme.Object);

			return dbContext;
		}
	}
}
