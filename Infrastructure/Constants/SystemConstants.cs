using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Infrastructure
{
	public class SystemConstants: Attribute
	{
		public enum Cors
		{
			[DisplayName("MovieCup")]
			[Description("MovieCup")]
			FrontMovieCup = 1
		}

		public enum AppSettings
		{
			[DisplayName("ConnectionString")]
			[Description("ConnectionString")]
			ConnectionString = 1,
			[DisplayName("AllowedHosts")]
			[Description("AllowedHosts")]
			AllowedHosts = 2
		}
	}
}
