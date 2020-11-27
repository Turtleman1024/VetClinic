using Microsoft.AspNetCore.JsonPatch;
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
        Task<List<Owner>> SearchForOwnerAsync(string searchValue);
        Task<Owner> UpdateOwnerAsync(int ownerId, JsonPatchDocument<Owner> ownerPatch);
        Task<bool> DeleteOwnerByIdAsync(int ownerId);

        Task<Patient> GetPatientByIdAsync(int patientId);
        Task<List<Patient>> GetPatientsByOwnerIdAsync(int ownerId);
        Task<List<Patient>> GetPatientsNameAsync(string name);
        Task<List<Patient>> GetActivePatientsAsync();
        Task<Patient> CreatePatientAsync(int patientId, Patient newPatient);
        Task<Patient> UpdatePatientAsync(int patientId, JsonPatchDocument<Patient> patientPatch);
        Task<bool> DeletePatientByIdAsync(int patientId);
    }
}
