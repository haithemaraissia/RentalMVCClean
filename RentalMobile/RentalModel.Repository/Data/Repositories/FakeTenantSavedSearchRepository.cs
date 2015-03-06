using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeTenantSavedSearchRepository : FakeGenericRepository<TenantSavedSearch>
    {
        public FakeTenantSavedSearchRepository() : base(new FakeTenantSavedSearchs().MyTenantSavedSearchs)
        {
        }
        public FakeTenantSavedSearchRepository(List<TenantSavedSearch> myTenantSavedSearch): base(myTenantSavedSearch)
        {
        }

    }
}
       