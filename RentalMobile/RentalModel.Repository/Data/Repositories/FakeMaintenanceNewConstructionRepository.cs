using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeMaintenanceNewConstructionRepository : FakeGenericRepository<MaintenanceNewConstruction>
    {
        public FakeMaintenanceNewConstructionRepository() : base(new FakeMaintenanceNewConstructions().MyMaintenanceNewConstructions)
        {
        }
        public FakeMaintenanceNewConstructionRepository(List<MaintenanceNewConstruction> myMaintenanceNewConstruction): base(myMaintenanceNewConstruction)
        {
        }

    }
}
       