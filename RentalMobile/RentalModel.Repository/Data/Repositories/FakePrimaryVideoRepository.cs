using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakePrimaryVideoRepository : FakeGenericRepository<PrimaryVideo>
    {
        public FakePrimaryVideoRepository() : base(new FakePrimaryVideos().MyPrimaryVideos)
        {
        }
        public FakePrimaryVideoRepository(List<PrimaryVideo> myPrimaryVideo): base(myPrimaryVideo)
        {
        }

    }
}
       