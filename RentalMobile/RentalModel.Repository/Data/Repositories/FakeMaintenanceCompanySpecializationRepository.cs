using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeMaintenanceCompanySpecializationRepository : FakeGenericRepository<MaintenanceCompanySpecialization>
    {
        public FakeMaintenanceCompanySpecializationRepository() : base(new FakeMaintenanceCompanySpecializations().MyMaintenanceCompanySpecializations)
        {
        }
        public FakeMaintenanceCompanySpecializationRepository(List<MaintenanceCompanySpecialization> myMaintenanceCompanySpecialization): base(myMaintenanceCompanySpecialization)
        {
        }

    }
}
       