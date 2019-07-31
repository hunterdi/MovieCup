using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace Infrastructure
{
	public static class MvcConfigurationExtension
	{
		public static IApplicationBuilder UseMvcConfiguration(this IApplicationBuilder app)
		{
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{moreInfo?}");

				routes.MapRoute(
					name: "aboutPage",
					template: "more",
					defaults: new { controller = "About", action = "TellMeMore" });
			});

			return app;
		}
	}
}
