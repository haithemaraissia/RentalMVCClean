using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Data.Tool;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeSpecialists
    { 
       public List<Specialist> MySpecialists;

       public FakeSpecialists()
        {
            InitializeSpecialistList();
        }

       public void InitializeSpecialistList()
        {
            MySpecialists = new List<Specialist> {
                FirstSpecialist(), 
                SecondSpecialist(),
                ThirdSpecialist()
            };
        }

       public Specialist FirstSpecialist()
        {

            var firstSpecialist = new Specialist {

                 SpecialistId = 1
,
                 FirstName = null,
                 LastName = null,
                 Address = null,
                 EmailAddress = null,
                 Description = null,
                // GUID = new CustomGuid().CreateGuid("BSNAItOawkSl07t77RKnMjYwYyG4bCt0g8DVDBv5m0")
                 GUID = new Guid("dddddddd-dddd-dddd-1111-dddddddddddd")
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
                 YouTubeVideo = new Boolean(),
                 YouTubeVideoURL = null,
                 VimeoVideo = new Boolean(),
                 VimeoVideoURL = null
    
 };

            return firstSpecialist;
        }

       public Specialist SecondSpecialist()
        {

            var secondSpecialist = new Specialist {

                 SpecialistId = 2
,
                 FirstName = null,
                 LastName = null,
                 Address = null,
                 EmailAddress = null,
                 Description = null,
                 GUID = new CustomGuid().CreateGuid("BSNePf57YwhzeE9QfOyepPfIPao4UD5UohG_fI-#eda7d")
,
                 VCard = null,
                 Skype = null,
                 Twitter = null,
                 LinkedIn = null,
                 GooglePlus = null,
                 Photo = null,
                 GoogleMap = null,
                 Country = "USA",
                 Region = null,
                 City = null,
                 Zip = null,
                 CountryCode = null,
                 PercentageofCompletion = new Int32(),
                 Rating = new Int32(),
                 YouTubeVideo = new Boolean(),
                 YouTubeVideoURL = null,
                 VimeoVideo = new Boolean(),
                 VimeoVideoURL = null
        
 };

            return secondSpecialist;
        }

       public Specialist ThirdSpecialist()
        {

            var thirdSpecialist = new Specialist {

                 SpecialistId = 3
,
                 FirstName = null,
                 LastName = null,
                 Address = null,
                 EmailAddress = null,
                 Description = null,
                 GUID = new CustomGuid().CreateGuid("BSNAItOeidr07t77RKnMjYwYyG4bCt0g8DVDBv5m0")
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
                 YouTubeVideo = new Boolean(),
                 YouTubeVideoURL = null,
                 VimeoVideo = new Boolean(),
                 VimeoVideoURL = null
 
 };

            return thirdSpecialist;
        }

        ~FakeSpecialists()
        {
            MySpecialists = null;
        }
    }
}


    