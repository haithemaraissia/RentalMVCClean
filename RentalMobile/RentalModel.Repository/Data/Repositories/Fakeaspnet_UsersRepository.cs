using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeaspnetUsersRepository : FakeGenericRepository<aspnet_Users>
    {
        public FakeaspnetUsersRepository() : base(new FakeaspnetUserss().MyaspnetUserss)
        {
        }
        public FakeaspnetUsersRepository(List<aspnet_Users> myaspnetUsers): base(myaspnetUsers)
        {
        }

    }
}
       