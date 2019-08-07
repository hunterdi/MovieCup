using Domains;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class ApplicationUserRepository : RepositoryBase<ApplicationUser, DbContext>, IApplicationUserRepository
	{
		public ApplicationUserRepository(DbContext dbContext) : base(dbContext)
		{

		}
	}
}
