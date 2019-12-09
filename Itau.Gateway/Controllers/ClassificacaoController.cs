using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domains;
using Infrastructure;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Itau.Gateway
{
	public class ClassificacaoController : ControllerApiBase<Classificacao, ClassificacaoDto>
	{

		public ClassificacaoController(IClassificacaoService classificacaoService, IMapper mapper): base(classificacaoService, mapper)
		{

		}
    }
}