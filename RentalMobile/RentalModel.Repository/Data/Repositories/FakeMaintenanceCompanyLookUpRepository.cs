using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeMaintenanceCompanyLookUpRepository : FakeGenericRepository<MaintenanceCompanyLookUp>
    {
        public FakeMaintenanceCompanyLookUpRepository() : base(new FakeMaintenanceCompanyLookUps().MyMaintenanceCompanyLookUps)
        {
        }
        public FakeMaintenanceCompanyLookUpRepository(List<MaintenanceCompanyLookUp> myMaintenanceCompanyLookUp): base(myMaintenanceCompanyLookUp)
        {
        }

    }
}
       