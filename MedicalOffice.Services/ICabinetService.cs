using System.Threading.Tasks;
using MedicalOffice.DAL.Models;

namespace MedicalOffice.Services;

public interface ICabinetService
{
    Task<Cabinet> GetByIdAsync(int id);
}