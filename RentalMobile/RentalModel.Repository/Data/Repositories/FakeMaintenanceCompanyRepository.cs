using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeMaintenanceCompanyRepository : FakeGenericRepository<MaintenanceCompany>
    {
        public FakeMaintenanceCompanyRepository() : base(new FakeMaintenanceCompanys().MyMaintenanceCompanys)
        {
        }
        public FakeMaintenanceCompanyRepository(List<MaintenanceCompany> myMaintenanceCompany): base(myMaintenanceCompany)
        {
        }

    }
}
       