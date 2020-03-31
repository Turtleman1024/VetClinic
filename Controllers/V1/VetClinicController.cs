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
        [HttpGet(ApiRoutes.Owners.GetAllOwners)]
        public async Task<IActionResult> GetAllOwnersAsync()
        {
            var owners = await _vetClinic.GetAllOwnersAsync();
            if(((owners?.Count ?? 0) == 0))
            {
                return NotFound("Could not find any Owners");
            }

            return Ok(owners);
        }

        [HttpGet(ApiRoutes.Owners.GetOwnerById)]
        public async Task<IActionResult> GetOwnerByIdAync(int ownerId)
        {
            var owners = await _vetClinic.GetOwnerByIdAsync(ownerId);
            if (owners == null)
            {
                return NotFound($"Could not find Owner Id: {ownerId}");
            }

            return Ok(owners);
        }

        [HttpPost(ApiRoutes.Owners.CreateOwner)]
        public async Task<IActionResult> CreateOwnerAsync([FromBody] Owner newOwner)
        {
            var owner = await _vetClinic.CreateOwnerAsync(newOwner);
            
            if(owner == null)
            {
                return BadRequest("Could not Create Owner");
            }

            return Ok(owner);
        }

        [HttpPatch(ApiRoutes.Owners.UpdateOwner)]
        public async Task<IActionResult> UpdateOwnerAsync([FromBody] Owner ownerPatch)
        {
            var owner = await _vetClinic.PatchOwnerAsync(ownerPatch);

            if(owner == null)
            {
                return BadRequest($"Could not Patch Owner with Id: {ownerPatch.OwnerId}");
            }

            return Ok(owner);
        }

        #endregion

        #region Patient
        [HttpGet(ApiRoutes.Patients.GetAllPatients)]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _vetClinic.GetAllPatientsAsync();
            if(((patients?.Count ?? 0) == 0))
            {
                return NotFound("Could not find any Patients");
            }

            return Ok(patients);
        }

        [HttpGet(ApiRoutes.Patients.GetPatientById)]
        public async Task<IActionResult> GetPatientByIdAsync(int patientId)
        {
            var patient = await _vetClinic.GetPatientByIdAsync(patientId);
            if (patient == null)
            {
                return NotFound($"Could not find Patients Id: {patientId}");
            }

            return Ok(patient);
        }

        [HttpGet(ApiRoutes.Patients.GetPatientByOwnerId)]
        public async Task<IActionResult> GetPatientsByOwnerIdAsync(int ownerId)
        {
            var patients = await _vetClinic.GetPatientsByOwnerIdAsync(ownerId);
            if ((patients?.Count ?? 0) == 0)
            {
                return NotFound($"Could not find Patients for Owner Id: {ownerId}");
            }

            return Ok(patients);
        }
        #endregion
    }
}
