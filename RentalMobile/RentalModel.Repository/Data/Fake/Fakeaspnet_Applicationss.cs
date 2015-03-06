using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeaspnetApplicationss
    { 
       public List<aspnet_Applications> MyaspnetApplicationss;

       public FakeaspnetApplicationss()
        {
            Initializeaspnet_ApplicationsList();
        }

       public void Initializeaspnet_ApplicationsList()
        {
            MyaspnetApplicationss = new List<aspnet_Applications> {
                Firstaspnet_Applications(), 
                Secondaspnet_Applications(),
                Thirdaspnet_Applications()
            };
        }

       public aspnet_Applications Firstaspnet_Applications()
        {

            var firstaspnetApplications = new aspnet_Applications {

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

            return firstaspnetApplications;
        }

       public aspnet_Applications Secondaspnet_Applications()
        {

            var secondaspnetApplications = new aspnet_Applications {

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

            return secondaspnetApplications;
        }

       public aspnet_Applications Thirdaspnet_Applications()
        {

            var thirdaspnetApplications = new aspnet_Applications {

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

            return thirdaspnetApplications;
        }

        ~FakeaspnetApplicationss()
        {
            MyaspnetApplicationss = null;
        }
    }
}


    