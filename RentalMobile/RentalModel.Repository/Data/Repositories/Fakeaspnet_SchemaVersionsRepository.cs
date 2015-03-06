using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class Fakeaspnet_SchemaVersionsRepository : FakeGenericRepository<aspnet_SchemaVersions>
    {
        public Fakeaspnet_SchemaVersionsRepository() : base(new Fakeaspnet_SchemaVersionss().Myaspnet_SchemaVersionss)
        {
        }
        public Fakeaspnet_SchemaVersionsRepository(List<aspnet_SchemaVersions> myaspnet_SchemaVersions): base(myaspnet_SchemaVersions)
        {
        }

    }
}
       