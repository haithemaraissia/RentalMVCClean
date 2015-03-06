using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeaspnetProfiles
    { 
       public List<aspnet_Profile> MyaspnetProfiles;

       public FakeaspnetProfiles()
        {
            Initializeaspnet_ProfileList();
        }

       public void Initializeaspnet_ProfileList()
        {
            MyaspnetProfiles = new List<aspnet_Profile> {
                Firstaspnet_Profile(), 
                Secondaspnet_Profile(),
                Thirdaspnet_Profile()
            };
        }

       public aspnet_Profile Firstaspnet_Profile()
        {

            var firstaspnetProfile = new aspnet_Profile {

                 UserId = new Guid()
,
                 PropertyNames = null,
                 PropertyValuesString = null,
                 PropertyValuesBinary = new [] {new byte()}
,
                 LastUpdatedDate = new DateTime()
,
                 aspnet_Users = new aspnet_Users()

    
 };

            return firstaspnetProfile;
        }

       public aspnet_Profile Secondaspnet_Profile()
        {

            var secondaspnetProfile = new aspnet_Profile {

                 UserId = new Guid()
,
                 PropertyNames = null,
                 PropertyValuesString = null,
                 PropertyValuesBinary = new [] {new byte()}
,
                 LastUpdatedDate = new DateTime()
,
                 aspnet_Users = new aspnet_Users()

        
 };

            return secondaspnetProfile;
        }

       public aspnet_Profile Thirdaspnet_Profile()
        {

            var thirdaspnetProfile = new aspnet_Profile {

                 UserId = new Guid()
,
                 PropertyNames = null,
                 PropertyValuesString = null,
                 PropertyValuesBinary = new [] {new byte()}
,
                 LastUpdatedDate = new DateTime()
,
                 aspnet_Users = new aspnet_Users()

 
 };

            return thirdaspnetProfile;
        }

        ~FakeaspnetProfiles()
        {
            MyaspnetProfiles = null;
        }
    }
}


    