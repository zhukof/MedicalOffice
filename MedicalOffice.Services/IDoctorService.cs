using System.Linq;
using System.Threading.Tasks;
using MedicalOffice.DAL.Models;

namespace MedicalOffice.Services
{
    public interface IDoctorService
    {
        IQueryable<Doctor> Table();
        Task<Doctor> GetByIdAsync(int id);
        Task<Doctor> UpdateAsync(Doctor doctor); 
        Task RemoveAsync(Doctor doctor);
    }
}