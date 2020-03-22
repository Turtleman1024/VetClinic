using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinic.Contracts;
using VetClinic.DomainModels;

namespace VetClinic.Controllers
{
    public class VetClinicController : Controller
    {
        private List<Owner> _owners;
        private List<Patient> _patients;

        public VetClinicController()
        {
            _owners = new List<Owner>();
            _patients = new List<Patient>();
            for (int i = 1; i < 4; i++)
            {
                _owners.Add(new Owner {OwnerId = i });
                _patients.Add(new Patient {PatientId = i });
            }
        }
        #region Owner
        [HttpGet(ApiRoutes.Owners.GetAllOwners)]
        public IActionResult GetAllOwners()
        {
            return Ok(_owners);
        }
        #endregion

        #region Patient
        [HttpGet(ApiRoutes.Patients.GetAllPatients)]
        public IActionResult GetAllPatients()
        {
            return Ok(_patients);
        }
        #endregion
    }
}
