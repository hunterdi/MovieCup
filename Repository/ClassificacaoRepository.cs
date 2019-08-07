using Domains;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class ClassificacaoRepository : RepositoryBase<Classificacao, DbContext>, IClassificacaoRepository
	{
		public ClassificacaoRepository(DbContext dbContext) : base(dbContext)
		{

		}
	}
}
