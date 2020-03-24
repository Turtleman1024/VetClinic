using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
                owners = (await cn.QueryAsync<Owner>("dbo.SpGetOwners", null, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).ToList();
            }

            return owners;
        }

        public async Task<Owner> GetOwnerByIdAsync(int ownerId)
        {
            var owner = new Owner();
            using (SqlConnection cn = await GetConnectionAsync())
            {
                var p = new DynamicParameters(new { OwnerId = ownerId });

                owner = (await cn.QueryAsync<Owner>("dbo.SpGetOwnerById", p, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
            }

            return owner;
        }

        public async Task<List<Patient>> GetPatientsByOwnerIdAsync(int ownerId)
        {
            var patients = new List<Patient>();

            using (SqlConnection cn = await GetConnectionAsync())
            {
                var p = new DynamicParameters(new { OwnerId = ownerId });

                patients = (await cn.QueryAsync<Patient>("dbo.SpGetPatientsByOwnerId", p, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).ToList();
            }
            return patients;
        }
    }
}
