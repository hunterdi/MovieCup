using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class DisputaRepository: RepositoryBase<Disputa, DbContext>, IDisputaRepository
	{
		public DisputaRepository(DbContext dbContext): base(dbContext)
		{

		}
	}
}
