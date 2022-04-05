using MedicalOffice.Api.Models;
using MedicalOffice.Api.Models.Dtos;
using MedicalOffice.DAL.Extensions;
using MedicalOffice.Services;
using Microsoft.EntityFrameworkCore;

namespace MedicalOffice.Api.Factories;

public class PatientModelFactory : IPatientModelFactory
{
    private readonly IPatientService _patientService;

    public PatientModelFactory(IPatientService patientService)
    {
        _patientService = patientService;
    }
    
    public PagedList<PatientDto> GetAll(PagingInfo pagingInfo)
    {
        var patientDtoQuery = GetPatientDto();
        
        patientDtoQuery = patientDtoQuery.OrderByOrderingModel(pagingInfo.Order);

        var result = new PagedList<PatientDto>(patientDtoQuery, pagingInfo.Page, pagingInfo.PageSize);

        return result;
    }

    public async Task<PatientDto?> GetByIdAsync(int id)
    {
        var patientDto = await GetPatientDto()
            .FirstOrDefaultAsync(el => el.Id == id);

        return patientDto;
    }
    
    private IQueryable<PatientDto> GetPatientDto()
    {
        return _patientService.Table()
            .Include(el=>el.Regions)
            .ThenInclude(el=>el.Region)
            .Select(el => new PatientDto
            {
                Id = el.Id,
                FirstName = el.FirstName,
                LastName = el.LastName,
                SecondName = el.SecondName,
                Address = el.Address,
                Gender = el.Gender,
                DateOfBirth = el.DateOfBirth,
                Regions = el.Regions.Select(reg=>new RegionDto
                {
                    Id = reg.RegionId,
                    Number = reg.Region.Number
                }).ToList()
            });
    }
}