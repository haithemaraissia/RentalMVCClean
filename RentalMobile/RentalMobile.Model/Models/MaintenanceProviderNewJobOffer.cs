//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentalMobile.Model.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MaintenanceProviderNewJobOffer
    {
        public int MaintenanceProviderId { get; set; }
        public Nullable<int> TenantId { get; set; }
        public string TenantName { get; set; }
        public string TenantEmailAddress { get; set; }
        public Nullable<int> PropertyId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    }
}
