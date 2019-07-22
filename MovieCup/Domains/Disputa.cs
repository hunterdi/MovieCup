using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
	public class Disputa: BaseDomain
	{
		public virtual Filme desafiante { get; set; }
		public virtual Filme desafiado { get; set; }
		public virtual Filme vencedor { get; set; }
		public virtual Classificacao classificacao { get; set; }
	}
}
