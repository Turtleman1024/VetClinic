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
            public const string GetOwnersByLastName = Base + "/owner/last-name/{lastName}";
            public const string CreateOwner = Base + "/owner";
            public const string UpdateOwner = Base + "/owner";
            public const string DeleteOwner = Base + "/owner/remove/{ownerId}";
        }

        public static class Patients
        {
            public const string GetAllPatients = Base + "/patients";
            public const string GetPatientById = Base + "/patient/{patientId}";
            public const string GetPatientsByName = Base + "/patient/name/{name}";
            public const string CreatePatient = Base + "/patient";
            public const string UpdatePatient = Base + "/patient";
            public const string DeletePatient = Base + "/patient/remove/{patientId}";
        }
    }
}
