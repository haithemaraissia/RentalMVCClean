using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class Fakeaspnet_PersonalizationPerUserRepository : FakeGenericRepository<aspnet_PersonalizationPerUser>
    {
        public Fakeaspnet_PersonalizationPerUserRepository() : base(new Fakeaspnet_PersonalizationPerUsers().Myaspnet_PersonalizationPerUsers)
        {
        }
        public Fakeaspnet_PersonalizationPerUserRepository(List<aspnet_PersonalizationPerUser> myaspnet_PersonalizationPerUser): base(myaspnet_PersonalizationPerUser)
        {
        }

    }
}
       