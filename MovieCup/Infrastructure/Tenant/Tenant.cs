using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
	public class Tenant
	{
		public string StorageConnectionString { get; set; }
		public string PathContainer { get; set; }
	}
}
