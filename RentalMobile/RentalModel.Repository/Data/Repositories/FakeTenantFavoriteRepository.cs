using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeTenantFavoriteRepository : FakeGenericRepository<TenantFavorite>
    {
        public FakeTenantFavoriteRepository() : base(new FakeTenantFavorites().MyTenantFavorites)
        {
        }
        public FakeTenantFavoriteRepository(List<TenantFavorite> myTenantFavorite): base(myTenantFavorite)
        {
        }

    }
}
       