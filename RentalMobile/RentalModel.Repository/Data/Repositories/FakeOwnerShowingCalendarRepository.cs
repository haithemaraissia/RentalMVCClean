using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeOwnerShowingCalendarRepository : FakeGenericRepository<OwnerShowingCalendar>
    {
        public FakeOwnerShowingCalendarRepository() : base(new FakeOwnerShowingCalendars().MyOwnerShowingCalendars)
        {
        }
        public FakeOwnerShowingCalendarRepository(List<OwnerShowingCalendar> myOwnerShowingCalendar): base(myOwnerShowingCalendar)
        {
        }

    }
}
       