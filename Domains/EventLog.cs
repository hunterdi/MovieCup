using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
	public class EventLog: BaseDomain
	{
		public int? EventId { get; set; }
		public string LogLevel { get; set; }
		public string Message { get; set; }
		public DateTime? CreatedTime { get; set; }
	}
}
