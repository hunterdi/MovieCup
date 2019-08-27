using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using GraphQL.Types;

namespace LayerGraphQL
{
	public class CampeonatoType: ObjectGraphType<Campeonato>
	{
		public CampeonatoType()
		{
			Field(f => f.id);
			Field(f => f.nome);
			Field<ListGraphType<ClassificacaoType>>(nameof(Campeonato.classificacao));
			Field<ListGraphType<FilmeCampeonatoType>>(nameof(Campeonato.campeonatoFilmes));
		}
	}
}
