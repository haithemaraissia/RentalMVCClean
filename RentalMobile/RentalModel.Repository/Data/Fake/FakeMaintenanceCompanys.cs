using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenanceCompanys
    { 
       public List<MaintenanceCompany> MyMaintenanceCompanys;

       public FakeMaintenanceCompanys()
        {
            InitializeMaintenanceCompanyList();
        }

       public void InitializeMaintenanceCompanyList()
        {
            MyMaintenanceCompanys = new List<MaintenanceCompany> {
                FirstMaintenanceCompany(), 
                SecondMaintenanceCompany(),
                ThirdMaintenanceCompany()
            };
        }

       public MaintenanceCompany FirstMaintenanceCompany()
        {

            var firstMaintenanceCompany = new MaintenanceCompany {

                 CompanyId = new Int32()
,
                 Name = null,
                 Website = null,
                 Address = null,
                 EmailAddress = null,
                 Description = null,
                 GUID = new Guid()
,
                 VCard = null,
                 Skype = null,
                 Twitter = null,
                 LinkedIn = null,
                 GooglePlus = null,
                 Photo = null,
                 GoogleMap = null,
                 Country = null,
                 Region = null,
                 City = null,
                 Zip = null,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()

    
 };

            return firstMaintenanceCompany;
        }

       public MaintenanceCompany SecondMaintenanceCompany()
        {

            var secondMaintenanceCompany = new MaintenanceCompany {

                 CompanyId = new Int32()
,
                 Name = null,
                 Website = null,
                 Address = null,
                 EmailAddress = null,
                 Description = null,
                 GUID = new Guid()
,
                 VCard = null,
                 Skype = null,
                 Twitter = null,
                 LinkedIn = null,
                 GooglePlus = null,
                 Photo = null,
                 GoogleMap = null,
                 Country = null,
                 Region = null,
                 City = null,
                 Zip = null,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()

        
 };

            return secondMaintenanceCompany;
        }

       public MaintenanceCompany ThirdMaintenanceCompany()
        {

            var thirdMaintenanceCompany = new MaintenanceCompany {

                 CompanyId = new Int32()
,
                 Name = null,
                 Website = null,
                 Address = null,
                 EmailAddress = null,
                 Description = null,
                 GUID = new Guid()
,
                 VCard = null,
                 Skype = null,
                 Twitter = null,
                 LinkedIn = null,
                 GooglePlus = null,
                 Photo = null,
                 GoogleMap = null,
                 Country = null,
                 Region = null,
                 City = null,
                 Zip = null,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()

 
 };

            return thirdMaintenanceCompany;
        }

        ~FakeMaintenanceCompanys()
        {
            MyMaintenanceCompanys = null;
        }
    }
}


    