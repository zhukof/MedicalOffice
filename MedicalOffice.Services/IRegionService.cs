using System.Linq;
using System.Threading.Tasks;
using MedicalOffice.DAL.Models;

namespace MedicalOffice.Services;

public interface IRegionService
{
    IQueryable<Region> Table();
    Task<Region> GetByIdAsync(int id);
}