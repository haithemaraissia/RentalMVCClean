using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeProviderMaintenanceCompleteProfile
    { 
       public List<ProviderMaintenanceCompleteProfile> MyProviderMaintenanceCompleteProfiles;

       public FakeProviderMaintenanceCompleteProfile()
        {
            InitializeProviderMaintenanceCompleteProfileList();
        }

       public void InitializeProviderMaintenanceCompleteProfileList()
        {
            MyProviderMaintenanceCompleteProfiles = new List<ProviderMaintenanceCompleteProfile> {
                FirstProviderMaintenanceCompleteProfile(), 
                SecondProviderMaintenanceCompleteProfile(),
                ThirdProviderMaintenanceCompleteProfile()
            };
        }

       public ProviderMaintenanceCompleteProfile FirstProviderMaintenanceCompleteProfile()
        {

            var firstProviderMaintenanceCompleteProfile = new ProviderMaintenanceCompleteProfile {

                 MaintenanceProvider = new MaintenanceProvider()
,
                 ProviderMaintenanceProfile = new ProviderMaintenanceProfile()

         
 };

            return firstProviderMaintenanceCompleteProfile;
        }

       public ProviderMaintenanceCompleteProfile SecondProviderMaintenanceCompleteProfile()
        {

            var secondProviderMaintenanceCompleteProfile = new ProviderMaintenanceCompleteProfile {

                 MaintenanceProvider = new MaintenanceProvider()
,
                 ProviderMaintenanceProfile = new ProviderMaintenanceProfile()

        
 };

            return secondProviderMaintenanceCompleteProfile;
        }

       public ProviderMaintenanceCompleteProfile ThirdProviderMaintenanceCompleteProfile()
        {

            var thirdProviderMaintenanceCompleteProfile = new ProviderMaintenanceCompleteProfile {

                 MaintenanceProvider = new MaintenanceProvider()
,
                 ProviderMaintenanceProfile = new ProviderMaintenanceProfile()

 
 };

            return thirdProviderMaintenanceCompleteProfile;
        }

        ~FakeProviderMaintenanceCompleteProfile()
        {
            MyProviderMaintenanceCompleteProfiles = null;
        }
    }
}


    