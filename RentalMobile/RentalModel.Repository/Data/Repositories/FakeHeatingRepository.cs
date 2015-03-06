using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeHeatingRepository : FakeGenericRepository<Heating>
    {
        public FakeHeatingRepository() : base(new FakeHeatings().MyHeatings)
        {
        }
        public FakeHeatingRepository(List<Heating> myHeating): base(myHeating)
        {
        }

    }
}
       