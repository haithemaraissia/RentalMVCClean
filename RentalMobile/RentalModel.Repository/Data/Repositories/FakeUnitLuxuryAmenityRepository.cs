using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeUnitLuxuryAmenityRepository : FakeGenericRepository<UnitLuxuryAmenity>
    {
        public FakeUnitLuxuryAmenityRepository() : base(new FakeUnitLuxuryAmenitys().MyUnitLuxuryAmenitys)
        {
        }
        public FakeUnitLuxuryAmenityRepository(List<UnitLuxuryAmenity> myUnitLuxuryAmenity): base(myUnitLuxuryAmenity)
        {
        }

    }
}
       