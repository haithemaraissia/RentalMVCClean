using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeOwnerPendingPostedProjectRepository : FakeGenericRepository<OwnerPendingPostedProject>
    {
        public FakeOwnerPendingPostedProjectRepository() : base(new FakeOwnerPendingPostedProjects().MyOwnerPendingPostedProjects)
        {
        }
        public FakeOwnerPendingPostedProjectRepository(List<OwnerPendingPostedProject> myOwnerPendingPostedProject): base(myOwnerPendingPostedProject)
        {
        }

    }
}
       