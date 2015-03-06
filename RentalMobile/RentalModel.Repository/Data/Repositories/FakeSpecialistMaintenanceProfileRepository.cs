using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeSpecialistMaintenanceProfileRepository : FakeGenericRepository<SpecialistMaintenanceProfile>
    {
        public FakeSpecialistMaintenanceProfileRepository() : base(new FakeSpecialistMaintenanceProfiles().MySpecialistMaintenanceProfiles)
        {
        }
        public FakeSpecialistMaintenanceProfileRepository(List<SpecialistMaintenanceProfile> mySpecialistMaintenanceProfile): base(mySpecialistMaintenanceProfile)
        {
        }

    }
}
       