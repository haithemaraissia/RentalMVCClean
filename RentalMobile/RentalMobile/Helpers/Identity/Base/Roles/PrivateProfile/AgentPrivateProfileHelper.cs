using System.Linq;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Identity.Abstract.Roles.PrivateProfile;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Identity.Base.Roles.PrivateProfile
{
    public class AgentPrivateProfileHelper : BaseController ,IAgentPrivateProfileHelper
    {
        public AgentPrivateProfileHelper(IGenericUnitofWork uow, IMembershipService membershipService)
        {
            MembershipService = membershipService;
            UnitofWork = uow;
        }

        public Agent GetAgentPrivateProfileByAgentId(int id)
        {
            var agentId = new UserIdentity(UnitofWork, MembershipService).GetAgentId();
            return UnitofWork.AgentRepository.FindBy(x => x.AgentId == agentId).FirstOrDefault();
        }

        public Agent GetAgent()
        {
            var agentId = new UserIdentity(UnitofWork, MembershipService).GetAgentId();
            return UnitofWork.AgentRepository.FindBy(x => x.AgentId == agentId).FirstOrDefault();
        }

        public string AgentGoogleMap()
        {
            return string.IsNullOrEmpty(GetAgent().Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(GetAgent().Address, GetAgent().City, GetAgent().CountryCode);
        }

        public void DeleteAgentMemebership()
        {
            var username = UserHelper.GetUserName();
            if (MembershipService.GetRolesForUser(username).Any())
            {
                MembershipService.RemoveUserFromRoles(username,
                    MembershipService.GetRolesForUser(username));
            }
            MembershipService.DeleteUser(username);
            MembershipService.SignOut();
        }

    }
}