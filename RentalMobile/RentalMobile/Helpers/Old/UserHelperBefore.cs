using System;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Identity.Base;
using RentalMobile.Helpers.Identity.Base.Roles.PrivateProfile;
using RentalMobile.Helpers.Identity.Base.Roles.PublicProfile;
using RentalMobile.Helpers.Membership;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Identity
{
    public class UserHelperBefore : BaseController
    {
        public LocationHelper LocationHelper { get; set; }
        public PosterHelper PosterHelper { get; set; }
        public UserIdentity UserIdentity { get; set; }

        public SpecialistPublicProfileHelper SpecialistHelper { get; set; }
        public TenantPrivateProfileHelper TenantHelper { get; set; }
        public ProviderPrivateProfileHelper ProviderHelper { get; set; }
        public OwnerPrivateProfileHelper OwnerHelper { get; set; }
        public AgentPublicProfileHelper AgentHelper { get; set; }


        public UserHelperBefore(IGenericUnitofWork uow, IMembershipService membershipService)
        {
            MembershipService = membershipService;
            UnitofWork = uow;

            LocationHelper = new LocationHelper(uow, membershipService);
            PosterHelper = new PosterHelper(uow, membershipService);           
            UserIdentity = new UserIdentity(uow, membershipService);
            SpecialistHelper = new SpecialistPublicProfileHelper(uow, membershipService);
            TenantHelper = new TenantPrivateProfileHelper(uow, membershipService);


        }

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

        public int? GetTenantId(Guid userId)
        {
            return UserIdentity.GetTenantId(userId);
        }

        public int? GetTenantId()
        {
            return UserIdentity.GetTenantId();
        }

        public int? GetTenantId(int id)
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

        public string GetCurrentRole(out string photoPath)
        {
            return UserIdentity.SetPhotoPathByCurrentRole(out photoPath);
        }

        public string ResolveImageUrl(string relativeUrl)
        {
            return UserIdentity.ResolveImageUrl(relativeUrl);
        }


        /// <summary>
        /// PosterHelper Instance
        /// </summary>
        /// <returns></returns>

        public PosterAttributes GetPoster(int uniId)
        {
            return PosterHelper.GetPoster(uniId);
        }

        public PosterAttributes GetSendtoFriendPoster()
        {
            return PosterHelper.GetSendtoFriendPoster();
        }

        public PosterAttributes GetCommentPoster()
        {
            return PosterHelper.GetCommentPoster();
        }


        /// <summary>
        /// PosterHelper Instance
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

        /// <summary>
        /// SpecialistHelper Instance
        /// </summary>
        /// <returns></returns>
        /// 
        public string GetTeamPrimaryPhoto(int id)
        {
            return SpecialistHelper.GetTeamPrimaryPhoto(id);
        }

        public string GetSpecialistPrimaryPhoto(int id)
        {
            return SpecialistHelper.GetSpecialistPrimaryPhoto(id);
        }

        public string GetSpecialistName(int id)
        {
            return SpecialistHelper.GetSpecialistName(id);
        }

        public int GetTotalAvailableZoneSpotForProvider(int providerId)
        {
            return SpecialistHelper.GetTotalAvailableZoneSpotForProvider(providerId);
        }

        ~UserHelperBefore()
        {
        LocationHelper = null;
        PosterHelper = null;
        SpecialistHelper = null;
        UserIdentity = null;
        }
    }
}