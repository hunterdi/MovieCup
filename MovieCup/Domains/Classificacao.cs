using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
	public class Classificacao: BaseDomain
	{
		public Classificacao()
		{
			this.disputa = new List<Disputa>();
		}

		public virtual Campeonato campeonato { get; set; }
		public virtual IList<Disputa> disputa { get; set; }
	}
}
