using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinic.DomainModels
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string OwnerAddress { get; set; }
        public string OwnerCity { get; set; }
        public string OwnerState { get; set; }
        public int OwnerZip { get; set; }
        public string OwnerPhone { get; set; }
        public bool IsActive { get; set; }
        public List<Patient> OwnerPets { get; set; }
    }
}
