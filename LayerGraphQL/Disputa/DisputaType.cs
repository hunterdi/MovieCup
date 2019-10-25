using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using GraphQL.Types;

namespace LayerGraphQL
{
	public class DisputaType: ObjectGraphType<Disputa>
	{
		public DisputaType()
		{
			Field(e => e.Id);
			Field<ClassificacaoType>(nameof(Disputa.classificacao));
			Field<FilmeType>(nameof(Disputa.desafiante));
			Field<FilmeType>(nameof(Disputa.desafiado));
			Field<FilmeType>(nameof(Disputa.vencedor));
		}
	}
}
