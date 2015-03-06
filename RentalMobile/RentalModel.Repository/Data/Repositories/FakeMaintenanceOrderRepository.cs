using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeMaintenanceOrderRepository : FakeGenericRepository<MaintenanceOrder>
    {
        public FakeMaintenanceOrderRepository() : base(new FakeMaintenanceOrders().MyMaintenanceOrders)
        {
        }
        public FakeMaintenanceOrderRepository(List<MaintenanceOrder> myMaintenanceOrder): base(myMaintenanceOrder)
        {
        }

    }
}
       