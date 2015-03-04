using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class Fakeaspnet_PersonalizationPerUser
    { 
       public List<aspnet_PersonalizationPerUser> Myaspnet_PersonalizationPerUsers;

       public Fakeaspnet_PersonalizationPerUser()
        {
            Initializeaspnet_PersonalizationPerUserList();
        }

       public void Initializeaspnet_PersonalizationPerUserList()
        {
            Myaspnet_PersonalizationPerUsers = new List<aspnet_PersonalizationPerUser> {
                Firstaspnet_PersonalizationPerUser(), 
                Secondaspnet_PersonalizationPerUser(),
                Thirdaspnet_PersonalizationPerUser()
            };
        }

       public aspnet_PersonalizationPerUser Firstaspnet_PersonalizationPerUser()
        {

            var firstaspnet_PersonalizationPerUser = new aspnet_PersonalizationPerUser {

                 Id = new Guid()
,
                 PathId = new Guid(),
                 UserId = new Guid(),
                 PageSettings = new Byte[new byte()]()
,
                 LastUpdatedDate = new DateTime()
,
                 aspnet_Paths = new aspnet_Paths()
,
                 aspnet_Users = new aspnet_Users()

    
 };

            return firstaspnet_PersonalizationPerUser;
        }

       public aspnet_PersonalizationPerUser Secondaspnet_PersonalizationPerUser()
        {

            var secondaspnet_PersonalizationPerUser = new aspnet_PersonalizationPerUser {

                 Id = new Guid()
,
                 PathId = new Guid(),
                 UserId = new Guid(),
                 PageSettings = new Byte[new byte()]()
,
                 LastUpdatedDate = new DateTime()
,
                 aspnet_Paths = new aspnet_Paths()
,
                 aspnet_Users = new aspnet_Users()

        
 };

            return secondaspnet_PersonalizationPerUser;
        }

       public aspnet_PersonalizationPerUser Thirdaspnet_PersonalizationPerUser()
        {

            var thirdaspnet_PersonalizationPerUser = new aspnet_PersonalizationPerUser {

                 Id = new Guid()
,
                 PathId = new Guid(),
                 UserId = new Guid(),
                 PageSettings = new Byte[new byte()]()
,
                 LastUpdatedDate = new DateTime()
,
                 aspnet_Paths = new aspnet_Paths()
,
                 aspnet_Users = new aspnet_Users()

 
 };

            return thirdaspnet_PersonalizationPerUser;
        }

        ~Fakeaspnet_PersonalizationPerUser()
        {
            Myaspnet_PersonalizationPerUsers = null;
        }
    }
}


    