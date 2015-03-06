using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeProviderWorkRepository : FakeGenericRepository<ProviderWork>
    {
        public FakeProviderWorkRepository() : base(new FakeProviderWorks().MyProviderWorks)
        {
        }
        public FakeProviderWorkRepository(List<ProviderWork> myProviderWork): base(myProviderWork)
        {
        }

    }
}
       