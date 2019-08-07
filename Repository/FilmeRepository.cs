using Domains;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class FilmeRepository : RepositoryBase<Filme, DbContext>, IFilmeRepository
	{
		public FilmeRepository(DbContext dbContext) : base(dbContext)
		{
		}
	}
}
