using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public interface IBaseDto<TKey>
    {
        TKey Id { get; set; }
    }
}
