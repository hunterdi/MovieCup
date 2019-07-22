using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using Infrastructure;

namespace Repository
{
	public class DisputaRepository: RepositoryBase<Disputa, ApplicationMemoryDbContext>, IDisputaRepository
	{
		public DisputaRepository(ApplicationMemoryDbContext dbContext): base(dbContext)
		{

		}
	}
}
