using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeMaintenanceExteriorRepository : FakeGenericRepository<MaintenanceExterior>
    {
        public FakeMaintenanceExteriorRepository() : base(new FakeMaintenanceExteriors().MyMaintenanceExteriors)
        {
        }
        public FakeMaintenanceExteriorRepository(List<MaintenanceExterior> myMaintenanceExterior): base(myMaintenanceExterior)
        {
        }

    }
}
       