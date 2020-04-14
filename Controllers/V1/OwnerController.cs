using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using VetClinic.Business;
using VetClinic.Contracts;
using VetClinic.DomainModels;

namespace VetClinic.Controllers.V1
{
    public class OwnerController : ControllerBase
    {

        private readonly IVetClinicBusinessService _vetClinic;

        public OwnerController(IVetClinicBusinessService vetClinic)
        {
            _vetClinic = vetClinic ?? throw new ArgumentNullException(nameof(vetClinic));
        }


        #region Owner
        /// <summary>
        /// Asynchronously get all active owners
        /// </summary>
        /// <returns>List of active owners</returns>
        [HttpGet, Route(ApiRoutes.Owners.GetAllOwners, Name = "GetAllOwnersAsync")]
        public async Task<IActionResult> GetAllOwnersAsync()
        {
            var owners = await _vetClinic.GetAllOwnersAsync();
            if (((owners?.Count ?? 0) == 0))
            {
                return NotFound("Could not find any Owners");
            }

            return Ok(owners);
        }

        /// <summary>
        /// Asynchronously get owner by id
        /// </summary>
        /// <param name="ownerId">The owner id</param>
        /// <returns>The owner</returns>
        [HttpGet, Route(ApiRoutes.Owners.GetOwnerById, Name = "GetOwnerByIdAync")]
        public async Task<IActionResult> GetOwnerByIdAync(int ownerId)
        {
            var owner = await _vetClinic.GetOwnerByIdAsync(ownerId);
            if (owner == null)
            {
                return NotFound($"Could not find Owner Id: {ownerId}");
            }

            return Ok(owner);
        }

        /// <summary>
        /// Asynchronously search for owners by last name
        /// </summary>
        /// <param name="lastName">Last Name to search for</param>
        /// <returns>List of owners</returns>
        [HttpGet, Route(ApiRoutes.Owners.GetOwnersByLastName, Name = "GetOwnersByLastNameAync")]
        public async Task<IActionResult> GetOwnersByLastNameAync(string lastName)
        {
            var owners = await _vetClinic.GetOwnersByLastNameAsync(lastName);
            if (owners == null)
            {
                return NotFound($"Could not find Owner with last name: {lastName}");
            }

            return Ok(owners);
        }

        /// <summary>
        /// Asynchronously create a new owner
        /// NOTE: Think this workflow will have to be change 
        /// </summary>
        /// <param name="newOwner">The new owner</param>
        /// <returns>The created owner </returns>
        [HttpPost, Route(ApiRoutes.Owners.CreateOwner, Name = "CreateOwnerAsync")]
        public async Task<IActionResult> CreateOwnerAsync([FromBody] Owner newOwner)
        {
            var owner = await _vetClinic.CreateOwnerAsync(newOwner);

            if (owner == null)
            {
                return BadRequest("Could not Create Owner");
            }

            return Ok(owner);
        }

        /// <summary>
        /// Asynchronously update owner information
        /// </summary>
        /// <param name="ownerId">The current owner Id</param>
        /// <param name="ownerPatch">The field to patch</param>
        /// <returns>The patched owner</returns>
        [HttpPatch, Route(ApiRoutes.Owners.UpdateOwner, Name = "UpdateOwnerAsync")]
        public async Task<IActionResult> UpdateOwnerAsync(int ownerId, [FromBody] JsonPatchDocument<Owner> ownerPatch)
        {
            if (ownerPatch?.Operations?.Count > 0)
            {
                var owner = await _vetClinic.UpdateOwnerAsync(ownerId, ownerPatch);
                if (owner != null)
                {
                    return Ok(owner);
                }
                return BadRequest($"Could not Patch Owner with Id: {ownerId}");
            }

            return BadRequest($"Could not Patch Owner with Id: {ownerId}");
        }

        /// <summary>
        /// Asynchronously set a owner to inactive
        /// </summary>
        /// <param name="ownerId">The current owner id</param>
        [HttpDelete, Route(ApiRoutes.Owners.DeleteOwner, Name = "DeleteOwnerByIdAsync")]
        public async Task<IActionResult> DeleteOwnerByIdAsync(int ownerId)
        {
            var deleted = await _vetClinic.DeleteOwnerByIdAsync(ownerId);

            if (deleted)
            {
                return Ok();
            }

            return NotFound("Owner has already been set to inactive or does not exist");

        }

        #endregion
    }
}