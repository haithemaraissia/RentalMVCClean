using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeProviderMaintenanceProfileRepository : FakeGenericRepository<ProviderMaintenanceProfile>
    {
        public FakeProviderMaintenanceProfileRepository() : base(new FakeProviderMaintenanceProfiles().MyProviderMaintenanceProfiles)
        {
        }
        public FakeProviderMaintenanceProfileRepository(List<ProviderMaintenanceProfile> myProviderMaintenanceProfile): base(myProviderMaintenanceProfile)
        {
        }

    }
}
       