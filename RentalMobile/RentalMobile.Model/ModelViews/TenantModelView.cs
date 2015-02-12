using System.Collections.Generic;

namespace RentalMobile.Models
{
    public class TenantModelView 
    {

        public Tenant Tenants { get; set; }
        public List<TenantShowing> TenantShowings { get; set; }
        //public List<TenantMaintenance> TenantMaitenance { get; set; }
    }
}
