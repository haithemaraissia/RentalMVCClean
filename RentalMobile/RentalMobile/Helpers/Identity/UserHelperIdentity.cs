using System;
using System.Linq;
using System.Web;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Membership;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Identity
{
    public class UserHelperIdentity 
    {
        public IMembershipService MembershipService;
        public UnitofWork UnitOfWork;

        public UserHelperIdentity(UnitofWork uow, IMembershipService membershipService)
        {
            MembershipService = membershipService;
            UnitOfWork = uow;
        }

        public UserHelperIdentity()
        {
            MembershipService = new MembershipService();
            UnitOfWork = new UnitofWork();
        }

        public string GetUserName()
        {
            var currentuser = new MembershipService().GetUser(HttpContext.Current.User.Identity.Name);
            return currentuser != null ? currentuser.ToString() : UserHelper.Login();
        }

        public Guid? GetUserGuid()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var user = MembershipService.GetUser(HttpContext.Current.User.Identity.Name);

                // MembershipUser user = Membership.GetUser(HttpContext.Current.User.Identity.Name);

                if (user != null && user.ProviderUserKey != null)
                {
                    return (Guid)user.ProviderUserKey;
                }
            }
            return null;
        }

        public int GetTenantId(Guid userId)
        {
            var tenant = UserHelper.Db.Tenants.FirstOrDefault(x => x.GUID == userId);
            if (tenant != null) return tenant.TenantId;
            return 0;
        }

        public int GetTenantId()
        {
            var userId = GetUserGuid();
            var tenant = UserHelper.Db.Tenants.FirstOrDefault(x => x.GUID == userId);
            if (tenant != null) return tenant.TenantId;
            return 0;
        }

        public int GetTenantId(int id)
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
    }
}