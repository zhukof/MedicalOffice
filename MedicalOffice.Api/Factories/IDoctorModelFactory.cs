using MedicalOffice.Api.Models;
using MedicalOffice.Api.Models.Dtos;

namespace MedicalOffice.Api.Factories;

public interface IDoctorModelFactory
{
    PagedList<DoctorDto> GetAll(PagingInfo pagingInfo);
    Task<DoctorDto?> GetByIdAsync(int id);
}