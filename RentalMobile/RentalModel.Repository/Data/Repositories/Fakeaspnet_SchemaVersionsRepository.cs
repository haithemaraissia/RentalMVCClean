using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeaspnetSchemaVersionsRepository : FakeGenericRepository<aspnet_SchemaVersions>
    {
        public FakeaspnetSchemaVersionsRepository() : base(new FakeaspnetSchemaVersionss().MyaspnetSchemaVersionss)
        {
        }
        public FakeaspnetSchemaVersionsRepository(List<aspnet_SchemaVersions> myaspnetSchemaVersions): base(myaspnetSchemaVersions)
        {
        }

    }
}
       