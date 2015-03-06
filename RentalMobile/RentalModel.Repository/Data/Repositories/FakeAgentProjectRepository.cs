using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeAgentProjectRepository : FakeGenericRepository<AgentProject>
    {
        public FakeAgentProjectRepository() : base(new FakeAgentProjects().MyAgentProjects)
        {
        }
        public FakeAgentProjectRepository(List<AgentProject> myAgentProject): base(myAgentProject)
        {
        }

    }
}
       