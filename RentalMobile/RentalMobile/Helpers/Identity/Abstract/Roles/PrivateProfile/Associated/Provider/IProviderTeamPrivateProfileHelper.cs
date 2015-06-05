using System.Collections.Generic;
using RentalMobile.Model.Models;

namespace RentalMobile.Helpers.Identity.Abstract.Roles.PrivateProfile.Associated.Provider
{
    public interface IProviderTeamPrivateProfileHelper
    {
        List<MaintenanceTeam>  GetAllProviderPrivateMaintenanceTeamByProviderId (int providerId);
        MaintenanceTeam GetProviderPrivateMaintenanceTeamByProviderId(int providerId);
        string ProviderMaintenanceTeamTabUrl();
        void UpdateMaintenanceTeamsName(MaintenanceTeam maintenanceteam);
    }
}
