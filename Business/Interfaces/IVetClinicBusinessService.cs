using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VetClinic.DomainModels;

namespace VetClinic.Business.Interfaces;

public interface IVetClinicBusinessService
{
    /// <summary>
    /// Retrieves all owner records from the business service.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task<List<Owner>> GetAllOwnersAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all patient records from the business service.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task<List<Patient>> GetAllPatientsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a specific owner by their unique identifier.
    /// </summary>
    /// <param name="ownerId">The unique ID of the owner.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task<Owner> GetOwnerByIdAsync(int ownerId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new owner record.
    /// </summary>
    /// <param name="newOwner">The owner entity to create.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task<Owner> CreateOwnerAsync(Owner newOwner, CancellationToken cancellationToken = default);

    /// <summary>
    /// Searches for owners matching the specified search value.
    /// </summary>
    /// <param name="searchValue">The value to search for in owner records.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task<List<Owner>> SearchForOwnerAsync(string searchValue, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing owner record using a JSON patch document.
    /// </summary>
    /// <param name="ownerId">The unique ID of the owner to update.</param>
    /// <param name="ownerPatch">The patch document containing updated fields.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task<Owner> UpdateOwnerAsync(int ownerId, JsonPatchDocument<Owner> ownerPatch, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an owner record by its unique identifier.
    /// </summary>
    /// <param name="ownerId">The unique ID of the owner to delete.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>True if the owner was deleted; otherwise, false.</returns>
    Task<bool> DeleteOwnerByIdAsync(int ownerId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a specific patient by their unique identifier.
    /// </summary>
    /// <param name="patientId">The unique ID of the patient.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task<Patient> GetPatientByIdAsync(int patientId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all patients associated with a specific owner.
    /// </summary>
    /// <param name="ownerId">The unique ID of the owner.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task<List<Patient>> GetPatientsByOwnerIdAsync(int ownerId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves patients whose names match the specified value.
    /// </summary>
    /// <param name="name">The name to search for in patient records.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task<List<Patient>> GetPatientsNameAsync(string name, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all active patient records.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task<List<Patient>> GetActivePatientsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new patient record.
    /// </summary>
    /// <param name="newPatient">The patient entity to create.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task<Patient> CreatePatientAsync(Patient newPatient, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing patient record using a JSON patch document.
    /// </summary>
    /// <param name="patientId">The unique ID of the patient to update.</param>
    /// <param name="patientPatch">The patch document containing updated fields.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task<Patient> UpdatePatientAsync(int patientId, JsonPatchDocument<Patient> patientPatch, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a patient record by its unique identifier.
    /// </summary>
    /// <param name="patientId">The unique ID of the patient to delete.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>True if the patient was deleted; otherwise, false.</returns>
    Task<bool> DeletePatientByIdAsync(int patientId, CancellationToken cancellationToken = default);
}
