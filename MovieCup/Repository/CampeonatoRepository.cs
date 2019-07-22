using System.Threading.Tasks;
using Domains;
using Infrastructure;

namespace Repository
{
	public class CampeonatoRepository : RepositoryBase<Campeonato, ApplicationMemoryDbContext>, ICampeonatoRepository
	{
		public CampeonatoRepository(ApplicationMemoryDbContext dbContext) : base(dbContext)
		{

		}
	}
}
