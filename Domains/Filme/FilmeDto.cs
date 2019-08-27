using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
	public class FilmeDto: BaseDto
	{
		public FilmeDto()
		{
			this.filmesCampeonato = new List<FilmeCampeonatoDto>();
		}

		public string codigo { get; set; }
		public string titulo { get; set; }
		public int ano { get; set; }
		public decimal nota { get; set; }
		public virtual IList<FilmeCampeonatoDto> filmesCampeonato { get; set; }
	}
}
