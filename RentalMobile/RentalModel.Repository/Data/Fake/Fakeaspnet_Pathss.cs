using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class Fakeaspnet_Paths
    { 
       public List<aspnet_Paths> Myaspnet_Pathss;

       public Fakeaspnet_Paths()
        {
            Initializeaspnet_PathsList();
        }

       public void Initializeaspnet_PathsList()
        {
            Myaspnet_Pathss = new List<aspnet_Paths> {
                Firstaspnet_Paths(), 
                Secondaspnet_Paths(),
                Thirdaspnet_Paths()
            };
        }

       public aspnet_Paths Firstaspnet_Paths()
        {

            var firstaspnet_Paths = new aspnet_Paths {

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

            return firstaspnet_Paths;
        }

       public aspnet_Paths Secondaspnet_Paths()
        {

            var secondaspnet_Paths = new aspnet_Paths {

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

            return secondaspnet_Paths;
        }

       public aspnet_Paths Thirdaspnet_Paths()
        {

            var thirdaspnet_Paths = new aspnet_Paths {

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

            return thirdaspnet_Paths;
        }

        ~Fakeaspnet_Paths()
        {
            Myaspnet_Pathss = null;
        }
    }
}


    