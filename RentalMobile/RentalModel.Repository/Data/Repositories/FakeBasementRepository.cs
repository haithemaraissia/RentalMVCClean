using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeBasementRepository : FakeGenericRepository<Basement>
    {
        public FakeBasementRepository() : base(new FakeBasements().MyBasements)
        {
        }
        public FakeBasementRepository(List<Basement> myBasement): base(myBasement)
        {
        }

    }
}
       