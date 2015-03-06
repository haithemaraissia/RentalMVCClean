using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class Fakeaspnet_MembershipRepository : FakeGenericRepository<aspnet_Membership>
    {
        public Fakeaspnet_MembershipRepository() : base(new Fakeaspnet_Memberships().Myaspnet_Memberships)
        {
        }
        public Fakeaspnet_MembershipRepository(List<aspnet_Membership> myaspnet_Membership): base(myaspnet_Membership)
        {
        }

    }
}
       