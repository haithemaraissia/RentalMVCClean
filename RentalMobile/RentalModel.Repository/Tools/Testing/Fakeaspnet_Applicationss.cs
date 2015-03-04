using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class Fakeaspnet_Applications
    { 
       public List<aspnet_Applications> Myaspnet_Applicationss;

       public Fakeaspnet_Applications()
        {
            Initializeaspnet_ApplicationsList();
        }

       public void Initializeaspnet_ApplicationsList()
        {
            Myaspnet_Applicationss = new List<aspnet_Applications> {
                Firstaspnet_Applications(), 
                Secondaspnet_Applications(),
                Thirdaspnet_Applications()
            };
        }

       public aspnet_Applications Firstaspnet_Applications()
        {

            var firstaspnet_Applications = new aspnet_Applications {

                 ApplicationName = null,
                 LoweredApplicationName = null,
                 ApplicationId = new Guid()
,
                 Description = null,
//Skipping aspnet_Membership Collection
//Skipping aspnet_Paths Collection
//Skipping aspnet_Roles Collection
//Skipping aspnet_Users Collection

    
 };

            return firstaspnet_Applications;
        }

       public aspnet_Applications Secondaspnet_Applications()
        {

            var secondaspnet_Applications = new aspnet_Applications {

                 ApplicationName = null,
                 LoweredApplicationName = null,
                 ApplicationId = new Guid()
,
                 Description = null,
//Skipping aspnet_Membership Collection
//Skipping aspnet_Paths Collection
//Skipping aspnet_Roles Collection
//Skipping aspnet_Users Collection

        
 };

            return secondaspnet_Applications;
        }

       public aspnet_Applications Thirdaspnet_Applications()
        {

            var thirdaspnet_Applications = new aspnet_Applications {

                 ApplicationName = null,
                 LoweredApplicationName = null,
                 ApplicationId = new Guid()
,
                 Description = null,
//Skipping aspnet_Membership Collection
//Skipping aspnet_Paths Collection
//Skipping aspnet_Roles Collection
//Skipping aspnet_Users Collection

 
 };

            return thirdaspnet_Applications;
        }

        ~Fakeaspnet_Applications()
        {
            Myaspnet_Applicationss = null;
        }
    }
}


    