using Domains;

namespace Infrastructure
{
	public class LoggerRepository: RepositoryBase<EventLog, ApplicationMemoryDbContext>, ILoggerRepository
	{
		public LoggerRepository(ApplicationMemoryDbContext dbContext): base(dbContext)
		{

		}
	}
}
