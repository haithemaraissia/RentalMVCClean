using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeMaintenanceProviderNewJobOfferRepository : FakeGenericRepository<MaintenanceProviderNewJobOffer>
    {
        public FakeMaintenanceProviderNewJobOfferRepository() : base(new FakeMaintenanceProviderNewJobOffers().MyMaintenanceProviderNewJobOffers)
        {
        }
        public FakeMaintenanceProviderNewJobOfferRepository(List<MaintenanceProviderNewJobOffer> myMaintenanceProviderNewJobOffer): base(myMaintenanceProviderNewJobOffer)
        {
        }

    }
}
       