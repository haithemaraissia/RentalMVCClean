using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class Fakeaspnet_UsersRepository : FakeGenericRepository<aspnet_Users>
    {
        public Fakeaspnet_UsersRepository() : base(new Fakeaspnet_Userss().Myaspnet_Userss)
        {
        }
        public Fakeaspnet_UsersRepository(List<aspnet_Users> myaspnet_Users): base(myaspnet_Users)
        {
        }

    }
}
       