using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeTeamSpecialistInvitationRepository : FakeGenericRepository<TeamSpecialistInvitation>
    {
        public FakeTeamSpecialistInvitationRepository() : base(new FakeTeamSpecialistInvitations().MyTeamSpecialistInvitations)
        {
        }
        public FakeTeamSpecialistInvitationRepository(List<TeamSpecialistInvitation> myTeamSpecialistInvitation): base(myTeamSpecialistInvitation)
        {
        }

    }
}
       