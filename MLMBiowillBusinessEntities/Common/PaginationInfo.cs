using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinessEntities.Common
{
    public class PaginationInfo
    {

        public int TotalRecords { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int StartPage { get; set; }

        public int EndPage { get; set; }

        public bool IsPagingRequired { get; set; }

        public PaginationInfo()
        {
            //PageSize = 1;
        }

        public PaginationInfo(int totalrecords, int? page, int pageSize = 5)
        {
            var totalPages = (int)Math.Ceiling((decimal)totalrecords / (decimal)pageSize);

            var currentPage = page != null ? (int)page : 1;

            var startPage = currentPage - 5;

            var endPage = currentPage + 4;

            if (startPage <= 0)
            {
                endPage -= (startPage - 1);

                startPage = 1;
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;

                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            if (currentPage == 0)
            {
                currentPage = 1;
            }

            TotalRecords = totalrecords;

            CurrentPage = currentPage;

            PageSize = pageSize;

            TotalPages = totalPages;

            StartPage = startPage;

            EndPage = endPage;

        }

    }
}
