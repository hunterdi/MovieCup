using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domains;
using Infrastructure;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services;

namespace Santander.Api.Precla
{
	public class FilmeController : ControllerApiBase<Filme, FilmeDto>
    {
		public FilmeController(IFilmeService movieService, IMapper mapper): base(movieService, mapper)
		{
		}
	}
}