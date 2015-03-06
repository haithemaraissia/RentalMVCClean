using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeTenantShowingRepository : FakeGenericRepository<TenantShowing>
    {
        public FakeTenantShowingRepository() : base(new FakeTenantShowings().MyTenantShowings)
        {
        }
        public FakeTenantShowingRepository(List<TenantShowing> myTenantShowing): base(myTenantShowing)
        {
        }

    }
}
       