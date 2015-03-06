using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeGarageRepository : FakeGenericRepository<Garage>
    {
        public FakeGarageRepository() : base(new FakeGarages().MyGarages)
        {
        }
        public FakeGarageRepository(List<Garage> myGarage): base(myGarage)
        {
        }

    }
}
       