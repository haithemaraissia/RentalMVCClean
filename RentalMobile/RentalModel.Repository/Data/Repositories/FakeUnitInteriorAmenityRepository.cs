using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeUnitInteriorAmenityRepository : FakeGenericRepository<UnitInteriorAmenity>
    {
        public FakeUnitInteriorAmenityRepository() : base(new FakeUnitInteriorAmenitys().MyUnitInteriorAmenitys)
        {
        }
        public FakeUnitInteriorAmenityRepository(List<UnitInteriorAmenity> myUnitInteriorAmenity): base(myUnitInteriorAmenity)
        {
        }

    }
}
       