using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
	public class Filme: BaseDomain
	{
		public Filme()
		{
			this.filmesCampeonato = new List<FilmeCampeonato>();
		}

		public string codigo { get; set; }
		public string titulo { get; set; }
		public int ano { get; set; }
		public decimal nota { get; set; }
		public virtual IList<FilmeCampeonato> filmesCampeonato { get; set; }
	}
}
