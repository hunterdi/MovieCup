using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
	public class Campeonato: BaseDomain
	{
		public Campeonato()
		{
			this.campeonatoFilmes = new List<FilmeCampeonato>();
			this.classificacao = new List<Classificacao>();
		}

		public string nome { get; set; }
		public virtual IList<FilmeCampeonato> campeonatoFilmes { get; set; }
		public virtual IList<Classificacao> classificacao { get; set; }
	}
}
