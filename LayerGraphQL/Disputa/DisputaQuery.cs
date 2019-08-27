using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using GraphQL.Types;
using Repository;

namespace LayerGraphQL
{
	public class DisputaQuery: ObjectGraphType<Disputa>
	{
		private readonly IDisputaRepository _disputaRepository;

		public DisputaQuery(IDisputaRepository disputaRepository)
		{
			this._disputaRepository = disputaRepository;

			Field<ListGraphType<DisputaType>>("disputas", resolve: context => this._disputaRepository.GetAll());
			Field<DisputaType>("disputa", arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
				resolve: context => this._disputaRepository.GetById(context.GetArgument<int>("id")));
		}
	}
}
