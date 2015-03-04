using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeSpecialistMaintenanceProfile
    { 
       public List<SpecialistMaintenanceProfile> MySpecialistMaintenanceProfiles;

       public FakeSpecialistMaintenanceProfile()
        {
            InitializeSpecialistMaintenanceProfileList();
        }

       public void InitializeSpecialistMaintenanceProfileList()
        {
            MySpecialistMaintenanceProfiles = new List<SpecialistMaintenanceProfile> {
                FirstSpecialistMaintenanceProfile(), 
                SecondSpecialistMaintenanceProfile(),
                ThirdSpecialistMaintenanceProfile()
            };
        }

       public SpecialistMaintenanceProfile FirstSpecialistMaintenanceProfile()
        {

            var firstSpecialistMaintenanceProfile = new SpecialistMaintenanceProfile {

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

            return firstSpecialistMaintenanceProfile;
        }

       public SpecialistMaintenanceProfile SecondSpecialistMaintenanceProfile()
        {

            var secondSpecialistMaintenanceProfile = new SpecialistMaintenanceProfile {

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

            return secondSpecialistMaintenanceProfile;
        }

       public SpecialistMaintenanceProfile ThirdSpecialistMaintenanceProfile()
        {

            var thirdSpecialistMaintenanceProfile = new SpecialistMaintenanceProfile {

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

            return thirdSpecialistMaintenanceProfile;
        }

        ~FakeSpecialistMaintenanceProfile()
        {
            MySpecialistMaintenanceProfiles = null;
        }
    }
}


    