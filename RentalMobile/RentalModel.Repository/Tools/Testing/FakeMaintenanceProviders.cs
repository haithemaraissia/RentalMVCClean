using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenanceProvider
    { 
       public List<MaintenanceProvider> MyMaintenanceProviders;

       public FakeMaintenanceProvider()
        {
            InitializeMaintenanceProviderList();
        }

       public void InitializeMaintenanceProviderList()
        {
            MyMaintenanceProviders = new List<MaintenanceProvider> {
                FirstMaintenanceProvider(), 
                SecondMaintenanceProvider(),
                ThirdMaintenanceProvider()
            };
        }

       public MaintenanceProvider FirstMaintenanceProvider()
        {

            var firstMaintenanceProvider = new MaintenanceProvider {

                 MaintenanceProviderId = new Int32()
,
                 FirstName = null,
                 LastName = null,
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
                 CountryCode = null,
                 PercentageofCompletion = new Int32(),
                 Rating = new Int32(),
                 YouTubeVideo = new Boolean()
,
                 YouTubeVideoURL = null,
                 VimeoVideo = new Boolean()
,
                 VimeoVideoURL = null
    
 };

            return firstMaintenanceProvider;
        }

       public MaintenanceProvider SecondMaintenanceProvider()
        {

            var secondMaintenanceProvider = new MaintenanceProvider {

                 MaintenanceProviderId = new Int32()
,
                 FirstName = null,
                 LastName = null,
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
                 CountryCode = null,
                 PercentageofCompletion = new Int32(),
                 Rating = new Int32(),
                 YouTubeVideo = new Boolean()
,
                 YouTubeVideoURL = null,
                 VimeoVideo = new Boolean()
,
                 VimeoVideoURL = null
        
 };

            return secondMaintenanceProvider;
        }

       public MaintenanceProvider ThirdMaintenanceProvider()
        {

            var thirdMaintenanceProvider = new MaintenanceProvider {

                 MaintenanceProviderId = new Int32()
,
                 FirstName = null,
                 LastName = null,
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
                 CountryCode = null,
                 PercentageofCompletion = new Int32(),
                 Rating = new Int32(),
                 YouTubeVideo = new Boolean()
,
                 YouTubeVideoURL = null,
                 VimeoVideo = new Boolean()
,
                 VimeoVideoURL = null
 
 };

            return thirdMaintenanceProvider;
        }

        ~FakeMaintenanceProvider()
        {
            MyMaintenanceProviders = null;
        }
    }
}


    