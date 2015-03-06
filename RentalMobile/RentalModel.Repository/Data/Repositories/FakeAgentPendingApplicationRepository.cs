using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeAgentPendingApplicationRepository : FakeGenericRepository<AgentPendingApplication>
    {
        public FakeAgentPendingApplicationRepository() : base(new FakeAgentPendingApplications().MyAgentPendingApplications)
        {
        }
        public FakeAgentPendingApplicationRepository(List<AgentPendingApplication> myAgentPendingApplication): base(myAgentPendingApplication)
        {
        }

    }
}
       