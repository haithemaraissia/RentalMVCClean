using System;
using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Membership;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.PrivateProfile.Owner
{
    public class OwnerController : BaseController
    {
        #region OwnerHelper

        public OwnerController(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        public ViewResult Index()
        {
            var owner = UserHelper.OwnerPrivateProfileHelper.GetOwner();
            ViewBag.OwnerProfile = owner;
            ViewBag.OwnerId = owner.OwnerId;
            ViewBag.OwnerGoogleMap = owner.GoogleMap;
            return View(owner);
        }

        public ActionResult Edit(int id)
        {
            var owner = UserHelper.OwnerPrivateProfileHelper.GetPrivateProfileOwnerByOwnerId(id);
            return View(owner);
        }

        [HttpPost]
        public ActionResult Edit(Model.Models.Owner owner)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.OwnerRepository.Edit(owner);
                UnitofWork.Save();
                return RedirectToAction("Index");
            }
            return View(owner);
        }

        public ActionResult ChangeAddress(int id)
        {
            var owner = UserHelper.OwnerPrivateProfileHelper.GetPrivateProfileOwnerByOwnerId(id);
            return View(owner);
        }

        [HttpPost]
        public ActionResult ChangeAddress(Model.Models.Owner owner)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.OwnerRepository.Edit(owner);
                owner.GoogleMap = UserHelper.OwnerPrivateProfileHelper.OwnerGoogleMap();
                UnitofWork.Save();
                return RedirectToAction("Index");
            }
            return View(owner);
        }

        public ActionResult Delete(int id)
        {
            var owner = UserHelper.OwnerPrivateProfileHelper.GetPrivateProfileOwnerByOwnerId(id);
            return View(owner);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserHelper.OwnerPrivateProfileHelper.DeleteOwnerRecords(id);
            UserHelper.OwnerPrivateProfileHelper.DeleteOwnerMemebership();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UpdateProfilePicture(int id)
        {
            return RedirectToAction("Upload", "Account", new { id });
        }

        #endregion

        #region Unit
        public ActionResult ForwardUnittoFriend(string friendname, string friendemailaddress, string message, int id)
        {
            var email = UserHelper.OwnerPrivateProfileHelper.ComposeForwardUnitToFriendEmail(friendname, friendemailaddress, message, id);
            try
            {
                email.SendAsync();

            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Details", "Unit", new { id });

        }

        #endregion

        #region Application

        public ActionResult PendingApplication()
        {
            return View(UserHelper.OwnerPrivateProfileHelper.GetOwnerPendingApplication());
        }

        public ActionResult AcceptApplication(int id)
        {
            UserHelper.OwnerPrivateProfileHelper.OwnerAcceptApplicationByApplicationId(id);
            return RedirectToAction("PendingApplication");
        }

        public ActionResult RejectApplication(int id)
        {
            UserHelper.OwnerPrivateProfileHelper.OwnerRejectApplicationByApplicationId(id);
            return RedirectToAction("PendingApplication");
        }

        public ActionResult AcceptedApplication()
        {
            return View(UserHelper.OwnerPrivateProfileHelper.GetOwnerAcceptedApplication());
        }

        public ActionResult RejectedApplication()
        {
            return View(UserHelper.OwnerPrivateProfileHelper.GetOwnerRejectedApplication());
        }

        #endregion

        #region Contract

        //same as index to get the same look and fell
        public ViewResult GeneratedContract()
        {
            var owner = UserHelper.OwnerPrivateProfileHelper.GetOwner();
            ViewBag.OwnerProfile = owner;
            ViewBag.OwnerId = owner.OwnerId;
            ViewBag.OwnerGoogleMap = owner.GoogleMap;
            return View(owner);

        }

        public ViewResult GeneratedRentalAgreement()
        {
            return View(UserHelper.OwnerPrivateProfileHelper.GetOwnerGeneratedRentalContract());
        }

        public ViewResult UploadedAgreement()
        {
            return View(UserHelper.OwnerPrivateProfileHelper.GetUploadedOwnerRentalContract());
        }

        #endregion

        #region Showing

        public ActionResult ShowingSchedule()
        {
            return View();
        }

        public ActionResult NewShowingRequest(bool? requestshowing)
        {
            if (requestshowing == true)
            {
                ViewBag.ConfirmationRequest = true;
                ViewBag.ConfirmationScript = new JNotfiyScriptQueryHelper().JNotifyShowingAppointmentConfirmation();
            }
            return View(UserHelper.OwnerPrivateProfileHelper.GetOwnerPendingShowingCalendar());
        }

        public ActionResult ShowingRequestDeny(int id)
        {
            UserHelper.OwnerPrivateProfileHelper.OwnerDenyShowingRequest(id);
            return RedirectToAction("NewShowingRequest");
        }

        public ActionResult ShowingRequestConfirm(int id)
        {
            UserHelper.OwnerPrivateProfileHelper.OwnerAcceptApplicationByApplicationId(id);
            return RedirectToAction("NewShowingRequest", new { id, requestshowing = true });
        }

        public JsonResult GetOwnerCalendar()
        {
            return UserHelper.OwnerPrivateProfileHelper.GetOwnerCalendar();
        }

        #endregion

        #region RSS
        /// <summary>
        /// RSS FEED WITH RSS AND ATOM CONFIGURED
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public FileResult Syndicate(string format)
        {
            return UserHelper.OwnerPrivateProfileHelper.Syndicate(format);
        }
        #endregion

        #region TODO
        //TODO
        #region project
        //Still in Design Phase///
        // Project Same as Index

        //public ActionResult ActiveProject()
        //{
        //    var owner = UserHelper.OwnerPrivateProfileHelper.GetOwner();
        //    ViewBag.OwnerProfile = owner;
        //    ViewBag.OwnerId = owner.OwnerId;
        //    ViewBag.OwnerGoogleMap = owner.GoogleMap;
        //    return View(owner);
        //}

        //public ActionResult ViewActiveProject()
        //{
        //    var owner = UserHelper.OwnerPrivateProfileHelper.GetOwner();
        //    ViewBag.OwnerProfile = owner;
        //    ViewBag.OwnerId = owner.OwnerId;
        //    ViewBag.OwnerGoogleMap = owner.GoogleMap;
        //    return View(owner);
        //}

        //public ActionResult NewProject()
        //{
        //    var owner = UserHelper.OwnerPrivateProfileHelper.GetOwner();
        //    ViewBag.OwnerProfile = owner;
        //    ViewBag.OwnerId = owner.OwnerId;
        //    ViewBag.OwnerGoogleMap = owner.GoogleMap;
        //    return View(owner);
        //}

        //public ActionResult CreateNewProject()
        //{
        //    return View();
        //}

        //public ActionResult SavedProject()
        //{
        //    var owner = UserHelper.OwnerPrivateProfileHelper.GetOwner();
        //    ViewBag.OwnerProfile = owner;
        //    ViewBag.OwnerId = owner.OwnerId;
        //    ViewBag.OwnerGoogleMap = owner.GoogleMap;
        //    return View(owner);
        //}

        //public ActionResult EditSavedProject()
        //{
        //    var owner = UserHelper.OwnerPrivateProfileHelper.GetOwner();
        //    ViewBag.OwnerProfile = owner;
        //    ViewBag.OwnerId = owner.OwnerId;
        //    ViewBag.OwnerGoogleMap = owner.GoogleMap;
        //    return View(owner);
        //}

        //public ActionResult DeleteSavedProject()
        //{
        //    var owner = UserHelper.OwnerPrivateProfileHelper.GetOwner();
        //    ViewBag.OwnerProfile = owner;
        //    ViewBag.OwnerId = owner.OwnerId;
        //    ViewBag.OwnerGoogleMap = owner.GoogleMap;
        //    return View(owner);
        //}

        //public ActionResult ArchivedProject()
        //{
        //    var owner = UserHelper.OwnerPrivateProfileHelper.GetOwner();
        //    ViewBag.OwnerProfile = owner;
        //    ViewBag.OwnerId = owner.OwnerId;
        //    ViewBag.OwnerGoogleMap = owner.GoogleMap;
        //    return View(owner);
        //}

        //public ActionResult ViewArchivedProject()
        //{
        //    return View();
        //}

        //public ActionResult ViewArchivedProject(int id)
        //{
        //    return View();
        //}

        //public ActionResult DeleteArchivedProject()
        //{
        //    return View();
        //}

        //public ActionResult DeleteArchivedProject(int id)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult DeleteArchivedProject(int id)
        //{
        //    return View();
        //}



        //[HttpPost]
        //public ActionResult NewProject(UnitModelView u)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Units.Add(u.Unit);
        //            db.UnitPricings.Add(u.UnitPricing);
        //            db.UnitFeatures.Add(u.UnitFeature);
        //            db.UnitCommunityAmenities.Add(u.UnitCommunityAmenity);
        //            db.UnitAppliances.Add(u.UnitAppliance);
        //            db.UnitInteriorAmenities.Add(u.UnitInteriorAmenity);
        //            db.UnitExteriorAmenities.Add(u.UnitExteriorAmenity);
        //            db.UnitLuxuryAmenities.Add(u.UnitLuxuryAmenity);
        //            ViewBag.CurrencyCode = u.Unit.CurrencyCode;
        //            db.SaveChanges();
        //            //  SavePictures(u.Unit);
        //            return RedirectToAction("Index");
        //        }
        //        return View(u);
        //    }


        //    catch (DbEntityValidationException e)
        //    {
        //        foreach (var eve in e.EntityValidationErrors)
        //        {
        //            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
        //                              eve.Entry.Entity.GetType().Name, eve.Entry.State);
        //            foreach (var ve in eve.ValidationErrors)
        //            {
        //                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
        //                                  ve.PropertyName, ve.ErrorMessage);
        //            }
        //        }
        //        throw;
        //    }



        //}

        //public ActionResult ProjectPreview(int id, bool? shareproperty, bool? requestshowing)
        //{
        //    var u = new UnitModelView
        //    {
        //        Unit = db.Units.Find(id),
        //        UnitFeature = db.UnitFeatures.Find(id),
        //        UnitAppliance = db.UnitAppliances.Find(id),
        //        UnitCommunityAmenity = db.UnitCommunityAmenities.Find(id),
        //        UnitPricing = db.UnitPricings.Find(id),
        //        UnitInteriorAmenity = db.UnitInteriorAmenities.Find(id),
        //        UnitExteriorAmenity = db.UnitExteriorAmenities.Find(id),
        //        UnitLuxuryAmenity = db.UnitLuxuryAmenities.Find(id)
        //    };

        //    if (Request.Url != null)
        //    {
        //        var url = Request.Url.AbsoluteUri.ToString(CultureInfo.InvariantCulture);
        //        var primaryimagethumbnail = UserHelper.ResolveImageUrl(u.Unit.PrimaryPhoto);
        //        string title;
        //        if (String.IsNullOrEmpty(u.Unit.Title))
        //        {
        //            title = (u.Unit.Address + " , " + u.Unit.State + " , " + u.Unit.City);
        //            if (title.Length >= 50)
        //            {
        //                title = title.Substring(0, 50);
        //            }
        //        }
        //        else
        //        {
        //            title = u.Unit.Title;
        //            if (u.Unit.Title.Length >= 50)
        //            {
        //                title = u.Unit.Title.Substring(0, 50);
        //            }
        //        }

        //        var summary = u.Unit.Description;
        //        if (!String.IsNullOrEmpty(summary))
        //        {
        //            if (summary.Length >= 140)
        //            {
        //                summary = summary.Substring(0, 140);
        //            }
        //        }

        //        var unitrentprice = u.UnitPricing.Rent == null
        //                                ? ""
        //                                : u.UnitPricing.Rent.Value.ToString(CultureInfo.InvariantCulture) + " ";
        //        unitrentprice += UserHelper.GetCurrencyValue(u.Unit.CurrencyCode);
        //        var tweet = u.Unit.Title + ": " + unitrentprice + "--" + url;
        //        if (!String.IsNullOrEmpty(tweet))
        //        {
        //            if (tweet.Length >= 140)
        //            {
        //                tweet = tweet.Substring(0, 140);
        //            }
        //        }

        //        const string sitename = "http://www.haithem-araissia.com";
        //        ViewBag.FaceBook = SocialHelper.FacebookShare(url, primaryimagethumbnail, title, summary);
        //        ViewBag.Twitter = SocialHelper.TwitterShare(tweet);
        //        ViewBag.GooglePlusShare = SocialHelper.GooglePlusShare(url);
        //        ViewBag.LinkedIn = SocialHelper.LinkedInShare(url, title, summary, sitename);
        //    }

        //    ViewBag.UnitGoogleMap = string.IsNullOrEmpty(u.Unit.Address)
        //                                ? UserHelper.GetFormattedLocation("", "", "USA")
        //                                : UserHelper.GetFormattedLocation(u.Unit.Address, u.Unit.City, "US");
        //    var poster = UserHelper.GetPoster(id) ?? UserHelper.DefaultPoster;
        //    ViewBag.PosterFirstName = poster.FirstName;
        //    ViewBag.PosterLastName = poster.LastName;
        //    ViewBag.PosterPictureProfile = poster.ProfilePicturePath;
        //    ViewBag.PosterProfileLink = poster.ProfileLink;


        //    if (shareproperty != null && shareproperty == true)
        //    {
        //        ViewBag.EmailSharedwithFriend = true;
        //        ViewBag.EmailSucessSharedwithFriend =  new JNotfiyScriptQueryHelper().JNotifyConfirmationSharingEmail();
        //    }

        //    return View(u);
        //}

        #endregion

        #region Unit Picture
        //TODO REDO IT CLEANER
        //private readonly RentalContext _db = new RentalContext();

        ////MAKE SURE THAT USER ARE AUTHENTICATED
        //public string Username = Membership.GetUser(System.Web.HttpContext.Current.User.Identity.Name).ToString();
        ////MAKE SURE THAT USER ARE AUTHENTICATED

        //public string TenantPhotoPath = "~/Photo/Tenant/Property";
        //public string OwnerPhotoPath = "~/Photo/Owner/Property";
        //public string AgentPhotoPath = "~/Photo/Agent/Property";
        //public string ProviderPhotoPath = "~/Photo/Provider/Property";
        //public string SpecialistPhotoPath = "~/Photo/Specialist/Property";
        //public string RequestId;
        //public string PhotoPath;


        //public ActionResult Partial2(UnitModelView unitModelView)
        //{



        //    if (role == "Tenant")
        //    {
        //        ViewBag.Id = UserHelper.GetTenantId();
        //        ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
        //        ViewBag.Type = "Property";
        //        TempData["UserID"] = UserHelper.GetTenantId();
        //    }

        //    if (role == "Owner")
        //    {
        //        ViewBag.Id = UserHelper.GetOwnerId();
        //        ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
        //        ViewBag.Type = "Property";
        //        TempData["UserID"] = UserHelper.GetOwnerId();
        //    }

        //    if (role == "Agent")
        //    {
        //        ViewBag.Id = UserHelper.GetAgentId();
        //        ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
        //        ViewBag.Type = "Property";
        //        TempData["UserID"] = UserHelper.GetAgentId();
        //    }

        //    if (role == "Specialist")
        //    {
        //        ViewBag.Id = UserHelper.GetSpecialistId();
        //        ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
        //        ViewBag.Type = "Property";
        //        TempData["UserID"] = UserHelper.GetSpecialistId();
        //    }
        //    if (role == "Provider")
        //    {
        //        ViewBag.Id = UserHelper.GetProviderId();
        //        ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
        //        ViewBag.Type = "Property";
        //        TempData["UserID"] = UserHelper.GetProviderId();
        //    }



        //    //RequestID = "5";
        //    //ViewBag.UserName = "Test";
        //    //ViewBag.Id = "10";
        //    //ViewBag.Type = "Requests";
        //    //TempData["Id"] = "5";

        //    // SavePictures(unitModelView.Unit);
        //    //ViewBag.Sript = FancyBox.Fancy(unitModelView.Unit.UnitId);
        //    return PartialView("_Partial2", unitModelView.UnitGallery);
        //    }





        //}
        #endregion

        #endregion
    }
}


