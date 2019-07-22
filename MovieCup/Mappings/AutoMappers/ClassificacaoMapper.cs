using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domains;

namespace Mappings
{
	public class ClassificacaoMapper: Profile
	{
		public ClassificacaoMapper()
		{
			CreateMap<Classificacao, ClassificacaoDto>().ReverseMap();
		}
	}
}
