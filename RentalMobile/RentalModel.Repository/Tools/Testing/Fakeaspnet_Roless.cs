using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class Fakeaspnet_Roles
    { 
       public List<aspnet_Roles> Myaspnet_Roless;

       public Fakeaspnet_Roles()
        {
            Initializeaspnet_RolesList();
        }

       public void Initializeaspnet_RolesList()
        {
            Myaspnet_Roless = new List<aspnet_Roles> {
                Firstaspnet_Roles(), 
                Secondaspnet_Roles(),
                Thirdaspnet_Roles()
            };
        }

       public aspnet_Roles Firstaspnet_Roles()
        {

            var firstaspnet_Roles = new aspnet_Roles {

                 ApplicationId = new Guid()
,
                 RoleId = new Guid()
,
                 RoleName = null,
                 LoweredRoleName = null,
                 Description = null,
                 aspnet_Applications = new aspnet_Applications()
,
//Skipping aspnet_Users Collection

    
 };

            return firstaspnet_Roles;
        }

       public aspnet_Roles Secondaspnet_Roles()
        {

            var secondaspnet_Roles = new aspnet_Roles {

                 ApplicationId = new Guid()
,
                 RoleId = new Guid()
,
                 RoleName = null,
                 LoweredRoleName = null,
                 Description = null,
                 aspnet_Applications = new aspnet_Applications()
,
//Skipping aspnet_Users Collection

        
 };

            return secondaspnet_Roles;
        }

       public aspnet_Roles Thirdaspnet_Roles()
        {

            var thirdaspnet_Roles = new aspnet_Roles {

                 ApplicationId = new Guid()
,
                 RoleId = new Guid()
,
                 RoleName = null,
                 LoweredRoleName = null,
                 Description = null,
                 aspnet_Applications = new aspnet_Applications()
,
//Skipping aspnet_Users Collection

 
 };

            return thirdaspnet_Roles;
        }

        ~Fakeaspnet_Roles()
        {
            Myaspnet_Roless = null;
        }
    }
}


    