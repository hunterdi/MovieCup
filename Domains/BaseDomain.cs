using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
	public class BaseDomain: IBaseDomain<long>
    {
		public long Id { get; set; }
	}
}
