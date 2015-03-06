using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeOwnerPendingShowingCalendarModelViewRepository : FakeGenericRepository<OwnerPendingShowingCalendarModelView>
    {
        public FakeOwnerPendingShowingCalendarModelViewRepository() : base(new FakeOwnerPendingShowingCalendarModelViews().MyOwnerPendingShowingCalendarModelViews)
        {
        }
        public FakeOwnerPendingShowingCalendarModelViewRepository(List<OwnerPendingShowingCalendarModelView> myOwnerPendingShowingCalendarModelView): base(myOwnerPendingShowingCalendarModelView)
        {
        }

    }
}
       