using System.Linq;
using System.Threading.Tasks;
using MedicalOffice.DAL.Models;

namespace MedicalOffice.Services;

public interface IPatientService
{
    IQueryable<Patient> Table();
    IQueryable<PatientRegionMapping> PatientRegionTable();
    Task<Patient> GetByIdAsync(int id);
    Task<Patient> UpdateAsync(Patient patient); 
    Task RemoveAsync(Patient patient);
}