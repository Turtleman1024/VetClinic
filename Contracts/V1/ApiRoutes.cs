using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinic.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Owners
        {
            public const string GetAllOwners = Base + "/owners";
            public const string GetOwnerById = Base + "/owner/{ownerId}";
            public const string CreateOwner = Base + "/owner";
            public const string UpdateOwner = Base + "/owner";
            public const string DeleteOwner = Base + "/owners/{ownerId}";
        }

        public static class Patients
        {
            public const string GetAllPatients = Base + "/patients";
            public const string GetPatientById = Base + "/patient/{patientId}";
            public const string GetPatientByOwnerId = Base + "/patient/{ownerId}";
            public const string CreatePatient = Base + "/patient";
            public const string UpdatePatient = Base + "/patient";
            public const string DeletePatient = Base + "/patients/{patientId}";
        }
    }
}
