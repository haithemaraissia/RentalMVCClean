using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeUnitFeatureRepository : FakeGenericRepository<UnitFeature>
    {
        public FakeUnitFeatureRepository() : base(new FakeUnitFeatures().MyUnitFeatures)
        {
        }
        public FakeUnitFeatureRepository(List<UnitFeature> myUnitFeature): base(myUnitFeature)
        {
        }

    }
}
       