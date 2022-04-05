using System.Threading.Tasks;
using MedicalOffice.DAL.Models;

namespace MedicalOffice.Services;

public interface ISpecializationService
{
    Task<Specialization> GetByIdAsync(int id);
}