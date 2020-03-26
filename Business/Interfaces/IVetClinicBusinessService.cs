using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinic.DomainModels;

namespace VetClinic.Business
{
    public interface IVetClinicBusinessService
    {
        Task<List<Owner>> GetAllOwnersAsync();
        List<Patient> GetAllPatientsAsync();

        Task<Owner> GetOwnerByIdAsync(int ownerId);
        Task<Owner> CreateOwnerAsync(Owner newOwner);
        Task<Owner> PatchOwnerAsync(Owner ownerPatch);
    }
}
