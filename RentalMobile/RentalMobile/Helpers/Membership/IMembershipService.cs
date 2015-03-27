using System.Web.Security;

namespace RentalMobile.Helpers.Membership
{
    public interface IMembershipService
    {
        MembershipUser GetUser(string name);

        void UpdateUser(MembershipUser user);
    }
}