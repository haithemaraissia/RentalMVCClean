using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeTenantRepository : FakeGenericRepository<Tenant>
    {
        public FakeTenantRepository() : base(new FakeTenants().MyTenants)
        {
        }
        public FakeTenantRepository(List<Tenant> myTenant): base(myTenant)
        {
        }

    }
}
       