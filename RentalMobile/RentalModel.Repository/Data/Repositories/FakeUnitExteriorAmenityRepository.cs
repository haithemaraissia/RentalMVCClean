using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeUnitExteriorAmenityRepository : FakeGenericRepository<UnitExteriorAmenity>
    {
        public FakeUnitExteriorAmenityRepository() : base(new FakeUnitExteriorAmenitys().MyUnitExteriorAmenitys)
        {
        }
        public FakeUnitExteriorAmenityRepository(List<UnitExteriorAmenity> myUnitExteriorAmenity): base(myUnitExteriorAmenity)
        {
        }

    }
}
       