using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeProjectPhotoRepository : FakeGenericRepository<ProjectPhoto>
    {
        public FakeProjectPhotoRepository() : base(new FakeProjectPhotos().MyProjectPhotos)
        {
        }
        public FakeProjectPhotoRepository(List<ProjectPhoto> myProjectPhoto): base(myProjectPhoto)
        {
        }

    }
}
       