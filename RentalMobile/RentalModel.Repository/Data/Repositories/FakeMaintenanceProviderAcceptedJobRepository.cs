using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeMaintenanceProviderAcceptedJobRepository : FakeGenericRepository<MaintenanceProviderAcceptedJob>
    {
        public FakeMaintenanceProviderAcceptedJobRepository() : base(new FakeMaintenanceProviderAcceptedJobs().MyMaintenanceProviderAcceptedJobs)
        {
        }
        public FakeMaintenanceProviderAcceptedJobRepository(List<MaintenanceProviderAcceptedJob> myMaintenanceProviderAcceptedJob): base(myMaintenanceProviderAcceptedJob)
        {
        }

    }
}
       