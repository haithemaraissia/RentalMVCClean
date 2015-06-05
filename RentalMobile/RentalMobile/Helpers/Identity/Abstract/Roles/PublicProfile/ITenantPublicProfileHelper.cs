using RentalMobile.Model.Models;

namespace RentalMobile.Helpers.Identity.Abstract.Roles.PublicProfile
{
    public interface ITenantPublicProfileHelper
    {
        Tenant GetPublicProfileTenantByTenantId(int id);
        string TenantPublicProfileUsername();
    }
}
