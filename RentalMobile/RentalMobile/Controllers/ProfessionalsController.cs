using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Security.Application;
using RentalMobile.Helpers;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Generic.UnitofWork;
using Email = Postal.Email;

namespace RentalMobile.Controllers
{
    public class ProfessionalsController : Controller
    {
        private readonly UnitofWork _unitOfWork;
        public ProfessionalsController(UnitofWork uow)
        {
            _unitOfWork = uow;
        }

        public ActionResult Index(int? id, bool? sharespecialist, bool? insertingnewcomment)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Specialists");
            }
            var specialist = _unitOfWork.SpecialistRepository.FindBy(x => x.SpecialistId == UserHelper.GetSpecialistId((int)id)).FirstOrDefault();
            ViewBag.SpecialistProfile = specialist;
            if (specialist != null)
            {
                ViewBag.SpecialistId = specialist.SpecialistId;
                ViewBag.SpecialistGoogleMap = specialist.GoogleMap;
                ViewBag.Title = specialist.FirstName + " " + specialist.LastName + " Profile";
                ViewBag.CommentCount = GetCommentCount((int)id);
                ViewBag.Sript = FancyBox.FancySpecialist((int)id);
                ViewBag.SpecialistPrimaryPhoto = GetSpecialistPrimaryWorkPhoto((int)id);
                ShareSpecialist(specialist);
                if (sharespecialist != null && sharespecialist == true)
                {
                    ViewBag.EmailSharedwithFriend = true;
                    ViewBag.EmailSucessSharedwithFriend = JNotfiyScriptQueryHelper.JNotifyConfirmationSharingEmail();
                }
                if (insertingnewcomment != null && insertingnewcomment == true)
                {
                    ViewBag.InsertNewComment = true;
                    ViewBag.InsertNewCommentSuccess = JNotfiyScriptQueryHelper.JNotifyConfirmationSuccessComment();
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
                    _unitOfWork.MaintenanceCompanyLookUpRepository.FindBy(x => x.Role == specialistrole && x.UserId == id).FirstOrDefault();
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    var mp = new SpecialistMaintenanceProfile
                    {
                        MaintenanceCompanyLookUp = _unitOfWork.MaintenanceCompanyLookUpRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault(),
                        MaintenanceCompany = _unitOfWork.MaintenanceCompanyRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault(),
                        MaintenanceCompanySpecialization = _unitOfWork.MaintenanceCompanySpecializationRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault(),
                        MaintenanceCustomService = _unitOfWork.MaintenanceCustomServiceRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault(),
                        MaintenanceExterior = _unitOfWork.MaintenanceExteriorRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault(),
                        MaintenanceInterior = _unitOfWork.MaintenanceInteriorRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault(),
                        MaintenanceNewConstruction = _unitOfWork.MaintenanceNewConstructionRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault(),
                        MaintenanceRepair = _unitOfWork.MaintenanceRepairRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault(),
                        MaintenanceUtility = _unitOfWork.MaintenanceUtilityRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault()
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
                   _unitOfWork.MaintenanceCompanyLookUpRepository.FindBy(x => x.Role == specialistrole && x.UserId == id).FirstOrDefault();
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;
                    var mcs = _unitOfWork.MaintenanceCompanySpecializationRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault();
                    if (mcs != null)
                    {
                        ViewBag.Rate = mcs.Rate;
                        ViewBag.YearsofExperience = mcs.Years_Experience;
                        var currency = _unitOfWork.CurrencyRepository.FindBy(x => x.CurrencyID == mcs.CurrencyID).FirstOrDefault();
                        if (currency != null)
                            ViewBag.Currency = currency.CurrencyValue;
                    }

                    var currentspecialist = _unitOfWork.SpecialistRepository.FindBy(x => x.SpecialistId == id).FirstOrDefault();
                    return PartialView(currentspecialist);
                }
            }
            return null;
        }

