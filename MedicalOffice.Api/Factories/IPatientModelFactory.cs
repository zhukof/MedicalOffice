using MedicalOffice.Api.Models;
using MedicalOffice.Api.Models.Dtos;

namespace MedicalOffice.Api.Factories;

public interface IPatientModelFactory
{
    PagedList<PatientDto> GetAll(PagingInfo pagingInfo);
    Task<PatientDto?> GetByIdAsync(int id);
}