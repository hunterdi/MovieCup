using GraphQL;
using GraphQL.Types;

namespace LayerGraphQL
{
	public class CampeonatoSchema : Schema
	{
		public CampeonatoSchema(IDependencyResolver resolver) : base(resolver)
		{
			Query = resolver.Resolve<CampeonatoQuery>();
		}
	}
}
