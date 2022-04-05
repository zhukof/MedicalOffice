using MedicalOffice.Api.Factories;
using MedicalOffice.Api.Models;
using MedicalOffice.Api.Models.Dtos;
using MedicalOffice.Api.Models.Requests;
using MedicalOffice.DAL.Models;
using MedicalOffice.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalOffice.Api.Controllers;

public class DoctorController : BaseController
{
    private readonly IDoctorModelFactory _doctorModelFactory;
    private readonly IDoctorService _doctorService;

    public DoctorController(
        IDoctorModelFactory doctorModelFactory,
        IDoctorService doctorService)
    {
        _doctorModelFactory = doctorModelFactory;
        _doctorService = doctorService;
    }
    
    [HttpPost("GetDoctors")]
    public IActionResult GetDoctors(PagingInfo pagingInfo)
    {
        try
        {
            return Ok(_doctorModelFactory.GetAll(pagingInfo));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return BadRequest(exception);
        }
    }
    
    [HttpGet("GetDoctor")]
    public async Task<IActionResult> GetDoctor(int id)
    {
        try
        {
            var doctor = await _doctorModelFactory.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
        
            return Ok(doctor);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return BadRequest(exception);
        }
    }
    
    [HttpPost("CreateDoctor")]
    public async Task<IActionResult> CreateDoctor(DoctorCreateRequest request)
    {
        try
        {
            var doctor = new Doctor();
        
            await CreateOrUpdateDoctor(request, doctor);
        
            return Ok(await _doctorModelFactory.GetByIdAsync(doctor.Id));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return BadRequest(exception);
        }
    }
    
    [HttpPost("UpdateDoctor")]
    public async Task<IActionResult> UpdateDoctor(DoctorCreateRequest request)
    {
        try
        {
            var doctor = await _doctorService.GetByIdAsync(request.Id);
            if (doctor == null)
            {
                return NotFound();
            }

            await CreateOrUpdateDoctor(request, doctor);

            return Ok(await _doctorModelFactory.GetByIdAsync(doctor.Id));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return BadRequest(exception);
        }
    }

    [HttpDelete("RemoveDoctor")]
    public async Task<IActionResult> RemoveDoctor(int id)
    {
        try
        {
            var doctor = await _doctorService.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
        
            await _doctorService.RemoveAsync(doctor);

            return Ok();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return BadRequest(exception);
        }
    }
    
    private async Task CreateOrUpdateDoctor(DoctorCreateRequest request, Doctor doctor)
    {
        doctor.FirstName = request.FirstName;
        doctor.LastName = request.LastName;
        doctor.SecondName = request.SecondName;

        await _doctorService.CreateOrUpdateAsync(doctor, request.CabinetId, request.SpecializationId, request.RegionId);
    }
}