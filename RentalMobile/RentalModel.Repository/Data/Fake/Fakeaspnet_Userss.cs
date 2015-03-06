using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeaspnetUserss
    { 
       public List<aspnet_Users> MyaspnetUserss;

       public FakeaspnetUserss()
        {
            Initializeaspnet_UsersList();
        }

       public void Initializeaspnet_UsersList()
        {
            MyaspnetUserss = new List<aspnet_Users> {
                Firstaspnet_Users(), 
                Secondaspnet_Users(),
                Thirdaspnet_Users()
            };
        }

       public aspnet_Users Firstaspnet_Users()
        {

            var firstaspnetUsers = new aspnet_Users {

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

            return firstaspnetUsers;
        }

       public aspnet_Users Secondaspnet_Users()
        {

            var secondaspnetUsers = new aspnet_Users {

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

            return secondaspnetUsers;
        }

       public aspnet_Users Thirdaspnet_Users()
        {

            var thirdaspnetUsers = new aspnet_Users {

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

            return thirdaspnetUsers;
        }

        ~FakeaspnetUserss()
        {
            MyaspnetUserss = null;
        }
    }
}


    