using System.Collections.Generic;
using Ninject.Activation;
using RentalMobile.Helpers.Team;
using RentalMobile.Helpers.Visitor;
using RentalMobile.Model.Models;

namespace RentalMobile.Helpers.Identity.Abstract.Roles.PublicProfile
{
    public interface IProviderPublicProfileHelper
    {
        ProviderProfileViewVisitor GetProviderProfileViewVisitorProperties();
        string TeamName(int maintenanceProviderId);
        List<Teammember> GetTeamByProviderId(int maintenanceProviderId);
        List<Teammember> GetTeamByTeamAssociation(IEnumerable<MaintenanceTeamAssociation> team);
        int GetSpecialistYearofExperience(int specialistId);
        MaintenanceProvider GetPublicProfileProviderByProviderId(int id);
        
        void ShareProvider(MaintenanceProvider s);
        string SocialTitleBuilding(MaintenanceProvider s);
        string GetProviderCommentCount(int id);
        string GetProviderPrimaryWorkPhoto(int id);
        dynamic ProviderPublicComposeForwardToFriendEmail(string friendname, string friendemailaddress, string message, int id);       

    }
}
