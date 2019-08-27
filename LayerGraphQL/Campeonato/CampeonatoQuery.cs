using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using GraphQL.Types;
using Repository;

namespace LayerGraphQL
{
	public class CampeonatoQuery: ObjectGraphType<Campeonato>
	{
		private readonly ICampeonatoRepository _campeonatoRepository;

		public CampeonatoQuery(ICampeonatoRepository campeonatoRepository)
		{
			this._campeonatoRepository = campeonatoRepository;

			Field<ListGraphType<CampeonatoType>>("campeonatos", resolve: context => this._campeonatoRepository.GetAll());
			Field<CampeonatoType>("campeonato", arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
				resolve: context => this._campeonatoRepository.GetById(context.GetArgument<int>("id")));
		}
	}
}
