using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeSpecialistRepository : FakeGenericRepository<Specialist>
    {
        public FakeSpecialistRepository() : base(new FakeSpecialists().MySpecialists)
        {
        }
        public FakeSpecialistRepository(List<Specialist> mySpecialist): base(mySpecialist)
        {
        }

    }
}
       