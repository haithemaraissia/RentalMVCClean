using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class Fakeaspnet_PersonalizationAllUsers
    { 
       public List<aspnet_PersonalizationAllUsers> Myaspnet_PersonalizationAllUserss;

       public Fakeaspnet_PersonalizationAllUsers()
        {
            Initializeaspnet_PersonalizationAllUsersList();
        }

       public void Initializeaspnet_PersonalizationAllUsersList()
        {
            Myaspnet_PersonalizationAllUserss = new List<aspnet_PersonalizationAllUsers> {
                Firstaspnet_PersonalizationAllUsers(), 
                Secondaspnet_PersonalizationAllUsers(),
                Thirdaspnet_PersonalizationAllUsers()
            };
        }

       public aspnet_PersonalizationAllUsers Firstaspnet_PersonalizationAllUsers()
        {

            var firstaspnet_PersonalizationAllUsers = new aspnet_PersonalizationAllUsers {

                 PathId = new Guid()
,
                 PageSettings = new Byte[new byte()]()
,
                 LastUpdatedDate = new DateTime()
,
                 aspnet_Paths = new aspnet_Paths()

    
 };

            return firstaspnet_PersonalizationAllUsers;
        }

       public aspnet_PersonalizationAllUsers Secondaspnet_PersonalizationAllUsers()
        {

            var secondaspnet_PersonalizationAllUsers = new aspnet_PersonalizationAllUsers {

                 PathId = new Guid()
,
                 PageSettings = new Byte[new byte()]()
,
                 LastUpdatedDate = new DateTime()
,
                 aspnet_Paths = new aspnet_Paths()

        
 };

            return secondaspnet_PersonalizationAllUsers;
        }

       public aspnet_PersonalizationAllUsers Thirdaspnet_PersonalizationAllUsers()
        {

            var thirdaspnet_PersonalizationAllUsers = new aspnet_PersonalizationAllUsers {

                 PathId = new Guid()
,
                 PageSettings = new Byte[new byte()]()
,
                 LastUpdatedDate = new DateTime()
,
                 aspnet_Paths = new aspnet_Paths()

 
 };

            return thirdaspnet_PersonalizationAllUsers;
        }

        ~Fakeaspnet_PersonalizationAllUsers()
        {
            Myaspnet_PersonalizationAllUserss = null;
        }
    }
}


    