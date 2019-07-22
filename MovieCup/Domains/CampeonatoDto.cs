using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
	public class CampeonatoDto: BaseDto
	{
		public CampeonatoDto()
		{
			this.campeonatoFilmes = new List<FilmeCampeonatoDto>();
			this.classificacao = new List<ClassificacaoDto>();
		}

		public string nome { get; set; }
		public IList<FilmeCampeonatoDto> campeonatoFilmes { get; set; }
		public IList<ClassificacaoDto> classificacao { get; set; }
	}
}
