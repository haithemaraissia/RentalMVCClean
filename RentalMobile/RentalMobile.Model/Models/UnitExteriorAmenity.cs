
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
    
public partial class UnitExteriorAmenity
{

    public int UnitId { get; set; }

    public bool Pool { get; set; }

    public bool Garden { get; set; }

    public bool Gated_Entry { get; set; }

    public bool Greenhouse { get; set; }

    public bool Lawn { get; set; }

    public bool Deck { get; set; }

    public bool Dock { get; set; }

    public bool Fenced_Yard { get; set; }

    public bool Sprinkler_System { get; set; }

    public bool Patio { get; set; }

    public bool Pond { get; set; }



    public virtual Unit Unit { get; set; }

}

}