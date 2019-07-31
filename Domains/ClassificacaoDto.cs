using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
	public class ClassificacaoDto: BaseDto
	{
		public ClassificacaoDto()
		{
			this.disputa = new List<DisputaDto>();
		}

		public CampeonatoDto campeonato { get; set; }
		public IList<DisputaDto> disputa { get; set; }
	}
}
