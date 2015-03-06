using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeMaintenanceRepairRepository : FakeGenericRepository<MaintenanceRepair>
    {
        public FakeMaintenanceRepairRepository() : base(new FakeMaintenanceRepairs().MyMaintenanceRepairs)
        {
        }
        public FakeMaintenanceRepairRepository(List<MaintenanceRepair> myMaintenanceRepair): base(myMaintenanceRepair)
        {
        }

    }
}
       