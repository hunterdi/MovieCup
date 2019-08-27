using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using GraphQL.Types;
using Repository;

namespace LayerGraphQL
{
	public class FilmeCampeonatoQuery: ObjectGraphType<FilmeCampeonato>
	{
		private readonly IFilmeCampeonatoRepository _filmeCampeonatoRepository;

		public FilmeCampeonatoQuery(IFilmeCampeonatoRepository filmeCampeonatoRepository)
		{
			this._filmeCampeonatoRepository = filmeCampeonatoRepository;

			Field<ListGraphType<FilmeCampeonatoType>>("filmesCampeonatos", resolve: context => this._filmeCampeonatoRepository.GetAll());
			Field<FilmeCampeonatoType>("filmeCampeonato", arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
				resolve: context => this._filmeCampeonatoRepository.GetById(context.GetArgument<int>("id")));
		}
	}
}
