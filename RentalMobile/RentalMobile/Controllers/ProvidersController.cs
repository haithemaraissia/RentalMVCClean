﻿using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Security.Application;
using RentalMobile.Helpers;
using RentalMobile.ModelViews;
using RentalMobile.Models;
using Email = Postal.Email;


namespace RentalMobile.Controllers
{
    public class ProvidersController : Controller
    {
        private readonly DB_33736_rentalEntities _db = new DB_33736_rentalEntities();

        public ActionResult Index(int? id, bool? shareprovider, bool? insertingnewcomment)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Maintain");
            }
            var provider = _db.MaintenanceProviders.Find(UserHelper.GetProviderId((int)id));
            ViewBag.ProviderProfile = provider;
            ViewBag.providerId = provider.MaintenanceProviderId;
            ViewBag.providerGoogleMap = provider.GoogleMap;
            ViewBag.Title = provider.FirstName + " " + provider.LastName + " Profile";
            ViewBag.CommentCount = GetCommentCount((int)id);
            ViewBag.Sript = FancyBox.FancyProvider((int)id);
            ViewBag.providerPrimaryPhoto = GetproviderPrimaryPhoto((int)id);
            Shareprovider(provider);
            if (shareprovider != null && shareprovider == true)
            {
                ViewBag.EmailSharedwithFriend = true;
                ViewBag.EmailSucessSharedwithFriend = JNotifyConfirmationSharingEmail();
            }
            if (insertingnewcomment != null && insertingnewcomment == true)
            {
                ViewBag.InsertNewComment = true;
                ViewBag.InsertNewCommentSuccess = JNotifyConfirmationSuccessComment();
            }



            //    //For Advertismement
            //TODO MORE WORK NEED TO BE DONE
             ViewBag.MiddleBannerKeywordFilter = Advertisement.MiddleBanner("11", "2");
            //   // For Advertismement


            return View(provider);
        }

        public PartialViewResult _Coverage(int id)
        {
            if (id != 0)
            {
                const int providerrole = 2;
                var lookUp =
                    _db.MaintenanceCompanyLookUps.FirstOrDefault(
                        x => x.Role == providerrole && x.UserId == id);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    var mp = new ProviderMaintenanceProfile
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
                const int providerrole = 2;
                var lookUp =
                    _db.MaintenanceCompanyLookUps.FirstOrDefault(
                        x => x.Role == providerrole && x.UserId == id);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;
                    var mcs = _db.MaintenanceCompanySpecializations.FirstOrDefault(x => x.CompanyId == companyId);
                    if (mcs != null)
                    {
                        ViewBag.Rate = mcs.Rate;
                        ViewBag.YearsofExperience = mcs.Years_Experience;
                        var currency = _db.Currencies.FirstOrDefault(x => x.CurrencyID == mcs.CurrencyID);
                        if (currency != null)
                            ViewBag.Currency = currency.CurrencyValue;
                    }

                    var currentprovider = _db.MaintenanceProviders.FirstOrDefault(x => x.MaintenanceProviderId == id);
                    return PartialView(currentprovider);
                }
            }
            return null;
        }

        public void Shareprovider(MaintenanceProvider s)
        {
            if (Request.Url == null) return;
            var url = Request.Url.AbsoluteUri.ToString(CultureInfo.InvariantCulture);
            var title = (s.FirstName + " , " + s.LastName + " , " + s.Address + " , " + s.Region + " , " + s.City);
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

            //TO UPDATE BEFORE RELEASE
            const string sitename = "http://www.haithem-araissia.com";
            //This is the correct one for production
            //ViewBag.FaceBook = SocialHelper.FacebookShareOnlyUrl(url);
            //TO UPDATE BEFORE RELEASE
            ViewBag.FaceBook = SocialHelper.FacebookShareOnlyUrl(sitename);

            ViewBag.Twitter = SocialHelper.TwitterShare(tweet);
            ViewBag.GooglePlusShare = SocialHelper.GooglePlusShare(url);
            ViewBag.LinkedIn = SocialHelper.LinkedInShare(url, title, summary, sitename);
        }


        /// <summary>
        /// YOU MIGHT NEED TO CREATE A NEW MESSAGE
        /// </summary>
        /// <param name="friendname"></param>
        /// <param name="friendemailaddress"></param>
        /// <param name="message"></param>
        /// <param name="id"></param>
        /// <returns></returns>
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
            email.FooterNote = "Check out this Provider";
            var uri = Request.Url;
            if (uri != null)
            {
                var host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
                email.ProfileUrl = host + uri.AbsolutePath.Replace("ForwardtoFriend", "");
                var currentprovider = _db.MaintenanceProviders.FirstOrDefault(x => x.MaintenanceProviderId == id);
                if (currentprovider != null)
                {
                    var providerTitle = currentprovider.FirstName + " , " + currentprovider.LastName;
                    if (providerTitle.Length >= 50)
                    {
                        providerTitle = providerTitle.Substring(0, 50);
                    }
                    email.CustomTitle = providerTitle;
                }
                if (currentprovider != null)
                {
                    email.PhotoPath = host + "/" + GetproviderPrimaryPhoto(id).Replace("../../", "");

                }
            }
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
            if (id != 0)
            {
                var providerPublicProfileComment =
                    _db.ProviderProfileComments.Where(x => x.ProviderId == id);
                ViewBag.CommentCount = providerPublicProfileComment.Any() ? "( " + providerPublicProfileComment.Count() + " )" : "";
                return PartialView(providerPublicProfileComment.ToList());
            }
            return null;
        }

        public string GetCommentCount(int id)
        {
            if (id != 0)
            {
                var providerPublicProfileComment =
                    _db.ProviderProfileComments.Where(x => x.ProviderId == id);
                return providerPublicProfileComment.Any() ? "( " + providerPublicProfileComment.Count() + " )" : "";
            }
            return "";
        }

        public string JNotifyConfirmationSharingEmail()
        {

            var jNotifyConfirmationScript = string.Format(@"jSuccess('Your sharing has been sent successfully.")
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
	  	                        
	  	                          window.location.href = location.href.replace('?shareprovider=True','#send-to-friend'); 
	   
	  	                }
		             });

";
            return jNotifyConfirmationScript;
        }

        public string JNotifyConfirmationSuccessComment()
        {

            var jNotifyConfirmationScript = string.Format(@"jSuccess('Your comment have been successfully inserted.")
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
	  	                        
	  	                          window.location.href = location.href.replace('?insertingnewcomment=True','#comments'); 
	   
	  	                }
		             });

";
            return jNotifyConfirmationScript;
        }

        public string GetproviderPrimaryPhoto(int id)
        {
            var providerwork = _db.ProviderWorks.FirstOrDefault(x => x.ProviderId == id);
            return providerwork == null ? "./../images/dotimages/home-handyman-projects.jpg" : providerwork.PhotoPath;
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult InsertComment(int? id, string comment)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "providers");
            }
            var poster = UserHelper.GetSendtoFriendPoster() ?? UserHelper.DefaultPoster;
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
                _db.ProviderProfileComments.Add(providerComment);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", new { id, insertingnewcomment = true });
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }










        //* TODO Complete it */
        //Actually hiring for Professional which should map to new job
        public ActionResult HireProvider(int id, string enctype)
        {
            return JavaScript("This should be the hiring procedure");
        }
    }
}
