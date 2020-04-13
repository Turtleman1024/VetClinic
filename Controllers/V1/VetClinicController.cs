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
        /// <summary>
        /// Asynchronously get all active owners
        /// </summary>
        /// <returns>List of active owners</returns>
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

        /// <summary>
        /// Asynchronously get owner by id
        /// </summary>
        /// <param name="ownerId">The owner id</param>
        /// <returns>The owner</returns>
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

        /// <summary>
        /// Asynchronously search for owners by last name
        /// </summary>
        /// <param name="lastName">Last Name to search for</param>
        /// <returns>List of owners</returns>
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

        /// <summary>
        /// Asynchronously create a new owner
        /// NOTE: Think this workflow will have to be change 
        /// </summary>
        /// <param name="newOwner">The new owner</param>
        /// <returns>The created owner </returns>
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

        /// <summary>
        /// Asynchronously update owner information
        /// </summary>
        /// <param name="ownerId">The current owner Id</param>
        /// <param name="ownerPatch">The field to patch</param>
        /// <returns>The patched owner</returns>
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

        /// <summary>
        /// Asynchronously set a owner to inactive
        /// </summary>
        /// <param name="ownerId">The current owner id</param>
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
        /// <summary>
        /// Asynchronously get all patients
        /// </summary>
        /// <returns>List of patients</returns>
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

        /// <summary>
        /// Asynchronously get patient by id
        /// </summary>
        /// <param name="patientId">The patient id</param>
        /// <returns>The current patient</returns>
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

        /// <summary>
        /// Asynchronously create a new patient
        /// NOTE: Think this workflow will have to be changed
        /// </summary>
        /// <param name="ownerId">The </param>
        /// <param name="newPatient"></param>
        /// <returns>The newly created patient</returns>
        [HttpPost, Route(ApiRoutes.Patients.CreatePatient, Name = "CreatePatientAsync")]
        public async Task<IActionResult> CreatePatientAsync(int patientId, [FromBody] Patient newPatient)
        {
            var patient = await _vetClinic.CreatePatientAsync(patientId, newPatient);
            if(patient == null)
            {
                return BadRequest("Could not Create Patient");
            }

            return Ok(patient);
        }

        /// <summary>
        /// Asynchronously update patient information
        /// </summary>
        /// <param name="patientId">The current patient id</param>
        /// <param name="patientPatch">The field to patch</param>
        /// <returns>The patched patient</returns>
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

        /// <summary>
        /// Asynchronously set a patient to inactive
        /// NOTE: Future will need to figure out business logic of how to handle deceased pets information
        /// </summary>
        /// <param name="patientId">The patient Id</param>
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
