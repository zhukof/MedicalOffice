namespace MedicalOffice.Api.Models.Requests;

public class DoctorCreateRequest
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
        
    public int CabinetId { get; set; }
    public int SpecializationId { get; set; }
    public int? RegionId { get; set; }
}