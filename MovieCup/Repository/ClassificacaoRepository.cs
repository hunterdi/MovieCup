using Domains;
using Infrastructure;

namespace Repository
{
	public class ClassificacaoRepository : RepositoryBase<Classificacao, ApplicationMemoryDbContext>, IClassificacaoRepository
	{
		public ClassificacaoRepository(ApplicationMemoryDbContext dbContext) : base(dbContext)
		{

		}
	}
}
