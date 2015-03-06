using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeUnitTypeRepository : FakeGenericRepository<UnitType>
    {
        public FakeUnitTypeRepository() : base(new FakeUnitTypes().MyUnitTypes)
        {
        }
        public FakeUnitTypeRepository(List<UnitType> myUnitType): base(myUnitType)
        {
        }

    }
}
       