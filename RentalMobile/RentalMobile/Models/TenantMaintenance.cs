
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace RentalMobile.Models
{

using System;
    using System.Collections.Generic;
    
public partial class TenantMaintenance
{

    public int TenantID { get; set; }

    public int MaintenanceID { get; set; }



    public virtual MaintenanceOrder MaintenanceOrder { get; set; }

}

}
