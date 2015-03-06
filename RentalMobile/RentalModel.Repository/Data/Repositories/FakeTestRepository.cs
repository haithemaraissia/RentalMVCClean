using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeTestRepository : FakeGenericRepository<Test>
    {
        public FakeTestRepository() : base(new FakeTests().MyTests)
        {
        }
        public FakeTestRepository(List<Test> myTest): base(myTest)
        {
        }

    }
}
       