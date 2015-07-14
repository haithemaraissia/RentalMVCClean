using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeTenants
    { 
       public List<Tenant> MyTenants;

       public FakeTenants()
        {
            InitializeTenantList();
        }

       public void InitializeTenantList()
        {
            MyTenants = new List<Tenant> {
                FirstTenant(), 
                SecondTenant(),
                ThirdTenant()
            };
        }

       public Tenant FirstTenant()
        {

            var firstTenant = new Tenant {

                 TenantId = 5
,
                 FirstName = null,
                 LastName = null,
                 Address = null,
                 EmailAddress = null,
                 Description = null,
                 GUID = new Guid("ffffffff-dddd-dddd-dddd-dddddddddddd")
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
                 YouTubeVideo = new Boolean(),
                 YouTubeVideoURL = "http://www.agenttenant.com",
                 VimeoVideo = new Boolean(),
                 VimeoVideoURL = null,
//Skipping TenantFavorite Collection
//Skipping TenantSavedSearch Collection
//Skipping TenantShowing Collection

    
 };

            return firstTenant;
        }

       public Tenant SecondTenant()
        {

            var secondTenant = new Tenant {

                 TenantId = new Int32()
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
                 YouTubeVideo = new Boolean(),
                 YouTubeVideoURL = null,
                 VimeoVideo = new Boolean(),
                 VimeoVideoURL = null,
//Skipping TenantFavorite Collection
//Skipping TenantSavedSearch Collection
//Skipping TenantShowing Collection

        
 };

            return secondTenant;
        }

       public Tenant ThirdTenant()
        {

            var thirdTenant = new Tenant {

                 TenantId = 3
,
                 FirstName = "Lynda Tenant",
                 LastName = "Smith",
                 Address = "5412 South Bronx, NY 2008",
                 EmailAddress = "lyndasmith@yahoo.com",
                 Description = "Lynda Description",
                 GUID = new Guid()
,
                 VCard = null,
                 Skype = null,
                 Twitter = null,
                 LinkedIn = null,
                 GooglePlus = "Google Map",
                 Photo = null,
                 GoogleMap = null,
                 Country = null,
                 Region = null,
                 City = null,
                 Zip = null,
                 CountryCode = null,
                 YouTubeVideo = new Boolean(),
                 YouTubeVideoURL = null,
                 VimeoVideo = new Boolean(),
                 VimeoVideoURL = null,
//Skipping TenantFavorite Collection
//Skipping TenantSavedSearch Collection
//Skipping TenantShowing Collection

 
 };

            return thirdTenant;
        }

        ~FakeTenants()
        {
            MyTenants = null;
        }
    }
}


    