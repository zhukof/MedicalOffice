using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalOffice.DAL;
using MedicalOffice.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalOffice.Services;

public class PatientService : IPatientService
{
    private readonly AppDbContext _appDbContext;
    private readonly IRegionService _regionService;

    public PatientService(AppDbContext appDbContext, IRegionService regionService)
    {
        _appDbContext = appDbContext;
        _regionService = regionService;
    }

    public IQueryable<Patient> Table()
    {
        return _appDbContext.Patients;
    }

    public IQueryable<PatientRegionMapping> PatientRegionTable()
    {
        return _appDbContext.PatientRegionMappings;
    }

    public async Task<Patient> GetByIdAsync(int id)
    {
        return await _appDbContext.Patients.FirstOrDefaultAsync(el => el.Id == id);
    }

    public async Task<Patient> CreateOrUpdateAsync(Patient patient)
    {
        _appDbContext.Patients.Update(patient);
        await _appDbContext.SaveChangesAsync();

        return patient;
    }

    public async Task UpdatePatientRegionAsync(Patient patient, IList<int> regionIds)
    {
        regionIds = await _regionService
            .GetByIds(regionIds)
            .Select(el => el.Id)
            .ToListAsync();
        
        var patientRegionMappings = await _appDbContext
            .PatientRegionMappings
            .Where(el => el.PatientId == patient.Id)
            .ToListAsync();

        var newPatientRegionIds = regionIds.Where(el => patientRegionMappings.All(prm => prm.RegionId != el));

        var removePatientRegionMapping = patientRegionMappings.Where(el => !regionIds.Contains(el.RegionId));

        await _appDbContext.PatientRegionMappings.AddRangeAsync(newPatientRegionIds.Select(el => new PatientRegionMapping
        {
            PatientId = patient.Id,
            RegionId = el
        }));
        
        _appDbContext.RemoveRange(removePatientRegionMapping);

        await _appDbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(Patient patient)
    {
        await using var transaction = await _appDbContext.Database.BeginTransactionAsync();

        var patientRegionMappings = _appDbContext
            .PatientRegionMappings
            .Where(el => el.PatientId == patient.Id);
        
        _appDbContext.PatientRegionMappings.RemoveRange(patientRegionMappings);
        _appDbContext.Patients.Remove(patient);
        
        await _appDbContext.SaveChangesAsync();
        
        await transaction.CommitAsync();
    }
}