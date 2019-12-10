using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domains;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Itau.Gateway
{
    public class DisputaController : ControllerApiBase<Disputa, DisputaDto>
	{
		public DisputaController(IDisputaService disputaService, IMapper mapper): base(disputaService, mapper)
		{

		}
    }
}