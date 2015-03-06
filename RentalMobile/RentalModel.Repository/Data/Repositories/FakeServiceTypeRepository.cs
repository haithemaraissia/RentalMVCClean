using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeServiceTypeRepository : FakeGenericRepository<ServiceType>
    {
        public FakeServiceTypeRepository() : base(new FakeServiceTypes().MyServiceTypes)
        {
        }
        public FakeServiceTypeRepository(List<ServiceType> myServiceType): base(myServiceType)
        {
        }

    }
}
       