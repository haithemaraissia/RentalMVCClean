using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeaspnetApplicationsRepository : FakeGenericRepository<aspnet_Applications>
    {
        public FakeaspnetApplicationsRepository() : base(new FakeaspnetApplicationss().MyaspnetApplicationss)
        {
        }
        public FakeaspnetApplicationsRepository(List<aspnet_Applications> myaspnetApplications): base(myaspnetApplications)
        {
        }

    }
}
       