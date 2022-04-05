using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalOffice.DAL;
using MedicalOffice.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalOffice.Services;

public class RegionService : IRegionService
{
    private readonly AppDbContext _appDbContext;

    public RegionService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IQueryable<Region> Table()
    {
        return _appDbContext.Regions;
    }

    public async Task<Region> GetByIdAsync(int id)
    {
        return await _appDbContext.Regions.FirstOrDefaultAsync(el => el.Id == id);
    }

    public IQueryable<Region> GetByIds(IList<int> regionIds)
    {
        return _appDbContext.Regions.Where(el => regionIds.Contains(el.Id));
    }
}