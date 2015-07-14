using System;
using System.Web.Mvc;
using System.Web.Security;
using RentalMobile.Helpers.Account;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Email;
using RentalMobile.Helpers.JQuery.JNotify;
using RentalMobile.Helpers.Membership;
using RentalMobile.Helpers.Roles;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.PrivateProfile.Common
{
    public class AccountController : BaseController
    {
        public readonly AccountHelper AccountHelper;
        
        public AccountController(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper ,IEmailService emailService)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
            EmailService = emailService;
            AccountHelper = new AccountHelper(uow, membershipService, userHelper, emailService);
        }

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);

            if (MembershipService.ValidateUser(model.UserName, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                if (Roles.IsUserInRole(model.UserName, "Tenant"))
                {
                    return RedirectToAction("Index", "Tenant");
                }
                if (Roles.IsUserInRole(model.UserName, "Owner"))
                {
                    return RedirectToAction("Index", "Owner");
                }
                if (Roles.IsUserInRole(model.UserName, "Agent"))
                {
                    return RedirectToAction("Index", "Agent");
                }
                if (Roles.IsUserInRole(model.UserName, "Specialist"))
                {
                    return RedirectToAction("Index", "Specialist");
                }
                if (Roles.IsUserInRole(model.UserName, "Provider"))
                {
                    return RedirectToAction("Index", "Provider");
                }
            }
            else
            {
                ModelState.AddModelError("", @"The user name or password provided is incorrect.");
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid) return View(model);
            MembershipCreateStatus createStatus;
            MembershipService.CreateUser(model.UserName, model.Password, model.Email, null, null, true, null,
                out createStatus);
            if (createStatus == MembershipCreateStatus.Success)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                Roles.AddUserToRole(model.UserName, model.Role);
                AccountHelper.RegisterAccountByType(model);
                return RedirectToAction("Index", model.Role);
            }
            ModelState.AddModelError("", new ErrorCode().ErrorCodeToString(createStatus));
            return View(model);
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var changePasswordSucceeded = false;
            try
            {
                var currentUser = MembershipService.GetUser(User.Identity.Name, true /* userIsOnline */);
                if (currentUser != null)
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
            }
            catch (Exception)
            {
                changePasswordSucceeded = false;
            }

            if (changePasswordSucceeded)
            {
                return RedirectToAction("ChangePasswordSuccess");
            }
            ModelState.AddModelError("", @"The current password is incorrect or the new password is invalid.");
            return View(model);
        }

        [Authorize]
        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        [Authorize]
        public ActionResult ChangeEmail()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangeEmail(ChangeEmail model)
        {
            if (!ModelState.IsValid) return View(model);
            var changeEmailSucceeded = true;
            try
            {
                var u = MembershipService.GetUser(User.Identity.Name);
                if (u != null)
                {
                    u.Email = model.Email;
                    MembershipService.UpdateUser(u);
                }
                AccountHelper.ChangeEmailByType(model);
            }
            catch (Exception)
            {
                changeEmailSucceeded = false;
            }

            if (changeEmailSucceeded)
            {
                return RedirectToAction("ChangeEmailSuccess");
            }
            ModelState.AddModelError("", @"The email address is incorrect.");
            return View(model);
        }

        [Authorize]
        public ActionResult ChangeEmailSuccess()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var userName = MembershipService.GetUserNameByEmail(model.Email);

                if (userName != null)
                {
                    var currentUser = MembershipService.GetUser(userName);

                    if (currentUser != null && model.Email.ToLower() == currentUser.Email.ToLower())
                    {
                        AccountHelper.SendResetEmail(currentUser);

                        return RedirectToAction("ResetPasswordSuccess", "Account");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, @"The email address entered does not exist.");
                }

            }
            return View();
        }

        public ActionResult ResetPasswordSuccess()
        {
            return View();
        }

        [Authorize]
        public ActionResult Upload(int id)
        {
            var role = UserHelper.GetCurrentRole();
            if (role == "Tenant")
            {
                ViewBag.Id = UserHelper.GetTenantId();
                ViewBag.UserName = UserHelper.GetUserName();
                ViewBag.Type = "Profile";
                TempData["UserID"] = UserHelper.GetTenantId();
            }

            if (role == "Owner")
            {
                ViewBag.Id = UserHelper.GetOwnerId();
                ViewBag.UserName = UserHelper.GetUserName();
                ViewBag.Type = "Profile";
                TempData["UserID"] = UserHelper.GetOwnerId();
            }

            if (role == "Agent")
            {
                ViewBag.Id = UserHelper.GetAgentId();
                ViewBag.UserName = UserHelper.GetUserName();
                ViewBag.Type = "Profile";
                TempData["UserID"] = UserHelper.GetAgentId();
            }

            if (role == "Specialist")
            {
                ViewBag.Id = UserHelper.GetSpecialistId();
                ViewBag.UserName = UserHelper.GetUserName();
                ViewBag.Type = "Profile";
                TempData["UserID"] = UserHelper.GetSpecialistId();
            }
            if (role == "Provider")
            {
                ViewBag.Id = UserHelper.GetProviderId();
                ViewBag.UserName = UserHelper.GetUserName();
                ViewBag.Type = "Profile";
                TempData["UserID"] = UserHelper.GetProviderId();
            }

            return View();
        }

        [Authorize]
        public ActionResult UpdateProfilePhoto(int id)
        {
            AccountHelper.SaveProfilePhoto(id);
            var user = UserHelper.GetCurrentRole();
            switch (user)
            {
                case LookUpRoles.TenantRole:
                    return RedirectToAction("Index", LookUpRoles.TenantRole);
                case LookUpRoles.OwnerRole:
                    return RedirectToAction("Index", LookUpRoles.OwnerRole);
                case LookUpRoles.AgentRole:
                    return RedirectToAction("Index", LookUpRoles.AgentRole);
                case LookUpRoles.ProviderRole:
                    return RedirectToAction("Index", LookUpRoles.ProviderRole);
            }
            return user == LookUpRoles.SpecialistRole ? RedirectToAction("Index", LookUpRoles.SpecialistRole) : null;
        }

        [Authorize]
        public ActionResult UpdateVideo(bool? updatevideo)
        {
            var primaryVideoModel = new PrimaryVideo
                {
                    VimeoVideo = false,
                    VimeoVideoUrl = "",
                    YouTubeVideo = false,
                    YouTubeVideoUrl = ""
                };
           primaryVideoModel = AccountHelper.LoadVideoByAccountType(primaryVideoModel);
            if (updatevideo != null && updatevideo == true)
            {
                ViewBag.UpdateVideo = true;
                ViewBag.UpdateVideoSuccess = new JNotfiyScriptQueryHelper().JNotifyConfirmationUpdatingVideo();
            }
            return View(primaryVideoModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateVideo(PrimaryVideo primaryVideo)
        {
            if (ModelState.IsValid)
            {
                var updateVideoSucceeded = true;
                try
                {
                    AccountHelper.UpdateVideoByAccountType(primaryVideo);
                }
                catch (Exception)
                {
                    updateVideoSucceeded = false;
                }

                if (updateVideoSucceeded)
                {
                    return RedirectToAction("UpdateVideo", new { updatevideo = true });

                }
                ModelState.AddModelError("", @"The video url is incorrect.");
                return RedirectToAction("UpdateVideo");
            }
            ModelState.AddModelError("", @"The video url is incorrect.");
            return RedirectToAction("UpdateVideo");
        }

    }
}
