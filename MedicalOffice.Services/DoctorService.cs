using System.Linq;
using System.Threading.Tasks;
using MedicalOffice.DAL;
using MedicalOffice.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalOffice.Services;

public class DoctorService : IDoctorService
{
    private readonly AppDbContext _appDbContext;

    public DoctorService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IQueryable<Doctor> Table()
    {
        return _appDbContext.Doctors;
    }

    public async Task<Doctor> GetByIdAsync(int id)
    {
        return await _appDbContext.Doctors.FirstOrDefaultAsync(el => el.Id == id);
    }

    public async Task<Doctor> UpdateAsync(Doctor doctor)
    {
        _appDbContext.Doctors.Update(doctor);
        await _appDbContext.SaveChangesAsync();
        return doctor;
    }

    public async Task RemoveAsync(Doctor doctor)
    {
        _appDbContext.Doctors.Remove(doctor);
        await _appDbContext.SaveChangesAsync();
    }
}