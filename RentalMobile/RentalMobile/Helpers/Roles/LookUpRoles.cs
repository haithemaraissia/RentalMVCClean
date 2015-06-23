using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Activation;
using RentalMobile.Model.Models;

namespace RentalMobile.Helpers.Roles
{
    public static class LookUpRoles
    {
        public const string TenantRoleId = "tenant";
        public const string OwnerRoleId = "owner";
        public const string AgentRoleId = "agent";
        public const string SpecialistRoleId = "specialist";
        public const string ProviderRoleId = "provider";
        public const string NotAuthenticatedRoleId = "notauthenticated";

        public const string TenantRole = "Tenant";
        public const string OwnerRole = "Owner";
        public const string AgentRole = "Agent";
        public const string SpecialistRole = "Specialist";
        public const string ProviderRole = "Provider";
        public const string NotAuthenticatedRole = "NotAuthenticated";

        public const string Tenant = "Tenant";
        public const string Owner = "Owner";
        public const string Agent = "Agent";
        public const string Specialist = "Specialist";
        public const string Provider = "Provider";
        public const string NotAuthenticated = "NotAuthenticated";

        public enum Roles
        {
            Tenant = 1,
            Owner = 2,
            Agent = 3,
            Specialist = 4,
            Provider = 5

        }
            

    }
}
