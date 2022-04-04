using MedicalOffice.Api.DtoModels;
using MedicalOffice.Api.Factories;
using MedicalOffice.DAL.Models;
using MedicalOffice.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalOffice.Api.Controllers;

public class PatientController : BaseController
{
    private readonly IPatientModelFactory _patientModelFactory;
    private readonly IPatientService _patientService;

    public PatientController(IPatientModelFactory patientModelFactory, IPatientService patientService)
    {
        _patientModelFactory = patientModelFactory;
        _patientService = patientService;
    }
    
    [HttpPost("GetPatients")]
    public async Task<IList<PatientDto>> GetPatients()
    {
        return await _patientModelFactory.GetAllAsync();
    }
    
    [HttpGet("GetPatient")]
    public async Task<IActionResult> GetPatient(int id)
    {
        var patientDto = await _patientModelFactory.GetByIdAsync(id);
        
        if (patientDto == null)
        {
            return NotFound();
        }
        
        return Ok(patientDto);
    }
    
    [HttpPost("UpdatePatient")]
    public async Task<IActionResult> UpdatePatient(PatientDto patientDto)
    {
        var patient = await _patientService.GetByIdAsync(patientDto.Id);
        
        if (patient == null)
        {
            return NotFound();
        }

        patient.FirstName = patient.FirstName;
        patient.LastName = patient.LastName;
        patient.SecondName = patient.SecondName;
        
        patient.Address = patient.Address;
        patient.Gender = patient.Gender;
        patient.DateOfBirth = patient.DateOfBirth;
        
        return Ok(patient);
    }
    
    [HttpDelete("RemovePatient")]
    public async Task RemovePatient(int id)
    {
        
        
        await _patientService.UpdateAsync(new Patient());
    }
}