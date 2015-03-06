using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenanceProviderNewJobOffers
    { 
       public List<MaintenanceProviderNewJobOffer> MyMaintenanceProviderNewJobOffers;

       public FakeMaintenanceProviderNewJobOffers()
        {
            InitializeMaintenanceProviderNewJobOfferList();
        }

       public void InitializeMaintenanceProviderNewJobOfferList()
        {
            MyMaintenanceProviderNewJobOffers = new List<MaintenanceProviderNewJobOffer> {
                FirstMaintenanceProviderNewJobOffer(), 
                SecondMaintenanceProviderNewJobOffer(),
                ThirdMaintenanceProviderNewJobOffer()
            };
        }

       public MaintenanceProviderNewJobOffer FirstMaintenanceProviderNewJobOffer()
        {

            var firstMaintenanceProviderNewJobOffer = new MaintenanceProviderNewJobOffer {

                 MaintenanceProviderId = new Int32()
,
                 TenantId = new Int32(),
                 TenantName = null,
                 TenantEmailAddress = null,
                 PropertyId = new Int32(),
                 StartDate = new DateTime(),
                 EndDate = new DateTime()
    
 };

            return firstMaintenanceProviderNewJobOffer;
        }

       public MaintenanceProviderNewJobOffer SecondMaintenanceProviderNewJobOffer()
        {

            var secondMaintenanceProviderNewJobOffer = new MaintenanceProviderNewJobOffer {

                 MaintenanceProviderId = new Int32()
,
                 TenantId = new Int32(),
                 TenantName = null,
                 TenantEmailAddress = null,
                 PropertyId = new Int32(),
                 StartDate = new DateTime(),
                 EndDate = new DateTime()
        
 };

            return secondMaintenanceProviderNewJobOffer;
        }

       public MaintenanceProviderNewJobOffer ThirdMaintenanceProviderNewJobOffer()
        {

            var thirdMaintenanceProviderNewJobOffer = new MaintenanceProviderNewJobOffer {

                 MaintenanceProviderId = new Int32()
,
                 TenantId = new Int32(),
                 TenantName = null,
                 TenantEmailAddress = null,
                 PropertyId = new Int32(),
                 StartDate = new DateTime(),
                 EndDate = new DateTime()
 
 };

            return thirdMaintenanceProviderNewJobOffer;
        }

        ~FakeMaintenanceProviderNewJobOffers()
        {
            MyMaintenanceProviderNewJobOffers = null;
        }
    }
}


    