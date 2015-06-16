using System.Collections.Generic;
using RentalMobile.Helpers.JQuery;
using RentalMobile.Helpers.JQuery.JNotify;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalMobile.Helpers.Identity.Abstract.Roles.PrivateProfile
{
    public interface IProviderPrivateProfileHelper
    {
        #region Main
            MaintenanceProvider GetProvider();
            MaintenanceProvider GetPrivateProfileProviderByProviderId(int id);
            MaintenanceTeamAssociation GetMaintenanceTeamAssociations();
            string ProviderGoogleMap();  
        #endregion

        #region Coverage

        ProviderMaintenanceProfile GetMaintenanceProviderProfile();
        ProviderMaintenanceProfile GetMaintenanceProviderProfileByCompanyId(int companyId);
        string DoesProviderHasTeam();
        int GetTotalAvailableZoneSpot();
        List<MaintenanceProviderZone> GetDistinctProviderZones();
        List<MaintenanceProviderZone> GetAllProviderZones();
        int GetAllZonesUsedCount();
        bool IsProviderZoneAlreadyExist(MaintenanceProviderZone maintenanceproviderzone, List<MaintenanceProviderZone> maintenanceProviderZones);
        void AddNewMaintenanceProviderZone(MaintenanceProviderZone maintenanceproviderzone, List<MaintenanceProviderZone> maintenanceProviderZones);
        bool IsZipcodeBelongtoTeamMember(int providerId, string zipcode);
        int GetmNumberofMembersInTeam();
        JNotifyMessage RemoveProviderZone(MaintenanceProviderZone maintenanceproviderzone);
        JNotifyMessage DeleteMaintenanceProviderZone(MaintenanceProviderZone maintenanceproviderzone);
        JNotifyMessage UpdateZone(MaintenanceProviderZone maintenanceproviderzone);
        List<TeamSpecialistInvitation> GetAllSpecialistThatHasPendingTeamInvitation();
        #endregion

        #region Account

        void CompleteProviderProfile(ProviderMaintenanceProfile s);

        ///<summary>
        ///Find the new Zip code of the company
        ///     If the new Zip code does not match any zip
        ///          Add the new Zip code to the list
        ///     If previous Zip code exist
        ///         Don't Update
        /// </summary>
        /// <param name="providerCompanyZip"></param>
        /// <param name="providerCompanyZipCity"></param>
        void UpdateProviderZoneList(string providerCompanyZip = "", string providerCompanyZipCity = "");

        void UpdateproviderProfile(MaintenanceProvider p, MaintenanceCompany m);

        /// <summary>
        /// Calculation of Completion
        /// description = 20 ; Other = 10
        /// 
        /// Members of formula 
        /// Name 
        /// Address 
        /// EmailAddress 
        /// Description 
        /// Country 
        /// Region 
        /// City 
        /// Zip 
        /// CountryCode
        /// </summary>
        int CalculateNewProviderProfileCompletionPercentage(MaintenanceCompany m);

        void UpdateProviderProfileCompletion(int newprofilecompletionpercentage);
        void DeleteProviderMemebership();
        void DeleteProviderRecords(int providerId);
        void UpdateProviderMaintenanceCompany();
        decimal? GetProviderRate(int providerId);
        List<MaintenanceCompany> GetProviderCompanies();
        
        #endregion

        #region Team

        /// <summary/>
        /// Team Tab
        /// Finished and Clean
        /// Only 1 team can exist
        IEnumerable<Specialist> GetAllSpecialistsWithoutExistingOrPendingTeamAssociationWithProvider(int specialistId, int maintenanceProviderId);
        void AddNewPendingSpecialistInvitationToProviderTeam(Specialist specialist, int specialistId, int maintenanceProviderId);
        
        #endregion
    }
}
