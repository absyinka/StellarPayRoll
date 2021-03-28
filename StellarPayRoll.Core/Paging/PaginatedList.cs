using System;
using System.Collections.Generic;
using System.Linq;

namespace StellarPayRoll.Core.Paging
{
    public class PaginatedList<T>
    {
        public int TotalCount { get; }

        public IEnumerable<T> Rows { get; }

        public PaginatedList(IQueryable<T> source, int count)
        {
            TotalCount = count;
            Rows = source;
        }

        public PaginatedList(ICollection<T> source, int count)
        {
            TotalCount = count;
            Rows = source;
        }

        public static PaginatedList<T> Default => new PaginatedList<T>(Array.Empty<T>(), 0);
    }
}
