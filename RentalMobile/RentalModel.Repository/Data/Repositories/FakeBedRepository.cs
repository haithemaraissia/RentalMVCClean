using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeBedRepository : FakeGenericRepository<Bed>
    {
        public FakeBedRepository() : base(new FakeBeds().MyBeds)
        {
        }
        public FakeBedRepository(List<Bed> myBed): base(myBed)
        {
        }

    }
}
       