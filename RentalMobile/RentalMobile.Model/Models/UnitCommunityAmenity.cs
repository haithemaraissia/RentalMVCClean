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
    
    public partial class UnitCommunityAmenity
    {
        public int UnitId { get; set; }
        public string Neighborhood_Name { get; set; }
        public string Elementary_School { get; set; }
        public string High_School { get; set; }
        public string School_District { get; set; }
        public string Middle_School { get; set; }
        public string County_Name { get; set; }
        public bool Assisted_Living_Community { get; set; }
        public bool Over_55_Active_Community { get; set; }
        public bool Disability_Access { get; set; }
        public bool Controlled_Access { get; set; }
        public bool Community_Pool { get; set; }
    
        public virtual Unit Unit { get; set; }
    }
}
