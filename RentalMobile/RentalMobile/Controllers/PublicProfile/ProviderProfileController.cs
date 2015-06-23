using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Security.Application;
using RentalMobile.Helpers;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.JQuery;
using RentalMobile.Helpers.JQuery.JNotify;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.PublicProfile
{
    public class ProviderProfileController : BaseController
    {
     
        public ProviderProfileController(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        public ActionResult Index(int? id, bool? shareprovider, bool? insertingnewcomment)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Providers");
            }
            var provider = UserHelper.GetPublicProfileProviderByProviderId((int)id);
            ViewBag.ProviderProfile = provider;
            var visitor = UserHelper.ProviderPublicProfileHelper.GetProviderProfileViewVisitorProperties();
            if (visitor != null)
            {
                ViewBag.VisitorEmail = visitor.EmailAddress;
                ViewBag.VisitorName = visitor.Name;
            }
            if (provider != null)
            {
                ViewBag.providerId = provider.MaintenanceProviderId;
                ViewBag.providerGoogleMap = provider.GoogleMap;
                ViewBag.Title = provider.FirstName + " " + provider.LastName + " Profile";
                ViewBag.CommentCount = UserHelper.ProviderPublicProfileHelper.GetProviderCommentCount((int)id);
                ViewBag.Sript = FancyBox.FancyProvider((int)id);
                ViewBag.providerPrimaryPhoto = UserHelper.ProviderPublicProfileHelper.GetProviderPrimaryWorkPhoto((int)id);
                UserHelper.ProviderPublicProfileHelper.ShareProvider(provider); 
                if (shareprovider != null && shareprovider == true)
                {
                    ViewBag.EmailSharedwithFriend = true;
                    ViewBag.EmailSucessSharedwithFriend = new JNotfiyScriptQueryHelper().JNotifyConfirmationSharingEmail();
                }
                if (insertingnewcomment != null && insertingnewcomment == true)
                {
                    ViewBag.InsertNewComment = true;
                    ViewBag.InsertNewCommentSuccess = new JNotfiyScriptQueryHelper().JNotifyConfirmationSuccessComment();
                }

                #region TODO
                //TODO
                //For Advertisement
                //TODO MORE WORK NEED TO BE DONE
                ViewBag.MiddleBannerKeywordFilter = Advertisement.MiddleBanner("11", "2");
                //   // For Advertisement
                #endregion

                return View(provider);
            }
            return RedirectToAction("Index", "Providers");
        }

        public PartialViewResult _Coverage(int id)
        {
            if (id != 0)
            {
                const int providerrole = 2;
                var lookUp =
                    UnitofWork.MaintenanceCompanyLookUpRepository.FindBy(x => x.Role == providerrole && x.UserId == id).FirstOrDefault();
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    var mp = new ProviderMaintenanceProfile
                    {
                        MaintenanceCompanyLookUp = UnitofWork.MaintenanceCompanyLookUpRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault(),
                        MaintenanceCompany = UnitofWork.MaintenanceCompanyRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault(),
                        MaintenanceCompanySpecialization = UnitofWork.MaintenanceCompanySpecializationRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault(),
                        MaintenanceCustomService = UnitofWork.MaintenanceCustomServiceRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault(),
                        MaintenanceExterior = UnitofWork.MaintenanceExteriorRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault(),
                        MaintenanceInterior = UnitofWork.MaintenanceInteriorRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault(),
                        MaintenanceNewConstruction = UnitofWork.MaintenanceNewConstructionRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault(),
                        MaintenanceRepair = UnitofWork.MaintenanceRepairRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault(),
                        MaintenanceUtility = UnitofWork.MaintenanceUtilityRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault()
                    };
                    return PartialView(mp);
                }
            }
            return null;
        }

        public PartialViewResult _Description(int id)
        {
            if (id != 0)
            {
                const int providerrole = 2;
                var lookUp =
                   UnitofWork.MaintenanceCompanyLookUpRepository.FindBy(x => x.Role == providerrole && x.UserId == id).FirstOrDefault();
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;
                    var mcs = UnitofWork.MaintenanceCompanySpecializationRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault();
                    if (mcs != null)
                    {
                        ViewBag.Rate = mcs.Rate;
                        ViewBag.YearsofExperience = mcs.Years_Experience;
                        var currency = UnitofWork.CurrencyRepository.FindBy(x => x.CurrencyID == mcs.CurrencyID).FirstOrDefault();
                        if (currency != null)
                            ViewBag.Currency = currency.CurrencyValue;
                    }

                    var currentprovider = UnitofWork.MaintenanceProviderRepository.FirstOrDefault(x => x.MaintenanceProviderId == id);
                    return PartialView(currentprovider);
                }
            }
            return PartialView(null);
        }

        public PartialViewResult _Team(int id)
        {
            ViewBag.TeamName = UserHelper.ProviderPublicProfileHelper.TeamName(id);
            return PartialView(UserHelper.ProviderPublicProfileHelper.GetTeamByProviderId(id));
        }

        public ActionResult ForwardtoFriend(string friendname, string friendemailaddress, string message, int id)
        {
            var email = UserHelper.ProviderPublicProfileHelper.ProviderPublicComposeForwardToFriendEmail(friendname, friendemailaddress, message, id);
            try
            {
                email.SendAsync();

            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { id, shareprovider = false });
            }
            return RedirectToAction("Index", new { id, shareprovider = true });
        }

        public PartialViewResult _Comment(int id)
        {
            ViewBag.providerId = id;
            if (id == 0) return null;
            ViewBag.CommentCount = UserHelper.ProviderPublicProfileHelper.GetProviderCommentCount(id);
           return PartialView(UnitofWork.ProviderProfileCommentRepository.FindBy(x => x.ProviderId == id).ToList());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult InsertComment(int? id, string comment)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "ProviderProfile");
            }
            var poster = UserHelper.GetSendtoFriendPoster(HttpContext.Request.Url) ?? UserHelper.PosterHelper.DefaultPoster;
            if (ModelState.IsValid)
            {
                var providerComment = new ProviderProfileComment
                {
                    Comment = Sanitizer.GetSafeHtmlFragment(comment),
                    CommentDate = DateTime.UtcNow,
                    PosterId = poster.PosterId,
                    PosterName = poster.FirstName + " , " + poster.LastName,
                    PosterPhotoPath = poster.ProfilePicturePath,
                    PosterProfileLink = poster.ProfileLink,
                    PosterRole = UserHelper.GetRoleId(poster.Role),
                    ProviderId = id
                };
                UnitofWork.ProviderProfileCommentRepository.Add(providerComment);
                UnitofWork.Save();
            }
            return RedirectToAction("Index", new { id, insertingnewcomment = true });
        }

        //* TODO Complete it */
        //Actually hiring for Professional which should map to new job
        public ActionResult HireProvider(int id, string enctype)
        {
            return JavaScript("This should be the hiring procedure");
        }

    }
}
