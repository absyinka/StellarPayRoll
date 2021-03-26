using System;
using System.Collections.Generic;
using System.Text;

namespace StellarPayRoll.Core
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
