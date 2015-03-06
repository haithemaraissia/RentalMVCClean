using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeOwnerRepository : FakeGenericRepository<Owner>
    {
        public FakeOwnerRepository() : base(new FakeOwners().MyOwners)
        {
        }
        public FakeOwnerRepository(List<Owner> myOwner): base(myOwner)
        {
        }

    }
}
       