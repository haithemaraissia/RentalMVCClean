using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenanceOrder
    { 
       public List<MaintenanceOrder> MyMaintenanceOrders;

       public FakeMaintenanceOrder()
        {
            InitializeMaintenanceOrderList();
        }

       public void InitializeMaintenanceOrderList()
        {
            MyMaintenanceOrders = new List<MaintenanceOrder> {
                FirstMaintenanceOrder(), 
                SecondMaintenanceOrder(),
                ThirdMaintenanceOrder()
            };
        }

       public MaintenanceOrder FirstMaintenanceOrder()
        {

            var firstMaintenanceOrder = new MaintenanceOrder {

                 MaintenanceID = new Int32()
,
                 UnitID = new Int32()
,
                 MaintenanceDate = new DateTime()
,
                 UrgencyID = new Int32()
,
                 Description = null,
                 ServiceTypeID = new Int32()
,
                 PetsinUnit = new Boolean()
,
                 TenantPresence = new Boolean()
,
//Skipping MaintenanceCrew Collection
                 ServiceType = new ServiceType()
,
                 UrgencyType = new UrgencyType()
,
//Skipping MaintenancePhoto Collection
//Skipping OwnerMaintenance Collection
                 TenantMaintenance = new TenantMaintenance()

    
 };

            return firstMaintenanceOrder;
        }

       public MaintenanceOrder SecondMaintenanceOrder()
        {

            var secondMaintenanceOrder = new MaintenanceOrder {

                 MaintenanceID = new Int32()
,
                 UnitID = new Int32()
,
                 MaintenanceDate = new DateTime()
,
                 UrgencyID = new Int32()
,
                 Description = null,
                 ServiceTypeID = new Int32()
,
                 PetsinUnit = new Boolean()
,
                 TenantPresence = new Boolean()
,
//Skipping MaintenanceCrew Collection
                 ServiceType = new ServiceType()
,
                 UrgencyType = new UrgencyType()
,
//Skipping MaintenancePhoto Collection
//Skipping OwnerMaintenance Collection
                 TenantMaintenance = new TenantMaintenance()

        
 };

            return secondMaintenanceOrder;
        }

       public MaintenanceOrder ThirdMaintenanceOrder()
        {

            var thirdMaintenanceOrder = new MaintenanceOrder {

                 MaintenanceID = new Int32()
,
                 UnitID = new Int32()
,
                 MaintenanceDate = new DateTime()
,
                 UrgencyID = new Int32()
,
                 Description = null,
                 ServiceTypeID = new Int32()
,
                 PetsinUnit = new Boolean()
,
                 TenantPresence = new Boolean()
,
//Skipping MaintenanceCrew Collection
                 ServiceType = new ServiceType()
,
                 UrgencyType = new UrgencyType()
,
//Skipping MaintenancePhoto Collection
//Skipping OwnerMaintenance Collection
                 TenantMaintenance = new TenantMaintenance()

 
 };

            return thirdMaintenanceOrder;
        }

        ~FakeMaintenanceOrder()
        {
            MyMaintenanceOrders = null;
        }
    }
}


    