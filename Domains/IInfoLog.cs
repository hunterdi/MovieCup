using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public interface IInfoLog<TKey>
    {
        DateTime Created { get; set; }
        TKey IdUserCreated { get; set; }
        DateTime Updated { get; set; }
        TKey IdUserUpdated { get; set; }
    }
}
