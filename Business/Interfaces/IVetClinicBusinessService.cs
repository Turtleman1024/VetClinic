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
        Task<List<Patient>> GetAllPatientsAsync();

        Task<Owner> GetOwnerByIdAsync(int ownerId);
        Task<Owner> CreateOwnerAsync(Owner newOwner);
        Task<Owner> UpdateOwnerAsync(Owner ownerPatch);
        Task<Patient> GetPatientByIdAsync(int patientId);
        Task<List<Patient>> GetPatientsByOwnerIdAsync(int ownerId);
        Task<bool> DeleteOwnerByIdAsync(int ownerId);
        Task<Patient> CreatePatientAsync(int ownerId, Patient newPatient);
        Task<Patient> UpdatePatientAsync(Patient patientPatch);
    }
}
