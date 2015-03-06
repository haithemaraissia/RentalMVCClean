using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeSpecialistPendingTeamInvitationRepository : FakeGenericRepository<SpecialistPendingTeamInvitation>
    {
        public FakeSpecialistPendingTeamInvitationRepository() : base(new FakeSpecialistPendingTeamInvitations().MySpecialistPendingTeamInvitations)
        {
        }
        public FakeSpecialistPendingTeamInvitationRepository(List<SpecialistPendingTeamInvitation> mySpecialistPendingTeamInvitation): base(mySpecialistPendingTeamInvitation)
        {
        }

    }
}
       