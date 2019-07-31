using Domains;
using Infrastructure;
using Repository;

namespace Services
{
	public class FilmeService : ServiceBase<Filme>, IFilmeService
	{
		public FilmeService(IFilmeRepository movieRepository) : base(movieRepository)
		{
		}
	}
}
