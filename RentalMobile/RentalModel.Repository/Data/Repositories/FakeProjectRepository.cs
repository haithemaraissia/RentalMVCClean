using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeProjectRepository : FakeGenericRepository<Project>
    {
        public FakeProjectRepository() : base(new FakeProjects().MyProjects)
        {
        }
        public FakeProjectRepository(List<Project> myProject): base(myProject)
        {
        }

    }
}
       