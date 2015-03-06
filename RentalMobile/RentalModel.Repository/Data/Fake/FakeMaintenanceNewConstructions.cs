using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenanceNewConstructions
    { 
       public List<MaintenanceNewConstruction> MyMaintenanceNewConstructions;

       public FakeMaintenanceNewConstructions()
        {
            InitializeMaintenanceNewConstructionList();
        }

       public void InitializeMaintenanceNewConstructionList()
        {
            MyMaintenanceNewConstructions = new List<MaintenanceNewConstruction> {
                FirstMaintenanceNewConstruction(), 
                SecondMaintenanceNewConstruction(),
                ThirdMaintenanceNewConstruction()
            };
        }

       public MaintenanceNewConstruction FirstMaintenanceNewConstruction()
        {

            var firstMaintenanceNewConstruction = new MaintenanceNewConstruction {

                 CompanyId = new Int32()
,
                 Architects = new Boolean()
,
                 Barns__Gazebos_and_Sheds = new Boolean()
,
                 Commercial_Construction = new Boolean()
,
                 Design_Build = new Boolean()
,
                 Custom_Cabinets___Furniture = new Boolean()
,
                 Foundation = new Boolean()
,
                 Garage___Carport_Construction = new Boolean()
,
                 Home_Additions = new Boolean()
,
                 Bathtub_Refinishing = new Boolean()
,
                 Home___Garage_Builders = new Boolean()
,
                 Land_Clearing___Site_Preparation = new Boolean()
,
                 New_Home_Construction = new Boolean()
,
                 Surveyors___Land = new Boolean()
,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()

    
 };

            return firstMaintenanceNewConstruction;
        }

       public MaintenanceNewConstruction SecondMaintenanceNewConstruction()
        {

            var secondMaintenanceNewConstruction = new MaintenanceNewConstruction {

                 CompanyId = new Int32()
,
                 Architects = new Boolean()
,
                 Barns__Gazebos_and_Sheds = new Boolean()
,
                 Commercial_Construction = new Boolean()
,
                 Design_Build = new Boolean()
,
                 Custom_Cabinets___Furniture = new Boolean()
,
                 Foundation = new Boolean()
,
                 Garage___Carport_Construction = new Boolean()
,
                 Home_Additions = new Boolean()
,
                 Bathtub_Refinishing = new Boolean()
,
                 Home___Garage_Builders = new Boolean()
,
                 Land_Clearing___Site_Preparation = new Boolean()
,
                 New_Home_Construction = new Boolean()
,
                 Surveyors___Land = new Boolean()
,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()

        
 };

            return secondMaintenanceNewConstruction;
        }

       public MaintenanceNewConstruction ThirdMaintenanceNewConstruction()
        {

            var thirdMaintenanceNewConstruction = new MaintenanceNewConstruction {

                 CompanyId = new Int32()
,
                 Architects = new Boolean()
,
                 Barns__Gazebos_and_Sheds = new Boolean()
,
                 Commercial_Construction = new Boolean()
,
                 Design_Build = new Boolean()
,
                 Custom_Cabinets___Furniture = new Boolean()
,
                 Foundation = new Boolean()
,
                 Garage___Carport_Construction = new Boolean()
,
                 Home_Additions = new Boolean()
,
                 Bathtub_Refinishing = new Boolean()
,
                 Home___Garage_Builders = new Boolean()
,
                 Land_Clearing___Site_Preparation = new Boolean()
,
                 New_Home_Construction = new Boolean()
,
                 Surveyors___Land = new Boolean()
,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()

 
 };

            return thirdMaintenanceNewConstruction;
        }

        ~FakeMaintenanceNewConstructions()
        {
            MyMaintenanceNewConstructions = null;
        }
    }
}


    