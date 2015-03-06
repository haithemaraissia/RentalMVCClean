using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeMaintenanceCustomServiceRepository : FakeGenericRepository<MaintenanceCustomService>
    {
        public FakeMaintenanceCustomServiceRepository() : base(new FakeMaintenanceCustomServices().MyMaintenanceCustomServices)
        {
        }
        public FakeMaintenanceCustomServiceRepository(List<MaintenanceCustomService> myMaintenanceCustomService): base(myMaintenanceCustomService)
        {
        }

    }
}
       