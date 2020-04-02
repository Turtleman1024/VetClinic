using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinic.Business;
using VetClinic.Contracts;
using VetClinic.DomainModels;

namespace VetClinic.Controllers
{
    public class VetClinicController : Controller
    {
        private readonly IVetClinicBusinessService _vetClinic;

        public VetClinicController(IVetClinicBusinessService vetClinic)
        {
            _vetClinic = vetClinic ?? throw new ArgumentNullException(nameof(vetClinic));
        }

        #region Owner
        [HttpGet, Route(ApiRoutes.Owners.GetAllOwners, Name = "GetAllOwnersAsync")]
        public async Task<IActionResult> GetAllOwnersAsync()
        {
            var owners = await _vetClinic.GetAllOwnersAsync();
            if(((owners?.Count ?? 0) == 0))
            {
                return NotFound("Could not find any Owners");
            }

            return Ok(owners);
        }

        [HttpGet, Route(ApiRoutes.Owners.GetOwnerById, Name = "GetOwnerByIdAync")]
        public async Task<IActionResult> GetOwnerByIdAync(int ownerId)
        {
            var owners = await _vetClinic.GetOwnerByIdAsync(ownerId);
            if (owners == null)
            {
                return NotFound($"Could not find Owner Id: {ownerId}");
            }

            return Ok(owners);
        }

        [HttpPost, Route(ApiRoutes.Owners.CreateOwner, Name = "CreateOwnerAsync")]
        public async Task<IActionResult> CreateOwnerAsync([FromBody] Owner newOwner)
        {
            var owner = await _vetClinic.CreateOwnerAsync(newOwner);
            
            if(owner == null)
            {
                return BadRequest("Could not Create Owner");
            }

            return Ok(owner);
        }

        [HttpPatch, Route(ApiRoutes.Owners.UpdateOwner, Name = "UpdateOwnerAsync")]
        public async Task<IActionResult> UpdateOwnerAsync([FromBody] Owner ownerPatch)
        {
            var owner = await _vetClinic.UpdateOwnerAsync(ownerPatch);

            if(owner == null)
            {
                return BadRequest($"Could not Patch Owner with Id: {ownerPatch.OwnerId}");
            }

            return Ok(owner);
        }

        [HttpDelete, Route(ApiRoutes.Owners.DeleteOwner, Name = "DeleteOwnerByIdAsync")]
        public async Task<IActionResult> DeleteOwnerByIdAsync(int ownerId)
        {
            var deleted = await _vetClinic.DeleteOwnerByIdAsync(ownerId);

            if(deleted)
            {
                return Ok();
            }

            return NotFound("Owner has already been set to inactive or does not exist");

        }

        #endregion

        #region Patient
        [HttpGet, Route(ApiRoutes.Patients.GetAllPatients, Name = "GetAllPatientsAsync")]
        public async Task<IActionResult> GetAllPatientsAsync()
        {
            var patients = await _vetClinic.GetAllPatientsAsync();
            if(((patients?.Count ?? 0) == 0))
            {
                return NotFound("Could not find any Patients");
            }

            return Ok(patients);
        }

        [HttpGet, Route(ApiRoutes.Patients.GetPatientById, Name = "GetPatientByIdAsync")]
        public async Task<IActionResult> GetPatientByIdAsync(int patientId)
        {
            var patient = await _vetClinic.GetPatientByIdAsync(patientId);
            if (patient == null)
            {
                return NotFound($"Could not find Patients Id: {patientId}");
            }

            return Ok(patient);
        }

        //[HttpGet, Route(ApiRoutes.Patients.GetPatientByOwnerId, Name = "GetPatientsByOwnerIdAsync")]
        //public async Task<IActionResult> GetPatientsByOwnerIdAsync(int ownerId)
        //{
        //    var patients = await _vetClinic.GetPatientsByOwnerIdAsync(ownerId);
        //    if ((patients?.Count ?? 0) == 0)
        //    {
        //        return NotFound($"Could not find Patients for Owner Id: {ownerId}");
        //    }

        //    return Ok(patients);
        //}

        [HttpPost, Route(ApiRoutes.Patients.CreatePatient, Name = "CreatePatientAsync")]
        public async Task<IActionResult> CreatePatientAsync(int ownerId, [FromBody] Patient newPatient)
        {
            var patient = await _vetClinic.CreatePatientAsync(ownerId, newPatient);
            if(patient == null)
            {
                return BadRequest("Could not Create Patient");
            }

            return Ok(patient);
        }

        [HttpPatch, Route(ApiRoutes.Patients.UpdatePatient, Name = "UpdatePatientAsync")]
        public async Task<IActionResult> UpdatePatientAsync([FromBody] Patient patientPatch)
        {
            var patient = await _vetClinic.UpdatePatientAsync(patientPatch);

            if(patient == null)
            {
                return BadRequest($"Could not Patch Patient with Id: {patient.PatientId}");
            }

            return Ok(patient);
        }

        [HttpDelete, Route(ApiRoutes.Patients.DeletePatient, Name = "DeletePatientAsync")]
        public async Task<IActionResult> DeletePatientAsync(int patientId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
