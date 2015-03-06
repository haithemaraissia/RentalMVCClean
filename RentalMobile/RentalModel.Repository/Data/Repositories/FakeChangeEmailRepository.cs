using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeChangeEmailRepository : FakeGenericRepository<ChangeEmail>
    {
        public FakeChangeEmailRepository() : base(new FakeChangeEmails().MyChangeEmails)
        {
        }
        public FakeChangeEmailRepository(List<ChangeEmail> myChangeEmail): base(myChangeEmail)
        {
        }

    }
}
       