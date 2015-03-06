using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeUnitModelViewRepository : FakeGenericRepository<UnitModelView>
    {
        public FakeUnitModelViewRepository() : base(new FakeUnitModelViews().MyUnitModelViews)
        {
        }
        public FakeUnitModelViewRepository(List<UnitModelView> myUnitModelView): base(myUnitModelView)
        {
        }

    }
}
       