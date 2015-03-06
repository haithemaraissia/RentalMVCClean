using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeaspnetPathss
    { 
       public List<aspnet_Paths> MyaspnetPathss;

       public FakeaspnetPathss()
        {
            Initializeaspnet_PathsList();
        }

       public void Initializeaspnet_PathsList()
        {
            MyaspnetPathss = new List<aspnet_Paths> {
                Firstaspnet_Paths(), 
                Secondaspnet_Paths(),
                Thirdaspnet_Paths()
            };
        }

       public aspnet_Paths Firstaspnet_Paths()
        {

            var firstaspnetPaths = new aspnet_Paths {

                 ApplicationId = new Guid()
,
                 PathId = new Guid()
,
                 Path = null,
                 LoweredPath = null,
                 aspnet_Applications = new aspnet_Applications()
,
//Skipping aspnet_PersonalizationPerUser Collection
                 aspnet_PersonalizationAllUsers = new aspnet_PersonalizationAllUsers()

    
 };

            return firstaspnetPaths;
        }

       public aspnet_Paths Secondaspnet_Paths()
        {

            var secondaspnetPaths = new aspnet_Paths {

                 ApplicationId = new Guid()
,
                 PathId = new Guid()
,
                 Path = null,
                 LoweredPath = null,
                 aspnet_Applications = new aspnet_Applications()
,
//Skipping aspnet_PersonalizationPerUser Collection
                 aspnet_PersonalizationAllUsers = new aspnet_PersonalizationAllUsers()

        
 };

            return secondaspnetPaths;
        }

       public aspnet_Paths Thirdaspnet_Paths()
        {

            var thirdaspnetPaths = new aspnet_Paths {

                 ApplicationId = new Guid()
,
                 PathId = new Guid()
,
                 Path = null,
                 LoweredPath = null,
                 aspnet_Applications = new aspnet_Applications()
,
//Skipping aspnet_PersonalizationPerUser Collection
                 aspnet_PersonalizationAllUsers = new aspnet_PersonalizationAllUsers()

 
 };

            return thirdaspnetPaths;
        }

        ~FakeaspnetPathss()
        {
            MyaspnetPathss = null;
        }
    }
}


    