using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenanceCrews
    { 
       public List<MaintenanceCrew> MyMaintenanceCrews;

       public FakeMaintenanceCrews()
        {
            InitializeMaintenanceCrewList();
        }

       public void InitializeMaintenanceCrewList()
        {
            MyMaintenanceCrews = new List<MaintenanceCrew> {
                FirstMaintenanceCrew(), 
                SecondMaintenanceCrew(),
                ThirdMaintenanceCrew()
            };
        }

       public MaintenanceCrew FirstMaintenanceCrew()
        {

            var firstMaintenanceCrew = new MaintenanceCrew {

                 CrewID = new Int32()
,
                 CompanyId = new Int32()
,
                 MaintenanceOrder = new MaintenanceOrder()

    
 };

            return firstMaintenanceCrew;
        }

       public MaintenanceCrew SecondMaintenanceCrew()
        {

            var secondMaintenanceCrew = new MaintenanceCrew {

                 CrewID = new Int32()
,
                 CompanyId = new Int32()
,
                 MaintenanceOrder = new MaintenanceOrder()

        
 };

            return secondMaintenanceCrew;
        }

       public MaintenanceCrew ThirdMaintenanceCrew()
        {

            var thirdMaintenanceCrew = new MaintenanceCrew {

                 CrewID = new Int32()
,
                 CompanyId = new Int32()
,
                 MaintenanceOrder = new MaintenanceOrder()

 
 };

            return thirdMaintenanceCrew;
        }

        ~FakeMaintenanceCrews()
        {
            MyMaintenanceCrews = null;
        }
    }
}


    