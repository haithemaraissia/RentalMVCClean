using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeUnitGalleryRepository : FakeGenericRepository<UnitGallery>
    {
        public FakeUnitGalleryRepository() : base(new FakeUnitGallerys().MyUnitGallerys)
        {
        }
        public FakeUnitGalleryRepository(List<UnitGallery> myUnitGallery): base(myUnitGallery)
        {
        }

    }
}
       