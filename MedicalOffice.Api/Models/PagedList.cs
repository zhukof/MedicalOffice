using Microsoft.EntityFrameworkCore;

namespace MedicalOffice.Api.Models
{
    public class PagedList<T> : List<T>
    {
        public async Task<PagedList<T>> FillDataAsync(IQueryable<T> source, int pageIndex, int pageSize)
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
            
            AddRange(await source.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync());

            return this;
        }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get;  set;}

        public int TotalPages { get; set; }
        
        public bool HasPreviousPage => PageIndex > 0;

        public bool HasNextPage => PageIndex + 1 < TotalPages;
    }
}
