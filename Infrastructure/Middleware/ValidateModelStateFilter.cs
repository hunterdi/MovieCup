using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infrastructure
{
	public class ValidateModelStateFilter : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			if (!context.ModelState.IsValid)
			{
				var modelStateEntries = context.ModelState.Where(e => e.Value.Errors.Count > 0).ToArray();
				var errors = new List<ValidationError>();
				var details = "See ValidationErrors for details";

				if (modelStateEntries.Any())
				{
					if (modelStateEntries.Length == 1 && modelStateEntries[0].Value.Errors.Count == 1 && modelStateEntries[0].Key == string.Empty)
					{
						details = modelStateEntries[0].Value.Errors[0].ErrorMessage;
					}
					else
					{
						foreach (var modelStateEntry in modelStateEntries)
						{
							foreach (var modeStateError in modelStateEntry.Value.Errors)
							{
								var error = new ValidationError
								{
									Name = modelStateEntry.Key,
									Description = modeStateError.ErrorMessage
								};

								errors.Add(error);
							}
						}
					}
				}

				var problemDetails = new ValidationProblemDetails
				{
					Status = (int)HttpStatusCode.BadRequest,
					Title = "Request Validation Error",
					Instance = $"urn:UrbanTick:BadRequest:{Guid.NewGuid()}",
					Detail = details,
					ValidationErrors = errors
				};

				context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
				context.HttpContext.Response.WriteJson(problemDetails);
			}
		}
	}
}
