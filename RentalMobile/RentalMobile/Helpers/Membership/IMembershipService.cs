using System.Web.Security;

namespace RentalMobile.Helpers.Membership
{
    public interface IMembershipService
    {
        MembershipUser GetUser(string name);

        MembershipUser GetUser(string username, bool userIsOnline);

        string GetUserNameByEmail(string emailToMatch);

        void UpdateUser(MembershipUser user);

        bool ValidateUser(string username, string password);

        MembershipUser CreateUser(string username, string password, string email, string passwordQuestion,
            string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status);

        bool DeleteUser(string username);

        string[] GetRolesForUser(string username);

        void RemoveUserFromRoles(string username, string[] roleNames);

        string ResetPassword();

        void SignOut();
    }
}