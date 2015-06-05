using System.Linq;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Identity.Abstract.Roles.PublicProfile;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Identity.Base.Roles.PublicProfile
{
    public class AgentPublicProfileHelper : BaseController ,IAgentPublicProfileHelper
    {
        public AgentPublicProfileHelper(IGenericUnitofWork uow, IMembershipService membershipService)
        {
            MembershipService = membershipService;
            UnitofWork = uow;
        }

        public Agent GetAgentPublicProfileByAgentId(int id)
        {
            var agentId = new UserIdentity(UnitofWork, MembershipService).GetAgentId();
            return UnitofWork.AgentRepository.FindBy(x => x.AgentId == agentId).FirstOrDefault();
        }
    }
}