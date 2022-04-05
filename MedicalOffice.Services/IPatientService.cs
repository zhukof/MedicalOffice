using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalOffice.DAL.Models;

namespace MedicalOffice.Services;

public interface IPatientService
{
    IQueryable<Patient> Table();
    IQueryable<PatientRegionMapping> PatientRegionTable();
    Task<Patient> GetByIdAsync(int id);
    Task<Patient> CreateOrUpdateAsync(Patient patient);
    
    Task UpdatePatientRegionAsync(Patient patient, IList<int> regionIds);
    Task RemoveAsync(Patient patient);
}