using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
	public class FilmeCampeonatoDto: BaseDto
	{
		public virtual FilmeDto filme { get; set; }
		public virtual CampeonatoDto campeonato { get; set; }
	}
}
