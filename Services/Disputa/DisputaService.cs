using Domains;
using Infrastructure;
using Repository;

namespace Services
{
	public class DisputaService : ServiceBase<Disputa>, IDisputaService
	{
		public DisputaService(IDisputaRepository disputaRepository) : base(disputaRepository)
		{
		}
	}
}
