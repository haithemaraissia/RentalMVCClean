using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenanceProviderRejectedJobs
    { 
       public List<MaintenanceProviderRejectedJob> MyMaintenanceProviderRejectedJobs;

       public FakeMaintenanceProviderRejectedJobs()
        {
            InitializeMaintenanceProviderRejectedJobList();
        }

       public void InitializeMaintenanceProviderRejectedJobList()
        {
            MyMaintenanceProviderRejectedJobs = new List<MaintenanceProviderRejectedJob> {
                FirstMaintenanceProviderRejectedJob(), 
                SecondMaintenanceProviderRejectedJob(),
                ThirdMaintenanceProviderRejectedJob()
            };
        }

       public MaintenanceProviderRejectedJob FirstMaintenanceProviderRejectedJob()
        {

            var firstMaintenanceProviderRejectedJob = new MaintenanceProviderRejectedJob {

                 MaintenanceProviderId = new Int32()
,
                 TenantId = new Int32(),
                 TenantName = null,
                 TenantEmailAddress = null,
                 PropertyId = new Int32(),
                 StartDate = new DateTime(),
                 EndDate = new DateTime()
    
 };

            return firstMaintenanceProviderRejectedJob;
        }

       public MaintenanceProviderRejectedJob SecondMaintenanceProviderRejectedJob()
        {

            var secondMaintenanceProviderRejectedJob = new MaintenanceProviderRejectedJob {

                 MaintenanceProviderId = new Int32()
,
                 TenantId = new Int32(),
                 TenantName = null,
                 TenantEmailAddress = null,
                 PropertyId = new Int32(),
                 StartDate = new DateTime(),
                 EndDate = new DateTime()
        
 };

            return secondMaintenanceProviderRejectedJob;
        }

       public MaintenanceProviderRejectedJob ThirdMaintenanceProviderRejectedJob()
        {

            var thirdMaintenanceProviderRejectedJob = new MaintenanceProviderRejectedJob {

                 MaintenanceProviderId = new Int32()
,
                 TenantId = new Int32(),
                 TenantName = null,
                 TenantEmailAddress = null,
                 PropertyId = new Int32(),
                 StartDate = new DateTime(),
                 EndDate = new DateTime()
 
 };

            return thirdMaintenanceProviderRejectedJob;
        }

        ~FakeMaintenanceProviderRejectedJobs()
        {
            MyMaintenanceProviderRejectedJobs = null;
        }
    }
}


    