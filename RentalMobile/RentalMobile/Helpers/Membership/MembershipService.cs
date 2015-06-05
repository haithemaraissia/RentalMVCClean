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

        public MembershipUser GetUser(string username, bool userIsOnline)
        {
            return System.Web.Security.Membership.GetUser(username, userIsOnline);
        }

        public string GetUserNameByEmail(string emailToMatch)
        {
            return System.Web.Security.Membership.GetUserNameByEmail(emailToMatch);
        }

        public virtual  void UpdateUser(MembershipUser user)
        {
            System.Web.Security.Membership.UpdateUser(user);
        }

        public bool ValidateUser(string username, string password)
        {
            return System.Web.Security.Membership.ValidateUser(username, password);
        }

        public MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer,
            bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            return System.Web.Security.Membership.CreateUser(username, password, email, passwordQuestion, passwordAnswer,
                isApproved, providerUserKey, out status);
        }

        public bool DeleteUser(string username)
        {
            return System.Web.Security.Membership.DeleteUser(username, true);
        }

        public string[] GetRolesForUser(string username)
        {
            return System.Web.Security.Roles.GetRolesForUser(username);
        }

        public void RemoveUserFromRoles(string username, string[] roleNames)
        {
            System.Web.Security.Roles.RemoveUserFromRoles(username, System.Web.Security.Roles.GetRolesForUser(username));
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}