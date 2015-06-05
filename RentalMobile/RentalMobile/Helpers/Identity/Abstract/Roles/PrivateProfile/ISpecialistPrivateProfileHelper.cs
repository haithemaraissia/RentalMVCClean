using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalMobile.Helpers.Identity.Abstract.Roles.PrivateProfile
{
    public interface ISpecialistPrivateProfileHelper
    {

        #region SpecialistHelper
        Specialist GetSpecialist();
        Specialist GetPrivateProfileSpecialistBySpecialistId(int id);
        string SpecialistGoogleMap();
        void DeleteSpecialistMemebership();
        /// TODO ///
        /// NOT Complete, wrong
        void UploadPhoto();
        void CompleteSpecialistMaitenanceProfile(SpecialistMaintenanceProfile spf);
        void EditSpecialistMaintenanceProfile(SpecialistMaintenanceProfile spf);
        void UpdateSpecialistProfile(MaintenanceCompany m);
        int SpecialistPrivateCalculateNewProfileCompletionPercentage(MaintenanceCompany m);
        void SpecialistPrivateUpdateProfileCompletion(int newprofilecompletionpercentage);
        decimal? GetProfessionalRate(int specialistId);
        #endregion

        #region Provider Tab
        SpecialistMaintenanceProfile GetSpecialistMaitenanceProfile();
        SpecialistMaintenanceProfile GetSpecialistMaintenanceProfileByCompanyId(int companyId);
        void AcceptInvitation(SpecialistPendingTeamInvitation sti);
        void AddSpecialistZoneToProviderTeamZone(int providerId, int specialistId);
        void DenyInvitation(SpecialistPendingTeamInvitation sti);
        void RemoveTeamAssociation(MaintenanceTeamAssociation mta);
        #endregion
    }
}
