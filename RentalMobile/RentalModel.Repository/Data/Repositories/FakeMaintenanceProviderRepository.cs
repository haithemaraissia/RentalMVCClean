using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeMaintenanceProviderRepository : FakeGenericRepository<MaintenanceProvider>
    {
        public FakeMaintenanceProviderRepository() : base(new FakeMaintenanceProviders().MyMaintenanceProviders)
        {
        }
        public FakeMaintenanceProviderRepository(List<MaintenanceProvider> myMaintenanceProvider): base(myMaintenanceProvider)
        {
        }

    }
}
       