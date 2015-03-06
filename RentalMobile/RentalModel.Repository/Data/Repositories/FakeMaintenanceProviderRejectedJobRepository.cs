using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeMaintenanceProviderRejectedJobRepository : FakeGenericRepository<MaintenanceProviderRejectedJob>
    {
        public FakeMaintenanceProviderRejectedJobRepository() : base(new FakeMaintenanceProviderRejectedJobs().MyMaintenanceProviderRejectedJobs)
        {
        }
        public FakeMaintenanceProviderRejectedJobRepository(List<MaintenanceProviderRejectedJob> myMaintenanceProviderRejectedJob): base(myMaintenanceProviderRejectedJob)
        {
        }

    }
}
       