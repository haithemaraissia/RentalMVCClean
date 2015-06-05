using RentalMobile.Model.Models;

namespace RentalMobile.Helpers.Identity.Abstract.Roles.PublicProfile
{
    public interface IOwnerPublicProfileHelper
    {
        Owner GetPublicProfileOwnerByOwnerId(int id);
        string OwnerPublicProfileUsername();
    }
}
