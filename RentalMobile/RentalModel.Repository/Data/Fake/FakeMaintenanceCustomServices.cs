using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenanceCustomServices
    { 
       public List<MaintenanceCustomService> MyMaintenanceCustomServices;

       public FakeMaintenanceCustomServices()
        {
            InitializeMaintenanceCustomServiceList();
        }

       public void InitializeMaintenanceCustomServiceList()
        {
            MyMaintenanceCustomServices = new List<MaintenanceCustomService> {
                FirstMaintenanceCustomService(), 
                SecondMaintenanceCustomService(),
                ThirdMaintenanceCustomService()
            };
        }

       public MaintenanceCustomService FirstMaintenanceCustomService()
        {

            var firstMaintenanceCustomService = new MaintenanceCustomService {

                 CompanyId = 0
,
                 Demolition_Services = new Boolean()
,
                 Disability_Accessibility = new Boolean()
,
                 Childproofing = new Boolean()
,
                 Energy_Efficiency_Inspection = new Boolean()
,
                 Excavation = new Boolean()
,
                 Biohazard_Cleanup = new Boolean()
,
                 Mold_Removal = new Boolean()
,
                 Home_Staging = new Boolean()
,
                 Inspection_Services = new Boolean()
,
                 Moving_Services = new Boolean()
,
                 Restoration = new Boolean()
,
                 Metal_Restoration = new Boolean()
,
                 Earthquake_Retrofitting = new Boolean()
,
                 Epoxy_Flooring_Excavators = new Boolean()
,
                 Structural_Engineering = new Boolean()
,
                 Trash_Removal___Hauling = new Boolean()
,
                 Welding = new Boolean()
,
                 Mudjacking = new Boolean()
,
                 Picture_Framing = new Boolean()
,
                 Woodworking_Services = new Boolean()

    
 };

            return firstMaintenanceCustomService;
        }

       public MaintenanceCustomService SecondMaintenanceCustomService()
        {

            var secondMaintenanceCustomService = new MaintenanceCustomService {

                 CompanyId = 1
,
                 Demolition_Services = new Boolean()
,
                 Disability_Accessibility = new Boolean()
,
                 Childproofing = new Boolean()
,
                 Energy_Efficiency_Inspection = new Boolean()
,
                 Excavation = new Boolean()
,
                 Biohazard_Cleanup = new Boolean()
,
                 Mold_Removal = new Boolean()
,
                 Home_Staging = new Boolean()
,
                 Inspection_Services = new Boolean()
,
                 Moving_Services = new Boolean()
,
                 Restoration = new Boolean()
,
                 Metal_Restoration = new Boolean()
,
                 Earthquake_Retrofitting = new Boolean()
,
                 Epoxy_Flooring_Excavators = new Boolean()
,
                 Structural_Engineering = new Boolean()
,
                 Trash_Removal___Hauling = new Boolean()
,
                 Welding = new Boolean()
,
                 Mudjacking = new Boolean()
,
                 Picture_Framing = new Boolean()
,
                 Woodworking_Services = new Boolean()

        
 };

            return secondMaintenanceCustomService;
        }

       public MaintenanceCustomService ThirdMaintenanceCustomService()
        {

            var thirdMaintenanceCustomService = new MaintenanceCustomService {

                 CompanyId = 2
,
                 Demolition_Services = new Boolean()
,
                 Disability_Accessibility = new Boolean()
,
                 Childproofing = new Boolean()
,
                 Energy_Efficiency_Inspection = new Boolean()
,
                 Excavation = new Boolean()
,
                 Biohazard_Cleanup = new Boolean()
,
                 Mold_Removal = new Boolean()
,
                 Home_Staging = new Boolean()
,
                 Inspection_Services = new Boolean()
,
                 Moving_Services = new Boolean()
,
                 Restoration = new Boolean()
,
                 Metal_Restoration = new Boolean()
,
                 Earthquake_Retrofitting = new Boolean()
,
                 Epoxy_Flooring_Excavators = new Boolean()
,
                 Structural_Engineering = new Boolean()
,
                 Trash_Removal___Hauling = new Boolean()
,
                 Welding = new Boolean()
,
                 Mudjacking = new Boolean()
,
                 Picture_Framing = new Boolean()
,
                 Woodworking_Services = new Boolean()

 
 };

            return thirdMaintenanceCustomService;
        }

        ~FakeMaintenanceCustomServices()
        {
            MyMaintenanceCustomServices = null;
        }
    }
}


    