using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeAgentRepository : FakeGenericRepository<Agent>
    {
        public FakeAgentRepository() : base(new FakeAgents().MyAgents)
        {
        }
        public FakeAgentRepository(List<Agent> myAgent): base(myAgent)
        {
        }

    }
}
       