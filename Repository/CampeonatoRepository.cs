using System.Threading.Tasks;
using Domains;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class CampeonatoRepository : RepositoryBase<Campeonato, DbContext>, ICampeonatoRepository
	{
		public CampeonatoRepository(DbContext dbContext) : base(dbContext)
		{

		}
	}
}
