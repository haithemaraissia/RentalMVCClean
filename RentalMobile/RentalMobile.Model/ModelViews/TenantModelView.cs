using System.Collections.Generic;
using RentalMobile.Model.Models;

namespace RentalMobile.Model.ModelViews
{
    public class TenantModelView
    {
        public Tenant Tenants { get; set; }
        public List<TenantShowing> TenantShowings { get; set; }
    }
}