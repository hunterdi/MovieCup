using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using GraphQL.Types;
using Repository;

namespace LayerGraphQL
{
	public class FilmeQuery: ObjectGraphType<Filme>
	{
		private readonly IFilmeRepository _filmeRepository;

		public FilmeQuery(IFilmeRepository filmeRepository)
		{
			this._filmeRepository = filmeRepository;

			Field<ListGraphType<FilmeType>>("filmes", resolve: context => this._filmeRepository.GetAll());
			Field<FilmeType>("filme", arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
				resolve: context => this._filmeRepository.GetById(context.GetArgument<int>("id")));
		}
	}
}
