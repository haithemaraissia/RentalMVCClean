using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeaspnetProfileRepository : FakeGenericRepository<aspnet_Profile>
    {
        public FakeaspnetProfileRepository() : base(new FakeaspnetProfiles().MyaspnetProfiles)
        {
        }
        public FakeaspnetProfileRepository(List<aspnet_Profile> myaspnetProfile): base(myaspnetProfile)
        {
        }

    }
}
       