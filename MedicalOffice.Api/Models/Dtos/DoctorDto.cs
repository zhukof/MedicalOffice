namespace MedicalOffice.Api.Models.Dtos;

public class DoctorDto : BaseModel
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
        
    public int CabinetId { get; set; }
    public string? Cabinet { get; set; }
        
    public int SpecializationId { get; set; }
    public string? Specialization { get; set; }
        
    public int? RegionId { get; set; }
    public string? Region { get; set; }
}