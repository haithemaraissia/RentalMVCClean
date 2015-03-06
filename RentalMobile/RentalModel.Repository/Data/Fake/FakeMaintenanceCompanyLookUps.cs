using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenanceCompanyLookUps
    { 
       public List<MaintenanceCompanyLookUp> MyMaintenanceCompanyLookUps;

       public FakeMaintenanceCompanyLookUps()
        {
            InitializeMaintenanceCompanyLookUpList();
        }

       public void InitializeMaintenanceCompanyLookUpList()
        {
            MyMaintenanceCompanyLookUps = new List<MaintenanceCompanyLookUp> {
                FirstMaintenanceCompanyLookUp(), 
                SecondMaintenanceCompanyLookUp(),
                ThirdMaintenanceCompanyLookUp()
            };
        }

       public MaintenanceCompanyLookUp FirstMaintenanceCompanyLookUp()
        {

            var firstMaintenanceCompanyLookUp = new MaintenanceCompanyLookUp {

                 CompanyId = new Int32()
,
                 UserId = new Int32()
,
                 Role = new Int32()
,
                 MaintenanceCompany = new MaintenanceCompany()
,
                 MaintenanceExterior = new MaintenanceExterior()
,
                 MaintenanceInterior = new MaintenanceInterior()
,
                 MaintenanceNewConstruction = new MaintenanceNewConstruction()
,
                 MaintenanceRepair = new MaintenanceRepair()
,
                 MaintenanceUtility = new MaintenanceUtility()

    
 };

            return firstMaintenanceCompanyLookUp;
        }

       public MaintenanceCompanyLookUp SecondMaintenanceCompanyLookUp()
        {

            var secondMaintenanceCompanyLookUp = new MaintenanceCompanyLookUp {

                 CompanyId = new Int32()
,
                 UserId = new Int32()
,
                 Role = new Int32()
,
                 MaintenanceCompany = new MaintenanceCompany()
,
                 MaintenanceExterior = new MaintenanceExterior()
,
                 MaintenanceInterior = new MaintenanceInterior()
,
                 MaintenanceNewConstruction = new MaintenanceNewConstruction()
,
                 MaintenanceRepair = new MaintenanceRepair()
,
                 MaintenanceUtility = new MaintenanceUtility()

        
 };

            return secondMaintenanceCompanyLookUp;
        }

       public MaintenanceCompanyLookUp ThirdMaintenanceCompanyLookUp()
        {

            var thirdMaintenanceCompanyLookUp = new MaintenanceCompanyLookUp {

                 CompanyId = new Int32()
,
                 UserId = new Int32()
,
                 Role = new Int32()
,
                 MaintenanceCompany = new MaintenanceCompany()
,
                 MaintenanceExterior = new MaintenanceExterior()
,
                 MaintenanceInterior = new MaintenanceInterior()
,
                 MaintenanceNewConstruction = new MaintenanceNewConstruction()
,
                 MaintenanceRepair = new MaintenanceRepair()
,
                 MaintenanceUtility = new MaintenanceUtility()

 
 };

            return thirdMaintenanceCompanyLookUp;
        }

        ~FakeMaintenanceCompanyLookUps()
        {
            MyMaintenanceCompanyLookUps = null;
        }
    }
}


    