namespace MedicalOffice.Api.Models
{
    public abstract class PagedModel<T>
    {
        public IEnumerable<T> Data { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPage { get; set; }        
    }
}