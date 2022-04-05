using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalOffice.DAL.Models;

[Table(nameof(PatientRegionMapping))]
public class PatientRegionMapping
{
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    
    public int RegionId { get; set; }
    public Region Region { get; set; }
}