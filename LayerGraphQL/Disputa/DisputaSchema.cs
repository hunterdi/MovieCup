using GraphQL;
using GraphQL.Types;

namespace LayerGraphQL
{
	public class DisputaSchema : Schema
	{
		public DisputaSchema(IDependencyResolver resolver) : base(resolver)
		{
			Query = resolver.Resolve<DisputaQuery>();
		}
	}
}
