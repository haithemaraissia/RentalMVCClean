using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeLogOnModelRepository : FakeGenericRepository<LogOnModel>
    {
        public FakeLogOnModelRepository() : base(new FakeLogOnModels().MyLogOnModels)
        {
        }
        public FakeLogOnModelRepository(List<LogOnModel> myLogOnModel): base(myLogOnModel)
        {
        }

    }
}
       