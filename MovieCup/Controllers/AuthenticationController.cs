using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domains;
using FluentValidation;
using Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MovieCup
{
	[AllowAnonymous]
	[EnableCors("MovieCup")]
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
    public class AuthenticationController : Controller
    {
		private readonly IApplicationUserService _service;
		private readonly IMapper _mapper;

		public AuthenticationController(IApplicationUserService service, IMapper mapper)
		{
			this._service = service;
			this._mapper = mapper;
		}

		[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
		[HttpPost("signup")]
		public async Task<IActionResult> CreateUserAsync([FromBody] SignupDto dto)
		{
			var user = this._mapper.Map<ApplicationUser>(dto);

			IdentityResult result = await _service.CreateUserAsync(user);

			if (result.Succeeded)
			{
				return Ok(new { message = "successful operation", statusCode = 200 });
			}
			return UnprocessableEntity(result.Errors.Where(e => e.Code.ToUpper() == "DuplicateEmail".ToUpper()).Select(e => new { message = "E-mail already exists", statusCode = 422 }).Distinct());
		}

		[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
		[HttpGet("logout")]
		public async Task<IActionResult> SignOutAsync()
		{
			await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
			return Content("done");
		}

		[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
		[HttpPost("signin")]
		public async Task<IActionResult> LoginAsync([FromBody] SigninDto dto, [FromServices]SigningConfigurations signingConfigurations, [FromServices]TokenConfigurations tokenConfigurations, [FromServices] IApplicationUserService userService)
		{
			var result = await _service.SignInAsync(dto.Email, dto.Password);

			if (result.Succeeded)
			{
				var user = (await userService.GetByIncludingAsync((e => e.Email.ToUpper() == dto.Email.ToUpper()), false, (e => e.Phones))).FirstOrDefault();
				if (user == null)
				{
					return NotFound(new { message = "User Not Found", statusCode = 404 });
				}
				user.LastLogin = DateTime.Now;
				await userService.UpdateAsync(user, user.Id);

				var response = this._mapper.Map<ApplicationUserDto>(user);
				
				return GenerateResultToken(user, signingConfigurations, tokenConfigurations, response);
			}
			return UnprocessableEntity(new { message = "Invalid e-mail or password", statusCode = 422 });
		}

		[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
		[UserIdentityValidatorsMiddleware, Authorize("Bearer")]
		[HttpPost("me")]
		public async Task<IActionResult> Me([FromQuery(Name = "email")] string email, [FromServices] IApplicationUserService userService)
		{
			var user = (await userService.GetAllIncludingAsync((e => e.Phones))).SingleOrDefault(e => e.Email.ToUpper() == email.ToUpper());
			var result = _mapper.Map<ApplicationUserDto>(user);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest();
		}

		[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
		[UserIdentityValidatorsMiddleware, Authorize("Bearer")]
		[HttpPut("password")]
		public async Task<IActionResult> ChangePassword([FromBody] ApplicationUserChangePasswordDto dto)
		{
			var user = await this._service.ChangePasswordAsync(dto.Email, dto.CurrentPassword, dto.NewPassword);

			return Ok();
		}

		[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
		[UserIdentityValidatorsMiddleware, Authorize("Bearer")]
		[HttpPut("email")]
		public async Task<IActionResult> ChangeEmail([FromBody] ApplicationUserChangeEmailDto dto)
		{
			var user = await this._service.ChangeEmailAsync(dto.CurrentEmail, dto.NewEmail);

			return Ok();
		}

		private IActionResult GenerateResultToken(ApplicationUser user, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations, ApplicationUserDto dto)
		{
			var objectToken = user.GenerateToken(tokenConfigurations, signingConfigurations);

			return Ok(new { user = dto, token = objectToken });
		}
	}
}