using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class Fakeaspnet_Userss
    { 
       public List<aspnet_Users> Myaspnet_Userss;

       public Fakeaspnet_Userss()
        {
            Initializeaspnet_UsersList();
        }

       public void Initializeaspnet_UsersList()
        {
            Myaspnet_Userss = new List<aspnet_Users> {
                Firstaspnet_Users(), 
                Secondaspnet_Users(),
                Thirdaspnet_Users()
            };
        }

       public aspnet_Users Firstaspnet_Users()
        {

            var firstaspnet_Users = new aspnet_Users {

                 ApplicationId = new Guid()
,
                 UserId = new Guid()
,
                 UserName = null,
                 LoweredUserName = null,
                 MobileAlias = null,
                 IsAnonymous = new Boolean()
,
                 LastActivityDate = new DateTime()
,
                 aspnet_Applications = new aspnet_Applications()
,
                 aspnet_Membership = new aspnet_Membership()
,
//Skipping aspnet_PersonalizationPerUser Collection
                 aspnet_Profile = new aspnet_Profile()
,
//Skipping aspnet_Roles Collection

    
 };

            return firstaspnet_Users;
        }

       public aspnet_Users Secondaspnet_Users()
        {

            var secondaspnet_Users = new aspnet_Users {

                 ApplicationId = new Guid()
,
                 UserId = new Guid()
,
                 UserName = null,
                 LoweredUserName = null,
                 MobileAlias = null,
                 IsAnonymous = new Boolean()
,
                 LastActivityDate = new DateTime()
,
                 aspnet_Applications = new aspnet_Applications()
,
                 aspnet_Membership = new aspnet_Membership()
,
//Skipping aspnet_PersonalizationPerUser Collection
                 aspnet_Profile = new aspnet_Profile()
,
//Skipping aspnet_Roles Collection

        
 };

            return secondaspnet_Users;
        }

       public aspnet_Users Thirdaspnet_Users()
        {

            var thirdaspnet_Users = new aspnet_Users {

                 ApplicationId = new Guid()
,
                 UserId = new Guid()
,
                 UserName = null,
                 LoweredUserName = null,
                 MobileAlias = null,
                 IsAnonymous = new Boolean()
,
                 LastActivityDate = new DateTime()
,
                 aspnet_Applications = new aspnet_Applications()
,
                 aspnet_Membership = new aspnet_Membership()
,
//Skipping aspnet_PersonalizationPerUser Collection
                 aspnet_Profile = new aspnet_Profile()
,
//Skipping aspnet_Roles Collection

 
 };

            return thirdaspnet_Users;
        }

        ~Fakeaspnet_Userss()
        {
            Myaspnet_Userss = null;
        }
    }
}


    