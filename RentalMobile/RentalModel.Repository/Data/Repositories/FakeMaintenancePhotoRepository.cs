using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeMaintenancePhotoRepository : FakeGenericRepository<MaintenancePhoto>
    {
        public FakeMaintenancePhotoRepository() : base(new FakeMaintenancePhotos().MyMaintenancePhotos)
        {
        }
        public FakeMaintenancePhotoRepository(List<MaintenancePhoto> myMaintenancePhoto): base(myMaintenancePhoto)
        {
        }

    }
}
       