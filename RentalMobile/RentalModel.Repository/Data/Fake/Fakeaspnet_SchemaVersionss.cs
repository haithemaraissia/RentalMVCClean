using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class Fakeaspnet_SchemaVersions
    { 
       public List<aspnet_SchemaVersions> Myaspnet_SchemaVersionss;

       public Fakeaspnet_SchemaVersions()
        {
            Initializeaspnet_SchemaVersionsList();
        }

       public void Initializeaspnet_SchemaVersionsList()
        {
            Myaspnet_SchemaVersionss = new List<aspnet_SchemaVersions> {
                Firstaspnet_SchemaVersions(), 
                Secondaspnet_SchemaVersions(),
                Thirdaspnet_SchemaVersions()
            };
        }

       public aspnet_SchemaVersions Firstaspnet_SchemaVersions()
        {

            var firstaspnet_SchemaVersions = new aspnet_SchemaVersions {

                 Feature = null,
                 CompatibleSchemaVersion = null,
                 IsCurrentVersion = new Boolean()

    
 };

            return firstaspnet_SchemaVersions;
        }

       public aspnet_SchemaVersions Secondaspnet_SchemaVersions()
        {

            var secondaspnet_SchemaVersions = new aspnet_SchemaVersions {

                 Feature = null,
                 CompatibleSchemaVersion = null,
                 IsCurrentVersion = new Boolean()

        
 };

            return secondaspnet_SchemaVersions;
        }

       public aspnet_SchemaVersions Thirdaspnet_SchemaVersions()
        {

            var thirdaspnet_SchemaVersions = new aspnet_SchemaVersions {

                 Feature = null,
                 CompatibleSchemaVersion = null,
                 IsCurrentVersion = new Boolean()

 
 };

            return thirdaspnet_SchemaVersions;
        }

        ~Fakeaspnet_SchemaVersions()
        {
            Myaspnet_SchemaVersionss = null;
        }
    }
}


    