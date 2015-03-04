using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeProviderMaintenanceProfile
    { 
       public List<ProviderMaintenanceProfile> MyProviderMaintenanceProfiles;

       public FakeProviderMaintenanceProfile()
        {
            InitializeProviderMaintenanceProfileList();
        }

       public void InitializeProviderMaintenanceProfileList()
        {
            MyProviderMaintenanceProfiles = new List<ProviderMaintenanceProfile> {
                FirstProviderMaintenanceProfile(), 
                SecondProviderMaintenanceProfile(),
                ThirdProviderMaintenanceProfile()
            };
        }

       public ProviderMaintenanceProfile FirstProviderMaintenanceProfile()
        {

            var firstProviderMaintenanceProfile = new ProviderMaintenanceProfile {

                 MaintenanceProvider = new MaintenanceProvider()
,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()
,
                 MaintenanceCompany = new MaintenanceCompany()
,
                 MaintenanceCompanySpecialization = new MaintenanceCompanySpecialization()
,
                 MaintenanceCustomService = new MaintenanceCustomService()
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

            return firstProviderMaintenanceProfile;
        }

       public ProviderMaintenanceProfile SecondProviderMaintenanceProfile()
        {

            var secondProviderMaintenanceProfile = new ProviderMaintenanceProfile {

                 MaintenanceProvider = new MaintenanceProvider()
,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()
,
                 MaintenanceCompany = new MaintenanceCompany()
,
                 MaintenanceCompanySpecialization = new MaintenanceCompanySpecialization()
,
                 MaintenanceCustomService = new MaintenanceCustomService()
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

            return secondProviderMaintenanceProfile;
        }

       public ProviderMaintenanceProfile ThirdProviderMaintenanceProfile()
        {

            var thirdProviderMaintenanceProfile = new ProviderMaintenanceProfile {

                 MaintenanceProvider = new MaintenanceProvider()
,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()
,
                 MaintenanceCompany = new MaintenanceCompany()
,
                 MaintenanceCompanySpecialization = new MaintenanceCompanySpecialization()
,
                 MaintenanceCustomService = new MaintenanceCustomService()
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

            return thirdProviderMaintenanceProfile;
        }

        ~FakeProviderMaintenanceProfile()
        {
            MyProviderMaintenanceProfiles = null;
        }
    }
}


    