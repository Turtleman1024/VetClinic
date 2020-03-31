using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VetClinic.Data.Interfaces;
using VetClinic.DomainModels;

namespace VetClinic.Data.MsSqlStore
{
    public class VetClinicMsSqlStore : IVetClinicStore
    {
        private readonly IConfiguration _configuration;

        public VetClinicMsSqlStore(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        private async Task<SqlConnection> GetConnectionAsync()
        {
            var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await sqlConnection.OpenAsync();
            return sqlConnection;
        }

        public async Task<List<Owner>> GetAllOwnersAsync()
        {
            var owners = new List<Owner>(); 
            using (SqlConnection cn = await GetConnectionAsync())
            {
                owners = (await cn.QueryAsync<Owner>("dbo.SpGetOwners", null, commandTimeout: 0, commandType: CommandType.StoredProcedure)).ToList();
            }

            return owners;
        }

        public async Task<Owner> GetOwnerByIdAsync(int ownerId)
        {
            var owner = new Owner();
            using (SqlConnection cn = await GetConnectionAsync())
            {
                var p = new DynamicParameters(new { OwnerId = ownerId });

                owner = (await cn.QueryAsync<Owner>("dbo.SpGetOwnerById", p, commandTimeout: 0, commandType: CommandType.StoredProcedure)).FirstOrDefault();
            }

            return owner;
        }

        public async Task<int> CreateOwnerAsync(Owner newOwner)
        {
            int ownerId = 0;

            using (SqlConnection cn = await GetConnectionAsync())
            {
                var p = new DynamicParameters(new 
                {
                    OwnerFirstName = newOwner.OwnerFirstName,
                    OwnerLastName = newOwner.OwnerLastName,
                    OwnerAddress = newOwner.OwnerAddress,
                    OwnerCity = newOwner.OwnerCity,
                    OwnerState = newOwner.OwnerState,
                    OwnerZip = newOwner.OwnerZip,
                    OwnerPhone = newOwner.OwnerPhone
                });

                p.Add("@OwnerId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await cn.QueryAsync<int>("dbo.SpCreateOwner", p, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                ownerId = p.Get<int>("@OwnerId");
            }

            return ownerId;
        }

        public async Task PatchOwnerAsync(Owner ownerPatch)
        {
            using (SqlConnection cn = await GetConnectionAsync())
            {
                var p = new DynamicParameters(new
                { 
                    OwnerId = ownerPatch.OwnerId,
                    OwnerFirstName = ownerPatch.OwnerFirstName,
                    OwnerLastName = ownerPatch.OwnerLastName,
                    OwnerAddress = ownerPatch.OwnerAddress,
                    OwnerCity = ownerPatch.OwnerCity,
                    OwnerState = ownerPatch.OwnerState,
                    OwnerZip = ownerPatch.OwnerZip,
                    OwnerPhone = ownerPatch.OwnerPhone
                });

                await cn.ExecuteAsync("dbo.SpUpdateOwner", p, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<List<Patient>> GetPatientsByOwnerIdAsync(int ownerId)
        {
            var patients = new List<Patient>();

            using (SqlConnection cn = await GetConnectionAsync())
            {
                var p = new DynamicParameters(new { OwnerId = ownerId });

                patients = (await cn.QueryAsync<Patient>("dbo.SpGetPatientsByOwnerId", p, commandTimeout: 0, commandType: CommandType.StoredProcedure)).ToList();
            }

            return patients;
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            var patients = new List<Patient>();
            using (SqlConnection cn = await GetConnectionAsync())
            {
                patients = (await cn.QueryAsync<Patient>("dbo.SpGetPatients", null, commandTimeout: 0, commandType: CommandType.StoredProcedure)).ToList();
            }
            return patients;
        }

        public async Task<Patient> GetPatientByIdAsync(int patientId)
        {
            var patient = new Patient();
            using (SqlConnection cn = await GetConnectionAsync())
            {
                var p = new DynamicParameters(new { PatientId = patientId });

                patient = (await cn.QueryAsync<Patient>("dbo.SpGetPatientById", p, commandTimeout: 0, commandType: CommandType.StoredProcedure)).FirstOrDefault();
            }

            return patient;
        }
    }
}
