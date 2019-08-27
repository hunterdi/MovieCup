using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using GraphQL.Types;

namespace LayerGraphQL
{
	public class FilmeCampeonatoType: ObjectGraphType<FilmeCampeonato>
	{
		public FilmeCampeonatoType()
		{
			Field(e => e.id);
			Field<FilmeType>(nameof(FilmeCampeonato.filme));
			Field<CampeonatoType>(nameof(FilmeCampeonato.campeonato));
		}
	}
}
