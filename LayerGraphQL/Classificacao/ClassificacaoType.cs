using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using GraphQL.Types;

namespace LayerGraphQL
{
	public class ClassificacaoType: ObjectGraphType<Classificacao>
	{
		public ClassificacaoType()
		{
			Field(f => f.id);
			Field<CampeonatoType>(nameof(Classificacao.campeonato));
			Field<ListGraphType<DisputaType>>(nameof(Classificacao.disputa));
		}
	}
}
