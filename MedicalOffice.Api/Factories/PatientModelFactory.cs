using MedicalOffice.Api.DtoModels;
using MedicalOffice.Services;
using Microsoft.EntityFrameworkCore;

namespace MedicalOffice.Api.Factories;

public class PatientModelFactory : IPatientModelFactory
{
    private readonly IPatientService _patientService;
    private readonly IRegionService _regionService;

    public PatientModelFactory(IPatientService patientService, IRegionService regionService)
    {
        _patientService = patientService;
        _regionService = regionService;
    }
    
    public async Task<IList<PatientDto>> GetAllAsync()
    {
        var patientDto = (IQueryable<PatientDto>) _patientService.Table()
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
                Regions = el.Regions.Select(reg=>reg.Region).ToList()
            });

        return await patientDto.ToListAsync();
    }


    public async Task<PatientDto?> GetByIdAsync(int id)
    {
        var patientDto = await ((IQueryable<PatientDto>) _patientService.Table()
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
                    Regions = el.Regions.Select(reg=>reg.Region).ToList()
                }))
            .FirstOrDefaultAsync(el => el.Id == id);

        return patientDto;
    }
}