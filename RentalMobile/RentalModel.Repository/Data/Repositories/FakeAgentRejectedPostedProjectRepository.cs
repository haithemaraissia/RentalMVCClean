using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeAgentRejectedPostedProjectRepository : FakeGenericRepository<AgentRejectedPostedProject>
    {
        public FakeAgentRejectedPostedProjectRepository() : base(new FakeAgentRejectedPostedProjects().MyAgentRejectedPostedProjects)
        {
        }
        public FakeAgentRejectedPostedProjectRepository(List<AgentRejectedPostedProject> myAgentRejectedPostedProject): base(myAgentRejectedPostedProject)
        {
        }

    }
}
       