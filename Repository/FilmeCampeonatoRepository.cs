using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class FilmeCampeonatoRepository: RepositoryBase<FilmeCampeonato, DbContext>, IFilmeCampeonatoRepository
	{
		public FilmeCampeonatoRepository(DbContext dbContext): base(dbContext)
		{

		}
	}
}
