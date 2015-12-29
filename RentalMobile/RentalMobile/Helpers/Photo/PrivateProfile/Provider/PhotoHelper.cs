using System.Web;
using RentalMobile.Helpers.Roles;

namespace RentalMobile.Helpers.Photo.PrivateProfile.Provider
{
    class PhotoHelper
    {
        public const string TenantPhotoPath = "~/Photo/Tenant/Property";
        public const string OwnerPhotoPath = "~/Photo/Owner/Property";
        public const string AgentPhotoPath = "~/Photo/Agent/Property";
        public const string ProviderPhotoPath = "~/Photo/Provider/Property";
        public const string SpecialistPhotoPath = "~/Photo/Specialist/Property";
      //  public string RequestID;
        public string PhotoPath { get; set; }
        public string Role { get; set; }

        public PhotoHelper()
        {
            var user = HttpContext.Current.User;

            if (user.IsInRole(LookUpRoles.TenantRole))
            {
                PhotoPath = HttpContext.Current.Server.MapPath(TenantPhotoPath);
                Role = LookUpRoles.TenantRole;
            }
            if (user.IsInRole(LookUpRoles.OwnerRole))
            {
                PhotoPath = HttpContext.Current.Server.MapPath(OwnerPhotoPath);
                Role = LookUpRoles.OwnerRole;
            }
            if (user.IsInRole(LookUpRoles.AgentRole))
            {
                PhotoPath = HttpContext.Current.Server.MapPath(AgentPhotoPath);
                Role = LookUpRoles.AgentRole;
            }
            if (user.IsInRole(LookUpRoles.ProviderRole))
            {
                PhotoPath = HttpContext.Current.Server.MapPath(ProviderPhotoPath);
                Role = LookUpRoles.ProviderRole;
            }

            PhotoPath = HttpContext.Current.Server.MapPath(SpecialistPhotoPath);
            Role = user.IsInRole(LookUpRoles.SpecialistRole) ? LookUpRoles.SpecialistRole : null;
        }
    }
}