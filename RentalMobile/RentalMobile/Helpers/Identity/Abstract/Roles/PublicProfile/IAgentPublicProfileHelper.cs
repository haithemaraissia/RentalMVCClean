using RentalMobile.Model.Models;

namespace RentalMobile.Helpers.Identity.Abstract.Roles.PublicProfile
{
    public interface IAgentPublicProfileHelper
    {
        Agent GetAgentPublicProfileByAgentId(int id);
    }
}
