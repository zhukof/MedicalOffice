using MedicalOffice.DAL.Models.Enums;

namespace MedicalOffice.Api.Models.Dtos;

public class PatientDto : BaseModel
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
        
    public IList<RegionDto> Regions { get; set; } 
}