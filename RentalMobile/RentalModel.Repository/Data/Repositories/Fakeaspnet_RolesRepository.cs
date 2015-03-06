using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeaspnetRolesRepository : FakeGenericRepository<aspnet_Roles>
    {
        public FakeaspnetRolesRepository() : base(new FakeaspnetRoless().MyaspnetRoless)
        {
        }
        public FakeaspnetRolesRepository(List<aspnet_Roles> myaspnetRoles): base(myaspnetRoles)
        {
        }

    }
}
       