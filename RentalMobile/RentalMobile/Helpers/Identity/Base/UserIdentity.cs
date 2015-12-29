using System;
using System.Linq;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Identity.Abstract;
using RentalMobile.Helpers.Membership;
using RentalMobile.Helpers.Roles;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Identity.Base
{
    public class UserIdentity : BaseController, IUserIdentity
    {
        public string DefaultAvatarPlaceholderImagePath = "../../images/dotimages/avatar-placeholder.png";
        public string DefaultSpecialistName = "Specialist";
        public string TenantPhotoPath = "~/Photo/Tenant/Profile";
        public string OwnerPhotoPath = "~/Photo/Owner/Profile";
        public string AgentPhotoPath = "~/Photo/Agent/Profile";
        public string ProviderPhotoPath = "~/Photo/Provider/Profile";
        public string SpecialistPhotoPath = "~/Photo/Specialist/Profile";

        public IGenericUnitofWork UnitOfWork;

        public UserIdentity(IGenericUnitofWork uow, IMembershipService membershipService)
        {
            MembershipService = membershipService;
            UnitOfWork = uow;
        }

        public UserIdentity()
        {
            MembershipService = new MembershipService();
            UnitOfWork = new UnitofWork();
        }

        //Using the Base Class
        public string GetUserNameFromMembership()
        {
            var currentuser = MembershipProvider.GetUser(HttpContext.User.Identity.Name, true);
            return currentuser != null ? currentuser.UserName : new UserIdentity(UnitOfWork, MembershipService).Login();
        }
        //Using the Base Class


        public string Login()
        {
            if (HttpContext.Request.Url != null)
                return string.Format("~/NotAuthenticated/SignIn.aspx?ReturnUrl={0}", HttpContext.Request.Url.AbsoluteUri);
            return "~/NotAuthenticated/SignIn.aspx";
        }

        public string GetUserName()
        {
            var currentuser = MembershipService.GetUser(HttpContext.User.Identity.Name);
            return currentuser != null ? currentuser.UserName : new UserIdentity(UnitOfWork, MembershipService).Login();
        }

        public Guid? GetUserGuid()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var user = MembershipService.GetUser(HttpContext.User.Identity.Name);
                if (user != null && user.ProviderUserKey != null)
                {
                    return new Guid(user.ProviderUserKey.ToString());
                }
            }
            return null;
        }

        public int GetTenantId(Guid userId)
        {
            var tenant = UnitOfWork.TenantRepository.FindBy(x => x.GUID == userId).FirstOrDefault();
            if (tenant != null) return tenant.TenantId;
            return 0;
        }

        public int GetTenantId()
        {
            var userId = GetUserGuid();
            var tenant = UnitOfWork.TenantRepository.FindBy(x => x.GUID == userId).FirstOrDefault();
            if (tenant != null) return tenant.TenantId;
            return 0;
        }

        public int GetTenantId(int id)
        {
            //var userId = UnitOfWork.TenantRepository.FindBy(x => x.TenantId == id).FirstOrDefault();
            //if (userId != null)
            //{
            //    var tenant = UnitOfWork.TenantRepository.FindBy(x => x.GUID == userId.GUID).FirstOrDefault();
            //    if (tenant != null) return tenant.TenantId;
            //}
            //return 0;

            var tenant = UnitOfWork.TenantRepository.FindBy(x => x.TenantId == id).FirstOrDefault();
            if (tenant != null) return tenant.TenantId;
            return 0;

        }

        public int GetAgentId()
        {
            var userId = GetUserGuid();
            var agent = UnitOfWork.AgentRepository.FindBy(x => x.GUID == userId).FirstOrDefault();
            if (agent != null) return agent.AgentId;
            return 0;
        }

        public int GetAgentId(int id)
        {
            //var userId = UnitOfWork.AgentRepository.FindBy(x => x.AgentId == id).FirstOrDefault();
            //if (userId != null)
            //{
            //    var agent = UnitOfWork.AgentRepository.FindBy(x => x.GUID == userId.GUID).FirstOrDefault();
            //    if (agent != null) return agent.AgentId;
            //}
            //return 0;
            var agent = UnitOfWork.AgentRepository.FindBy(x => x.AgentId == id).FirstOrDefault();
            if (agent != null) return agent.AgentId;
            return 0;
        }

        public int GetOwnerId()
        {
            var userId = GetUserGuid();
            var owner = UnitOfWork.OwnerRepository.FindBy(x => x.GUID == userId).FirstOrDefault();
            if (owner != null) return owner.OwnerId;
            return 0;
        }

        public int GetOwnerId(int id)
        {
            //var userId = UnitOfWork.OwnerRepository.FindBy(x => x.OwnerId == id).FirstOrDefault();
            //if (userId != null)
            //{
            //    var owner = UnitOfWork.OwnerRepository.FindBy(x => x.GUID == userId.GUID).FirstOrDefault();
            //    if (owner != null) return owner.OwnerId;
            //}
            //return 0;
            var owner = UnitOfWork.OwnerRepository.FindBy(x => x.OwnerId == id).FirstOrDefault();
            if (owner != null) return owner.OwnerId;
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
            var specialist = UnitOfWork.SpecialistRepository.FindBy(x => x.SpecialistId == id).FirstOrDefault();
            if (specialist != null) return specialist.SpecialistId;
            return 0;
        }

        public int GetProviderId()
        {
            var userId = GetUserGuid();
            var provider = UnitOfWork.MaintenanceProviderRepository.FindBy(x => x.GUID == userId).FirstOrDefault();
            if (provider != null) return provider.MaintenanceProviderId;
            return 0;
        }

        public int GetProviderId(int id)
        {
            var provider = UnitOfWork.MaintenanceProviderRepository.FindBy(x => x.MaintenanceProviderId == id).FirstOrDefault();
            if (provider != null) return provider.MaintenanceProviderId;
            return 0;
        }

        public int GetRoleId(string chosenRole)
        {
            switch (chosenRole.ToLower())
            {
                case LookUpRoles.TenantRoleId:
                    return 1;
                case LookUpRoles.OwnerRoleId:
                    return 2;
                case LookUpRoles.AgentRoleId:
                    return 3;
                case LookUpRoles.SpecialistRoleId:
                    return 4;
                case LookUpRoles.ProviderRoleId:
                    return 5;
                case LookUpRoles.NotAuthenticatedRoleId:
                    return 6;
                default:
                    return 6;
            }
        }

        public string GetCurrentRole()
        {
            if (System.Web.HttpContext.Current != null)
            {
                var user = System.Web.HttpContext.Current.User;
                if (user.IsInRole(LookUpRoles.TenantRole))
                {
                    return LookUpRoles.TenantRole;
                }
                if (user.IsInRole(LookUpRoles.OwnerRole))
                {
                    return LookUpRoles.OwnerRole;
                }
                if (user.IsInRole(LookUpRoles.AgentRole))
                {
                    return LookUpRoles.AgentRole;
                }
                if (user.IsInRole(LookUpRoles.ProviderRole))
                {
                    return LookUpRoles.ProviderRole;
                }
                return user.IsInRole(LookUpRoles.SpecialistRole) ? LookUpRoles.SpecialistRole : null;
            }
            return null;
        }

        public string SetPhotoPathByCurrentRole(out string photoPath)
        {
            if (System.Web.HttpContext.Current != null)
            {
                var user = System.Web.HttpContext.Current.User;
                if (user == null)
                {
                    photoPath = null;
                    return null;
                }
                if (user.IsInRole(LookUpRoles.TenantRole))
                {
                    photoPath = HttpContext.Server.MapPath(TenantPhotoPath);
                    return LookUpRoles.Tenant;
                }
                if (user.IsInRole(LookUpRoles.OwnerRole))
                {
                    photoPath = HttpContext.Server.MapPath(OwnerPhotoPath);
                    return LookUpRoles.Owner;
                }
                if (user.IsInRole(LookUpRoles.AgentRole))
                {
                    photoPath = HttpContext.Server.MapPath(AgentPhotoPath);
                    return LookUpRoles.Agent;
                }
                if (user.IsInRole(LookUpRoles.ProviderRole))
                {
                    photoPath = HttpContext.Server.MapPath(ProviderPhotoPath);
                    return LookUpRoles.Provider;
                }
                if (user.IsInRole(LookUpRoles.SpecialistRole))
                {
                    photoPath = HttpContext.Server.MapPath(SpecialistPhotoPath);
                    return LookUpRoles.Specialist;
                }
            }
            photoPath = null;
            return null;
        }

        public string ResolveImageUrl(string relativeUrl)
        {
            if (HttpContext.Request == null) return null;
            return HttpContext.Request.Url != null ?
                new Uri(HttpContext.Request.Url, relativeUrl).AbsoluteUri : null;

            //if (VirtualPathUtility.IsAppRelative(relativeUrl))
            //{
            //    return VirtualPathUtility.ToAbsolute(relativeUrl);
            //}
            //else
            //{
            //    var curPath = WebPageContext.Current.Page.TemplateInfo.VirtualPath;
            //    var curDir = VirtualPathUtility.GetDirectory(curPath);
            //    return VirtualPathUtility.ToAbsolute(VirtualPathUtility.Combine(curDir, relativeUrl));
        }
    }
}