using System.Linq;
using System.Threading.Tasks;
using MedicalOffice.DAL;
using MedicalOffice.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalOffice.Services;

public class DoctorService : IDoctorService
{
    private readonly AppDbContext _appDbContext;
    private readonly ICabinetService _cabinetService;
    private readonly ISpecializationService _specializationService;
    private readonly IRegionService _regionService;

    public DoctorService(AppDbContext appDbContext, ICabinetService cabinetService, ISpecializationService specializationService, IRegionService regionService)
    {
        _appDbContext = appDbContext;
        _cabinetService = cabinetService;
        _specializationService = specializationService;
        _regionService = regionService;
    }

    public IQueryable<Doctor> Table()
    {
        return _appDbContext.Doctors;
    }

    public async Task<Doctor> GetByIdAsync(int id)
    {
        return await _appDbContext.Doctors.FirstOrDefaultAsync(el => el.Id == id);
    }

    public async Task<Doctor> CreateOrUpdateAsync(Doctor doctor, int cabinetId, int specializationId, int? regionId)
    {
        if (doctor.CabinetId != cabinetId)
        {
            var cabinet = await _cabinetService.GetByIdAsync(cabinetId);
            doctor.CabinetId = cabinet.Id;
        }
        
        if (doctor.SpecializationId != specializationId)
        {
            var specialization = await _specializationService.GetByIdAsync(specializationId);
            doctor.SpecializationId = specialization.Id;
        }

        if (regionId.HasValue)
        {
            var region = await _regionService.GetByIdAsync(regionId.Value);
            doctor.RegionId = region.Id;
        }
        else
        {
            doctor.RegionId = null;
        }
        
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