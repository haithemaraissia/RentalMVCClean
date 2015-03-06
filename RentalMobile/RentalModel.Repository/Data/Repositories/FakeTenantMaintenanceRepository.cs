using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeTenantMaintenanceRepository : FakeGenericRepository<TenantMaintenance>
    {
        public FakeTenantMaintenanceRepository() : base(new FakeTenantMaintenances().MyTenantMaintenances)
        {
        }
        public FakeTenantMaintenanceRepository(List<TenantMaintenance> myTenantMaintenance): base(myTenantMaintenance)
        {
        }

    }
}
       