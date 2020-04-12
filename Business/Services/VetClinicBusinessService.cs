using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VetClinic.Data.Interfaces;
using VetClinic.DomainModels;

namespace VetClinic.Business
{
    public class VetClinicBusinessService : IVetClinicBusinessService
    {
        private readonly IVetClinicStore _vetClinicStore;
        
        public VetClinicBusinessService(IVetClinicStore vetClinicStore)
        {
            _vetClinicStore = vetClinicStore ?? throw new ArgumentNullException(nameof(vetClinicStore));
        }

        #region Owner
        public async Task<List<Owner>> GetAllOwnersAsync()
        {
            var owners = await _vetClinicStore.GetAllOwnersAsync();
            foreach (var owner in owners)
            {
                owner.OwnerPets = await _vetClinicStore.GetPatientsByOwnerIdAsync(owner.OwnerId);
            }
            return owners;
        }

        public async Task<Owner> GetOwnerByIdAsync(int ownerId)
        {
            var owner = await _vetClinicStore.GetOwnerByIdAsync(ownerId);
            
            if(owner != null)
            {
                owner.OwnerPets = await _vetClinicStore.GetPatientsByOwnerIdAsync(ownerId);
            }
            
            return owner;
        }

        public async Task<List<Owner>> GetOwnersByLastNameAsync(string lastName)
        {
            var owners = await _vetClinicStore.GetOwnersByLastNameAsync(lastName);

            if(((owners?.Count ?? 0) != 0))
            {
                foreach (var owner in owners)
                {
                    owner.OwnerPets = await _vetClinicStore.GetPatientsByOwnerIdAsync(owner.OwnerId);
                }
            }
            return owners;
        }

        public async Task<Owner> CreateOwnerAsync(Owner newOwner)
        {
            var ownerId = await _vetClinicStore.CreateOwnerAsync(newOwner);

            var owner = await _vetClinicStore.GetOwnerByIdAsync(ownerId);

            return owner;
        }

        public async Task<Owner> UpdateOwnerAsync(int ownerId, JsonPatchDocument<Owner> ownerPatch)
        {
            var owner = await _vetClinicStore.GetOwnerByIdAsync(ownerId);

            if(owner == null)
            {
                return owner;
            }

            ownerPatch.ApplyTo(owner);

            await _vetClinicStore.UpdateOwnerAsync(owner);

            owner = await  _vetClinicStore.GetOwnerByIdAsync(ownerId);

            owner.OwnerPets = await _vetClinicStore.GetPatientsByOwnerIdAsync(ownerId);

            return owner;
        }

        public async Task<bool> DeleteOwnerByIdAsync(int ownerId)
        {
            var deleted = await _vetClinicStore.DeleteOwnerByIdAsync(ownerId);

            return deleted;
        }

        #endregion

        #region Patient
        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            var patients = await _vetClinicStore.GetAllPatientsAsync();

            return patients;
        }

        public async Task<Patient> GetPatientByIdAsync(int patientId)
        {
            var patient = await _vetClinicStore.GetPatientByIdAsync(patientId);
            return patient;
        }

        public async Task<List<Patient>> GetPatientsByLastNameAsync(string name)
        {
            var patients = await _vetClinicStore.GetPatientsByLastNameAsync(name);

            return patients;
        }

        public async Task<List<Patient>> GetPatientsByOwnerIdAsync(int ownerId)
        {
            var patients = await _vetClinicStore.GetPatientsByOwnerIdAsync(ownerId);
            return patients;
        }

        public async Task<Patient> CreatePatientAsync(int ownerId, Patient newPatient)
        {
            var patientId = await _vetClinicStore.CreatePatientAsync(ownerId, newPatient);

            var patient = await _vetClinicStore.GetPatientByIdAsync(patientId);

            return patient;
        }

        public async Task<Patient> UpdatePatientAsync(int patientId, JsonPatchDocument<Patient> patientPatch)
        {
            var patient = await _vetClinicStore.GetPatientByIdAsync(patientId);

            if (patient == null)
            {
                return patient;
            }

            patientPatch.ApplyTo(patient);

            await _vetClinicStore.UpdatePatientAsync(patient);

            patient = await _vetClinicStore.GetPatientByIdAsync(patientId);            

            return patient;
        }

        public async Task<bool> DeletePatientByIdAsync(int patientId)
        {
            var deleted = await _vetClinicStore.DeletePatientByIdAsync(patientId);

            return deleted;
        }
        #endregion
    }
}
