using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domains;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure
{
	[EnableCors("MovieCup")]
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class ControllerApiBase<TDomain, TDto> : Controller where TDomain : BaseDomain where TDto : BaseDto
	{
		protected readonly IServiceBase<TDomain> _serviceCrudBase;
		protected readonly IMapper _mapper;

		public ControllerApiBase(IServiceBase<TDomain> serviceCrudBase, IMapper mapper)
		{
			this._serviceCrudBase = serviceCrudBase;
			this._mapper = mapper;
		}

		[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
		[HttpGet]
		public async virtual Task<ActionResult<ICollection<TDto>>> GetAll()
		{
			var domains = await this._serviceCrudBase.GetAllAsync();

			var response = this._mapper.Map<ICollection<TDto>>(domains);

			return Ok(response);
		}

		[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
		[HttpPost]
		public async virtual Task<ActionResult> Create([FromBody] TDomain dto)
		{
			await this._serviceCrudBase.CreateAsync(dto);

			return Ok();
		}
	}
}
