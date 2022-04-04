using MedicalOffice.Api.DtoModels;
using MedicalOffice.Api.Models;
using MedicalOffice.DAL.Extensions;
using MedicalOffice.Services;
using Microsoft.EntityFrameworkCore;

namespace MedicalOffice.Api.Factories;

public class DoctorModelFactory : IDoctorModelFactory
{
    private readonly IDoctorService _doctorService;

    public DoctorModelFactory(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public async Task<IList<DoctorDto>> GetAllAsync(ParameterListModel parameterListModel)
    {
        var doctorDtoQuery = GetDoctorDtoQuery();

        doctorDtoQuery = doctorDtoQuery.OrderByOrderingModel(parameterListModel.Order);

        var result = await new PagedList<DoctorDto>().FillDataAsync(doctorDtoQuery, parameterListModel.Page, parameterListModel.PageSize);
        
        return result;
    }

    public async Task<DoctorDto?> GetByIdAsync(int id)
    {
        var doctor = await GetDoctorDtoQuery().FirstOrDefaultAsync(el => el.Id == id);

        return doctor;
    }
    
    private IQueryable<DoctorDto> GetDoctorDtoQuery()
    {
        return _doctorService
            .Table()
            .Include(el => el.Specialization)
            .Include(el => el.Cabinet)
            .Include(el => el.Region)
            .Select(el => new DoctorDto
            {
                Id = el.Id,
                FirstName = el.FirstName,
                LastName = el.LastName,
                SecondName = el.SecondName,
                CabinetId = el.CabinetId,
                Cabinet = el.Cabinet.Number,
                SpecializationId = el.SpecializationId,
                Specialization = el.Specialization.Name,
                RegionId = el.RegionId,
                Region = el.Region.Number
            });
    }
}