using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using GraphQL.Types;

namespace LayerGraphQL
{
	public class FilmeType: ObjectGraphType<Filme>
	{
		public FilmeType()
		{
			Field(e => e.Id);
			Field(e => e.ano);
			Field(e => e.codigo);
			Field(e => e.nota);
			Field(e => e.titulo);
			Field<ListGraphType<FilmeCampeonatoType>>(nameof(Filme.filmesCampeonato));
		}
	}
}
