using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinic.Controllers
{
    public class VetClinicController : Controller
    {
        [HttpGet("api/name")]
        public IActionResult Get()
        {
            return Ok(new { name = "Turtleman's Vet Clinic" });
        }
    }
}
