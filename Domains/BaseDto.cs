﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
	public class BaseDto: IBaseDto<long>
    {
		public long Id { get; set; }
	}
}
