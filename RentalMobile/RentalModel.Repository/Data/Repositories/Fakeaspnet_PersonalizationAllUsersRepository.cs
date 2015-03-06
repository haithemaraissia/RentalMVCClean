using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class Fakeaspnet_PersonalizationAllUsersRepository : FakeGenericRepository<aspnet_PersonalizationAllUsers>
    {
        public Fakeaspnet_PersonalizationAllUsersRepository() : base(new Fakeaspnet_PersonalizationAllUserss().Myaspnet_PersonalizationAllUserss)
        {
        }
        public Fakeaspnet_PersonalizationAllUsersRepository(List<aspnet_PersonalizationAllUsers> myaspnet_PersonalizationAllUsers): base(myaspnet_PersonalizationAllUsers)
        {
        }

    }
}
       