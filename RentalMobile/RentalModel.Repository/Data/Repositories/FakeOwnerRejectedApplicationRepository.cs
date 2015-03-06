using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeOwnerRejectedApplicationRepository : FakeGenericRepository<OwnerRejectedApplication>
    {
        public FakeOwnerRejectedApplicationRepository() : base(new FakeOwnerRejectedApplications().MyOwnerRejectedApplications)
        {
        }
        public FakeOwnerRejectedApplicationRepository(List<OwnerRejectedApplication> myOwnerRejectedApplication): base(myOwnerRejectedApplication)
        {
        }

    }
}
       