using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeAgentAcceptedApplicationRepository : FakeGenericRepository<AgentAcceptedApplication>
    {
        public FakeAgentAcceptedApplicationRepository() : base(new FakeAgentAcceptedApplications().MyAgentAcceptedApplications)
        {
        }
        public FakeAgentAcceptedApplicationRepository(List<AgentAcceptedApplication> myAgentAcceptedApplication): base(myAgentAcceptedApplication)
        {
        }

    }
}
       