using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeParkingSpaceRepository : FakeGenericRepository<ParkingSpace>
    {
        public FakeParkingSpaceRepository() : base(new FakeParkingSpaces().MyParkingSpaces)
        {
        }
        public FakeParkingSpaceRepository(List<ParkingSpace> myParkingSpace): base(myParkingSpace)
        {
        }

    }
}
       