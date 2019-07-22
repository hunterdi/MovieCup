using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
	public class FilmeCampeonato: BaseDomain
	{
		public virtual Filme filme { get; set; }
		public virtual Campeonato campeonato { get; set; }
	}
}
