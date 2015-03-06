using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeFloorRepository : FakeGenericRepository<Floor>
    {
        public FakeFloorRepository() : base(new FakeFloors().MyFloors)
        {
        }
        public FakeFloorRepository(List<Floor> myFloor): base(myFloor)
        {
        }

    }
}
       