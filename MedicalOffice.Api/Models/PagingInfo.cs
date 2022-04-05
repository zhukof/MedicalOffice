using MedicalOffice.DAL.Extensions.Models;

namespace MedicalOffice.Api.Models
{
    public class PagingInfo
    {
        public IList<OrderingModel> Order { get; set; } = new List<OrderingModel>();
        
        public int Page { get; set; }
        public int PageSize { get; set; } = 10;
    }
}