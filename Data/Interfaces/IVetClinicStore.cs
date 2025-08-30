using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VetClinic.DomainModels;

namespace VetClinic.Data.Interfaces;

public interface IVetClinicStore
{
    /// <summary>
    /// Retrieves all owner records from the data store.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task<List<Owner>> GetAllOwnersAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a specific owner by their unique identifier.
    /// </summary>
    /// <param name="ownerId">The unique ID of the owner.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task<Owner> GetOwnerByIdAsync(int ownerId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new owner record in the data store.
    /// </summary>
    /// <param name="newOwner">The owner entity to create.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>The unique ID of the newly created owner.</returns>
    Task<int> CreateOwnerAsync(Owner newOwner, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing owner record with new information.
    /// </summary>
    /// <param name="ownerPatch">The owner entity containing updated fields.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task UpdateOwnerAsync(Owner ownerPatch, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an owner record by its unique identifier.
    /// </summary>
    /// <param name="ownerId">The unique ID of the owner to delete.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>True if the owner was deleted; otherwise, false.</returns>
    Task<bool> DeleteOwnerByIdAsync(int ownerId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Searches for owners matching the specified search value.
    /// </summary>
    /// <param name="seaerchValue">The value to search for in owner records.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task<List<Owner>> SearchForOwnerAsync(string seaerchValue, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all patient records from the data store.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task<List<Patient>> GetAllPatientsAsync(CancellationToken cancellationToken = default);

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
    /// Retrieves all active patient records.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task<List<Patient>> GetActivePatientsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new patient record in the data store.
    /// </summary>
    /// <param name="newPatient">The patient entity to create.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>The unique ID of the newly created patient.</returns>
    Task<int> CreatePatientAsync(Patient newPatient, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing patient record with new information.
    /// </summary>
    /// <param name="patientPatch">The patient entity containing updated fields.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task UpdatePatientAsync(Patient patientPatch, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a patient record by its unique identifier.
    /// </summary>
    /// <param name="patientId">The unique ID of the patient to delete.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>True if the patient was deleted; otherwise, false.</returns>
    Task<bool> DeletePatientByIdAsync(int patientId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves patients whose names match the specified value.
    /// </summary>
    /// <param name="name">The name to search for in patient records.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task<List<Patient>> GetPatientsNameAsync(string name, CancellationToken cancellationToken = default);
}
