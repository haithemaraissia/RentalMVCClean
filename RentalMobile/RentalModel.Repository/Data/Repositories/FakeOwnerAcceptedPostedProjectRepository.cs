using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeOwnerAcceptedPostedProjectRepository : FakeGenericRepository<OwnerAcceptedPostedProject>
    {
        public FakeOwnerAcceptedPostedProjectRepository() : base(new FakeOwnerAcceptedPostedProjects().MyOwnerAcceptedPostedProjects)
        {
        }
        public FakeOwnerAcceptedPostedProjectRepository(List<OwnerAcceptedPostedProject> myOwnerAcceptedPostedProject): base(myOwnerAcceptedPostedProject)
        {
        }

    }
}
       