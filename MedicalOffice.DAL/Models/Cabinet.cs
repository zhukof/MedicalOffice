using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalOffice.DAL.Models
{
    [Table(nameof(Cabinet))]
    public class Cabinet : BaseEntity
    {
        public string Number { get; set; }
    }
}