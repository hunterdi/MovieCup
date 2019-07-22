using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
	public class DisputaDto: BaseDto
	{
		public FilmeDto desafiante { get; set; }
		public FilmeDto desafiado { get; set; }
		public FilmeDto vencedor { get; set; }
		public ClassificacaoDto classificacao { get; set; }
	}
}
