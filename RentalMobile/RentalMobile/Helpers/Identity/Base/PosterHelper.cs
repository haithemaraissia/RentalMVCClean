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
        public PosterAttributes DefaultPoster = new PosterAttributes("A Friend", "Friend", "#", "../../images/dotimages/single-property/agent-480x350.png", "none@yahoo.com", "notauthenticated", 0);

        private readonly UnitofWork _unitOfWork;

        public PosterHelper(UnitofWork uow, IMembershipService membershipService)
        {
            MembershipService = membershipService;
            _unitOfWork = uow;
        }

        public PosterHelper()
        {
            MembershipService = new MembershipService();
            _unitOfWork = new UnitofWork();
        }

        public PosterAttributes GetPoster(int uniId)
        {
            var uri = HttpContext.Request.Url;
            if (uri == null) return DefaultPoster;
            var currenturl = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;

            var unit = _unitOfWork.UnitRepository.FindBy(x => x.UnitId == uniId).FirstOrDefault();
            if (unit != null && unit.PosterRole != null)
            {
                switch (unit.PosterRole.Trim().ToLower())
                {
                    case "owner":
                        var owner = _unitOfWork.OwnerRepository.FindBy(x => x.OwnerId == unit.PosterID).FirstOrDefault();
                        if (owner != null)
                        {
                            return new PosterAttributes(owner.FirstName, owner.LastName, currenturl + "/ownerprofile/index/" + unit.PosterID, owner.Photo, owner.EmailAddress, "owner", owner.OwnerId);
                        }
                        break;
                    case "agent":
                        var agent = _unitOfWork.AgentRepository.FindBy(x => x.AgentId == unit.PosterID).FirstOrDefault();
                        if (agent != null)
                        {
                            return new PosterAttributes(agent.FirstName, agent.LastName, currenturl + "/agentprofile/index/" + unit.PosterID, agent.Photo, agent.EmailAddress, "agent", agent.AgentId);
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

        public string GetCurrencyValue(int? currencyId)
        {
            var currency = _unitOfWork.CurrencyRepository.FindBy(x => x.CurrencyID == currencyId).FirstOrDefault();
            if (currency != null)
                return currency.CurrencyValue;
            return _unitOfWork.CurrencyRepository.All.ToList().First().CurrencyValue;
        }

        public PosterAttributes GetSendtoFriendPoster()
        {
            var uri = HttpContext.Request.Url;
            if (uri == null) return DefaultPoster;
            var currenturl = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;

            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                //Not Authenticated
                return DefaultPoster;
            }
            string photoPath;
            var role = new UserIdentity().GetCurrentRole(out photoPath);
            if (role == "Tenant")
            {
                var tenant = _unitOfWork.TenantRepository.FindBy(x => x.TenantId == new UserIdentity(_unitOfWork, MembershipService).GetTenantId()).FirstOrDefault();
                if (tenant != null)
                {
                    return new PosterAttributes(tenant.FirstName, tenant.LastName,
                        currenturl + "/tenantprofile/index/" + tenant.TenantId, tenant.Photo,
                        tenant.EmailAddress, "tenant", tenant.TenantId);
                }
            }
            if (role == "Owner")
            {
                var owner = _unitOfWork.OwnerRepository.FindBy(x => x.OwnerId == new UserIdentity(_unitOfWork, MembershipService).GetOwnerId()).FirstOrDefault();
                if (owner != null)
                {
                    return new PosterAttributes(owner.FirstName, owner.LastName,
                        currenturl + "/ownerprofile/index/" + owner.OwnerId, owner.Photo,
                        owner.EmailAddress, "owner", owner.OwnerId);
                }
            }
            if (role == "Agent")
            {
                var agent = _unitOfWork.AgentRepository.FindBy(x => x.AgentId == new UserIdentity(_unitOfWork, MembershipService).GetAgentId()).FirstOrDefault();
                if (agent != null)
                {
                    return new PosterAttributes(agent.FirstName, agent.LastName,
                        currenturl + "/agentprofile/index/" + agent.AgentId, agent.Photo,
                        agent.EmailAddress, "tenant", agent.AgentId);
                }
            }

            if (role == "Specialist")
            {
                var specialist = _unitOfWork.SpecialistRepository.FindBy(x => x.SpecialistId == new UserIdentity(_unitOfWork, MembershipService).GetSpecialistId()).FirstOrDefault();
                if (specialist != null)
                {
                    return new PosterAttributes(specialist.FirstName, specialist.LastName,
                        currenturl + "/professionals/" + specialist.SpecialistId, specialist.Photo,
                        specialist.EmailAddress, "specialist", specialist.SpecialistId);
                }
            }


            if (role == "Provider")
            {
                var provider = _unitOfWork.MaintenanceProviderRepository.FindBy(x => x.MaintenanceProviderId == new UserIdentity(_unitOfWork, MembershipService).GetProviderId()).FirstOrDefault();
                if (provider != null)
                {
                    return new PosterAttributes(provider.FirstName, provider.LastName,
                        currenturl + "/providers/" + provider.MaintenanceProviderId, provider.Photo,
                        provider.EmailAddress, "provider", provider.MaintenanceProviderId);
                }
            }

            return DefaultPoster;
        }

        public PosterAttributes GetCommentPoster()
        {
            var uri = HttpContext.Request.Url;
            if (uri == null) return DefaultPoster;
            var currenturl = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;

            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                //Not Authenticated
                return DefaultPoster;
            }
            string photoPath;
            var role = new UserIdentity(_unitOfWork, MembershipService).GetCurrentRole(out photoPath);
            if (role == "Tenant")
            {
                var tenant = _unitOfWork.TenantRepository.FindBy(x => x.TenantId == new UserIdentity(_unitOfWork, MembershipService).GetTenantId()).FirstOrDefault();
                if (tenant != null)
                {
                    return new PosterAttributes(tenant.FirstName, tenant.LastName,
                        currenturl + "/tenantprofile/index/" + tenant.TenantId, tenant.Photo,
                        tenant.EmailAddress, "tenant", tenant.TenantId);
                }
            }
            if (role == "Owner")
            {
                var owner = _unitOfWork.OwnerRepository.FindBy(x => x.OwnerId == new UserIdentity(_unitOfWork, MembershipService).GetOwnerId()).FirstOrDefault();
                if (owner != null)
                {
                    return new PosterAttributes(owner.FirstName, owner.LastName,
                        currenturl + "/ownerprofile/index/" + owner.OwnerId, owner.Photo,
                        owner.EmailAddress, "owner", owner.OwnerId);
                }
            }
            if (role == "Agent")
            {
                var agent = _unitOfWork.AgentRepository.FindBy(x => x.AgentId == new UserIdentity(_unitOfWork, MembershipService).GetAgentId()).FirstOrDefault();
                if (agent != null)
                {
                    return new PosterAttributes(agent.FirstName, agent.LastName,
                        currenturl + "/agentprofile/index/" + agent.AgentId, agent.Photo,
                        agent.EmailAddress, "tenant", agent.AgentId);
                }
            }

            if (role == "Specialist")
            {
                var specialist = _unitOfWork.SpecialistRepository.FindBy(x => x.SpecialistId == new UserIdentity(_unitOfWork, MembershipService).GetSpecialistId()).FirstOrDefault();
                if (specialist != null)
                {
                    return new PosterAttributes(specialist.FirstName, specialist.LastName,
                        currenturl + "/professionals/" + specialist.SpecialistId, specialist.Photo,
                        specialist.EmailAddress, "specialist", specialist.SpecialistId);
                }
            }


            if (role == "Provider")
            {
                var provider = _unitOfWork.MaintenanceProviderRepository.FindBy(x => x.MaintenanceProviderId == new UserIdentity(_unitOfWork, MembershipService).GetProviderId()).FirstOrDefault();
                if (provider != null)
                {
                    return new PosterAttributes(provider.FirstName, provider.LastName,
                        currenturl + "/providers/" + provider.MaintenanceProviderId, provider.Photo,
                        provider.EmailAddress, "provider", provider.MaintenanceProviderId);
                }
            }

            return DefaultPoster;
        }

    }
}