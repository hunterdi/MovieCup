using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using Infrastructure;
using Repository;

namespace Services
{
	public class FilmeCampeonatoService: ServiceBase<FilmeCampeonato>, IFilmeCampeonatoService
	{
		public FilmeCampeonatoService(IFilmeCampeonatoRepository movieRepository) : base(movieRepository)
		{
		}
	}
}
