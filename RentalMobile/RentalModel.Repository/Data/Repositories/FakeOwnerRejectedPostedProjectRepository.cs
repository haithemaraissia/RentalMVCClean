using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeOwnerRejectedPostedProjectRepository : FakeGenericRepository<OwnerRejectedPostedProject>
    {
        public FakeOwnerRejectedPostedProjectRepository() : base(new FakeOwnerRejectedPostedProjects().MyOwnerRejectedPostedProjects)
        {
        }
        public FakeOwnerRejectedPostedProjectRepository(List<OwnerRejectedPostedProject> myOwnerRejectedPostedProject): base(myOwnerRejectedPostedProject)
        {
        }

    }
}
       