using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeFloorCoveringRepository : FakeGenericRepository<FloorCovering>
    {
        public FakeFloorCoveringRepository() : base(new FakeFloorCoverings().MyFloorCoverings)
        {
        }
        public FakeFloorCoveringRepository(List<FloorCovering> myFloorCovering): base(myFloorCovering)
        {
        }

    }
}
       