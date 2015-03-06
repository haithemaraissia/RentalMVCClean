using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeMaintenanceTeamRepository : FakeGenericRepository<MaintenanceTeam>
    {
        public FakeMaintenanceTeamRepository() : base(new FakeMaintenanceTeams().MyMaintenanceTeams)
        {
        }
        public FakeMaintenanceTeamRepository(List<MaintenanceTeam> myMaintenanceTeam): base(myMaintenanceTeam)
        {
        }

    }
}
       