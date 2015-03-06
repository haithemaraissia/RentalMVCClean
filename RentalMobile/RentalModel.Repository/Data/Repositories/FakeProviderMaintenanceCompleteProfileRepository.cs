using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeProviderMaintenanceCompleteProfileRepository : FakeGenericRepository<ProviderMaintenanceCompleteProfile>
    {
        public FakeProviderMaintenanceCompleteProfileRepository() : base(new FakeProviderMaintenanceCompleteProfiles().MyProviderMaintenanceCompleteProfiles)
        {
        }
        public FakeProviderMaintenanceCompleteProfileRepository(List<ProviderMaintenanceCompleteProfile> myProviderMaintenanceCompleteProfile): base(myProviderMaintenanceCompleteProfile)
        {
        }

    }
}
       