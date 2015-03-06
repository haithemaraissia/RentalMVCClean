using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class Fakeaspnet_RolesRepository : FakeGenericRepository<aspnet_Roles>
    {
        public Fakeaspnet_RolesRepository() : base(new Fakeaspnet_Roless().Myaspnet_Roless)
        {
        }
        public Fakeaspnet_RolesRepository(List<aspnet_Roles> myaspnet_Roles): base(myaspnet_Roles)
        {
        }

    }
}
       