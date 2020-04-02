using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinic.DomainModels
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientSpecies { get; set; }
        public char PatientGender { get; set; }
        public DateTime PatientBirthDate { get; set; }
        public string PatientNotes { get; set; }
        public int OwnerId { get; set; }
        public bool IsActive { get; set; }
    }
}
