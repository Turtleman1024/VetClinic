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
            if(owners == null)
            {
                return NotFound();
            }

            return Ok(owners);
        }

        [HttpGet(ApiRoutes.Owners.GetOwnerById)]
        public async Task<IActionResult> GetOwnerByIdAync(int ownerId)
        {
            var owners = await _vetClinic.GetOwnerByIdAsync(ownerId);
            if (owners == null)
            {
                return NotFound();
            }

            return Ok(owners);
        }

        #endregion

        #region Patient
        [HttpGet(ApiRoutes.Patients.GetAllPatients)]
        public IActionResult GetAllPatients()
        {
            var patients = _vetClinic.GetAllPatientsAsync();
            if(patients == null)
            {
                return NotFound();
            }

            return Ok(patients);
        }
        #endregion
    }
}
