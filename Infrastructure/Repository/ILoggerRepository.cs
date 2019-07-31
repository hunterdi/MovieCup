using System;
using System.Collections.Generic;
using System.Text;
using Domains;

namespace Infrastructure
{
	public interface ILoggerRepository: IRepositoryBase<EventLog>
	{
	}
}
