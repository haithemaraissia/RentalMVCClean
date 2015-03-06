using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeUnitApplianceRepository : FakeGenericRepository<UnitAppliance>
    {
        public FakeUnitApplianceRepository() : base(new FakeUnitAppliances().MyUnitAppliances)
        {
        }
        public FakeUnitApplianceRepository(List<UnitAppliance> myUnitAppliance): base(myUnitAppliance)
        {
        }

    }
}
       