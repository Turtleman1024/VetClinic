using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VetClinic.DomainModels;

namespace VetClinic.Data.Interfaces
{
    public interface IVetClinicStore
    {
        Task<List<Owner>> GetAllOwnersAsync();
        Task<Owner> GetOwnerByIdAsync(int ownerId);
        Task<List<Patient>> GetPatientsByOwnerIdAsync(int ownerId);
        Task<int> CreateOwnerAsync(Owner newOwner);
        Task UpdateOwnerAsync(Owner ownerPatch);
        Task<List<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int patientId);
        Task<bool> DeleteOwnerByIdAsync(int ownerId);
        Task<int> CreatePatientAsync(int ownerId, Patient newPatient);
        Task UpdatePatientAsync(Patient patientPatch);
    }
}
