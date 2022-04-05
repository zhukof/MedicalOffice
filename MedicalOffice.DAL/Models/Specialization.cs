using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalOffice.DAL.Models
{
    [Table(nameof(Specialization))]
    public class Specialization : BaseEntity
    {
        public string Name { get; set; }
    }
}