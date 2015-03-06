using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeMaintenanceTeamAssociationRepository : FakeGenericRepository<MaintenanceTeamAssociation>
    {
        public FakeMaintenanceTeamAssociationRepository() : base(new FakeMaintenanceTeamAssociations().MyMaintenanceTeamAssociations)
        {
        }
        public FakeMaintenanceTeamAssociationRepository(List<MaintenanceTeamAssociation> myMaintenanceTeamAssociation): base(myMaintenanceTeamAssociation)
        {
        }

    }
}
       