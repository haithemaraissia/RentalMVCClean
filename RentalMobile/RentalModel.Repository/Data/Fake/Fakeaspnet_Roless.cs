using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeaspnetRoless
    { 
       public List<aspnet_Roles> MyaspnetRoless;

       public FakeaspnetRoless()
        {
            Initializeaspnet_RolesList();
        }

       public void Initializeaspnet_RolesList()
        {
            MyaspnetRoless = new List<aspnet_Roles> {
                Firstaspnet_Roles(), 
                Secondaspnet_Roles(),
                Thirdaspnet_Roles()
            };
        }

       public aspnet_Roles Firstaspnet_Roles()
        {

            var firstaspnetRoles = new aspnet_Roles {

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

            return firstaspnetRoles;
        }

       public aspnet_Roles Secondaspnet_Roles()
        {

            var secondaspnetRoles = new aspnet_Roles {

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

            return secondaspnetRoles;
        }

       public aspnet_Roles Thirdaspnet_Roles()
        {

            var thirdaspnetRoles = new aspnet_Roles {

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

            return thirdaspnetRoles;
        }

        ~FakeaspnetRoless()
        {
            MyaspnetRoless = null;
        }
    }
}


    