using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeaspnetPersonalizationAllUserss
    { 
       public List<aspnet_PersonalizationAllUsers> MyaspnetPersonalizationAllUserss;

       public FakeaspnetPersonalizationAllUserss()
        {
            Initializeaspnet_PersonalizationAllUsersList();
        }

       public void Initializeaspnet_PersonalizationAllUsersList()
        {
            MyaspnetPersonalizationAllUserss = new List<aspnet_PersonalizationAllUsers> {
                Firstaspnet_PersonalizationAllUsers(), 
                Secondaspnet_PersonalizationAllUsers(),
                Thirdaspnet_PersonalizationAllUsers()
            };
        }

       public aspnet_PersonalizationAllUsers Firstaspnet_PersonalizationAllUsers()
        {

            var firstaspnetPersonalizationAllUsers = new aspnet_PersonalizationAllUsers {

                 PathId = new Guid()
,
                 PageSettings = new [] {new byte()}
,
                 LastUpdatedDate = new DateTime()
,
                 aspnet_Paths = new aspnet_Paths()

    
 };

            return firstaspnetPersonalizationAllUsers;
        }

       public aspnet_PersonalizationAllUsers Secondaspnet_PersonalizationAllUsers()
        {

            var secondaspnetPersonalizationAllUsers = new aspnet_PersonalizationAllUsers {

                 PathId = new Guid()
,
                 PageSettings = new [] {new byte()}
,
                 LastUpdatedDate = new DateTime()
,
                 aspnet_Paths = new aspnet_Paths()

        
 };

            return secondaspnetPersonalizationAllUsers;
        }

       public aspnet_PersonalizationAllUsers Thirdaspnet_PersonalizationAllUsers()
        {

            var thirdaspnetPersonalizationAllUsers = new aspnet_PersonalizationAllUsers {

                 PathId = new Guid()
,
                 PageSettings = new [] {new byte()}
,
                 LastUpdatedDate = new DateTime()
,
                 aspnet_Paths = new aspnet_Paths()

 
 };

            return thirdaspnetPersonalizationAllUsers;
        }

        ~FakeaspnetPersonalizationAllUserss()
        {
            MyaspnetPersonalizationAllUserss = null;
        }
    }
}


    