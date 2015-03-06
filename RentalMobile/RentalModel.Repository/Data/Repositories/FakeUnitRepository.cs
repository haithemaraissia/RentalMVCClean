using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeUnitRepository : FakeGenericRepository<Unit>
    {
        public FakeUnitRepository() : base(new FakeUnits().MyUnits)
        {
        }
        public FakeUnitRepository(List<Unit> myUnit): base(myUnit)
        {
        }

    }
}
       