using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeOwnerPendingApplicationRepository : FakeGenericRepository<OwnerPendingApplication>
    {
        public FakeOwnerPendingApplicationRepository() : base(new FakeOwnerPendingApplications().MyOwnerPendingApplications)
        {
        }
        public FakeOwnerPendingApplicationRepository(List<OwnerPendingApplication> myOwnerPendingApplication): base(myOwnerPendingApplication)
        {
        }

    }
}
       