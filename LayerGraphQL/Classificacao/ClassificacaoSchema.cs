using GraphQL;
using GraphQL.Types;

namespace LayerGraphQL
{
	public class ClassificacaoSchema : Schema
	{
		public ClassificacaoSchema(IDependencyResolver resolver) : base(resolver)
		{
			Query = resolver.Resolve<ClassificacaoQuery>();
		}
	}
}
