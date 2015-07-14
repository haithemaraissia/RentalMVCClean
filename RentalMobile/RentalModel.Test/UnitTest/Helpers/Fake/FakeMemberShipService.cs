using System.Web;
using System.Web.Security;
using RentalMobile.Helpers.Membership;
using RentalMobile.Helpers.Roles;

namespace TestProject.UnitTest.Helpers.Fake
{
    public class FakeMemberShipService : IMembershipService
    {
        #region IMemberShipService Functions
        //You Have to Mock HttpContext.User.Identity.Name

        public FakeMembershipProvider FakeMembershipProvider = new FakeMembershipProvider();

        public MembershipUser GetUser(string name)
        {
            MembershipUser userRet = null;
            if (name == FakeMembershipProvider.FakeUserFred.UserName)
            {
                userRet = FakeMembershipProvider.FakeUserFred;
            }
            else if (name == FakeMembershipProvider.FakeUserLisa.UserName)
            {
                userRet = FakeMembershipProvider.FakeUserLisa;
            }
            else if (name == FakeMembershipProvider.FakeUserMike.UserName)
            {
                userRet = FakeMembershipProvider.FakeUserMike;
            }
            else if (name == FakeMembershipProvider.FakeUserSara.UserName)
            {
                userRet = FakeMembershipProvider.FakeUserSara;
            }
            else if (name == FakeMembershipProvider.FakeUserJeff.UserName)
            {
                userRet = FakeMembershipProvider.FakeUserJeff;
            }
            return userRet;
        }

        public  MembershipUser GetUser(string username, bool userIsOnline)
        {
            MembershipUser userRet = null;
            if (username == FakeMembershipProvider.FakeUserFred.UserName)
            {
                userRet = FakeMembershipProvider.FakeUserFred;
            }
            else if (username == FakeMembershipProvider.FakeUserLisa.UserName)
            {
                userRet = FakeMembershipProvider.FakeUserLisa;
            }
            else if (username == FakeMembershipProvider.FakeUserMike.UserName)
            {
                userRet = FakeMembershipProvider.FakeUserMike;
            }
            else if (username == FakeMembershipProvider.FakeUserSara.UserName)
            {
                userRet = FakeMembershipProvider.FakeUserSara;
            }
            else if (username == FakeMembershipProvider.FakeUserJeff.UserName)
            {
                userRet = FakeMembershipProvider.FakeUserJeff;
            }
            return userRet;
        }

        public  string GetUserNameByEmail(string emailToMatch)
        {
            string strRet = "";
            if (emailToMatch == FakeMembershipProvider.FakeUserFred.Email)
            {
                strRet = FakeMembershipProvider._fakeAnswerFred;
            }
            else if (emailToMatch == FakeMembershipProvider.FakeUserLisa.Email)
            {
                strRet = FakeMembershipProvider._fakePasswordLisa;
            }
            else if (emailToMatch == FakeMembershipProvider.FakeUserMike.Email)
            {
                strRet = FakeMembershipProvider._fakePasswordMike;
            }
            else if (emailToMatch == FakeMembershipProvider.FakeUserSara.Email)
            {
                strRet = FakeMembershipProvider._fakePasswordSara;
            }
            else if (emailToMatch == FakeMembershipProvider.FakeUserJeff.Email)
            {
                strRet = FakeMembershipProvider._fakePasswordJeff;
            }
            return strRet;
        }

        public  void UpdateUser(MembershipUser user)
        {
            if (user.UserName == FakeMembershipProvider.FakeUserFred.UserName)
            {
                //Few Member Update
                user.Comment = FakeMembershipProvider.FakeUserFred.Comment;
                user.Email = FakeMembershipProvider.FakeUserFred.Email;
            }
            else if (user.UserName == FakeMembershipProvider.FakeUserLisa.UserName)
            {
                user.Comment = FakeMembershipProvider.FakeUserLisa.Comment;
                user.Email = FakeMembershipProvider.FakeUserLisa.Email;
            }
            else if (user.UserName == FakeMembershipProvider.FakeUserMike.UserName)
            {
                user.Comment = FakeMembershipProvider.FakeUserMike.Comment;
                user.Email = FakeMembershipProvider.FakeUserMike.Email;
            }
            else if (user.UserName == FakeMembershipProvider.FakeUserSara.UserName)
            {
                user.Comment = FakeMembershipProvider.FakeUserSara.Comment;
                user.Email = FakeMembershipProvider.FakeUserSara.Email;
            }
            else if (user.UserName == FakeMembershipProvider.FakeUserJeff.UserName)
            {
                user.Comment = FakeMembershipProvider.FakeUserJeff.Comment;
                user.Email = FakeMembershipProvider.FakeUserJeff.Email;
            }
        }

