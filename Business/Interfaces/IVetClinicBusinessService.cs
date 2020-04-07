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
        Task<List<Owner>> GetOwnersByLastNameAsync(string lastName);
        Task<Owner> UpdateOwnerAsync(Owner ownerPatch);
        Task<bool> DeleteOwnerByIdAsync(int ownerId);

        Task<Patient> GetPatientByIdAsync(int patientId);
        Task<List<Patient>> GetPatientsByOwnerIdAsync(int ownerId);
        Task<List<Patient>> GetPatientsByLastNameAsync(string name);
        Task<Patient> CreatePatientAsync(int ownerId, Patient newPatient);
        Task<Patient> UpdatePatientAsync(Patient patientPatch);
        Task<bool> DeletePatientByIdAsync(int patientId);
    }
}
