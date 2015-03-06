using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeUrgencyTypeRepository : FakeGenericRepository<UrgencyType>
    {
        public FakeUrgencyTypeRepository() : base(new FakeUrgencyTypes().MyUrgencyTypes)
        {
        }
        public FakeUrgencyTypeRepository(List<UrgencyType> myUrgencyType): base(myUrgencyType)
        {
        }

    }
}
       