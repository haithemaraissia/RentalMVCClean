using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeaspnetPersonalizationAllUsersRepository : FakeGenericRepository<aspnet_PersonalizationAllUsers>
    {
        public FakeaspnetPersonalizationAllUsersRepository() : base(new FakeaspnetPersonalizationAllUserss().MyaspnetPersonalizationAllUserss)
        {
        }
        public FakeaspnetPersonalizationAllUsersRepository(List<aspnet_PersonalizationAllUsers> myaspnetPersonalizationAllUsers): base(myaspnetPersonalizationAllUsers)
        {
        }

    }
}
       