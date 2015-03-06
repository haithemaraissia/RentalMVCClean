using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeaspnetSchemaVersionss
    { 
       public List<aspnet_SchemaVersions> MyaspnetSchemaVersionss;

       public FakeaspnetSchemaVersionss()
        {
            Initializeaspnet_SchemaVersionsList();
        }

       public void Initializeaspnet_SchemaVersionsList()
        {
            MyaspnetSchemaVersionss = new List<aspnet_SchemaVersions> {
                Firstaspnet_SchemaVersions(), 
                Secondaspnet_SchemaVersions(),
                Thirdaspnet_SchemaVersions()
            };
        }

       public aspnet_SchemaVersions Firstaspnet_SchemaVersions()
        {

            var firstaspnetSchemaVersions = new aspnet_SchemaVersions {

                 Feature = null,
                 CompatibleSchemaVersion = null,
                 IsCurrentVersion = new Boolean()

    
 };

            return firstaspnetSchemaVersions;
        }

       public aspnet_SchemaVersions Secondaspnet_SchemaVersions()
        {

            var secondaspnetSchemaVersions = new aspnet_SchemaVersions {

                 Feature = null,
                 CompatibleSchemaVersion = null,
                 IsCurrentVersion = new Boolean()

        
 };

            return secondaspnetSchemaVersions;
        }

       public aspnet_SchemaVersions Thirdaspnet_SchemaVersions()
        {

            var thirdaspnetSchemaVersions = new aspnet_SchemaVersions {

                 Feature = null,
                 CompatibleSchemaVersion = null,
                 IsCurrentVersion = new Boolean()

 
 };

            return thirdaspnetSchemaVersions;
        }

        ~FakeaspnetSchemaVersionss()
        {
            MyaspnetSchemaVersionss = null;
        }
    }
}


    