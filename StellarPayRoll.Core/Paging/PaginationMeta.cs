using System;
using System.Collections.Generic;
using System.Text;

namespace StellarPayRoll.Core.Paging
{
    public class PaginationMeta
    {
        public int CurrentPage { get; }

        public int CurrentPageSize { get; }

        public int TotalPages { get; }

        public int TotalRecords { get; }

        public PaginationMeta()
        { 
        }

        public PaginationMeta(int currentPage, int currentPageSize, int totalPages, int totalRecords)
        {
            CurrentPage = currentPage;
            CurrentPageSize = currentPageSize;
            TotalPages = totalPages;
            TotalRecords = totalRecords;
        }
    }
}
