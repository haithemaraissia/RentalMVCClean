using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeOwnerAcceptedApplicationRepository : FakeGenericRepository<OwnerAcceptedApplication>
    {
        public FakeOwnerAcceptedApplicationRepository() : base(new FakeOwnerAcceptedApplications().MyOwnerAcceptedApplications)
        {
        }
        public FakeOwnerAcceptedApplicationRepository(List<OwnerAcceptedApplication> myOwnerAcceptedApplication): base(myOwnerAcceptedApplication)
        {
        }

    }
}
       