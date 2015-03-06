using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeOwnerMaintenanceRepository : FakeGenericRepository<OwnerMaintenance>
    {
        public FakeOwnerMaintenanceRepository() : base(new FakeOwnerMaintenances().MyOwnerMaintenances)
        {
        }
        public FakeOwnerMaintenanceRepository(List<OwnerMaintenance> myOwnerMaintenance): base(myOwnerMaintenance)
        {
        }

    }
}
       