
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
    
public partial class MaintenanceProviderZone
{

    public int MaintenanceProviderZoneId { get; set; }

    public int MaintenanceProviderId { get; set; }

    public string CityName { get; set; }

    public string Country { get; set; }

    public string ZipCode { get; set; }

    public Nullable<int> TeamMemberCount { get; set; }

}

}