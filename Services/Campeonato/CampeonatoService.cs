using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domains;
using Infrastructure;
using Repository;

namespace Services
{
	public class CampeonatoService : ServiceBase<Campeonato>, ICampeonatoService
	{
		private readonly IClassificacaoService classificacaoService;
		private readonly IFilmeService filmeService;
		private readonly IFilmeCampeonatoService filmeCampeonatoService;

		public CampeonatoService(
			ICampeonatoRepository campeonatoRepository,
			IClassificacaoService classificacaoService,
			IFilmeService filmeService,
			IFilmeCampeonatoService filmeCampeonatoService) : base(campeonatoRepository)
		{
			this.classificacaoService = classificacaoService;
			this.filmeService = filmeService;
			this.filmeCampeonatoService = filmeCampeonatoService;
		}

		public override async Task CreateAsync(Campeonato campeonato)
		{
			var idsFilmes = campeonato.campeonatoFilmes.Select(e => e.filme.id).ToList();
			var filmes = (await this.filmeService.GetAllByAsync((e => idsFilmes.Contains(e.id)), false)).ToList();

			campeonato.campeonatoFilmes = CreateFilmeCampeonatos(campeonato, filmes);
			campeonato.classificacao = await this.classificacaoService.GerarClassificacoes(campeonato, filmes);

			await this._repositoryBase.CreateAsync(campeonato);
			await this._repositoryBase.SaveChangesAsync();
		}

		private IList<FilmeCampeonato> CreateFilmeCampeonatos(Campeonato campeonato, IList<Filme> filmes)
		{
			return filmes.Select(e =>
				new FilmeCampeonato
				{
					campeonato = campeonato,
					filme = e
				}
			).ToList();
		}

		public async Task<Campeonato> GetFinalist(long id)
		{
			var response = (await this._repositoryBase.GetByIncludingAsync(e => e.id == id, false, e => e.campeonatoFilmes)).FirstOrDefault();
			var classificacoes = (await this.classificacaoService.GetAllByAsync(e => e.campeonato.id == id, false)).ToList();

			response.classificacao = classificacoes;

			var expression = new List<Expression<Func<FilmeCampeonato, object>>>
			{
				(e => e.campeonato),
				(e => e.filme)
			};

			var campeonatoFilmes = (await this.filmeCampeonatoService.GetByIncludingAsync(e => e.campeonato.id == id, false, expression.ToArray())).ToList();
			response.campeonatoFilmes = campeonatoFilmes;

			return response;
		}
	}
}
