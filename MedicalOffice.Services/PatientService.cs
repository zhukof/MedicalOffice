using System.Linq;
using System.Threading.Tasks;
using MedicalOffice.DAL;
using MedicalOffice.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalOffice.Services;

public class PatientService : IPatientService
{
    private readonly AppDbContext _appDbContext;

    public PatientService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
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

    public async Task<Patient> UpdateAsync(Patient patient)
    {
        _appDbContext.Patients.Update(patient);
        await _appDbContext.SaveChangesAsync();

        return patient;
    }

    public async Task RemoveAsync(Patient patient)
    {
        _appDbContext.Patients.Remove(patient);
        await _appDbContext.SaveChangesAsync();
    }
}