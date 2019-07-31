using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using Infrastructure;

namespace Repository
{
	public class FilmeCampeonatoRepository: RepositoryBase<FilmeCampeonato, ApplicationMemoryDbContext>, IFilmeCampeonatoRepository
	{
		public FilmeCampeonatoRepository(ApplicationMemoryDbContext dbContext): base(dbContext)
		{

		}
	}
}
