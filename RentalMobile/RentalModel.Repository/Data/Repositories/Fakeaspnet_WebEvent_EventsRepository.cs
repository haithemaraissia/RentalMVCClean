using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeaspnetWebEventEventsRepository : FakeGenericRepository<aspnet_WebEvent_Events>
    {
        public FakeaspnetWebEventEventsRepository() : base(new FakeaspnetWebEventEventss().MyaspnetWebEventEventss)
        {
        }
        public FakeaspnetWebEventEventsRepository(List<aspnet_WebEvent_Events> myaspnetWebEventEvents): base(myaspnetWebEventEvents)
        {
        }

    }
}
       