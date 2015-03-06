using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class Fakeaspnet_ApplicationsRepository : FakeGenericRepository<aspnet_Applications>
    {
        public Fakeaspnet_ApplicationsRepository() : base(new Fakeaspnet_Applicationss().Myaspnet_Applicationss)
        {
        }
        public Fakeaspnet_ApplicationsRepository(List<aspnet_Applications> myaspnet_Applications): base(myaspnet_Applications)
        {
        }

    }
}
       