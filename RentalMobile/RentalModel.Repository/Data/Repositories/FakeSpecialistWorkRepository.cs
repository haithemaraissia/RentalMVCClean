using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeSpecialistWorkRepository : FakeGenericRepository<SpecialistWork>
    {
        public FakeSpecialistWorkRepository() : base(new FakeSpecialistWorks().MySpecialistWorks)
        {
        }
        public FakeSpecialistWorkRepository(List<SpecialistWork> mySpecialistWork): base(mySpecialistWork)
        {
        }

    }
}
       