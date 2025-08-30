using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VetClinic.Business.Interfaces;
using VetClinic.Data.Interfaces;
using VetClinic.DomainModels;

namespace VetClinic.Business.Services;

public class VetClinicBusinessService : IVetClinicBusinessService
{
    private readonly IVetClinicStore _vetClinicStore;
    
    public VetClinicBusinessService(IVetClinicStore vetClinicStore)
    {
        _vetClinicStore = vetClinicStore ?? throw new ArgumentNullException(nameof(vetClinicStore));
    }

    #region Owner
    /// <inheritdoc />
    public async Task<List<Owner>> GetAllOwnersAsync(CancellationToken cancellationToken = default)
    {
        var owners = await _vetClinicStore.GetAllOwnersAsync(cancellationToken);
        foreach (var owner in owners)
        {
            owner.OwnerPets = await _vetClinicStore.GetPatientsByOwnerIdAsync(owner.OwnerId, cancellationToken);
        }
        return owners;
    }

    /// <inheritdoc />
    public async Task<Owner> GetOwnerByIdAsync(int ownerId, CancellationToken cancellationToken = default)
    {
        var owner = await _vetClinicStore.GetOwnerByIdAsync(ownerId, cancellationToken);
        
        if(owner != null)
        {
            owner.OwnerPets = await _vetClinicStore.GetPatientsByOwnerIdAsync(ownerId, cancellationToken);
        }
        
        return owner;
    }

    /// <inheritdoc />
    public async Task<List<Owner>> SearchForOwnerAsync(string searchValue, CancellationToken cancellationToken = default)
    {
        var owners = await _vetClinicStore.SearchForOwnerAsync(searchValue, cancellationToken);

        if (owners != null)
        {
            foreach (var owner in owners)
            {
                owner.OwnerPets = await _vetClinicStore.GetPatientsByOwnerIdAsync(owner.OwnerId, cancellationToken);
            }
        }

        return owners;
    }

    /// <inheritdoc />
    public async Task<Owner> CreateOwnerAsync(Owner newOwner, CancellationToken cancellationToken = default)
    {
        var ownerId = await _vetClinicStore.CreateOwnerAsync(newOwner, cancellationToken);

        var owner = await _vetClinicStore.GetOwnerByIdAsync(ownerId, cancellationToken);

        return owner;
    }

    /// <inheritdoc />
    public async Task<Owner> UpdateOwnerAsync(int ownerId, JsonPatchDocument<Owner> ownerPatch, CancellationToken cancellationToken = default)
    {
        var owner = await _vetClinicStore.GetOwnerByIdAsync(ownerId, cancellationToken);

        if(owner == null)
        {
            return owner;
        }

        ownerPatch.ApplyTo(owner);

        await _vetClinicStore.UpdateOwnerAsync(owner, cancellationToken);

        owner = await  _vetClinicStore.GetOwnerByIdAsync(ownerId, cancellationToken);

        owner.OwnerPets = await _vetClinicStore.GetPatientsByOwnerIdAsync(ownerId, cancellationToken);

        return owner;
    }

    /// <inheritdoc />
    public async Task<bool> DeleteOwnerByIdAsync(int ownerId, CancellationToken cancellationToken = default)
    {
        var deleted = await _vetClinicStore.DeleteOwnerByIdAsync(ownerId, cancellationToken);

        return deleted;
    }

    #endregion

    #region Patient
    /// <inheritdoc />
    public async Task<List<Patient>> GetAllPatientsAsync(CancellationToken cancellationToken = default)
    {
        var patients = await _vetClinicStore.GetAllPatientsAsync(cancellationToken);

        return patients;
    }

    /// <inheritdoc />
    public async Task<Patient> GetPatientByIdAsync(int patientId, CancellationToken cancellationToken = default)
    {
        var patient = await _vetClinicStore.GetPatientByIdAsync(patientId, cancellationToken);
        return patient;
    }

    /// <inheritdoc />
    public async Task<List<Patient>> GetPatientsNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var patients = await _vetClinicStore.GetPatientsNameAsync(name, cancellationToken);

        return patients;
    }

    /// <inheritdoc />
    public async Task<List<Patient>> GetPatientsByOwnerIdAsync(int ownerId, CancellationToken cancellationToken = default)
    {
        var patients = await _vetClinicStore.GetPatientsByOwnerIdAsync(ownerId, cancellationToken);
        return patients;
    }

    /// <inheritdoc />
    public async Task<List<Patient>> GetActivePatientsAsync(CancellationToken cancellationToken = default)
    {
        var patients = await _vetClinicStore.GetActivePatientsAsync(cancellationToken);
        return patients;
    }

    /// <inheritdoc />
    public async Task<Patient> CreatePatientAsync(Patient newPatient, CancellationToken cancellationToken = default)
    {
        var createdPatientid = await _vetClinicStore.CreatePatientAsync(newPatient, cancellationToken);

        var patient = await _vetClinicStore.GetPatientByIdAsync(createdPatientid, cancellationToken);

        return patient;
    }

    /// <inheritdoc />
    public async Task<Patient> UpdatePatientAsync(int patientId, JsonPatchDocument<Patient> patientPatch, CancellationToken cancellationToken = default)
    {
        var patient = await _vetClinicStore.GetPatientByIdAsync(patientId, cancellationToken);

        if (patient == null)
        {
            return patient;
        }

        patientPatch.ApplyTo(patient);

        await _vetClinicStore.UpdatePatientAsync(patient, cancellationToken);

        patient = await _vetClinicStore.GetPatientByIdAsync(patientId, cancellationToken);            

        return patient;
    }

    /// <inheritdoc />
    public async Task<bool> DeletePatientByIdAsync(int patientId, CancellationToken cancellationToken = default)
    {
        var deleted = await _vetClinicStore.DeletePatientByIdAsync(patientId, cancellationToken);

        return deleted;
    }
    #endregion
}
