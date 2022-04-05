using System.Threading.Tasks;
using MedicalOffice.DAL;
using MedicalOffice.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalOffice.Services;

public class SpecializationService : ISpecializationService
{
    private readonly AppDbContext _appDbContext;

    public SpecializationService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<Specialization> GetByIdAsync(int id)
    {
        return await _appDbContext.Specializations.FirstOrDefaultAsync(el => el.Id == id);
    }
}