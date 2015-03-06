using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeAgentAcceptedPostedProjectRepository : FakeGenericRepository<AgentAcceptedPostedProject>
    {
        public FakeAgentAcceptedPostedProjectRepository() : base(new FakeAgentAcceptedPostedProjects().MyAgentAcceptedPostedProjects)
        {
        }
        public FakeAgentAcceptedPostedProjectRepository(List<AgentAcceptedPostedProject> myAgentAcceptedPostedProject): base(myAgentAcceptedPostedProject)
        {
        }

    }
}
       