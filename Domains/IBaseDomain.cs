using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public interface IBaseDomain<TKey>
    {
        TKey Id { get; set; }
    }
}
