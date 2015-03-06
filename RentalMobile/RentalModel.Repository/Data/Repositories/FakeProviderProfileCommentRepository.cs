using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeProviderProfileCommentRepository : FakeGenericRepository<ProviderProfileComment>
    {
        public FakeProviderProfileCommentRepository() : base(new FakeProviderProfileComments().MyProviderProfileComments)
        {
        }
        public FakeProviderProfileCommentRepository(List<ProviderProfileComment> myProviderProfileComment): base(myProviderProfileComment)
        {
        }

    }
}
       