using MedicalOffice.Api.Models.Dtos;
using MedicalOffice.DAL.Models.Enums;

namespace MedicalOffice.Api.Models.Requests;

public class PatientCreateRequest
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
        
    public IList<int> RegionIds { get; set; } 
}