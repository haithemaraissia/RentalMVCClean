using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeTenantModelViewRepository : FakeGenericRepository<TenantModelView>
    {
        public FakeTenantModelViewRepository() : base(new FakeTenantModelViews().MyTenantModelViews)
        {
        }
        public FakeTenantModelViewRepository(List<TenantModelView> myTenantModelView): base(myTenantModelView)
        {
        }

    }
}
       