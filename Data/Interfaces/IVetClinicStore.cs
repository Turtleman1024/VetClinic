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
        Task<int> CreateOwnerAsync(Owner newOwner);
        Task UpdateOwnerAsync(Owner ownerPatch);
        Task<bool> DeleteOwnerByIdAsync(int ownerId);
        Task<List<Owner>> SearchForOwnerAsync(string seaerchValue);

        Task<List<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int patientId);
        Task<List<Patient>> GetPatientsByOwnerIdAsync(int ownerId);
        Task<List<Patient>> GetActivePatientsAsync();
        Task<int> CreatePatientAsync(Patient newPatient);
        Task UpdatePatientAsync(Patient patientPatch);
        Task<bool> DeletePatientByIdAsync(int patientId);
        Task<List<Patient>> GetPatientsNameAsync(string name);
    }
}
