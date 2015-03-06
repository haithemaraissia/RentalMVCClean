using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeMaintenanceUtilityRepository : FakeGenericRepository<MaintenanceUtility>
    {
        public FakeMaintenanceUtilityRepository() : base(new FakeMaintenanceUtilitys().MyMaintenanceUtilitys)
        {
        }
        public FakeMaintenanceUtilityRepository(List<MaintenanceUtility> myMaintenanceUtility): base(myMaintenanceUtility)
        {
        }

    }
}
       