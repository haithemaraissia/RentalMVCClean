using RentalMobile.Model.Models;

namespace RentalMobile.Helpers.Identity.Abstract.Roles.PrivateProfile
{
    public interface IAgentPrivateProfileHelper
    {
        Agent GetAgent();
        Agent GetAgentPrivateProfileByAgentId(int id);
        string AgentGoogleMap();
        void DeleteAgentMemebership();
    }
}
