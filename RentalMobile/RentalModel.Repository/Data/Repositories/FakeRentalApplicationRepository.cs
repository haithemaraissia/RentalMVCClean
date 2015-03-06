using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeRentalApplicationRepository : FakeGenericRepository<RentalApplication>
    {
        public FakeRentalApplicationRepository() : base(new FakeRentalApplications().MyRentalApplications)
        {
        }
        public FakeRentalApplicationRepository(List<RentalApplication> myRentalApplication): base(myRentalApplication)
        {
        }

    }
}
       