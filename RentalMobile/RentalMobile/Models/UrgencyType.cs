
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
    
public partial class UrgencyType
{

    public UrgencyType()
    {

        this.MaintenanceOrders = new HashSet<MaintenanceOrder>();

    }


    public int UrgencyTypeID { get; set; }

    public string UrgencyType1 { get; set; }

    public int LCID { get; set; }



    public virtual ICollection<MaintenanceOrder> MaintenanceOrders { get; set; }

}

}
