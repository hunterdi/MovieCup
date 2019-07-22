using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure;
using Domains;
using System.Threading.Tasks;

namespace Services
{
	public interface IClassificacaoService: IServiceBase<Classificacao>
	{
		Task<IList<Classificacao>> GerarClassificacoes(Campeonato campeonato, IList<Filme> filmes);
	}
}
