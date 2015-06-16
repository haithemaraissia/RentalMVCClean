using System.Web;

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

            if (user.IsInRole("Tenant"))
            {
                PhotoPath = HttpContext.Current.Server.MapPath(TenantPhotoPath);
                Role = "Tenant";
            }
            if (user.IsInRole("Owner"))
            {
                PhotoPath = HttpContext.Current.Server.MapPath(OwnerPhotoPath);
                Role = "Owner";
            }
            if (user.IsInRole("Agent"))
            {
                PhotoPath = HttpContext.Current.Server.MapPath(AgentPhotoPath);
            }
            if (user.IsInRole("Provider"))
            {
                PhotoPath = HttpContext.Current.Server.MapPath(ProviderPhotoPath);
                Role = "Provider";
            }

            PhotoPath = HttpContext.Current.Server.MapPath(SpecialistPhotoPath);
            Role = user.IsInRole("Specialist") ? "Specialist" : null;
        }
    }
}