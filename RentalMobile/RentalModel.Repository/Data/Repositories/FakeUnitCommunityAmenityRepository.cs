using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeUnitCommunityAmenityRepository : FakeGenericRepository<UnitCommunityAmenity>
    {
        public FakeUnitCommunityAmenityRepository() : base(new FakeUnitCommunityAmenitys().MyUnitCommunityAmenitys)
        {
        }
        public FakeUnitCommunityAmenityRepository(List<UnitCommunityAmenity> myUnitCommunityAmenity): base(myUnitCommunityAmenity)
        {
        }

    }
}
       