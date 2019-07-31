using Domains;
using Infrastructure;

namespace Repository
{
	public class FilmeRepository : RepositoryBase<Filme, ApplicationMemoryDbContext>, IFilmeRepository
	{
		public FilmeRepository(ApplicationMemoryDbContext dbContext) : base(dbContext)
		{
		}
	}
}
