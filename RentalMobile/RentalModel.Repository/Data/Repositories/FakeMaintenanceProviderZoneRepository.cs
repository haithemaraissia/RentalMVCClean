using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeMaintenanceProviderZoneRepository : FakeGenericRepository<MaintenanceProviderZone>
    {
        public FakeMaintenanceProviderZoneRepository() : base(new FakeMaintenanceProviderZones().MyMaintenanceProviderZones)
        {
        }
        public FakeMaintenanceProviderZoneRepository(List<MaintenanceProviderZone> myMaintenanceProviderZone): base(myMaintenanceProviderZone)
        {
        }

    }
}
       