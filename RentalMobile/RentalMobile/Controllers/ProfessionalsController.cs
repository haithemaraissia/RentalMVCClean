using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalMobile.ModelViews;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{ 
    public class ProfessionalsController : Controller
    {
        private readonly DB_33736_rentalEntities _db = new DB_33736_rentalEntities();

        public ActionResult Index(int? id, bool? sharespecialist)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Specialists");
            }
            var specialist = _db.Specialists.Find(UserHelper.GetSpecialistID((int) id));
            ViewBag.SpecialistProfile = specialist;
            ViewBag.SpecialistId = specialist.SpecialistId;
            ViewBag.SpecialistGoogleMap = specialist.GoogleMap;
            ViewBag.Title = specialist.FirstName + " " + specialist.LastName + " Profile";
            ViewBag.Sript = FancyBox.FancySpecialist((int) id);
            ViewBag.SpecialistPrimaryPhoto = GetSpecialistPrimaryPhoto((int)id);
            ShareSpecialist(specialist);




            if (sharespecialist != null && sharespecialist == true)
            {
                ViewBag.EmailSharedwithFriend = true;
                ViewBag.EmailSucessSharedwithFriend = JNotifyConfirmationSharingEmail();
            }
            return View(specialist);
        }


        public PartialViewResult _Coverage(int id)
        {

            if (id != 0)
            {
                const int specialistrole = 1;
                var lookUp =
                    _db.MaintenanceCompanyLookUps.FirstOrDefault(
                        x => x.Role == specialistrole && x.UserId == id);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    var mp = new SpecialistMaintenanceProfile
                    {
                        MaintenanceCompanyLookUp = _db.MaintenanceCompanyLookUps.Find(companyId),
                        MaintenanceCompany = _db.MaintenanceCompanies.Find(companyId),
                        MaintenanceCompanySpecialization = _db.MaintenanceCompanySpecializations.Find(companyId),
                        MaintenanceCustomService = _db.MaintenanceCustomServices.Find(companyId),
                        MaintenanceExterior = _db.MaintenanceExteriors.Find(companyId),
                        MaintenanceInterior = _db.MaintenanceInteriors.Find(companyId),
                        MaintenanceNewConstruction = _db.MaintenanceNewConstructions.Find(companyId),
                        MaintenanceRepair = _db.MaintenanceRepairs.Find(companyId),
                        MaintenanceUtility = _db.MaintenanceUtilities.Find(companyId),
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
                    _db.MaintenanceCompanyLookUps.FirstOrDefault(
                        x => x.Role == specialistrole && x.UserId == id);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    var mcs = _db.MaintenanceCompanySpecializations.FirstOrDefault(x => x.CompanyId == companyId);
                    if (mcs != null)
                    {
                        ViewBag.Rate = mcs.Rate;
                        var currency = _db.Currencies.FirstOrDefault(x => x.CurrencyID == mcs.CurrencyID);
                        if (currency != null)
                            ViewBag.Currency = currency.CurrencyValue;
                    }

                    var currentspecialist = _db.Specialists.FirstOrDefault(x => x.SpecialistId == id);
                    return PartialView(currentspecialist);
                }
            }
            return null;
        }

        public void ShareSpecialist(Specialist s)
        {
            if (Request.Url == null) return;
            var url = Request.Url.AbsoluteUri.ToString(CultureInfo.InvariantCulture);
            var primaryimagethumbnail = UserHelper.ResolveImageUrl(GetSpecialistPrimaryPhoto(s.SpecialistId));
            var title = (s.FirstName+ " , " + s.LastName  + " , " + s.Address + " , " + s.Region + " , " + s.City);
                if (title.Length >= 50)
                {
                    title = title.Substring(0, 50);
                }
            var summary = s.Description;
            if (!String.IsNullOrEmpty(summary))
            {
                if (summary.Length >= 140)
                {
                    summary = summary.Substring(0, 140);
                }
            }
            var tweet = title + "--" + url;
            if (!String.IsNullOrEmpty(tweet))
            {
                if (tweet.Length >= 140)
                {
                    tweet = tweet.Substring(0, 140);
                }
            }


            const string sitename = "http://www.haithem-araissia.com";
            ViewBag.FaceBook = SocialHelper.FacebookShare(url, primaryimagethumbnail, title, summary);
            ViewBag.Twitter = SocialHelper.TwitterShare(tweet);
            ViewBag.GooglePlusShare = SocialHelper.GooglePlusShare(url);
            ViewBag.LinkedIn = SocialHelper.LinkedInShare(url, title, summary, sitename);
        }

        public string JNotifyConfirmationSharingEmail()
        {

            var jNotifyConfirmationScript = string.Format(@"jSuccess('Your email has been sent successfully.")
                                            +
                                            @"',{
	                        autoHide : true, // added in v2.0
	  	                        clickOverlay : false, // added in v2.0
	  	                        MinWidth : 300,
	  	                        TimeShown : 3000,
	  	                        ShowTimeEffect : 200,
	  	                        HideTimeEffect : 200,
	  	                        LongTrip :10,
	  	                        HorizontalPosition : 'center',
	  	                        VerticalPosition : 'center',
	  	                        ShowOverlay : true,
  		  	                        ColorOverlay : '#000',
	  	                        OpacityOverlay : 0.3,
	  	                        onClosed : function(){ // added in v2.0
	   
	  	                        },
	  	                         onCompleted : function(){ // added in v2.0
	  	                        
	  	                          window.location.href = location.href.replace('?shareproperty=True','#send-to-friend'); 
	   
	  	                }
		             });

";
            return jNotifyConfirmationScript;
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        public string GetSpecialistPrimaryPhoto(int id)
        {
            var specialistwork = _db.SpecialistWorks.FirstOrDefault(x => x.SpecialistId == id);
            return specialistwork == null ? "./../images/dotimages/home-handyman-projects.jpg" : specialistwork.PhotoPath;
        }

    }
}