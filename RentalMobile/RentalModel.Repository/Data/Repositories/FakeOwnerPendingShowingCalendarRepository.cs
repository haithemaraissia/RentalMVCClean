using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeOwnerPendingShowingCalendarRepository : FakeGenericRepository<OwnerPendingShowingCalendar>
    {
        public FakeOwnerPendingShowingCalendarRepository() : base(new FakeOwnerPendingShowingCalendars().MyOwnerPendingShowingCalendars)
        {
        }
        public FakeOwnerPendingShowingCalendarRepository(List<OwnerPendingShowingCalendar> myOwnerPendingShowingCalendar): base(myOwnerPendingShowingCalendar)
        {
        }

    }
}
       