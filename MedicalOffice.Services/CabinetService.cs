using System.Linq;
using System.Threading.Tasks;
using MedicalOffice.DAL;
using MedicalOffice.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalOffice.Services;

public class CabinetService : ICabinetService
{
    private readonly AppDbContext _appDbContext;

    public CabinetService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<Cabinet> GetByIdAsync(int id)
    {
        return await _appDbContext.Cabinets.FirstOrDefaultAsync(el => el.Id == id);
    }
}