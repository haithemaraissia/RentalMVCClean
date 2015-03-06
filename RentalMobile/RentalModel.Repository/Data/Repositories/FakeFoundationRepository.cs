using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeFoundationRepository : FakeGenericRepository<Foundation>
    {
        public FakeFoundationRepository() : base(new FakeFoundations().MyFoundations)
        {
        }
        public FakeFoundationRepository(List<Foundation> myFoundation): base(myFoundation)
        {
        }

    }
}
       