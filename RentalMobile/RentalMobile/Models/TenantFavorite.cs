
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
    
public partial class TenantFavorite
{

    public int FavoriteId { get; set; }

    public int TenantId { get; set; }

    public int UnitId { get; set; }

    public System.DateTime FavoriteDate { get; set; }



    public virtual Tenant Tenant { get; set; }

}

}
