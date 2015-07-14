

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Identity.Base;
using RentalMobile.Helpers.Identity.Base.Roles.PrivateProfile;
using RentalMobile.Helpers.Identity.Base.Roles.PrivateProfile.Associated;
using RentalMobile.Helpers.Identity.Base.Roles.PublicProfile;
using RentalMobile.Helpers.JQuery;
using RentalMobile.Helpers.JQuery.JNotify;
using RentalMobile.Helpers.Membership;
using RentalMobile.Helpers.Photo.Unit;
using RentalMobile.Helpers.Process.Application;
using RentalMobile.Helpers.Process.JobOffer;
using RentalMobile.Helpers.Social;
using RentalMobile.Helpers.Team;
using RentalMobile.Helpers.Unit;
using RentalMobile.Helpers.Visitor;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Core
{
    public class CoreUserHelper : BaseController, IUserHelper
    {
        #region Constructors

        #region PrivateProfileHelper
        public SpecialistPrivateProfileHelper SpecialistPrivateProfileHelper { get; set; }
        public OwnerPrivateProfileHelper OwnerPrivateProfileHelper { get; set; }
        public AgentPrivateProfileHelper AgentPrivateProfileHelper { get; set; }
        public TenantPrivateProfileHelper TenantPrivateProfileHelper { get; set; }
        public ProviderPrivateProfileHelper ProviderPrivateProfileHelper { get; set; }
        #region Associated
        public ProviderTeamPrivateProfileHelper ProviderTeamPrivateProfileHelper { get; set; }
        #endregion
        #endregion

        #region PublicProfileHelper
        public SpecialistPublicProfileHelper SpecialistPublicProfileHelper { get; set; }
        public OwnerPublicProfileHelper OwnerPublicProfileHelper { get; set; }
        public AgentPublicProfileHelper AgentPublicProfileHelper { get; set; }
        public TenantPublicProfileHelper TenantPublicProfileHelper { get; set; }
        public ProviderPublicProfileHelper ProviderPublicProfileHelper { get; set; }
        #endregion

        #region Common
        public LocationHelper LocationHelper { get; set; }
        public PosterHelper PosterHelper { get; set; }
        public UserIdentity UserIdentity { get; set; }
        #endregion

        #region Job
        public TenantRentalApplicationHelper TenantRentalApplicationHelper { get; set; }

        public JobOffer JobOffer { get; set; }
        #endregion

        #region Unit
        public UnitHelper UnitHelper { get; set; }
        #endregion

        public CoreUserHelper(IGenericUnitofWork uow, IMembershipService membershipService)
        {
            MembershipService = membershipService;
            UnitofWork = uow;

            #region PrivateProfileHelper
            SpecialistPrivateProfileHelper = new SpecialistPrivateProfileHelper(uow, membershipService, this);
            OwnerPrivateProfileHelper = new OwnerPrivateProfileHelper(uow, membershipService, this);
            AgentPrivateProfileHelper = new AgentPrivateProfileHelper(uow, membershipService, this);
            TenantPrivateProfileHelper = new TenantPrivateProfileHelper(uow, membershipService, this);
            ProviderPrivateProfileHelper = new ProviderPrivateProfileHelper(uow, membershipService, this);
            #region Associated
            ProviderTeamPrivateProfileHelper = new ProviderTeamPrivateProfileHelper(uow, membershipService, this);
            #endregion
            #endregion

            #region PublicProfileHelper
            SpecialistPublicProfileHelper = new SpecialistPublicProfileHelper(uow, membershipService, this);
            OwnerPublicProfileHelper = new OwnerPublicProfileHelper(uow, membershipService);
            AgentPublicProfileHelper = new AgentPublicProfileHelper(uow, membershipService);
            TenantPublicProfileHelper = new TenantPublicProfileHelper(uow, membershipService);
            ProviderPublicProfileHelper = new ProviderPublicProfileHelper(uow, membershipService, this);
            #endregion

            #region Common
            LocationHelper = new LocationHelper(uow, membershipService);
            PosterHelper = new PosterHelper(uow, membershipService);
            UserIdentity = new UserIdentity(uow, membershipService);
            #endregion

            #region Job
            TenantRentalApplicationHelper = new TenantRentalApplicationHelper(uow, membershipService);
            JobOffer = new JobOffer(uow, membershipService);
            #endregion

            #region Unit
            UnitHelper = new UnitHelper(uow, membershipService, this);
            #endregion

        }

        #endregion

        #region UserIdentity

        /// <summary>
        /// UserIdentity Instance
        /// </summary>
        /// <returns></returns>

        public string Login()
        {
            return UserIdentity.Login();
        }

        public string GetUserName()
        {
            return UserIdentity.GetUserName();
        }

        public Guid? GetUserGuid()
        {
            return UserIdentity.GetUserGuid();
        }
        /// <summary>
        /// GetId(GUID OR ID)
        /// Guid for user profile
        /// ID For Role like TenantId, OwnerId, AgentID, MaintenanceProviderId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        public int GetTenantId(Guid userId)
        {
            return UserIdentity.GetTenantId(userId);
        }

        public int GetTenantId()
        {
            return UserIdentity.GetTenantId();
        }

        public int GetTenantId(int id)
        {
            return UserIdentity.GetTenantId(id);
        }

        public int GetAgentId()
        {
            return UserIdentity.GetAgentId();
        }

        public int GetAgentId(int id)
        {
            return UserIdentity.GetAgentId(id);
        }

        public int GetOwnerId()
        {
            return UserIdentity.GetOwnerId();
        }

        public int GetOwnerId(int id)
        {
            return UserIdentity.GetOwnerId(id);
        }

        public int GetSpecialistId()
        {
            return UserIdentity.GetSpecialistId();
        }

        public int GetSpecialistId(int id)
        {
            return UserIdentity.GetSpecialistId(id);
        }

        public int GetProviderId()
        {
            return UserIdentity.GetProviderId();
        }

        public int GetProviderId(int id)
        {
            return UserIdentity.GetProviderId(id);
        }

        public int GetRoleId(string chosenRole)
        {
            return UserIdentity.GetRoleId(chosenRole);
        }

        public string GetCurrentRole()
        {
            return UserIdentity.GetCurrentRole();
        }

        public string ResolveImageUrl(string relativeUrl)
        {
            return UserIdentity.ResolveImageUrl(relativeUrl);
        }

        #endregion

        #region PosterHelper
        /// <summary>
        /// PosterHelper Instance
        /// </summary>
        /// <returns></returns>

        public PosterAttributes GetPoster(int uniId, Uri requestUri )
        {
            return PosterHelper.GetPoster(uniId, requestUri);
        }

        public PosterAttributes GetSendtoFriendPoster(Uri requestUri)
        {
            return PosterHelper.GetSendtoFriendPoster(requestUri);
        }

        public PosterAttributes GetCommentPoster(Uri requestUri )
        {
            return PosterHelper.GetCommentPoster(requestUri);
        }

        public string SetPhotoPathByCurrentRole(out string photoPath)
        {
            return UserIdentity.SetPhotoPathByCurrentRole(out photoPath);
        }

        #endregion

        #region LocationHelper
        /// <summary>
        /// LocationHelper Instance
        /// </summary>
        /// <returns></returns>

        public bool ValidateLocation(string location)
        {
            return LocationHelper.ValidateLocation(location);
        }

        public string GetFormattedAdress(string location)
        {
            return LocationHelper.GetFormattedAdress(location);
        }

        public string GetFormattedLocation(string address, string city, string country)
        {
            return LocationHelper.GetFormattedLocation(address, city, country);
        }

        #endregion

        #region SpecialistPublicProfile
        /// <summary>
        /// SpecialistPublicProfileHelper Instance
        /// </summary>
        /// <returns></returns>

        public SpecialistProfileViewVisitor GetSpecialistProfileViewVisitorProperties()
        {
            return SpecialistPublicProfileHelper.GetSpecialistProfileViewVisitorProperties();
        }

        public string GetTeamPrimaryPhoto(int id)
        {
            return SpecialistPublicProfileHelper.GetTeamPrimaryPhoto(id);
        }

        public string GetSpecialistPrimaryPhoto(int id)
        {
            return SpecialistPublicProfileHelper.GetSpecialistPrimaryPhoto(id);
        }

        public string GetSpecialistName(int id)
        {
            return SpecialistPublicProfileHelper.GetSpecialistName(id);
        }

        public int GetTotalAvailableZoneSpotForProvider(int providerId)
        {
            return SpecialistPublicProfileHelper.GetTotalAvailableZoneSpotForProvider(providerId);
        }

        public Specialist GetPublicProfileSpecialistBySpecialistId(int id)
        {
            return SpecialistPublicProfileHelper.GetPublicProfileSpecialistBySpecialistId(id);
        }

        public CommonSharedSocialLinks ShareSpecialist(Specialist s)
        {
            return SpecialistPublicProfileHelper.ShareSpecialist(s);
        }

        public string SocialTitleBuilding(Specialist s)
        {
            return SpecialistPublicProfileHelper.SocialTitleBuilding(s);
        }

        public string GetSpecialistCommentCount(int id)
        {
            return SpecialistPublicProfileHelper.GetSpecialistCommentCount(id);
        }

        public string GetSpecialistPrimaryWorkPhoto(int id)
        {
            return SpecialistPublicProfileHelper.GetSpecialistPrimaryPhoto(id);
        }

        public dynamic SpecialPublicProfileComposeForwardToFriendEmail(string friendname, string friendemailaddress, string message, int id)
        {
            return SpecialistPublicProfileHelper.SpecialPublicProfileComposeForwardToFriendEmail(friendname, friendemailaddress, message, id);
        }

        #endregion

        #region SpecialistPrivateProfile
        /// <summary>
        /// SpecialistPrivateProfileHelper Instance
        /// </summary>
        /// <returns></returns>

        public Specialist GetSpecialist()
        {
            return SpecialistPrivateProfileHelper.GetSpecialist();
        }

        public Specialist GetPrivateProfileSpecialistBySpecialistId(int id)
        {
            return SpecialistPrivateProfileHelper.GetPrivateProfileSpecialistBySpecialistId(id);
        }

        public string SpecialistGoogleMap()
        {
            return SpecialistPrivateProfileHelper.SpecialistGoogleMap();
        }

        public void DeleteSpecialistMemebership()
        {

            SpecialistPrivateProfileHelper.DeleteSpecialistMemebership();
        }

        public void UploadPhoto()
        {
            SpecialistPrivateProfileHelper.UploadPhoto();
        }

        public void CompleteSpecialistMaitenanceProfile(SpecialistMaintenanceProfile spf)
        {
            SpecialistPrivateProfileHelper.CompleteSpecialistMaitenanceProfile(spf);
        }

        public void EditSpecialistMaintenanceProfile(SpecialistMaintenanceProfile spf)
        {
            SpecialistPrivateProfileHelper.EditSpecialistMaintenanceProfile(spf);
        }

        public void UpdateSpecialistProfile(MaintenanceCompany m)
        {
            SpecialistPrivateProfileHelper.UpdateSpecialistProfile(m);
        }

        public int SpecialistPrivateCalculateNewProfileCompletionPercentage(MaintenanceCompany m)
        {
            return SpecialistPrivateProfileHelper.SpecialistPrivateCalculateNewProfileCompletionPercentage(m);
        }

        public void SpecialistPrivateUpdateProfileCompletion(int newprofilecompletionpercentage)
        {
            SpecialistPrivateProfileHelper.SpecialistPrivateUpdateProfileCompletion(newprofilecompletionpercentage);
        }

        public decimal? GetProfessionalRate(int specialistId)
        {
            return SpecialistPrivateProfileHelper.GetProfessionalRate(specialistId);
        }

        public SpecialistMaintenanceProfile GetSpecialistMaitenanceProfile()
        {
            return SpecialistPrivateProfileHelper.GetSpecialistMaitenanceProfile();
        }

        public SpecialistMaintenanceProfile GetSpecialistMaintenanceProfileByCompanyId(int companyId)
        {
            return SpecialistPrivateProfileHelper.GetSpecialistMaintenanceProfileByCompanyId(companyId);
        }

        public void AcceptInvitation(SpecialistPendingTeamInvitation sti)
        {
            SpecialistPrivateProfileHelper.AcceptInvitation(sti);
        }

        public void AddSpecialistZoneToProviderTeamZone(int providerId, int specialistId)
        {
            SpecialistPrivateProfileHelper.AddSpecialistZoneToProviderTeamZone(providerId, specialistId);
        }

        public void DenyInvitation(SpecialistPendingTeamInvitation sti)
        {
            SpecialistPrivateProfileHelper.DenyInvitation(sti);
        }

        public void RemoveTeamAssociation(MaintenanceTeamAssociation mta)
        {
            SpecialistPrivateProfileHelper.RemoveTeamAssociation(mta);
        }
        #endregion

        #region TenantPrivateProfile

        /// <summary>
        /// TenantPrivateProfileHelper Instance
        /// </summary>
        /// <returns></returns>


        public Tenant GetTenant()
        {
            return TenantPrivateProfileHelper.GetTenant();
        }

        public string TenantGoogleMap()
        {
            return TenantPrivateProfileHelper.TenantGoogleMap();
        }

        public int GetTenantApplicationCount(int tenantId)
        {
            return TenantPrivateProfileHelper.GetTenantApplicationCount(tenantId);
        }

        public void DeleteTenantRecords(int tenantId)
        {
            TenantPrivateProfileHelper.DeleteTenantRecords(tenantId);
        }

        public void DeleteTenantMemebership()
        {
            TenantPrivateProfileHelper.DeleteTenantMemebership();
        }

        public Tenant GetPrivateProfileTenantByTenantId(int id)
        {
            return TenantPrivateProfileHelper.GetPrivateProfileTenantByTenantId(id);
        }

        public MaintenanceOrder GetMaintenanceOrderByMaintenanceIdPlacedByTenant(int id)
        {
            return TenantPrivateProfileHelper.GetMaintenanceOrderByMaintenanceIdPlacedByTenant(id);
        }

        public string TenantPrivateProfileUsername()
        {
            return TenantPrivateProfileHelper.TenantPrivateProfileUsername();
        }

        public List<GeneratedRentalContract> GetTenantContract(int tenantId)
        {
            return TenantPrivateProfileHelper.GetTenantContract(tenantId);
        }

        public void AddTenantRequestPictures(string key)
        {
            TenantPrivateProfileHelper.AddTenantRequestPictures("Id");
        }

        public void AddMaintenancePhoto(int maintenanceId, string photoPath)
        {
            TenantPrivateProfileHelper.AddMaintenancePhoto(maintenanceId, photoPath);
        }
        #endregion

        #region TenantPublicProfile

        /// <summary>
        /// TenantPublicProfileHelper Instance
        /// </summary>
        /// <returns></returns>
        /// 
        public Tenant GetPublicProfileTenantByTenantId(int id)
        {
            return TenantPublicProfileHelper.GetPublicProfileTenantByTenantId(id);
        }

        #endregion

        #region ProviderPrivateProfile

        #region Main
        public MaintenanceProvider GetProvider()
        {
            return ((Identity.Abstract.Roles.PrivateProfile.IProviderPrivateProfileHelper)this).GetProvider();
        }

        /// <summary>
        /// ProviderPrivateProfileHelper Instance
        /// </summary>
        /// <returns></returns>
        public MaintenanceProvider GetPrivateProfileProviderByProviderId(int id)
        {
            return ProviderPrivateProfileHelper.GetPrivateProfileProviderByProviderId(id);
        }

        public MaintenanceTeamAssociation GetMaintenanceTeamAssociations()
        {
            return ((Identity.Abstract.Roles.PrivateProfile.IProviderPrivateProfileHelper)this).GetMaintenanceTeamAssociations();
        }

        public string ProviderGoogleMap()
        {
            return ((Identity.Abstract.Roles.PrivateProfile.IProviderPrivateProfileHelper)this).ProviderGoogleMap();
        }
        #endregion

        #region Coverage

        public ProviderMaintenanceProfile GetMaintenanceProviderProfile()
        {
            return ProviderPrivateProfileHelper.GetMaintenanceProviderProfile();
        }

        public ProviderMaintenanceProfile GetMaintenanceProviderProfileByCompanyId(int companyId)
        {
            return ProviderPrivateProfileHelper.GetMaintenanceProviderProfileByCompanyId(companyId);
        }

        public string DoesProviderHasTeam()
        {
            return ProviderPrivateProfileHelper.DoesProviderHasTeam();
        }

        public int GetTotalAvailableZoneSpot()
        {
            return ProviderPrivateProfileHelper.GetTotalAvailableZoneSpot();
        }

        public List<MaintenanceProviderZone> GetDistinctProviderZones()
        {
            return ProviderPrivateProfileHelper.GetDistinctProviderZones();
        }

        public List<MaintenanceProviderZone> GetAllProviderZones()
        {
            return ProviderPrivateProfileHelper.GetAllProviderZones();
        }

        public int GetAllZonesUsedCount()
        {
            return ProviderPrivateProfileHelper.GetAllZonesUsedCount();
        }

        public bool IsProviderZoneAlreadyExist(MaintenanceProviderZone maintenanceproviderzone, List<MaintenanceProviderZone> maintenanceProviderZones)
        {
            return ProviderPrivateProfileHelper.IsProviderZoneAlreadyExist(maintenanceproviderzone, maintenanceProviderZones);
        }

        public void AddNewMaintenanceProviderZone(MaintenanceProviderZone maintenanceproviderzone, List<MaintenanceProviderZone> maintenanceProviderZones)
        {
            ProviderPrivateProfileHelper.AddNewMaintenanceProviderZone(maintenanceproviderzone, maintenanceProviderZones);
        }

        public bool IsZipcodeBelongtoTeamMember(int providerId, string zipcode)
        {
            return ProviderPrivateProfileHelper.IsZipcodeBelongtoTeamMember(providerId, zipcode);
        }

        public int GetmNumberofMembersInTeam()
        {
            return ProviderPrivateProfileHelper.GetmNumberofMembersInTeam();
        }

        public JNotifyMessage RemoveProviderZone(MaintenanceProviderZone maintenanceproviderzone)
        {
            return ProviderPrivateProfileHelper.RemoveProviderZone(maintenanceproviderzone);
        }

        public JNotifyMessage DeleteMaintenanceProviderZone(MaintenanceProviderZone maintenanceproviderzone)
        {
            return ProviderPrivateProfileHelper.DeleteMaintenanceProviderZone(maintenanceproviderzone);
        }

        public JNotifyMessage UpdateZone(MaintenanceProviderZone maintenanceproviderzone)
        {
            return ProviderPrivateProfileHelper.UpdateZone(maintenanceproviderzone);
        }

        public List<TeamSpecialistInvitation> GetAllSpecialistThatHasPendingTeamInvitation()
        {
            return ProviderPrivateProfileHelper.GetAllSpecialistThatHasPendingTeamInvitation();
        }

        #endregion

        #region Account

        public void CompleteProviderProfile(ProviderMaintenanceProfile s)
        {
            ProviderPrivateProfileHelper.CompleteProviderProfile(s);
        }

        public void UpdateProviderZoneList(string providerCompanyZip = "", string providerCompanyZipCity = "")
        {
            ProviderPrivateProfileHelper.UpdateProviderZoneList(providerCompanyZip, providerCompanyZipCity);
        }

        public void UpdateproviderProfile(MaintenanceProvider p, MaintenanceCompany m)
        {
            ProviderPrivateProfileHelper.UpdateproviderProfile(p, m);
        }

        public int CalculateNewProviderProfileCompletionPercentage(MaintenanceCompany m)
        {
            return ProviderPrivateProfileHelper.CalculateNewProviderProfileCompletionPercentage(m);
        }

        public void UpdateProviderProfileCompletion(int newprofilecompletionpercentage)
        {
            ProviderPrivateProfileHelper.UpdateProviderProfileCompletion(newprofilecompletionpercentage);
        }





        public void DeleteProviderMemebership()
        {
            ProviderPrivateProfileHelper.DeleteProviderMemebership();
        }

        public void DeleteProviderRecords(int providerId)
        {
            ProviderPrivateProfileHelper.DeleteProviderRecords(providerId);
        }

        public void UpdateProviderMaintenanceCompany()
        {
            ProviderPrivateProfileHelper.UpdateProviderMaintenanceCompany();
        }

        public decimal? GetProviderRate(int providerId)
        {
            return ProviderPrivateProfileHelper.GetProviderRate(providerId);
        }

        public List<MaintenanceCompany> GetProviderCompanies()
        {
            return ProviderPrivateProfileHelper.GetProviderCompanies();
        }

        #endregion

        #region Team
        public IEnumerable<Specialist> GetAllSpecialistsWithoutExistingOrPendingTeamAssociationWithProvider(int specialistId, int maintenanceProviderId)
        {
            return ProviderPrivateProfileHelper.GetAllSpecialistsWithoutExistingOrPendingTeamAssociationWithProvider(specialistId,
                maintenanceProviderId);
        }

        public void AddNewPendingSpecialistInvitationToProviderTeam(Specialist specialist, int specialistId, int maintenanceProviderId)
        {
            ProviderPrivateProfileHelper.AddNewPendingSpecialistInvitationToProviderTeam(specialist, specialistId, maintenanceProviderId);
        }
        #endregion

        #endregion

        #region ProviderPublicProfile
        /// <summary>
        /// ProviderPublicProfileHelper Instance
        /// </summary>
        /// <returns></returns>
    
        public ProviderProfileViewVisitor GetProviderProfileViewVisitorProperties()
        {
            return ProviderPublicProfileHelper.GetProviderProfileViewVisitorProperties();
        }
        public string TeamName(int maintenanceProviderId)
        {
            return ProviderPublicProfileHelper.TeamName(maintenanceProviderId);
        }

        public List<Teammember> GetTeamByProviderId(int maintenanceProviderId)
        {
            return ProviderPublicProfileHelper.GetTeamByProviderId(maintenanceProviderId);
        }

        public List<Teammember> GetTeamByTeamAssociation(IEnumerable<MaintenanceTeamAssociation> team)
        {
            return ProviderPublicProfileHelper.GetTeamByTeamAssociation(team);
        }
        public int GetSpecialistYearofExperience(int specialistId)
        {
            return ProviderPublicProfileHelper.GetSpecialistYearofExperience(specialistId);
        }

        public MaintenanceProvider GetPublicProfileProviderByProviderId(int id)
        {
            return ProviderPublicProfileHelper.GetPublicProfileProviderByProviderId(id);
        }

        public void ShareProvider(MaintenanceProvider s)
        {
            ProviderPublicProfileHelper.ShareProvider(s);
        }

        public string SocialTitleBuilding(MaintenanceProvider s)
        {
            return ProviderPublicProfileHelper.SocialTitleBuilding(s);
        }

        public string GetProviderCommentCount(int id)
        {
            return ProviderPublicProfileHelper.GetProviderCommentCount(id);
        }

        public string GetProviderPrimaryWorkPhoto(int id)
        {
            return ProviderPublicProfileHelper.GetProviderPrimaryWorkPhoto(id);
        }

        public dynamic ProviderPublicComposeForwardToFriendEmail(string friendname, string friendemailaddress, string message, int id)
        {
            return ProviderPublicProfileHelper.ProviderPublicComposeForwardToFriendEmail(friendname, friendemailaddress, message, id);
        }

        #endregion

        #region AgentPublicProfileHelper
        /// <summary>
        /// AgentPublicProfileHelper Instance
        /// </summary>
        /// <returns></returns>
        public Agent GetAgentPublicProfileByAgentId(int id)
        {
            return AgentPublicProfileHelper.GetAgentPublicProfileByAgentId(id);
        }

        #endregion

        #region AgentPrivateProfileHelper

        /// <summary>
        /// AgentPrivateProfileHelper Instance
        /// </summary>
        /// <returns></returns>

        public Agent GetAgent()
        {
            return AgentPrivateProfileHelper.GetAgent();
        }

        public Agent GetAgentPrivateProfileByAgentId(int id)
        {
            return AgentPrivateProfileHelper.GetAgentPrivateProfileByAgentId(id);
        }

        public string AgentGoogleMap()
        {
            return AgentPrivateProfileHelper.AgentGoogleMap();
        }

        public void DeleteAgentMemebership()
        {
            AgentPrivateProfileHelper.DeleteAgentMemebership();
        }

        #endregion

        #region OwnerPublicProfileHelper
        /// <summary>
        /// OwnerPublicProfileHelper Instance
        /// </summary>
        /// <returns></returns>
        /// 
        public Owner GetPublicProfileOwnerByOwnerId(int id)
        {
            return OwnerPublicProfileHelper.GetPublicProfileOwnerByOwnerId(id);
        }

        public string OwnerPublicProfileUsername()
        {
            return OwnerPublicProfileHelper.OwnerPublicProfileUsername();
        }
        #endregion

        #region OwnerPrivateProfileHelper

        /// <summary>
        /// OwnerPrivateProfileHelper Instance
        /// </summary>
        /// <returns></returns>
        /// 
        #region OwnerHelper
        public string OwnerUsername()
        {
            return OwnerPrivateProfileHelper.OwnerUsername();
        }

        public Owner GetOwner()
        {
            return OwnerPrivateProfileHelper.GetOwner();
        }
        public Owner GetPrivateProfileOwnerByOwnerId(int id)
        {
            return OwnerPrivateProfileHelper.GetPrivateProfileOwnerByOwnerId(id);
        }

        public string OwnerGoogleMap()
        {
            return OwnerPrivateProfileHelper.OwnerGoogleMap();
        }

        public void DeleteOwnerRecords(int ownerId)
        {
            OwnerPrivateProfileHelper.DeleteOwnerRecords(ownerId);
        }

        public void DeleteOwnerMemebership()
        {
            OwnerPrivateProfileHelper.DeleteOwnerMemebership();
        }
        #endregion

        #region Unit
        public dynamic ComposeForwardUnitToFriendEmail(string friendname, string friendemailaddress, string message, int id)
        {
            return OwnerPrivateProfileHelper.ComposeForwardUnitToFriendEmail(friendname, friendemailaddress, message, id);
        }
        #endregion

        #region Application
        public List<OwnerPendingApplication> GetOwnerPendingApplication()
        {
            return OwnerPrivateProfileHelper.GetOwnerPendingApplication();
        }

        public void OwnerAcceptApplicationByApplicationId(int pendingApplicationId)
        {
            OwnerPrivateProfileHelper.OwnerAcceptApplicationByApplicationId(pendingApplicationId);
        }

        public void OwnerRejectApplicationByApplicationId(int pendingApplicationId)
        {
            OwnerPrivateProfileHelper.OwnerRejectApplicationByApplicationId(pendingApplicationId);
        }

        public List<OwnerAcceptedApplication> GetOwnerAcceptedApplication()
        {
            return OwnerPrivateProfileHelper.GetOwnerAcceptedApplication();
        }

        public List<OwnerRejectedApplication> GetOwnerRejectedApplication()
        {
            return OwnerPrivateProfileHelper.GetOwnerRejectedApplication();
        }
        #endregion

        #region Contract
        public List<GeneratedRentalContract> GetOwnerGeneratedRentalContract()
        {
            return OwnerPrivateProfileHelper.GetOwnerGeneratedRentalContract();
        }

        public List<UploadedContract> GetUploadedOwnerRentalContract()
        {
            return OwnerPrivateProfileHelper.GetUploadedOwnerRentalContract();
        }
        #endregion

        #region Showing
        public IQueryable<OwnerPendingShowingCalendarModelView> GetOwnerPendingShowingCalendar()
        {
            return OwnerPrivateProfileHelper.GetOwnerPendingShowingCalendar();
        }

        public void OwnerDenyShowingRequest(int eventId)
        {
            OwnerPrivateProfileHelper.OwnerDenyShowingRequest(eventId);
        }

        public void OwnerAcceptShowingRequest(int eventId)
        {
            OwnerPrivateProfileHelper.OwnerAcceptApplicationByApplicationId(eventId);
        }

        public JsonResult GetOwnerCalendar()
        {
            return OwnerPrivateProfileHelper.GetOwnerCalendar();
        }
        #endregion

        #region RSS
        public FileResult Syndicate(string format)
        {
            return OwnerPrivateProfileHelper.Syndicate(format);
        }
        #endregion

        #endregion

        #region TenantRentalApplication
        /// <summary>
        /// TenantRentalApplicationHelper Instance
        /// </summary>
        /// <returns></returns>

        public void InsertOwnerPendingApplication(RentalApplication r, int ownerId)
        {
            TenantRentalApplicationHelper.InsertOwnerPendingApplication(r, ownerId);
        }

        public void InsertAgentPendingApplication(RentalApplication r, int agentId)
        {
            TenantRentalApplicationHelper.InsertAgentPendingApplication(r, agentId);
        }
        #endregion

        #region JobOffer
        /// <summary>
        /// JobOfferHelper Instance
        /// </summary>
        /// <returns></returns>

        public void InsertPendingJobOffer(int providerid, Tenant tenant, int propertyid, DateTime startDate, DateTime endDate)
        {
            JobOffer.InsertPendingJobOffer(providerid, tenant, propertyid, startDate, endDate);
        }

        #endregion

        #region Associated

        #region ProviderTeamPrivateProfileHelper
        public List<MaintenanceTeam> GetAllProviderPrivateMaintenanceTeamByProviderId(int providerId)
        {
            return ProviderTeamPrivateProfileHelper.GetAllProviderPrivateMaintenanceTeamByProviderId(providerId);
        }

        public MaintenanceTeam GetProviderPrivateMaintenanceTeamByProviderId(int providerId)
        {
            return ProviderTeamPrivateProfileHelper.GetProviderPrivateMaintenanceTeamByProviderId(providerId);
        }

        public string ProviderMaintenanceTeamTabUrl()
        {
            return ProviderTeamPrivateProfileHelper.ProviderMaintenanceTeamTabUrl();
        }

        public void UpdateMaintenanceTeamsName(MaintenanceTeam maintenanceteam)
        {
            ProviderTeamPrivateProfileHelper.UpdateMaintenanceTeamsName(maintenanceteam);
        }

        #endregion

        #endregion

        #region Unit

        #region Main
        public void CreateNewUnit(UnitModelView u)
        {
            throw new NotImplementedException();
        }

        public int GetUnitCurrencyCode(UnitModelView u)
        {
            throw new NotImplementedException();
        }

        public UnitModelView GetUnitModelViewByUnitId(int id)
        {
            throw new NotImplementedException();
        }

        public void EditUnitModel(UnitModelView u)
        {
            throw new NotImplementedException();
        }
        #endregion

        # region ImageUpload
        public string Username()
        {
            throw new NotImplementedException();
        }

        public UnitGallery GetUnitGalleryByUnitId(int unitId)
        {
            throw new NotImplementedException();
        }

        public void EditPicture(Model.Models.Unit unit)
        {
            throw new NotImplementedException();
        }

        public void SavePictures(Model.Models.Unit unit)
        {
            throw new NotImplementedException();
        }

        public void DefaultPhoto(Model.Models.Unit unit, FileInfo[] files, string newdirectory, string virtualdestinationdirectoryvirtualmapping, string directory)
        {
            throw new NotImplementedException();
        }

        public void AddPicture(Model.Models.Unit unit, int uploaderid, string photoPath, int rank)
        {
            throw new NotImplementedException();
        }

        public JavaScriptResult ShareonFacebook()
        {
            throw new NotImplementedException();
        }


        public UnitUploaderAttributes GetUnitUploaderAttributes()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Features
        //Theorizing


        public void ShareProperty(UnitModelView u)
        {
            throw new NotImplementedException();
        }

        public string GetCurrencyValue(int? currencyId)
        {
            return UnitHelper.GetCurrencyValue(currencyId);
        }

        public void UnitProperty(int id, string previewPathWithHost, dynamic email, Model.Models.Unit currentunit, string unitPicture)
        {
            throw new NotImplementedException();
        }

        public void SendRequestToRequester(string requestername, string requesteremailaddress, string datepicker, int id)
        {
            throw new NotImplementedException();
        }

        public void SendRequestToReceiver(string requestername, string requesteremailaddress, string requestertelephone, string datepicker, int id)
        {
            throw new NotImplementedException();
        }

        public void InsertPendingShowingRequest(int id)
        {
            throw new NotImplementedException();
        }

        public string UnitGoogleMap(UnitModelView unitModel)
        {
            throw new NotImplementedException();
        }

        public void PreviewUnit(int id, bool? shareproperty, UnitModelView unitModel)
        {
            throw new NotImplementedException();
        }

        public dynamic ComposeForwardToFriendEmail(string friendname, string friendemailaddress, string message, int id)
        {
            throw new NotImplementedException();
        }

        public void RequestShowing(string yourname, string youremail, string yourtelephone, string datepicker, int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Helper
        public void SetCurrencyViewBag(int? currencyId = null)
        {
            throw new NotImplementedException();
        }
        public SelectList GetCurrencySelectList()
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region CleanUp
        ~CoreUserHelper()
        {
            SpecialistPrivateProfileHelper = null;
            SpecialistPublicProfileHelper = null;

            OwnerPrivateProfileHelper = null;
            OwnerPublicProfileHelper = null;

            AgentPrivateProfileHelper = null;
            AgentPublicProfileHelper = null;

            TenantPrivateProfileHelper = null;
            TenantPublicProfileHelper = null;

            ProviderPrivateProfileHelper = null;
            ProviderPublicProfileHelper = null;

            LocationHelper = null;
            PosterHelper = null;
            UserIdentity = null;
            TenantRentalApplicationHelper = null;
            JobOffer = null;
            UnitHelper = null;

        }
        #endregion

    }
}



