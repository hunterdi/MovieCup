using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using GraphQL.Types;
using Repository;

namespace LayerGraphQL
{
	public class ClassificacaoQuery: ObjectGraphType<Classificacao>
	{
		private readonly IClassificacaoRepository _classificacaoRepository;

		public ClassificacaoQuery(IClassificacaoRepository classificacaoRepository)
		{
			this._classificacaoRepository = classificacaoRepository;

			Field<ListGraphType<CampeonatoType>>("classificacoes", resolve: context => this._classificacaoRepository.GetAll());
			Field<CampeonatoType>("classificacao", arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
				resolve: context => this._classificacaoRepository.GetById(context.GetArgument<int>("id")));
		}
	}
}
