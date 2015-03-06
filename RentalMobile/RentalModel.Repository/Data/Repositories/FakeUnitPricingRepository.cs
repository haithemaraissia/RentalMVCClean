using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeUnitPricingRepository : FakeGenericRepository<UnitPricing>
    {
        public FakeUnitPricingRepository() : base(new FakeUnitPricings().MyUnitPricings)
        {
        }
        public FakeUnitPricingRepository(List<UnitPricing> myUnitPricing): base(myUnitPricing)
        {
        }

    }
}
       