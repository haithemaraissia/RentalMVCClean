using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeaspnetMembershipRepository : FakeGenericRepository<aspnet_Membership>
    {
        public FakeaspnetMembershipRepository() : base(new FakeaspnetMemberships().MyaspnetMemberships)
        {
        }
        public FakeaspnetMembershipRepository(List<aspnet_Membership> myaspnetMembership): base(myaspnetMembership)
        {
        }

    }
}
       