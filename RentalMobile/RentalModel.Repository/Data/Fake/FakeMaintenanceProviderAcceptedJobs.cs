using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenanceProviderAcceptedJobs
    { 
       public List<MaintenanceProviderAcceptedJob> MyMaintenanceProviderAcceptedJobs;

       public FakeMaintenanceProviderAcceptedJobs()
        {
            InitializeMaintenanceProviderAcceptedJobList();
        }

       public void InitializeMaintenanceProviderAcceptedJobList()
        {
            MyMaintenanceProviderAcceptedJobs = new List<MaintenanceProviderAcceptedJob> {
                FirstMaintenanceProviderAcceptedJob(), 
                SecondMaintenanceProviderAcceptedJob(),
                ThirdMaintenanceProviderAcceptedJob()
            };
        }

       public MaintenanceProviderAcceptedJob FirstMaintenanceProviderAcceptedJob()
        {

            var firstMaintenanceProviderAcceptedJob = new MaintenanceProviderAcceptedJob {

                 MaintenanceProviderId = new Int32()
,
                 TenantId = new Int32(),
                 TenantName = null,
                 TenantEmailAddress = null,
                 PropertyId = new Int32(),
                 StartDate = new DateTime(),
                 EndDate = new DateTime()
    
 };

            return firstMaintenanceProviderAcceptedJob;
        }

       public MaintenanceProviderAcceptedJob SecondMaintenanceProviderAcceptedJob()
        {

            var secondMaintenanceProviderAcceptedJob = new MaintenanceProviderAcceptedJob {

                 MaintenanceProviderId = new Int32()
,
                 TenantId = new Int32(),
                 TenantName = null,
                 TenantEmailAddress = null,
                 PropertyId = new Int32(),
                 StartDate = new DateTime(),
                 EndDate = new DateTime()
        
 };

            return secondMaintenanceProviderAcceptedJob;
        }

       public MaintenanceProviderAcceptedJob ThirdMaintenanceProviderAcceptedJob()
        {

            var thirdMaintenanceProviderAcceptedJob = new MaintenanceProviderAcceptedJob {

                 MaintenanceProviderId = new Int32()
,
                 TenantId = new Int32(),
                 TenantName = null,
                 TenantEmailAddress = null,
                 PropertyId = new Int32(),
                 StartDate = new DateTime(),
                 EndDate = new DateTime()
 
 };

            return thirdMaintenanceProviderAcceptedJob;
        }

        ~FakeMaintenanceProviderAcceptedJobs()
        {
            MyMaintenanceProviderAcceptedJobs = null;
        }
    }
}


    