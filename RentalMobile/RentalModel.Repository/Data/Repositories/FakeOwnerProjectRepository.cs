using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeOwnerProjectRepository : FakeGenericRepository<OwnerProject>
    {
        public FakeOwnerProjectRepository() : base(new FakeOwnerProjects().MyOwnerProjects)
        {
        }
        public FakeOwnerProjectRepository(List<OwnerProject> myOwnerProject): base(myOwnerProject)
        {
        }

    }
}
       