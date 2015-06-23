using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Security.Application;
using Postal;
using RentalMobile.Helpers;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Identity.Base;
using RentalMobile.Helpers.JQuery;
using RentalMobile.Helpers.JQuery.JNotify;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.PublicProfile
{
    public class SpecialistProfileController : BaseController
    {
        public SpecialistProfileController(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        public ActionResult Index(int? id, bool? sharespecialist, bool? insertingnewcomment)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Specialists");
            }
            var specialist = UserHelper.SpecialistPublicProfileHelper.GetPublicProfileSpecialistBySpecialistId((int)id);
            ViewBag.SpecialistProfile = specialist;
            var visitor = UserHelper.SpecialistPublicProfileHelper.GetSpecialistProfileViewVisitorProperties();
            if (visitor != null)
            {
             ViewBag.VisitorEmail = visitor.EmailAddress;
             ViewBag.VisitorName = visitor.Name; 
            }
            if (specialist != null)
            {
                ViewBag.SpecialistId = specialist.SpecialistId;
                ViewBag.SpecialistGoogleMap = specialist.GoogleMap;
                ViewBag.Title = specialist.FirstName + " " + specialist.LastName + " Profile";
                ViewBag.CommentCount = UserHelper.SpecialistPublicProfileHelper.GetSpecialistCommentCount((int)id);
                ViewBag.Sript = FancyBox.FancySpecialist((int)id);
                ViewBag.SpecialistPrimaryPhoto = UserHelper.SpecialistPublicProfileHelper.GetSpecialistPrimaryWorkPhoto((int)id);
                var socialLinks =  UserHelper.SpecialistPublicProfileHelper.ShareSpecialist(specialist);
                if (socialLinks != null)
                {
                    ViewBag.FaceBook = socialLinks.FaceBook;
                    ViewBag.Twitter = socialLinks.Twitter;
                    ViewBag.GooglePlusShare = socialLinks.GooglePlusShare;
                    ViewBag.LinkedIn = socialLinks.LinkedIn;
                }
                if (sharespecialist != null && sharespecialist == true)
                {
                    ViewBag.EmailSharedwithFriend = true;
                    ViewBag.EmailSucessSharedwithFriend = new JNotfiyScriptQueryHelper().JNotifyConfirmationSharingEmail();
                }
                if (insertingnewcomment != null && insertingnewcomment == true)
                {
                    ViewBag.InsertNewComment = true;
                    ViewBag.InsertNewCommentSuccess = new JNotfiyScriptQueryHelper().JNotifyConfirmationSuccessComment();
                }
                return View(specialist);
            }
            return RedirectToAction("Index", "Specialists");
        }


        public PartialViewResult _Coverage(int id)
        {
            if (id != 0)
            {
                const int specialistrole = 1;
                var lookUp =
                    UnitofWork.MaintenanceCompanyLookUpRepository.FindBy(x => x.Role == specialistrole && x.UserId == id).FirstOrDefault();
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    var mp = new SpecialistMaintenanceProfile
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
                const int specialistrole = 1;
                var lookUp =
                   UnitofWork.MaintenanceCompanyLookUpRepository.FindBy(x => x.Role == specialistrole && x.UserId == id).FirstOrDefault();
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

                    var currentspecialist = UnitofWork.SpecialistRepository.FindBy(x => x.SpecialistId == id).FirstOrDefault();
                    return PartialView(currentspecialist);
                }
            }
            return null;
        }

        public ActionResult ForwardtoFriend(string friendname, string friendemailaddress, string message, int id)
        {
            //var email = UserHelper.SpecialistPublicProfileHelper.SpecialPublicProfileComposeForwardToFriendEmail(friendname, friendemailaddress, message, id);
            dynamic email = new Postal.Email("ForwardtoFriend/Multipart");
            var newposter = new PosterHelper(UnitofWork, MembershipService);
            var poster = newposter.GetSendtoFriendPoster(HttpContext.Request.Url);
            email.To = friendemailaddress;
            email.FriendName = friendname;
            email.From = "postmaster@haithem-araissia.com";
            email.SenderFirstName = poster.FirstName;
            email.Title = string.Format("Request From {0}", poster.FirstName);
            email.SubTitle = "Request from ";
            email.Message = message;
            email.InvitationNote = " invite you to see this skilled professional.";
            email.FooterNote = "Check out this Professional";
            var uri = HttpContext.Request.Url;
            if (uri != null)
            {
                var host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
                email.ProfileUrl = host + uri.AbsolutePath.Replace("ForwardtoFriend", "");
                var currentSpecialist = UserHelper.SpecialistPublicProfileHelper.GetPublicProfileSpecialistBySpecialistId(id);
                if (currentSpecialist != null)
                {
                    var specialistTitle = currentSpecialist.FirstName + " , " + currentSpecialist.LastName;
                    if (specialistTitle.Length >= 50)
                    {
                        specialistTitle = specialistTitle.Substring(0, 50);
                    }
                    email.CustomTitle = specialistTitle;
                }
                if (currentSpecialist != null)
                {
                    email.PhotoPath = host + "/" + UserHelper.SpecialistPublicProfileHelper.GetSpecialistPrimaryWorkPhoto(id).Replace("../../", "");
                }
            }
            
            try
            {
               // ViewBag.Email = email;
                ((Postal.Email) email).SendAsync();

               // EmailService.Send(email);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { id, sharespecialist = false });
            }
            return RedirectToAction("Index", new { id, sharespecialist = true });

        }


        public PartialViewResult _Comment(int id)
        {
            ViewBag.SpecialistId = id;
            if (id == 0) return null;
            ViewBag.CommentCount = UserHelper.SpecialistPublicProfileHelper.GetSpecialistCommentCount(id);
            return PartialView(UnitofWork.SpecialistProfileCommentRepository.FindBy(x => x.SpecialistId == id).ToList());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult InsertComment(int? id, string comment)
        { 
            if (id == null)
            {
                return RedirectToAction("Index", "Specialists");
            }
            PosterHelper tempQualifier = UserHelper.PosterHelper;
            var poster = UserHelper.PosterHelper.GetSendtoFriendPoster(tempQualifier.HttpContext.Request.Url) ?? UserHelper.PosterHelper.DefaultPoster;
            if (ModelState.IsValid)
            {
                var specialistComment = new SpecialistProfileComment
                    {
                        Comment = Sanitizer.GetSafeHtmlFragment(comment),
                        CommentDate = DateTime.UtcNow,
                        PosterId = poster.PosterId,
                        PosterName = poster.FirstName + " , " + poster.LastName,
                        PosterPhotoPath = poster.ProfilePicturePath,
                        PosterProfileLink = poster.ProfileLink,
                        PosterRole = UserHelper.GetRoleId(poster.Role),
                        SpecialistId = id
                    };
                UnitofWork.SpecialistProfileCommentRepository.Add(specialistComment);
                UnitofWork.Save();
            }
            return RedirectToAction("Index", new { id, insertingnewcomment = true });
        }

        //* TODO Complete it /
        //Actually hiring for Professional which should map to new job
        public ActionResult HireProfessional(int id, string enctype)
        {
            return JavaScript("This should be the hiring procedure");
        }

    }
}