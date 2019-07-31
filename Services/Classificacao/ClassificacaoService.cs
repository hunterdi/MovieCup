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
	public class ClassificacaoService : ServiceBase<Classificacao>, IClassificacaoService
	{
		private readonly IDisputaService disputaService;

		public ClassificacaoService(IClassificacaoRepository classificacaoRepository, IDisputaService disputaService) : base(classificacaoRepository)
		{
			this.disputaService = disputaService;
		}

		public async Task<IList<Classificacao>> GerarClassificacoes(Campeonato campeonato, IList<Filme> filmes)
		{
			IList<Classificacao> retorno = new List<Classificacao>();

			Classificacao classificacao = new Classificacao
			{
				campeonato = campeonato
			};

			if (filmes.Count > 1)
			{
				IList<Filme> filmesClassificados = this.GerarProximaRodada(filmes, classificacao);
				retorno = await this.GerarClassificacoes(campeonato, filmesClassificados);
			}
			else
			{
				Disputa disputa = this.GerarDisputa(0, filmes, classificacao);
				classificacao.disputa.Add(disputa);
			}

			retorno.Add(classificacao);

			return retorno;
		}

		private IList<Filme> GerarProximaRodada(IList<Filme> filmes, Classificacao classificacao)
		{
			IList<Filme> retorno = new List<Filme>();

			IList<Disputa> disputas = new List<Disputa>();

			int quantidadeFilmesClassificados = (filmes.Count / 2);

			for (int i = 0; i < quantidadeFilmesClassificados; i++)
			{
				Disputa disputa = this.GerarDisputa(i, filmes, classificacao, retorno);

				disputas.Add(disputa);
				classificacao.disputa.Add(disputa);
			}

			return retorno;
		}

		private Disputa GerarDisputa(int index, IList<Filme> filmes, Classificacao classificacao, IList<Filme> proximaRodada = null)
		{
			IList<Filme> desafiadoXDesafiante = this.RealizarDisputa(index, filmes);
			Filme filmeVencedor = this.GetVencendor(desafiadoXDesafiante);

			if (proximaRodada != null)
				proximaRodada.Add(filmeVencedor);

			Disputa disputa = this.CriarDisputa(desafiadoXDesafiante, filmeVencedor, classificacao);

			return disputa;
		}

		private IList<Filme> RealizarDisputa(int index, IList<Filme> filmes)
		{
			IList<Filme> retorno = new List<Filme>();

			retorno.Add(filmes.ElementAt(index));

			if (filmes.Count > 1)
			{
				int indiceDesafiante = filmes.Count - (index + 1);
				retorno.Add(filmes.ElementAt(indiceDesafiante));
			}

			return retorno;
		}

		private Filme GetVencendor(IList<Filme> filmes)
		{
			return filmes.OrderByDescending(e => e.nota).ThenBy(e => e.titulo).FirstOrDefault();
		}

		private Disputa CriarDisputa(IList<Filme> disputa, Filme vencedor, Classificacao classificacao)
		{
			return new Disputa
			{
				classificacao = classificacao,
				desafiado = (disputa.Count == 2) ? disputa.ElementAt(0) : null,
				desafiante = (disputa.Count == 2) ? disputa.ElementAt(1) : null,
				vencedor = vencedor
			};
		}

		public override async Task<ICollection<Classificacao>> GetAllByAsync(Expression<Func<Classificacao, bool>> match, bool asNoTracking = true)
		{
			var response = await this._repositoryBase.GetAllByAsync(match, asNoTracking);

			var expression = new List<Expression<Func<Disputa, object>>>
			{
				(e=> e.vencedor),
				(e => e.desafiado),
				(e => e.desafiante)
			};

			foreach (var classificacao in response)
			{
				var disputas = await this.disputaService.GetByIncludingAsync(e => e.classificacao.id == classificacao.id, asNoTracking, expression.ToArray());

				classificacao.disputa = disputas.ToList();
			}

			return response;
		}
	}
}
