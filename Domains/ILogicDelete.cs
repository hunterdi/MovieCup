using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public interface ILogicDelete
    {
        bool Visible { get; set; }
        bool Active { get; set; }
    }
}
