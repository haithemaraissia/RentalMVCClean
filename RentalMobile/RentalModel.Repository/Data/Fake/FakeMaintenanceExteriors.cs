using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenanceExteriors
    { 
       public List<MaintenanceExterior> MyMaintenanceExteriors;

       public FakeMaintenanceExteriors()
        {
            InitializeMaintenanceExteriorList();
        }

       public void InitializeMaintenanceExteriorList()
        {
            MyMaintenanceExteriors = new List<MaintenanceExterior> {
                FirstMaintenanceExterior(), 
                SecondMaintenanceExterior(),
                ThirdMaintenanceExterior()
            };
        }

       public MaintenanceExterior FirstMaintenanceExterior()
        {

            var firstMaintenanceExterior = new MaintenanceExterior {

                 CompanyId = new Int32()
,
                 Asphalt_Paving = new Boolean()
,
                 Awnings = new Boolean()
,
                 Concrete_Installation___Repair = new Boolean()
,
                 Decks__Patios___Enclosures = new Boolean()
,
                 Fence_Install_and_Repair = new Boolean()
,
                 Gutter_Services = new Boolean()
,
                 Hurricane_Shutter_Systems = new Boolean()
,
                 Interlocking___Stonework = new Boolean()
,
                 Ironwork___Wrought_Iron = new Boolean()
,
                 Landscaping_Installation = new Boolean()
,
                 Lawn_Care = new Boolean()
,
                 Masonry_and_Brick_Work = new Boolean()
,
                 Power_Washing = new Boolean()
,
                 Roofing_Services = new Boolean()
,
                 Siding = new Boolean()
,
                 Skylights = new Boolean()
,
                 Sprinkler_Systems_and_Irrigation = new Boolean()
,
                 Stucco___Plaster = new Boolean()
,
                 Swimming_Pool_Install = new Boolean()
,
                 Tree_Service = new Boolean()
,
                 Waterproofing = new Boolean()
,
                 Windows___Exterior_Doors = new Boolean()
,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()

    
 };

            return firstMaintenanceExterior;
        }

       public MaintenanceExterior SecondMaintenanceExterior()
        {

            var secondMaintenanceExterior = new MaintenanceExterior {

                 CompanyId = new Int32()
,
                 Asphalt_Paving = new Boolean()
,
                 Awnings = new Boolean()
,
                 Concrete_Installation___Repair = new Boolean()
,
                 Decks__Patios___Enclosures = new Boolean()
,
                 Fence_Install_and_Repair = new Boolean()
,
                 Gutter_Services = new Boolean()
,
                 Hurricane_Shutter_Systems = new Boolean()
,
                 Interlocking___Stonework = new Boolean()
,
                 Ironwork___Wrought_Iron = new Boolean()
,
                 Landscaping_Installation = new Boolean()
,
                 Lawn_Care = new Boolean()
,
                 Masonry_and_Brick_Work = new Boolean()
,
                 Power_Washing = new Boolean()
,
                 Roofing_Services = new Boolean()
,
                 Siding = new Boolean()
,
                 Skylights = new Boolean()
,
                 Sprinkler_Systems_and_Irrigation = new Boolean()
,
                 Stucco___Plaster = new Boolean()
,
                 Swimming_Pool_Install = new Boolean()
,
                 Tree_Service = new Boolean()
,
                 Waterproofing = new Boolean()
,
                 Windows___Exterior_Doors = new Boolean()
,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()

        
 };

            return secondMaintenanceExterior;
        }

       public MaintenanceExterior ThirdMaintenanceExterior()
        {

            var thirdMaintenanceExterior = new MaintenanceExterior {

                 CompanyId = new Int32()
,
                 Asphalt_Paving = new Boolean()
,
                 Awnings = new Boolean()
,
                 Concrete_Installation___Repair = new Boolean()
,
                 Decks__Patios___Enclosures = new Boolean()
,
                 Fence_Install_and_Repair = new Boolean()
,
                 Gutter_Services = new Boolean()
,
                 Hurricane_Shutter_Systems = new Boolean()
,
                 Interlocking___Stonework = new Boolean()
,
                 Ironwork___Wrought_Iron = new Boolean()
,
                 Landscaping_Installation = new Boolean()
,
                 Lawn_Care = new Boolean()
,
                 Masonry_and_Brick_Work = new Boolean()
,
                 Power_Washing = new Boolean()
,
                 Roofing_Services = new Boolean()
,
                 Siding = new Boolean()
,
                 Skylights = new Boolean()
,
                 Sprinkler_Systems_and_Irrigation = new Boolean()
,
                 Stucco___Plaster = new Boolean()
,
                 Swimming_Pool_Install = new Boolean()
,
                 Tree_Service = new Boolean()
,
                 Waterproofing = new Boolean()
,
                 Windows___Exterior_Doors = new Boolean()
,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()

 
 };

            return thirdMaintenanceExterior;
        }

        ~FakeMaintenanceExteriors()
        {
            MyMaintenanceExteriors = null;
        }
    }
}


    