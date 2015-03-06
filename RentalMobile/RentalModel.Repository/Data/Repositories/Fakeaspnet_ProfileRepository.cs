using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class Fakeaspnet_ProfileRepository : FakeGenericRepository<aspnet_Profile>
    {
        public Fakeaspnet_ProfileRepository() : base(new Fakeaspnet_Profiles().Myaspnet_Profiles)
        {
        }
        public Fakeaspnet_ProfileRepository(List<aspnet_Profile> myaspnet_Profile): base(myaspnet_Profile)
        {
        }

    }
}
       