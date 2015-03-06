using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeRegisterModelRepository : FakeGenericRepository<RegisterModel>
    {
        public FakeRegisterModelRepository() : base(new FakeRegisterModels().MyRegisterModels)
        {
        }
        public FakeRegisterModelRepository(List<RegisterModel> myRegisterModel): base(myRegisterModel)
        {
        }

    }
}
       