        public void ShareSpecialist(Specialist s)
        {
            if (Request == null || Request.Url == null) return;
            var url = Request.Url.AbsoluteUri.ToString(CultureInfo.InvariantCulture);
            var title = SocialTitleBuilding(s);
            var summary = s.Description;
            if (!String.IsNullOrEmpty(summary))
            {
                if (summary.Length >= 140)
                {
                    summary = summary.Substring(0, 140);
                }
            }
            var tweet = title;
            if (tweet != null && title.Length >= 1)
            {
                tweet += "--";
            }
            tweet += url;
            if (!String.IsNullOrEmpty(tweet))
            {
                if (tweet.Length >= 140)
                {
                    tweet = tweet.Substring(0, 140);
                }
            }

            //TODO UPDATE BEFORE RELEASE
            const string sitename = "http://www.haithem-araissia.com";
            //This is the correct one for production because facebook require active url present. after you Register your domain
            //ViewBag.FaceBook = SocialHelper.FacebookShareOnlyUrl(url);
            //TOD UPDATE BEFORE RELEASE
            ViewBag.FaceBook = SocialHelper.FacebookShareOnlyUrl(sitename);

            ViewBag.Twitter = SocialHelper.TwitterShare(tweet);
            ViewBag.GooglePlusShare = SocialHelper.GooglePlusShare(url);
            ViewBag.LinkedIn = SocialHelper.LinkedInShare(url, title, summary, sitename);
        }

        public string SocialTitleBuilding(Specialist s)
        {
            var title = s.FirstName;
            if (title != null)
            {
                title += " , ";
            }

            title += s.LastName;
            if (title.Length >= 1)
            {
                title += " , ";
            }

            title += s.Address;
            if (title.Length >= 1)
            {
                title += " , ";
            }

            title += s.Region;
            if (title.Length >= 1)
            {
                title += " , ";
            }
            title += s.City;
            if (title.Length >= 1)
            {
                title += " , ";
            }

            if (title.Length >= 50)
            {
                title = title.Substring(0, 50);
            }
            return title;
        }

        public ActionResult ForwardtoFriend(string friendname, string friendemailaddress, string message, int id)
        {
            dynamic email = new Email("ForwardtoFriend/Multipart");
            var poster = UserHelper.GetSendtoFriendPoster() ?? UserHelper.DefaultPoster;
            email.To = friendemailaddress;
            email.FriendName = friendname;
            email.From = "postmaster@haithem-araissia.com";
            email.SenderFirstName = poster.FirstName;
            email.Title = string.Format("Request From {0}", poster.FirstName);
            email.SubTitle = "Request from ";
            email.Message = message;
            email.InvitationNote = " invite you to see this skilled professional.";
            email.FooterNote = "Check out this Professional";
            var uri = Request.Url;
            if (uri != null)
            {
                var host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
                email.ProfileUrl = host + uri.AbsolutePath.Replace("ForwardtoFriend", "");
                var currentSpecialist = _unitOfWork.SpecialistRepository.FindBy(x => x.SpecialistId == id).FirstOrDefault();
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
                    email.PhotoPath = host + "/" + GetSpecialistPrimaryWorkPhoto(id).Replace("../../", "");

                }
            }
            try
            {
                email.SendAsync();

            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { id, sharespecialist = false });
            }
            return RedirectToAction("Index", new { id, sharespecialist = true });

        }

        public PartialViewResult _Comment(int id)
        {
            ViewBag.SpecialistId = id;
            if (id != 0)
            {

                ViewBag.CommentCount = GetCommentCount(id);
                return PartialView(_unitOfWork.SpecialistProfileCommentRepository.FindBy(x => x.SpecialistId == id).ToList());
            }
            return null;
        }

        public string GetCommentCount(int id)
        {
            if (id != 0)
            {
                var specialistPublicProfileComment =
                    _unitOfWork.SpecialistProfileCommentRepository.FindBy(x => x.SpecialistId == id).ToList();
                return specialistPublicProfileComment.Any() ? "( " + specialistPublicProfileComment.Count() + " )" : "";
            }
            return "";
        }

        public string GetSpecialistPrimaryWorkPhoto(int id)
        {
            var specialistwork = _unitOfWork.SpecialistWorkRepository.FindBy(x => x.SpecialistId == id).FirstOrDefault();
            return (specialistwork == null || specialistwork.PhotoPath == null) ? "./../images/dotimages/home-handyman-projects.jpg" : specialistwork.PhotoPath;
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult InsertComment(int? id, string comment)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Specialists");
            }
            var poster = UserHelper.GetSendtoFriendPoster() ?? UserHelper.DefaultPoster;
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
                _unitOfWork.SpecialistProfileCommentRepository.Add(specialistComment);
                _unitOfWork.Save();
            }
            return RedirectToAction("Index", new { id, insertingnewcomment = true });
        }
















        //* TODO Complete it */
        //Actually hiring for Professional which should map to new job
        public ActionResult HireProfessional(int id, string enctype)
        {
            return JavaScript("This should be the hiring procedure");
        }

    }
}