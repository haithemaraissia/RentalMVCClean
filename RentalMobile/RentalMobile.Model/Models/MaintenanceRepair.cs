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
    
    public partial class MaintenanceRepair
    {
        public int CompanyId { get; set; }
        public bool Appliances_Service_and_Repair { get; set; }
        public bool Bathtub___Sink_Repair_Refinishing { get; set; }
        public bool Black_Mold_Removal { get; set; }
        public bool Carpet___Rug_Cleaning { get; set; }
        public bool Caulking { get; set; }
        public bool Chimney_Services { get; set; }
        public bool Cleaning_Services { get; set; }
        public bool Computers_Service_and_Repair { get; set; }
        public bool Duct_Cleaning { get; set; }
        public bool Foundation_Repair { get; set; }
        public bool Furniture_Repair___Restoration { get; set; }
        public bool Garage_Door_Install___Repair { get; set; }
        public bool Handyman_Services { get; set; }
        public bool Drain_Pipe { get; set; }
        public bool Doors { get; set; }
        public bool Locksmithing { get; set; }
        public bool Pest_Control { get; set; }
        public bool Property_Management { get; set; }
        public bool Snow_Removal { get; set; }
        public bool Window_Cleaning { get; set; }
        public bool Glass___Window_Services { get; set; }
        public bool Mailbox_Repair { get; set; }
    
        public virtual MaintenanceCompanyLookUp MaintenanceCompanyLookUp { get; set; }
    }
}
