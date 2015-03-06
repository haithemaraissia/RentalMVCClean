using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeTenantMaintenanceViewModelRepository : FakeGenericRepository<TenantMaintenanceViewModel>
    {
        public FakeTenantMaintenanceViewModelRepository() : base(new FakeTenantMaintenanceViewModels().MyTenantMaintenanceViewModels)
        {
        }
        public FakeTenantMaintenanceViewModelRepository(List<TenantMaintenanceViewModel> myTenantMaintenanceViewModel): base(myTenantMaintenanceViewModel)
        {
        }

    }
}
       