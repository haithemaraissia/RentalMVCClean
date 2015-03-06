using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeaspnetPersonalizationPerUserRepository : FakeGenericRepository<aspnet_PersonalizationPerUser>
    {
        public FakeaspnetPersonalizationPerUserRepository() : base(new FakeaspnetPersonalizationPerUsers().MyaspnetPersonalizationPerUsers)
        {
        }
        public FakeaspnetPersonalizationPerUserRepository(List<aspnet_PersonalizationPerUser> myaspnetPersonalizationPerUser): base(myaspnetPersonalizationPerUser)
        {
        }

    }
}
       