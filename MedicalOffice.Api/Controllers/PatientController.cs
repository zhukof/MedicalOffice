using MedicalOffice.Api.Factories;
using MedicalOffice.Api.Models;
using MedicalOffice.Api.Models.Dtos;
using MedicalOffice.Api.Models.Requests;
using MedicalOffice.DAL.Models;
using MedicalOffice.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalOffice.Api.Controllers;

public class PatientController : BaseController
{
    private readonly IPatientModelFactory _patientModelFactory;
    private readonly IPatientService _patientService;

    public PatientController(IPatientModelFactory patientModelFactory,
        IPatientService patientService)
    {
        _patientModelFactory = patientModelFactory;
        _patientService = patientService;
    }

    [HttpPost("GetPatients")]
    public IActionResult GetPatients(PagingInfo pagingInfo)
    {
        try
        {
            return Ok(_patientModelFactory.GetAll(pagingInfo));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return BadRequest(exception);
        }
    }

    [HttpGet("GetPatient")]
    public async Task<IActionResult> GetPatient(int id)
    {
        try
        {
            var patientDto = await _patientModelFactory.GetByIdAsync(id);

            if (patientDto == null)
            {
                return NotFound();
            }

            return Ok(patientDto);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return BadRequest(exception);
        }
    }

    [HttpPost("CreatePatient")]
    public async Task<IActionResult> CreatePatient(PatientCreateRequest request)
    {
        try
        {
            var patient = new Patient();

            await CreateOrUpdatePatient(request, patient);

            return Ok(await _patientModelFactory.GetByIdAsync(patient.Id));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return BadRequest(exception);
        }
    }

    [HttpPost("UpdatePatient")]
    public async Task<IActionResult> UpdatePatient(PatientCreateRequest request)
    {
        try
        {
            var patient = await _patientService.GetByIdAsync(request.Id);

            if (patient == null)
            {
                return NotFound();
            }

            await CreateOrUpdatePatient(request, patient);

            return Ok(await _patientModelFactory.GetByIdAsync(patient.Id));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return BadRequest(exception);
        }
    }

    [HttpDelete("RemovePatient")]
    public async Task<IActionResult> RemovePatient(int id)
    {
        try
        {
            var patient = await _patientService.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            await _patientService.RemoveAsync(patient);

            return Ok();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return BadRequest(exception);
        }
    }

    private async Task CreateOrUpdatePatient(PatientCreateRequest request, Patient patient)
    {
        patient.FirstName = request.FirstName;
        patient.LastName = request.LastName;
        patient.SecondName = request.SecondName;

        patient.Address = request.Address;
        patient.Gender = request.Gender;
        patient.DateOfBirth = request.DateOfBirth;

        await _patientService.CreateOrUpdateAsync(patient);
        await _patientService.UpdatePatientRegionAsync(patient, request.RegionIds);
    }
}