using System;
using System.Linq;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Identity.Abstract;
using RentalMobile.Helpers.Membership;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Identity.Base
{
    public class PosterHelper : BaseController, IPosterHelper
    {
        public string DefaultAvatarPlaceholderImagePath = "../../images/dotimages/avatar-placeholder.png";
        public string DefaultSpecialistName = "Specialist";
        public string TenantPhotoPath = "~/Photo/Tenant/Property";
        public string OwnerPhotoPath = "~/Photo/Owner/Property";
        public string AgentPhotoPath = "~/Photo/Agent/Property";
        public string ProviderPhotoPath = "~/Photo/Provider/Property";
        public string SpecialistPhotoPath = "~/Photo/Specialist/Property";

        public PosterAttributes DefaultPoster = new PosterAttributes("A Friend", "Friend", "#",
            "../../images/dotimages/single-property/agent-480x350.png", "none@yahoo.com", "notauthenticated", 0);

        public PosterHelper(IGenericUnitofWork uow, IMembershipService membershipService)
        {
            MembershipService = membershipService;
            UnitofWork = uow;
        }

        public PosterAttributes GetPoster(int uniId, Uri requestUri)
        {
            if (requestUri == null)
            {
                return DefaultPoster;
            }
            var currenturl = requestUri.Scheme + Uri.SchemeDelimiter + requestUri.Host + ":" + requestUri.Port;
            var unit = UnitofWork.UnitRepository.FindBy(x => x.UnitId == uniId).FirstOrDefault();
            if (unit != null && unit.PosterRole != null)
            {
                switch (unit.PosterRole.Trim().ToLower())
                {
                    case "owner":
                        var owner = UnitofWork.OwnerRepository.FindBy(x => x.OwnerId == unit.PosterID).FirstOrDefault();
                        if (owner != null)
                        {
                            return new PosterAttributes(owner.FirstName, owner.LastName,
                                currenturl + "/ownerprofile/index/" + unit.PosterID, owner.Photo, owner.EmailAddress,
                                "owner", owner.OwnerId);
                        }
                        break;
                    case "agent":
                        var agent = UnitofWork.AgentRepository.FindBy(x => x.AgentId == unit.PosterID).FirstOrDefault();
                        if (agent != null)
                        {
                            return new PosterAttributes(agent.FirstName, agent.LastName,
                                currenturl + "/agentprofile/index/" + unit.PosterID, agent.Photo, agent.EmailAddress,
                                "agent", agent.AgentId);
                        }
                        break;
                    default:
                        {
                            return DefaultPoster;
                        }
                }
            }
            return DefaultPoster;
        }

        public PosterAttributes GetSendtoFriendPoster(Uri requestUri)
        {
            if (requestUri == null)
            {
                return DefaultPoster;
            }
            var currenturl = requestUri.Scheme + Uri.SchemeDelimiter + requestUri.Host + ":" + requestUri.Port;
            return GetUserPosterAttributes(currenturl);
        }

        public PosterAttributes GetCommentPoster(Uri requestUri)
        {
            if (requestUri == null)
            {
                return DefaultPoster;
            }
            var currenturl = requestUri.Scheme + Uri.SchemeDelimiter + requestUri.Host + ":" + requestUri.Port;

            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return DefaultPoster;
            }
            return GetUserPosterAttributes(currenturl);
        }

        public PosterAttributes GetUserPosterAttributes(string currenturl)
        {
            string photoPath;
            var role = new UserIdentity(UnitofWork, MembershipService).SetPhotoPathByCurrentRole(out photoPath);
            if (role == "Tenant")
            {
                var tenantId = new UserIdentity(UnitofWork, MembershipService).GetTenantId();
                var tenant = UnitofWork.TenantRepository.FindBy(x => x.TenantId == tenantId).FirstOrDefault();
                if (tenant != null)
                {
                    return new PosterAttributes(tenant.FirstName, tenant.LastName,
                        currenturl + "/tenantprofile/index/" + tenant.TenantId, tenant.Photo,
                        tenant.EmailAddress, "tenant", tenant.TenantId);
                }
            }


            if (role == "Owner")
            {
                var ownerId = new UserIdentity(UnitofWork, MembershipService).GetOwnerId();
                var owner = UnitofWork.OwnerRepository.FindBy(x => x.OwnerId == ownerId).FirstOrDefault();
                if (owner != null)
                {
                    return new PosterAttributes(owner.FirstName, owner.LastName,
                        currenturl + "/ownerprofile/index/" + owner.OwnerId, owner.Photo,
                        owner.EmailAddress, "owner", owner.OwnerId);
                }
            }
            if (role == "Agent")
            {
                var agentId = new UserIdentity(UnitofWork, MembershipService).GetAgentId();
                var agent = UnitofWork.AgentRepository.FindBy(x => x.AgentId == agentId).FirstOrDefault();
                if (agent != null)
                {
                    return new PosterAttributes(agent.FirstName, agent.LastName,
                        currenturl + "/agentprofile/index/" + agent.AgentId, agent.Photo,
                        agent.EmailAddress, "tenant", agent.AgentId);
                }
            }

            if (role == "Specialist")
            {
                var specialistId = new UserIdentity(UnitofWork, MembershipService).GetSpecialistId();
                var specialist = UnitofWork.SpecialistRepository.FindBy(x => x.SpecialistId == specialistId).FirstOrDefault();
                if (specialist != null)
                {
                    return new PosterAttributes(specialist.FirstName, specialist.LastName,
                        currenturl + "/SpecialistProfile/" + specialist.SpecialistId, specialist.Photo,
                        specialist.EmailAddress, "specialist", specialist.SpecialistId);
                }
            }


            if (role == "Provider")
            {
                var providerId = new UserIdentity(UnitofWork, MembershipService).GetProviderId();
                var provider = UnitofWork.MaintenanceProviderRepository.FindBy(x => x.MaintenanceProviderId == providerId).FirstOrDefault();
                if (provider != null)
                {
                    return new PosterAttributes(provider.FirstName, provider.LastName,
                        currenturl + "/ProviderProfile/" + provider.MaintenanceProviderId, provider.Photo,
                        provider.EmailAddress, "provider", provider.MaintenanceProviderId);
                }
            }



            return DefaultPoster;

        }

    }
}