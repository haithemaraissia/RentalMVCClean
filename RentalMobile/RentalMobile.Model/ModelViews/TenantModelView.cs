using System.Collections.Generic;
using RentalMobile.Model.Models;

namespace RentalMobile.Models
{
    public class TenantModelView 
    {

        public Tenant Tenants { get; set; }
        public List<TenantShowing> TenantShowings { get; set; }
        //public List<TenantMaintenance> TenantMaitenance { get; set; }
    }
}
