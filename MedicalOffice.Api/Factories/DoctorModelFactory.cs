using MedicalOffice.Api.Models;
using MedicalOffice.Api.Models.Dtos;
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

    public PagedList<DoctorDto> GetAll(PagingInfo pagingInfo)
    {
        var doctorDtoQuery = GetDoctorDtoQuery();

        doctorDtoQuery = doctorDtoQuery.OrderByOrderingModel(pagingInfo.Order);

        var result = new PagedList<DoctorDto>(doctorDtoQuery, pagingInfo.Page, pagingInfo.PageSize);
        
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