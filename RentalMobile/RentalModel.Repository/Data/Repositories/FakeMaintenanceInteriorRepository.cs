using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeMaintenanceInteriorRepository : FakeGenericRepository<MaintenanceInterior>
    {
        public FakeMaintenanceInteriorRepository() : base(new FakeMaintenanceInteriors().MyMaintenanceInteriors)
        {
        }
        public FakeMaintenanceInteriorRepository(List<MaintenanceInterior> myMaintenanceInterior): base(myMaintenanceInterior)
        {
        }

    }
}
       