using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domains;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MovieCup
{
	public class CampeonatoController : ControllerApiBase<Campeonato, CampeonatoDto>
	{
		private readonly ICampeonatoService campeonatoService;
		private readonly IClassificacaoService classificacaoService;
		private readonly IFilmeService filmeService;

		public CampeonatoController(IFilmeService filmeService, IClassificacaoService classificacaoService, ICampeonatoService campeonatoService, IMapper mapper) : base(campeonatoService, mapper)
		{
			this.campeonatoService = campeonatoService;
			this.classificacaoService = classificacaoService;
			this.filmeService = filmeService;
		}

		[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
		[HttpGet("finalistas/{id}")]
		public async Task<ActionResult<CampeonatoDto>> finalists([FromRoute] long id)
		{
			var campeonato = await this.campeonatoService.GetFinalist(id);
			var response = this._mapper.Map<CampeonatoDto>(campeonato);

			return Ok(response);
		}
	}
}