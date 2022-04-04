using MedicalOffice.Api.DtoModels;

namespace MedicalOffice.Api.Factories;

public interface IPatientModelFactory
{
    Task<IList<PatientDto>> GetAllAsync();
    Task<PatientDto?> GetByIdAsync(int id);
}