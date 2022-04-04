using MedicalOffice.Api.DtoModels;
using MedicalOffice.Api.Models;

namespace MedicalOffice.Api.Factories;

public interface IDoctorModelFactory
{
    Task<IList<DoctorDto>> GetAllAsync(ParameterListModel parameterListModel);
    Task<DoctorDto?> GetByIdAsync(int id);
}