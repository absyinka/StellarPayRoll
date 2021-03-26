using System;
using System.Collections.Generic;
using System.Text;

namespace StellarPayRoll.Core.Paging
{
    public interface IPagedRequest
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }
}
