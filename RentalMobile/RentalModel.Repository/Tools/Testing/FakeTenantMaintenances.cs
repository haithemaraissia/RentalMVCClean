using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeTenantMaintenance
    { 
       public List<TenantMaintenance> MyTenantMaintenances;

       public FakeTenantMaintenance()
        {
            InitializeTenantMaintenanceList();
        }

       public void InitializeTenantMaintenanceList()
        {
            MyTenantMaintenances = new List<TenantMaintenance> {
                FirstTenantMaintenance(), 
                SecondTenantMaintenance(),
                ThirdTenantMaintenance()
            };
        }

       public TenantMaintenance FirstTenantMaintenance()
        {

            var firstTenantMaintenance = new TenantMaintenance {

                 TenantID = new Int32()
,
                 MaintenanceID = new Int32()
,
                 MaintenanceOrder = new MaintenanceOrder()

    
 };

            return firstTenantMaintenance;
        }

       public TenantMaintenance SecondTenantMaintenance()
        {

            var secondTenantMaintenance = new TenantMaintenance {

                 TenantID = new Int32()
,
                 MaintenanceID = new Int32()
,
                 MaintenanceOrder = new MaintenanceOrder()

        
 };

            return secondTenantMaintenance;
        }

       public TenantMaintenance ThirdTenantMaintenance()
        {

            var thirdTenantMaintenance = new TenantMaintenance {

                 TenantID = new Int32()
,
                 MaintenanceID = new Int32()
,
                 MaintenanceOrder = new MaintenanceOrder()

 
 };

            return thirdTenantMaintenance;
        }

        ~FakeTenantMaintenance()
        {
            MyTenantMaintenances = null;
        }
    }
}


    