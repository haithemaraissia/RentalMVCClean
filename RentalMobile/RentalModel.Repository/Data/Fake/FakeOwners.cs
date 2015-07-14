using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeOwners
    { 
       public List<Owner> MyOwners;

       public FakeOwners()
        {
            InitializeOwnerList();
        }

       public void InitializeOwnerList()
        {
            MyOwners = new List<Owner> {
                FirstOwner(), 
                SecondOwner(),
                ThirdOwner()
            };
        }

       public Owner FirstOwner()
        {

            var firstOwner = new Owner {

                 OwnerId = 1
,
                 FirstName = "Bob Owner",
                 LastName = "Godard",
                 Address = "8080 north Broadway, South Beach, Florida 5404",
                 EmailAddress = "BobGoddar@yahoo.com",
                 Description = "Bob Description",
                 GUID = new Guid("dddddddd-dddd-dddd-4567-dddddddddddd")
,
                 VCard = null,
                 Skype = null,
                 Twitter = null,
                 LinkedIn = null,
                 GooglePlus = null,
                 Photo = null,
                 GoogleMap = "Google Map",
                 Country = null,
                 Region = null,
                 City = null,
                 Zip = null,
                 CountryCode = null,
                 YouTubeVideo = new Boolean(),
                 YouTubeVideoURL = null,
                 VimeoVideo = new Boolean(),
                 VimeoVideoURL = "http://www.OwnerVimeo.com"
    
 };

            return firstOwner;
        }

       public Owner SecondOwner()
        {

            var secondOwner = new Owner {

                 OwnerId = new Int32()
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
                 VimeoVideoURL = null
        
 };

            return secondOwner;
        }

       public Owner ThirdOwner()
        {

            var thirdOwner = new Owner {

                 OwnerId = new Int32()
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
                 VimeoVideoURL = null
 
 };

            return thirdOwner;
        }

        ~FakeOwners()
        {
            MyOwners = null;
        }
    }
}


    