        public  bool ValidateUser(string username, string password)
        {
            bool bRet = ((username == FakeMembershipProvider.FakeUserFred.UserName) && (password == FakeMembershipProvider._fakePasswordFred)) ||
                        ((username == FakeMembershipProvider.FakeUserLisa.UserName) && (password == FakeMembershipProvider._fakePasswordLisa)) ||
                        ((username == FakeMembershipProvider.FakeUserMike.UserName) && (password == FakeMembershipProvider._fakePasswordMike)) ||
                        ((username == FakeMembershipProvider.FakeUserSara.UserName) && (password == FakeMembershipProvider._fakePasswordSara)) ||
                        ((username == FakeMembershipProvider.FakeUserJeff.UserName) && (password == FakeMembershipProvider._fakePasswordJeff))
                        ;
            return bRet;

        }

        public  MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer,
            bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            MembershipUser userRet = null;
            status = MembershipCreateStatus.UserRejected;


            if (((username == FakeMembershipProvider.FakeUserFred.UserName) && (password == FakeMembershipProvider._fakePasswordFred)) ||
                ((username == FakeMembershipProvider.FakeUserLisa.UserName) && (password == FakeMembershipProvider._fakePasswordLisa)) ||
                ((username == FakeMembershipProvider.FakeUserMike.UserName) && (password == FakeMembershipProvider._fakePasswordMike)) ||
                ((username == FakeMembershipProvider.FakeUserSara.UserName) && (password == FakeMembershipProvider._fakePasswordSara)) ||
                ((username == FakeMembershipProvider.FakeUserJeff.UserName) && (password == FakeMembershipProvider._fakePasswordJeff)))
            {
                if (username == FakeMembershipProvider.FakeUserFred.UserName)
                {
                    userRet = FakeMembershipProvider.FakeUserFred;
                }
                else if (username == FakeMembershipProvider.FakeUserLisa.UserName)
                {
                    userRet = FakeMembershipProvider.FakeUserLisa;
                }
                else if (username == FakeMembershipProvider.FakeUserMike.UserName)
                {
                    userRet = FakeMembershipProvider.FakeUserMike;
                }
                else if (username == FakeMembershipProvider.FakeUserSara.UserName)
                {
                    userRet = FakeMembershipProvider.FakeUserSara;
                }
                else if (username == FakeMembershipProvider.FakeUserJeff.UserName)
                {
                    userRet = FakeMembershipProvider.FakeUserJeff;
                }
                status = MembershipCreateStatus.Success;
            }
            return userRet;
        }

        public bool DeleteUser(string username)
        {
            bool bRet = (username == FakeMembershipProvider.FakeUserFred.UserName) || (username == FakeMembershipProvider.FakeUserLisa.UserName)
                        || (username == FakeMembershipProvider.FakeUserMike.UserName) || (username == FakeMembershipProvider.FakeUserSara.UserName)
                        || (username == FakeMembershipProvider.FakeUserJeff.UserName);
            return bRet;
        }

        public string[] GetRolesForUser(string username)
        {
            if (username == FakeMembershipProvider.FakeUserFred.UserName)
            {
                return new[] { "Tenant" };
            }
            if (username == FakeMembershipProvider.FakeUserLisa.UserName)
            {
                return new[] { "Owner" };
            }
            if (username == FakeMembershipProvider.FakeUserMike.UserName)
            {
                return new[] { "Agent" };
            }
            if (username == FakeMembershipProvider.FakeUserSara.UserName)
            {
                return new[] { "Specialist" };
            }
            if (username == FakeMembershipProvider.FakeUserJeff.UserName)
            {
                return new[] { "MaintenanceProvider" };
            }
            return new string[] { "No Role" };
        }

        public void RemoveUserFromRoles(string username, string[] roleNames)
        {
            return;
        }

        public void SignOut()
        {
            return;
        }

        public string ResetPassword()
        {

            const string strRet = "";
            if (HttpContext.Current.User.Identity.Name == FakeMembershipProvider.FakeUserFred.UserName && HttpContext.Current.User.IsInRole(LookUpRoles.TenantRole))
            {
                return FakeMembershipProvider.FakeResetPasswordFred;
            }
            if (HttpContext.Current.User.Identity.Name == FakeMembershipProvider.FakeUserLisa.UserName && HttpContext.Current.User.IsInRole(LookUpRoles.OwnerRole))
            {
                return FakeMembershipProvider.FakeResetPasswordLisa;
            }
            if (HttpContext.Current.User.Identity.Name == FakeMembershipProvider.FakeUserMike.UserName && HttpContext.Current.User.IsInRole(LookUpRoles.AgentRole))
            {
                return FakeMembershipProvider.FakeResetPasswordMike;
            }
            if (HttpContext.Current.User.Identity.Name == FakeMembershipProvider.FakeUserSara.UserName && HttpContext.Current.User.IsInRole(LookUpRoles.SpecialistRole))
            {
                return FakeMembershipProvider.FakeResetPasswordSara;
            }
            if (HttpContext.Current.User.Identity.Name == FakeMembershipProvider.FakeUserJeff.UserName && HttpContext.Current.User.IsInRole(LookUpRoles.ProviderRole))
            {
                return FakeMembershipProvider.FakeResetPasswordJeff;
            }
            return strRet;
        }


        #endregion
    }

}
