using System;
using System.Collections.Generic;
using System.Text;
using GraphQL;
using GraphQL.Types;

namespace LayerGraphQL
{
	public class FilmeCampeonatoSchema: Schema
	{
		public FilmeCampeonatoSchema(IDependencyResolver resolver) : base(resolver)
		{
			Query = resolver.Resolve<FilmeCampeonatoQuery>();
		}
	}
}
