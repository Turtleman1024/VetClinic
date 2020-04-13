using Microsoft.AspNetCore.JsonPatch;
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
            var owner = await _vetClinic.GetOwnerByIdAsync(ownerId);
            if (owner == null)
            {
                return NotFound($"Could not find Owner Id: {ownerId}");
            }

            return Ok(owner);
        }

        [HttpGet, Route(ApiRoutes.Owners.GetOwnersByLastName, Name = "GetOwnersByLastNameAync")]
        public async Task<IActionResult> GetOwnersByLastNameAync(string lastName)
        {
            var owners = await _vetClinic.GetOwnersByLastNameAsync(lastName);
            if (owners == null)
            {
                return NotFound($"Could not find Owner with last name: {lastName}");
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
        public async Task<IActionResult> UpdateOwnerAsync(int ownerId, [FromBody] JsonPatchDocument<Owner> ownerPatch)
        {
            if(ownerPatch?.Operations?.Count > 0)
            {
                var owner = await _vetClinic.UpdateOwnerAsync(ownerId, ownerPatch);
                if(owner != null)
                {
                    return Ok(owner);
                }
                return BadRequest($"Could not Patch Owner with Id: {ownerId}");
            }
            
            return BadRequest($"Could not Patch Owner with Id: {ownerId}");
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

        [HttpGet, Route(ApiRoutes.Patients.GetPatientsByName, Name = "GetPatientsByLastNameAync")]
        public async Task<IActionResult> GetPatientsNameAync(string name)
        {
            var patients = await _vetClinic.GetPatientsNameAsync(name);
            if (patients == null)
            {
                return NotFound($"Could not find Patient with name: {name}");
            }

            return Ok(patients);
        }

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
        [ProducesResponseType(typeof(Patient), 200)]
        public async Task<IActionResult> UpdatePatientAsync(int patientId, [FromBody] JsonPatchDocument<Patient> patientPatch)
        {
            if (patientPatch?.Operations?.Count > 0)
            {
                var patient = await _vetClinic.UpdatePatientAsync(patientId, patientPatch);
                if(patient != null)
                {
                    return Ok(patient);
                }
                return BadRequest($"Could not Patch Patient with Id: {patientId}");
            }

            return BadRequest($"Could not Patch Patient with Id: {patientId}");
        }

        [HttpDelete, Route(ApiRoutes.Patients.DeletePatient, Name = "DeletePatientAsync")]
        public async Task<IActionResult> DeletePatientAsync(int patientId)
        {
            var deleted = await _vetClinic.DeletePatientByIdAsync(patientId);

            if(deleted)
            {
                return Ok();
            }

            return NotFound("Patient has already been set to inactive or does not exist");
        }
        #endregion
    }
}
