using Microsoft.EntityFrameworkCore;

namespace MedicalOffice.Api.Models
{
    public class PagedList<T>
    {
        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var total = source.Count();
            TotalCount = total;
            TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;

            if (pageSize == -1)
            {
                pageSize = total;
            }

            PageSize = pageSize;
            PageIndex = pageIndex;

            Data = source.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
        
        public IList<T> Data { get; }

        public int PageIndex { get; }

        public int PageSize { get; }

        public int TotalCount { get; }
        public int TotalPages { get; }
        
        public bool HasPreviousPage => PageIndex > 0;

        public bool HasNextPage => PageIndex + 1 < TotalPages;
    }
}
