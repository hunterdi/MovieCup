using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infrastructure
{
	public class UserIdentityValidatorsMiddlewareAttribute: ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);
			if (context.HttpContext.Request.Headers["Authorization"].Count == 0)
			{
				context.Result = new UnauthorizedObjectResult(new { message = "Unauthorized", statusCode = 401 });
				return;
			}
			if (!context.HttpContext.User.Identity.IsAuthenticated)
				context.Result = new UnauthorizedObjectResult(new { message = "Unauthorized - invalid session", statusCode = 401 });
		}
	}
}
