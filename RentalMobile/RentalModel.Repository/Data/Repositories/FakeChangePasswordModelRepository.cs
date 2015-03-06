using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeChangePasswordModelRepository : FakeGenericRepository<ChangePasswordModel>
    {
        public FakeChangePasswordModelRepository() : base(new FakeChangePasswordModels().MyChangePasswordModels)
        {
        }
        public FakeChangePasswordModelRepository(List<ChangePasswordModel> myChangePasswordModel): base(myChangePasswordModel)
        {
        }

    }
}
       