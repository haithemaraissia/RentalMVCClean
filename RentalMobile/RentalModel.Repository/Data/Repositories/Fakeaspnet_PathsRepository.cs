using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class Fakeaspnet_PathsRepository : FakeGenericRepository<aspnet_Paths>
    {
        public Fakeaspnet_PathsRepository() : base(new Fakeaspnet_Pathss().Myaspnet_Pathss)
        {
        }
        public Fakeaspnet_PathsRepository(List<aspnet_Paths> myaspnet_Paths): base(myaspnet_Paths)
        {
        }

    }
}
       