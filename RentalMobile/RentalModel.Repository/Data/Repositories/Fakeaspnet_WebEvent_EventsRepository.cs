using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class Fakeaspnet_WebEvent_EventsRepository : FakeGenericRepository<aspnet_WebEvent_Events>
    {
        public Fakeaspnet_WebEvent_EventsRepository() : base(new Fakeaspnet_WebEvent_Eventss().Myaspnet_WebEvent_Eventss)
        {
        }
        public Fakeaspnet_WebEvent_EventsRepository(List<aspnet_WebEvent_Events> myaspnet_WebEvent_Events): base(myaspnet_WebEvent_Events)
        {
        }

    }
}
       