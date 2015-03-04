using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class Fakeaspnet_Profile
    { 
       public List<aspnet_Profile> Myaspnet_Profiles;

       public Fakeaspnet_Profile()
        {
            Initializeaspnet_ProfileList();
        }

       public void Initializeaspnet_ProfileList()
        {
            Myaspnet_Profiles = new List<aspnet_Profile> {
                Firstaspnet_Profile(), 
                Secondaspnet_Profile(),
                Thirdaspnet_Profile()
            };
        }

       public aspnet_Profile Firstaspnet_Profile()
        {

            var firstaspnet_Profile = new aspnet_Profile {

                 UserId = new Guid()
,
                 PropertyNames = null,
                 PropertyValuesString = null,
                 PropertyValuesBinary = new Byte[new byte()]()
,
                 LastUpdatedDate = new DateTime()
,
                 aspnet_Users = new aspnet_Users()

    
 };

            return firstaspnet_Profile;
        }

       public aspnet_Profile Secondaspnet_Profile()
        {

            var secondaspnet_Profile = new aspnet_Profile {

                 UserId = new Guid()
,
                 PropertyNames = null,
                 PropertyValuesString = null,
                 PropertyValuesBinary = new Byte[new byte()]()
,
                 LastUpdatedDate = new DateTime()
,
                 aspnet_Users = new aspnet_Users()

        
 };

            return secondaspnet_Profile;
        }

       public aspnet_Profile Thirdaspnet_Profile()
        {

            var thirdaspnet_Profile = new aspnet_Profile {

                 UserId = new Guid()
,
                 PropertyNames = null,
                 PropertyValuesString = null,
                 PropertyValuesBinary = new Byte[new byte()]()
,
                 LastUpdatedDate = new DateTime()
,
                 aspnet_Users = new aspnet_Users()

 
 };

            return thirdaspnet_Profile;
        }

        ~Fakeaspnet_Profile()
        {
            Myaspnet_Profiles = null;
        }
    }
}


    