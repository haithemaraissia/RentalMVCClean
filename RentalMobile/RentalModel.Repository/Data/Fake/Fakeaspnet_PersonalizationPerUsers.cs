using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeaspnetPersonalizationPerUsers
    { 
       public List<aspnet_PersonalizationPerUser> MyaspnetPersonalizationPerUsers;

       public FakeaspnetPersonalizationPerUsers()
        {
            Initializeaspnet_PersonalizationPerUserList();
        }

       public void Initializeaspnet_PersonalizationPerUserList()
        {
            MyaspnetPersonalizationPerUsers = new List<aspnet_PersonalizationPerUser> {
                Firstaspnet_PersonalizationPerUser(), 
                Secondaspnet_PersonalizationPerUser(),
                Thirdaspnet_PersonalizationPerUser()
            };
        }

       public aspnet_PersonalizationPerUser Firstaspnet_PersonalizationPerUser()
        {

            var firstaspnetPersonalizationPerUser = new aspnet_PersonalizationPerUser {

                 Id = new Guid()
,
                 PathId = new Guid(),
                 UserId = new Guid(),
                 PageSettings = new [] {new byte()}
,
                 LastUpdatedDate = new DateTime()
,
                 aspnet_Paths = new aspnet_Paths()
,
                 aspnet_Users = new aspnet_Users()

    
 };

            return firstaspnetPersonalizationPerUser;
        }

       public aspnet_PersonalizationPerUser Secondaspnet_PersonalizationPerUser()
        {

            var secondaspnetPersonalizationPerUser = new aspnet_PersonalizationPerUser {

                 Id = new Guid()
,
                 PathId = new Guid(),
                 UserId = new Guid(),
                 PageSettings = new [] {new byte()}
,
                 LastUpdatedDate = new DateTime()
,
                 aspnet_Paths = new aspnet_Paths()
,
                 aspnet_Users = new aspnet_Users()

        
 };

            return secondaspnetPersonalizationPerUser;
        }

       public aspnet_PersonalizationPerUser Thirdaspnet_PersonalizationPerUser()
        {

            var thirdaspnetPersonalizationPerUser = new aspnet_PersonalizationPerUser {

                 Id = new Guid()
,
                 PathId = new Guid(),
                 UserId = new Guid(),
                 PageSettings = new [] {new byte()}
,
                 LastUpdatedDate = new DateTime()
,
                 aspnet_Paths = new aspnet_Paths()
,
                 aspnet_Users = new aspnet_Users()

 
 };

            return thirdaspnetPersonalizationPerUser;
        }

        ~FakeaspnetPersonalizationPerUsers()
        {
            MyaspnetPersonalizationPerUsers = null;
        }
    }
}


    