using MedicalOffice.DAL.Models;

namespace MedicalOffice.Services
{
    public interface IDoctorService
    {
        Doctor GetById(int id);
    }
}