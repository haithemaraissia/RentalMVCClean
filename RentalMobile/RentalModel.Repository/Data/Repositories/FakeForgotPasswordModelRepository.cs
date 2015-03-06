using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeForgotPasswordModelRepository : FakeGenericRepository<ForgotPasswordModel>
    {
        public FakeForgotPasswordModelRepository() : base(new FakeForgotPasswordModels().MyForgotPasswordModels)
        {
        }
        public FakeForgotPasswordModelRepository(List<ForgotPasswordModel> myForgotPasswordModel): base(myForgotPasswordModel)
        {
        }

    }
}
       