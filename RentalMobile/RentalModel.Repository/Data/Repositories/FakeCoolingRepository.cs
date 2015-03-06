using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeCoolingRepository : FakeGenericRepository<Cooling>
    {
        public FakeCoolingRepository() : base(new FakeCoolings().MyCoolings)
        {
        }
        public FakeCoolingRepository(List<Cooling> myCooling): base(myCooling)
        {
        }

    }
}
       