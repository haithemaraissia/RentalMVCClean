using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Membership;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Identity.Correct
{
    public class UserIdentityWithBase : BaseController, IUserIdentity
    {
        public IMembershipService MembershipService { get; set; }
        public UnitofWork UnitOfWork;
        public static string DefaultAvatarPlaceholderImagePath = "../../images/dotimages/avatar-placeholder.png";
        public static string DefaultSpecialistName = "Specialist";
        public static string TenantPhotoPath = "~/Photo/Tenant/Property";
        public static string OwnerPhotoPath = "~/Photo/Owner/Property";
        public static string AgentPhotoPath = "~/Photo/Agent/Property";
        public static string ProviderPhotoPath = "~/Photo/Provider/Property";
        public static string SpecialistPhotoPath = "~/Photo/Specialist/Property";

        public UserIdentityWithBase(UnitofWork uow, IMembershipService membershipService)
        {
            MembershipService = membershipService;
            UnitOfWork = uow;
        }

        public UserIdentityWithBase()
        {
            MembershipService = new MembershipService();
            UnitOfWork = new UnitofWork();
        }

        public string GetUserName()
        {
            var currentuser = MembershipService.GetUser(HttpContext.User.Identity.Name);
            return currentuser != null ? currentuser.UserName: UserHelper.Login();
        }

        public Guid? GetUserGuid()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var user = MembershipService.GetUser(HttpContext.User.Identity.Name);
                if (user != null && user.ProviderUserKey != null)
                {
                    return (Guid)user.ProviderUserKey;
                }
            }
            return null;
        }

        public int? GetTenantId(Guid userId)
        {
            var tenant = UserHelper.Db.Tenants.FirstOrDefault(x => x.GUID == userId);
            if (tenant != null) return tenant.TenantId;
            return 0;
        }

        public int? GetTenantId()
        {
            var userId = GetUserGuid();
            var tenant = UserHelper.Db.Tenants.FirstOrDefault(x => x.GUID == userId);
            if (tenant != null) return tenant.TenantId;
            return 0;
        }

        public int? GetTenantId(int id)
        {
            var userId = UserHelper.Db.Tenants.FirstOrDefault(x => x.TenantId == id);
            if (userId != null)
            {
                var tenant = UserHelper.Db.Tenants.FirstOrDefault(x => x.GUID == userId.GUID);
                if (tenant != null) return tenant.TenantId;
            }
            return 0;
        }

        public int GetAgentId()
        {
            var userId = GetUserGuid();
            var agent = UserHelper.Db.Agents.FirstOrDefault(x => x.GUID == userId);
            if (agent != null) return agent.AgentId;
            return 0;
        }

        public int GetAgentId(int id)
        {
            var userId = UserHelper.Db.Agents.FirstOrDefault(x => x.AgentId == id);
            if (userId != null)
            {
                var agent = UserHelper.Db.Agents.FirstOrDefault(x => x.GUID == userId.GUID);
                if (agent != null) return agent.AgentId;
            }
            return 0;
        }

        public int GetOwnerId()
        {
            var userId = GetUserGuid();
            var owner = UserHelper.Db.Owners.FirstOrDefault(x => x.GUID == userId);
            if (owner != null) return owner.OwnerId;
            return 0;
        }

        public int GetOwnerId(int id)
        {
            var userId = UserHelper.Db.Owners.FirstOrDefault(x => x.OwnerId == id);
            if (userId != null)
            {
                var owner = UserHelper.Db.Owners.FirstOrDefault(x => x.GUID == userId.GUID);
                if (owner != null) return owner.OwnerId;
            }
            return 0;
        }

        public int GetSpecialistId()
        {
            var userId = GetUserGuid();
            var specialist = UnitOfWork.SpecialistRepository.FindBy(x => x.GUID == userId).FirstOrDefault();
            if (specialist != null) return specialist.SpecialistId;
            return 0;
        }

        public int GetSpecialistId(int id)
        {
            var userId = UserHelper.Db.Specialists.FirstOrDefault(x => x.SpecialistId == id);
            if (userId != null)
            {
                var specialist = UserHelper.Db.Specialists.FirstOrDefault(x => x.GUID == userId.GUID);
                if (specialist != null) return specialist.SpecialistId;
            }
            return 0;
        }

        public int GetProviderId()
        {
            var userId = GetUserGuid();
            var provider = UserHelper.Db.MaintenanceProviders.FirstOrDefault(x => x.GUID == userId);
            if (provider != null) return provider.MaintenanceProviderId;
            return 0;
        }

        public int GetProviderId(int id)
        {
            var userId = UserHelper.Db.MaintenanceProviders.FirstOrDefault(x => x.MaintenanceProviderId == id);
            if (userId != null)
            {
                var provider = UserHelper.Db.MaintenanceProviders.FirstOrDefault(x => x.GUID == userId.GUID);
                if (provider != null) return provider.MaintenanceProviderId;
            }
            return 0;
        }

        public  string GetCurrentRole(out string photoPath)
        {
            var user = HttpContext.User;
            if (user.IsInRole("Tenant"))
            {
                photoPath = HttpContext.Server.MapPath(TenantPhotoPath);
                return "Tenant";
            }
            if (user.IsInRole("Owner"))
            {
                photoPath = HttpContext.Server.MapPath(OwnerPhotoPath);
                return "Owner";
            }
            if (user.IsInRole("Agent"))
            {
                photoPath = HttpContext.Server.MapPath(AgentPhotoPath);
                return "Agent";
            }
            if (user.IsInRole("Provider"))
            {
                photoPath = HttpContext.Server.MapPath(ProviderPhotoPath);
                return "Provider";
            }

            photoPath = HttpContext.Server.MapPath(SpecialistPhotoPath);
            return user.IsInRole("Specialist") ? "Specialist" : null;
        }
    }
}