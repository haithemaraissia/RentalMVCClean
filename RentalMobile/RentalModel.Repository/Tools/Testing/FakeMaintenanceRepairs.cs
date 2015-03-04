using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenanceRepair
    { 
       public List<MaintenanceRepair> MyMaintenanceRepairs;

       public FakeMaintenanceRepair()
        {
            InitializeMaintenanceRepairList();
        }

       public void InitializeMaintenanceRepairList()
        {
            MyMaintenanceRepairs = new List<MaintenanceRepair> {
                FirstMaintenanceRepair(), 
                SecondMaintenanceRepair(),
                ThirdMaintenanceRepair()
            };
        }

       public MaintenanceRepair FirstMaintenanceRepair()
        {

            var firstMaintenanceRepair = new MaintenanceRepair {

                 CompanyId = new Int32()
,
                 Appliances_Service_and_Repair = new Boolean()
,
                 Bathtub___Sink_Repair_Refinishing = new Boolean()
,
                 Black_Mold_Removal = new Boolean()
,
                 Carpet___Rug_Cleaning = new Boolean()
,
                 Caulking = new Boolean()
,
                 Chimney_Services = new Boolean()
,
                 Cleaning_Services = new Boolean()
,
                 Computers_Service_and_Repair = new Boolean()
,
                 Duct_Cleaning = new Boolean()
,
                 Foundation_Repair = new Boolean()
,
                 Furniture_Repair___Restoration = new Boolean()
,
                 Garage_Door_Install___Repair = new Boolean()
,
                 Handyman_Services = new Boolean()
,
                 Drain_Pipe = new Boolean()
,
                 Doors = new Boolean()
,
                 Locksmithing = new Boolean()
,
                 Pest_Control = new Boolean()
,
                 Property_Management = new Boolean()
,
                 Snow_Removal = new Boolean()
,
                 Window_Cleaning = new Boolean()
,
                 Glass___Window_Services = new Boolean()
,
                 Mailbox_Repair = new Boolean()
,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()

    
 };

            return firstMaintenanceRepair;
        }

       public MaintenanceRepair SecondMaintenanceRepair()
        {

            var secondMaintenanceRepair = new MaintenanceRepair {

                 CompanyId = new Int32()
,
                 Appliances_Service_and_Repair = new Boolean()
,
                 Bathtub___Sink_Repair_Refinishing = new Boolean()
,
                 Black_Mold_Removal = new Boolean()
,
                 Carpet___Rug_Cleaning = new Boolean()
,
                 Caulking = new Boolean()
,
                 Chimney_Services = new Boolean()
,
                 Cleaning_Services = new Boolean()
,
                 Computers_Service_and_Repair = new Boolean()
,
                 Duct_Cleaning = new Boolean()
,
                 Foundation_Repair = new Boolean()
,
                 Furniture_Repair___Restoration = new Boolean()
,
                 Garage_Door_Install___Repair = new Boolean()
,
                 Handyman_Services = new Boolean()
,
                 Drain_Pipe = new Boolean()
,
                 Doors = new Boolean()
,
                 Locksmithing = new Boolean()
,
                 Pest_Control = new Boolean()
,
                 Property_Management = new Boolean()
,
                 Snow_Removal = new Boolean()
,
                 Window_Cleaning = new Boolean()
,
                 Glass___Window_Services = new Boolean()
,
                 Mailbox_Repair = new Boolean()
,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()

        
 };

            return secondMaintenanceRepair;
        }

       public MaintenanceRepair ThirdMaintenanceRepair()
        {

            var thirdMaintenanceRepair = new MaintenanceRepair {

                 CompanyId = new Int32()
,
                 Appliances_Service_and_Repair = new Boolean()
,
                 Bathtub___Sink_Repair_Refinishing = new Boolean()
,
                 Black_Mold_Removal = new Boolean()
,
                 Carpet___Rug_Cleaning = new Boolean()
,
                 Caulking = new Boolean()
,
                 Chimney_Services = new Boolean()
,
                 Cleaning_Services = new Boolean()
,
                 Computers_Service_and_Repair = new Boolean()
,
                 Duct_Cleaning = new Boolean()
,
                 Foundation_Repair = new Boolean()
,
                 Furniture_Repair___Restoration = new Boolean()
,
                 Garage_Door_Install___Repair = new Boolean()
,
                 Handyman_Services = new Boolean()
,
                 Drain_Pipe = new Boolean()
,
                 Doors = new Boolean()
,
                 Locksmithing = new Boolean()
,
                 Pest_Control = new Boolean()
,
                 Property_Management = new Boolean()
,
                 Snow_Removal = new Boolean()
,
                 Window_Cleaning = new Boolean()
,
                 Glass___Window_Services = new Boolean()
,
                 Mailbox_Repair = new Boolean()
,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()

 
 };

            return thirdMaintenanceRepair;
        }

        ~FakeMaintenanceRepair()
        {
            MyMaintenanceRepairs = null;
        }
    }
}


    