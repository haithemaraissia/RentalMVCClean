using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeBathroomRepository : FakeGenericRepository<Bathroom>
    {
        public FakeBathroomRepository() : base(new FakeBathrooms().MyBathrooms)
        {
        }
        public FakeBathroomRepository(List<Bathroom> myBathroom): base(myBathroom)
        {
        }

    }
}
       