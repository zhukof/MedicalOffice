using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalOffice.DAL.Models
{
    [Table(nameof(Region))]
    public class Region : BaseEntity
    {
        public string Number { get; set; }
        
        public ICollection<PatientRegionMapping> Patients { get; set; } 
    }
}