using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeOwnerMaintenances
    { 
       public List<OwnerMaintenance> MyOwnerMaintenances;

       public FakeOwnerMaintenances()
        {
            InitializeOwnerMaintenanceList();
        }

       public void InitializeOwnerMaintenanceList()
        {
            MyOwnerMaintenances = new List<OwnerMaintenance> {
                FirstOwnerMaintenance(), 
                SecondOwnerMaintenance(),
                ThirdOwnerMaintenance()
            };
        }

       public OwnerMaintenance FirstOwnerMaintenance()
        {

            var firstOwnerMaintenance = new OwnerMaintenance {

                 OwnerID = new Int32()
,
                 MaintenanceID = new Int32()
,
                 MaintenanceOrder = new MaintenanceOrder()

    
 };

            return firstOwnerMaintenance;
        }

       public OwnerMaintenance SecondOwnerMaintenance()
        {

            var secondOwnerMaintenance = new OwnerMaintenance {

                 OwnerID = new Int32()
,
                 MaintenanceID = new Int32()
,
                 MaintenanceOrder = new MaintenanceOrder()

        
 };

            return secondOwnerMaintenance;
        }

       public OwnerMaintenance ThirdOwnerMaintenance()
        {

            var thirdOwnerMaintenance = new OwnerMaintenance {

                 OwnerID = new Int32()
,
                 MaintenanceID = new Int32()
,
                 MaintenanceOrder = new MaintenanceOrder()

 
 };

            return thirdOwnerMaintenance;
        }

        ~FakeOwnerMaintenances()
        {
            MyOwnerMaintenances = null;
        }
    }
}


    