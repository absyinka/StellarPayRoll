using System;
using System.Collections.Generic;
using System.Text;

namespace StellarPayRoll.Core.Paging
{
    public class PagedResult<TItemType>
    {
        public int ItemCount { get; set; }

        public int Size { get; set; }

        public int Page { get; set; }

        public int PageCount { get; set; }

        public IEnumerable<TItemType> Items { get; set; }
    }
}
