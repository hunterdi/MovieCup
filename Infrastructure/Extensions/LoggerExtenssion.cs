using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
	public static class LoggerExtenssion
	{
		public static ILoggerFactory AddContext(this ILoggerFactory factory, Func<string, LogLevel, bool> filter = null, string connectionString = null)
		{
			//factory.AddProvider(new SystemLoggerProvider(filter, connectionString));
			return factory;
		}

		public static ILoggerFactory AddContext(this ILoggerFactory factory, LogLevel minLevel, string connectionString = null)
		{
			return AddContext(factory, (_, logLevel) => logLevel >= minLevel, connectionString);
		}
	}
}
