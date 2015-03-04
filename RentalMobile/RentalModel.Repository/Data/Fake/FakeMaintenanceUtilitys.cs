using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenanceUtility
    { 
       public List<MaintenanceUtility> MyMaintenanceUtilitys;

       public FakeMaintenanceUtility()
        {
            InitializeMaintenanceUtilityList();
        }

       public void InitializeMaintenanceUtilityList()
        {
            MyMaintenanceUtilitys = new List<MaintenanceUtility> {
                FirstMaintenanceUtility(), 
                SecondMaintenanceUtility(),
                ThirdMaintenanceUtility()
            };
        }

       public MaintenanceUtility FirstMaintenanceUtility()
        {

            var firstMaintenanceUtility = new MaintenanceUtility {

                 CompanyId = new Int32()
,
                 Security_Systems___Automation = new Boolean()
,
                 Central_Vacuum = new Boolean()
,
                 Electrical = new Boolean()
,
                 Energy_Audit = new Boolean()
,
                 Gas___Propane_Services = new Boolean()
,
                 Heating___Air_Conditioning = new Boolean()
,
                 Lighting_Services = new Boolean()
,
                 Plumbing = new Boolean()
,
                 Satellite_Dish_Systems = new Boolean()
,
                 Sewer___Septic_Services = new Boolean()
,
                 Solar_Panels___Energy = new Boolean()
,
                 Voice___Data_Wiring_Install___Repair = new Boolean()
,
                 Radon_Testing = new Boolean()
,
                 Water_Heaters___Pumps = new Boolean()
,
                 Water_Purification___Softening = new Boolean()
,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()

    
 };

            return firstMaintenanceUtility;
        }

       public MaintenanceUtility SecondMaintenanceUtility()
        {

            var secondMaintenanceUtility = new MaintenanceUtility {

                 CompanyId = new Int32()
,
                 Security_Systems___Automation = new Boolean()
,
                 Central_Vacuum = new Boolean()
,
                 Electrical = new Boolean()
,
                 Energy_Audit = new Boolean()
,
                 Gas___Propane_Services = new Boolean()
,
                 Heating___Air_Conditioning = new Boolean()
,
                 Lighting_Services = new Boolean()
,
                 Plumbing = new Boolean()
,
                 Satellite_Dish_Systems = new Boolean()
,
                 Sewer___Septic_Services = new Boolean()
,
                 Solar_Panels___Energy = new Boolean()
,
                 Voice___Data_Wiring_Install___Repair = new Boolean()
,
                 Radon_Testing = new Boolean()
,
                 Water_Heaters___Pumps = new Boolean()
,
                 Water_Purification___Softening = new Boolean()
,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()

        
 };

            return secondMaintenanceUtility;
        }

       public MaintenanceUtility ThirdMaintenanceUtility()
        {

            var thirdMaintenanceUtility = new MaintenanceUtility {

                 CompanyId = new Int32()
,
                 Security_Systems___Automation = new Boolean()
,
                 Central_Vacuum = new Boolean()
,
                 Electrical = new Boolean()
,
                 Energy_Audit = new Boolean()
,
                 Gas___Propane_Services = new Boolean()
,
                 Heating___Air_Conditioning = new Boolean()
,
                 Lighting_Services = new Boolean()
,
                 Plumbing = new Boolean()
,
                 Satellite_Dish_Systems = new Boolean()
,
                 Sewer___Septic_Services = new Boolean()
,
                 Solar_Panels___Energy = new Boolean()
,
                 Voice___Data_Wiring_Install___Repair = new Boolean()
,
                 Radon_Testing = new Boolean()
,
                 Water_Heaters___Pumps = new Boolean()
,
                 Water_Purification___Softening = new Boolean()
,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()

 
 };

            return thirdMaintenanceUtility;
        }

        ~FakeMaintenanceUtility()
        {
            MyMaintenanceUtilitys = null;
        }
    }
}


    