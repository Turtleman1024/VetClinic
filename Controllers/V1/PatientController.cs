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
    public class PatientController : Controller
    {
        private readonly IVetClinicBusinessService _vetClinic;

        public PatientController(IVetClinicBusinessService vetClinic)
        {
            _vetClinic = vetClinic ?? throw new ArgumentNullException(nameof(vetClinic));
        }

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
