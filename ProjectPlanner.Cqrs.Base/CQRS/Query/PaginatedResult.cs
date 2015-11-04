using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlanner.Cqrs.Base.CQRS.Query
{
    public class PaginatedResult<T>
    {
        public List<T> Items { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int PagesCount { get; set; }
        public int TotalItemsCount { get; set; }

        public PaginatedResult(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Items = new List<T>();
            PagesCount = 0;
            TotalItemsCount = 0;
        }

        public PaginatedResult(List<T> items, int pageNumber, int pageSize, int totalItemsCount)
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            PagesCount = CountPages(pageSize, totalItemsCount);
            TotalItemsCount = totalItemsCount;
        }

        private int CountPages(int size, int itemsCount)
        {
            return (int) Math.Ceiling((double) itemsCount/size);
        }
    }
}
