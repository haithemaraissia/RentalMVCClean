using System.Web;
using System.Web.Security;

namespace RentalMobile.Helpers.Membership
{
    public class MembershipService : IMembershipService
    {
        public virtual MembershipUser GetUser(string name)
        {
            return System.Web.Security.Membership.GetUser(HttpContext.Current.User.Identity.Name);
        }

        public virtual  void UpdateUser(MembershipUser user)
        {
            System.Web.Security.Membership.UpdateUser(user);
        }
    }
}