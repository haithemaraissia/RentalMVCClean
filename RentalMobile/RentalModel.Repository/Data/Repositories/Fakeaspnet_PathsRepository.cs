using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeaspnetPathsRepository : FakeGenericRepository<aspnet_Paths>
    {
        public FakeaspnetPathsRepository() : base(new FakeaspnetPathss().MyaspnetPathss)
        {
        }
        public FakeaspnetPathsRepository(List<aspnet_Paths> myaspnetPaths): base(myaspnetPaths)
        {
        }

    }
}
       