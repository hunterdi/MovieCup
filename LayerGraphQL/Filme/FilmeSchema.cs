using System;
using System.Collections.Generic;
using System.Text;
using GraphQL;
using GraphQL.Types;

namespace LayerGraphQL
{
	public class FilmeSchema: Schema
	{
		public FilmeSchema(IDependencyResolver resolver) : base(resolver)
		{
			Query = resolver.Resolve<FilmeQuery>();
		}
	}
}
