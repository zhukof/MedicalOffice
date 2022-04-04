using MedicalOffice.Api.DtoModels;
using MedicalOffice.Api.Factories;
using MedicalOffice.Api.Models;
using MedicalOffice.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalOffice.Api.Controllers;

public class DoctorController : BaseController
{
    private readonly IDoctorModelFactory _doctorModelFactory;
    private readonly IDoctorService _doctorService;
    private readonly ICabinetService _cabinetService;
    private readonly ISpecializationService _specializationService;
    private readonly IRegionService _regionService;

    public DoctorController(
        IDoctorModelFactory doctorModelFactory,
        IDoctorService doctorService,
        ICabinetService cabinetService,
        ISpecializationService specializationService,
        IRegionService regionService)
    {
        _doctorModelFactory = doctorModelFactory;
        _doctorService = doctorService;
        _cabinetService = cabinetService;
        _specializationService = specializationService;
        _regionService = regionService;
    }
    
    [HttpPost("GetDoctors")]
    public async Task<IList<DoctorDto>> GetDoctors(ParameterListModel parameterListModel)
    {
        return await _doctorModelFactory.GetAllAsync(parameterListModel);
    }
    
    [HttpGet("GetDoctor")]
    public async Task<IActionResult> Get(int id)
    {
        var doctor = await _doctorModelFactory.GetByIdAsync(id);
        if (doctor == null)
        {
            return NotFound();
        }
        
        return Ok(doctor);
    }
    
    [HttpPost("UpdateDoctor")]
    public async Task<IActionResult> UpdateDoctor(DoctorDto doctorDto)
    {
        var doctor = await _doctorService.GetByIdAsync(doctorDto.Id);
        if (doctor == null)
        {
            return NotFound();
        }

        doctor.FirstName = doctorDto.FirstName;
        doctor.LastName = doctorDto.LastName;
        doctor.SecondName = doctorDto.SecondName;

        if (doctor.CabinetId != doctorDto.CabinetId)
        {
            var cabinet = await _cabinetService.GetByIdAsync(doctorDto.CabinetId);
            doctor.CabinetId = cabinet.Id;
        }
        
        if (doctor.SpecializationId != doctorDto.SpecializationId)
        {
            var specialization = await _specializationService.GetByIdAsync(doctorDto.SpecializationId);
            doctor.SpecializationId = specialization.Id;
        }

        if (doctorDto.RegionId.HasValue)
        {
            var region = await _regionService.GetByIdAsync(doctorDto.RegionId.Value);
            doctor.RegionId = region.Id;
        }
        else
        {
            doctor.RegionId = null;
        }
        

        await _doctorService.UpdateAsync(doctor);
        
        return Ok(await _doctorModelFactory.GetByIdAsync(doctor.Id));
    }
    
    [HttpDelete("RemoveDoctor")]
    public async Task<IActionResult> RemoveDoctor(int id)
    {
        var doctor = await _doctorService.GetByIdAsync(id);
        if (doctor == null)
        {
            return NotFound();
        }
        
        await _doctorService.UpdateAsync(doctor);

        return Ok();
    }
}