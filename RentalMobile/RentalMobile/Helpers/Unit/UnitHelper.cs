using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Identity.Base;
using RentalMobile.Helpers.IO;
using RentalMobile.Helpers.Membership;
using RentalMobile.Helpers.Photo.Unit;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Unit
{

    public class UnitHelper : BaseController,  IUnitHelper
    {

        #region Main

        public UnitHelper(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        public void CreateNewUnit(UnitModelView u)
        {
            UnitofWork.UnitRepository.Add(u.Unit);
            UnitofWork.UnitPricingRepository.Add(u.UnitPricing);
            UnitofWork.UnitFeatureRepository.Add(u.UnitFeature);
            UnitofWork.UnitCommunityAmenityRepository.Add(u.UnitCommunityAmenity);
            UnitofWork.UnitApplianceRepository.Add(u.UnitAppliance);
            UnitofWork.UnitInteriorAmenityRepository.Add(u.UnitInteriorAmenity);
            UnitofWork.UnitExteriorAmenityRepository.Add(u.UnitExteriorAmenity);
            UnitofWork.UnitLuxuryAmenityRepository.Add(u.UnitLuxuryAmenity);
            UnitofWork.Save();
            SavePictures(u.Unit);
        }

        public int GetUnitCurrencyCode(UnitModelView u)
        {
            return u.Unit.CurrencyCode ?? 0 ;
        }

        public UnitModelView GetUnitModelViewByUnitId(int id)
        {
            var u = new UnitModelView
            {
                Unit = UnitofWork.UnitRepository.FirstOrDefault(x => x.UnitId == id),
                UnitFeature = UnitofWork.UnitFeatureRepository.FirstOrDefault(x => x.UnitId == id),
                UnitAppliance = UnitofWork.UnitApplianceRepository.FirstOrDefault(x => x.UnitId == id),
                UnitCommunityAmenity = UnitofWork.UnitCommunityAmenityRepository.FirstOrDefault(x => x.UnitId == id),
                UnitPricing = UnitofWork.UnitPricingRepository.FirstOrDefault(x => x.UnitId == id),
                UnitInteriorAmenity = UnitofWork.UnitInteriorAmenityRepository.FirstOrDefault(x => x.UnitId == id),
                UnitExteriorAmenity = UnitofWork.UnitExteriorAmenityRepository.FirstOrDefault(x => x.UnitId == id),
                UnitLuxuryAmenity = UnitofWork.UnitLuxuryAmenityRepository.FirstOrDefault(x => x.UnitId == id)
            };
            return u;
        }

        public void EditUnitModel(UnitModelView u)
        {
                UnitofWork.UnitRepository.Edit(u.Unit);
                UnitofWork.UnitFeatureRepository.Edit(u.UnitFeature);
                UnitofWork.UnitApplianceRepository.Edit(u.UnitAppliance);
                UnitofWork.UnitCommunityAmenityRepository.Edit(u.UnitCommunityAmenity);
                UnitofWork.UnitPricingRepository.Edit(u.UnitPricing);
                UnitofWork.UnitInteriorAmenityRepository.Edit(u.UnitInteriorAmenity);
                UnitofWork.UnitExteriorAmenityRepository.Edit(u.UnitExteriorAmenity);
                UnitofWork.UnitLuxuryAmenityRepository.Edit(u.UnitLuxuryAmenity);
                UnitofWork.Save();
        }       
        
        #endregion

        # region ImageUpload

        public string TenantPhotoPath = "~/Photo/Tenant/Property";
        public string OwnerPhotoPath = "~/Photo/Owner/Property";
        public string AgentPhotoPath = "~/Photo/Agent/Property";
        public string ProviderPhotoPath = "~/Photo/Provider/Property";
        public string SpecialistPhotoPath = "~/Photo/Specialist/Property";
        public string RequestId;
        public string PhotoPath;

        public string Username()
        {
            return UserHelper.GetUserName();
        }

        public UnitGallery GetUnitGalleryByUnitId(int unitId)
        {
            return UnitofWork.UnitGalleryRepository.FirstOrDefault(x => x.UnitGalleryId == unitId);
        }

        public void EditPicture(Model.Models.Unit unit)
        {
            var imageStoragePath = HttpContext.Server.MapPath("~/UploadedImages");
            var directory = @"\" + Username() + @"\" + "Property" + @"\" + TempData["UserID"] + @"\";
            var path = imageStoragePath + directory;
            var uploadDirectory = new DirectoryInfo(path);
            if (!Directory.Exists(path))
            {
                new DirectoryHelper().CreateDirectoryIfNotExist(path);
            }
            var files = uploadDirectory.GetFiles();
            directory = @"\" + Username() + @"\" + TempData["UserID"] + @"\";
            var newdirectory = PhotoPath + directory;
            if (!Directory.Exists(path))
            {
                new DirectoryHelper().CreateDirectoryIfNotExist(newdirectory);
            }
            int counter = 0;
            var virtualdestinationdirectoryvirtualmapping = HttpContext.Server.MapPath("~/Photo");
            virtualdestinationdirectoryvirtualmapping += @"\Owner\Property" + directory;
            //var virtualdestinationFile =  @"~\Photo\Owner\Property" + directory;
            if (!Directory.Exists(virtualdestinationdirectoryvirtualmapping))
            {
                new DirectoryHelper().CreateDirectoryIfNotExist(virtualdestinationdirectoryvirtualmapping);
            }
            foreach (var f in files)
            {
                var destinationFile = newdirectory + @"\" + f.Name;
                //TO COMPLETE
                virtualdestinationdirectoryvirtualmapping += f.Name;
                //TO COMPLETE
                if (!System.IO.File.Exists(destinationFile))
                {
                    System.IO.File.Move(f.FullName, destinationFile);
                    AddPicture(unit, Convert.ToInt32(TempData["UserID"]), virtualdestinationdirectoryvirtualmapping,
                               counter);
                    counter++;
                }
                if (System.IO.File.Exists(f.Name))
                    System.IO.File.Delete(f.Name);
            }
            new DirectoryHelper().DeleteDirectoryIfExist(path);
            DefaultPhoto(unit, files, newdirectory, virtualdestinationdirectoryvirtualmapping, directory);
        }

        public void SavePictures(Model.Models.Unit unit)
        {
            var imageStoragePath = HttpContext.Server.MapPath("~/UploadedImages");
            var directory = @"\" + Username() + @"\" + "Property" + @"\" + TempData["UserID"] + @"\";
            var path = imageStoragePath + directory;
            var uploadDirectory = new DirectoryInfo(path);
            if (!Directory.Exists(path))
            {
                new DirectoryHelper().CreateDirectoryIfNotExist(path);
            }
            var files = uploadDirectory.GetFiles();

            directory = @"\" + Username() + @"\" + TempData["UserID"] + @"\";
            var newdirectory = PhotoPath + directory;
            if (!Directory.Exists(path))
            {
                new DirectoryHelper().CreateDirectoryIfNotExist(newdirectory);
            }
            int counter = 0;
            var virtualdestinationdirectoryvirtualmapping = HttpContext.Server.MapPath("~/Photo");
            virtualdestinationdirectoryvirtualmapping += @"\Owner\Property" + directory;
            //var virtualdestinationFile =  @"~\Photo\Owner\Property" + directory;
            if (!Directory.Exists(virtualdestinationdirectoryvirtualmapping))
            {
                new DirectoryHelper().CreateDirectoryIfNotExist(virtualdestinationdirectoryvirtualmapping);
            }
            foreach (var f in files)
            {
                //TO COMPLETE
                virtualdestinationdirectoryvirtualmapping += f.Name;
                //TO COMPLETE
                if (!System.IO.File.Exists(virtualdestinationdirectoryvirtualmapping))
                {
                    //sSystem.IO.File.Move(f.FullName, destinationFile);
                    System.IO.File.Move(f.FullName, virtualdestinationdirectoryvirtualmapping);
                    AddPicture(unit, Convert.ToInt32(TempData["UserID"]), virtualdestinationdirectoryvirtualmapping,
                               counter);
                    counter++;
                }
                if (System.IO.File.Exists(f.Name))
                    System.IO.File.Delete(f.Name);
            }
            new DirectoryHelper().DeleteDirectoryIfExist(path);
            DefaultPhoto(unit, files, newdirectory, virtualdestinationdirectoryvirtualmapping, directory);
        }

        public void DefaultPhoto(Model.Models.Unit unit, FileInfo[] files, string newdirectory,string virtualdestinationdirectoryvirtualmapping, string directory)
        {
            if (!files.Any()) return;
            var defaultpropertyphoto = HttpContext.Server.MapPath("~/UploadedImages/Default/Property/coming_soon.png");
            var defaultpropertyphotodestination = newdirectory + @"\" + "coming_soon.png";
            var defaultvirtualpropertyphotodestination = virtualdestinationdirectoryvirtualmapping + @"\Owner\Property" +
                                                         directory + "coming_soon.png";
            System.IO.File.Copy(defaultpropertyphoto, defaultpropertyphotodestination);
            AddPicture(unit, Convert.ToInt32(TempData["UserID"]), defaultvirtualpropertyphotodestination, 0);
        }

        public void AddPicture(Model.Models.Unit unit, int uploaderid, string photoPath, int rank)
        {
            var unitgallery = new UnitGallery
            {
                Path = photoPath,
                Caption = "",
                Rank = rank,
                Unit = unit
            };

            if (!ModelState.IsValid) return;
            UnitofWork.UnitGalleryRepository.Add(unitgallery);
            UnitofWork.Save();
        }

        public JavaScriptResult ShareonFacebook()
        {
            var facebookAuthentication = new Facebook();
            facebookAuthentication.CheckAuthorization();
            return JavaScript(new JNotfiyScriptQueryHelper().JNotifySocialConfirmation("Facebook"));
        }

        public string GetCurrentRole()
        {
            var user = System.Web.HttpContext.Current.User;
            if (user.IsInRole("Tenant"))
            {
                PhotoPath = HttpContext.Server.MapPath(TenantPhotoPath);
                return "Tenant";
            }
            if (user.IsInRole("Owner"))
            {
                PhotoPath = HttpContext.Server.MapPath(OwnerPhotoPath);
                return "Owner";
            }
            if (user.IsInRole("Agent"))
            {
                PhotoPath = HttpContext.Server.MapPath(AgentPhotoPath);
            }
            if (user.IsInRole("Provider"))
            {
                PhotoPath = HttpContext.Server.MapPath(ProviderPhotoPath);
                return "Provider";
            }

            PhotoPath = Server.MapPath(SpecialistPhotoPath);
            return user.IsInRole("Specialist") ? "Specialist" : null;
        }

        public UnitUploaderAttributes GetUnitUploaderAttributes()
        {
            var role = GetCurrentRole();
            switch (role)
            {
                case "Tenant":
                    return new UnitUploaderAttributes
                    {
                        UploaderId = UserHelper.GetSpecialistId(),
                        UploaderName = UserHelper.GetUserName(),
                        UploadType = "Property"
                    };
                case "Owner":
                    return new UnitUploaderAttributes
                    {
                        UploaderId = UserHelper.GetOwnerId(),
                        UploaderName = UserHelper.GetUserName(),
                        UploadType = "Property"
                    };
                case "Agent":
                    return new UnitUploaderAttributes
                    {
                        UploaderId = UserHelper.GetAgentId(),
                        UploaderName = UserHelper.GetUserName(),
                        UploadType = "Property"
                    };
                case "Specialist":
                    return new UnitUploaderAttributes
                    {
                        UploaderId = UserHelper.GetSpecialistId(),
                        UploaderName = UserHelper.GetUserName(),
                        UploadType = "Property"
                    };
                case "Provider":
                    return new UnitUploaderAttributes
                    {
                        UploaderId = UserHelper.GetProviderId(),
                        UploaderName = UserHelper.GetUserName(),
                        UploadType = "Property"
                    };
            }
            return null;
        }

        #endregion

        #region Features
        //Theorizing

        public void ShareProperty(UnitModelView u)
        {
            if (Request.Url == null) return;
            var url = Request.Url.AbsoluteUri.ToString(CultureInfo.InvariantCulture);
            var primaryimagethumbnail = new UserIdentity(UnitofWork, MembershipService).ResolveImageUrl(u.Unit.PrimaryPhoto);
            string title;
            if (String.IsNullOrEmpty(u.Unit.Title))
            {
                title = (u.Unit.Address + " , " + u.Unit.State + " , " + u.Unit.City);
                if (title.Length >= 50)
                {
                    title = title.Substring(0, 50);
                }
            }
            else
            {
                title = u.Unit.Title;
                if (u.Unit.Title.Length >= 50)
                {
                    title = u.Unit.Title.Substring(0, 50);
                }
            }

            var summary = u.Unit.Description;
            if (!String.IsNullOrEmpty(summary))
            {
                if (summary.Length >= 140)
                {
                    summary = summary.Substring(0, 140);
                }
            }

            var unitrentprice = u.UnitPricing.Rent == null
                                    ? ""
                                    : u.UnitPricing.Rent.Value.ToString(CultureInfo.InvariantCulture) + " ";
            unitrentprice += GetCurrencyValue(u.Unit.CurrencyCode);
            var tweet = u.Unit.Title + ": " + unitrentprice + "--" + url;
            if (!String.IsNullOrEmpty(tweet))
            {
                if (tweet.Length >= 140)
                {
                    tweet = tweet.Substring(0, 140);
                }
            }

            const string sitename = "http://www.haithem-araissia.com";

            //TOD REFACTOR SO THAT INVOKING WILL BE CALLING VIEWBAG
            ViewBag.FaceBook = new SocialHelper().FacebookShare(url, primaryimagethumbnail, title, summary);
            ViewBag.Twitter = new SocialHelper().TwitterShare(tweet);
            ViewBag.GooglePlusShare = new SocialHelper().GooglePlusShare(url);
            ViewBag.LinkedIn = new SocialHelper().LinkedInShare(url, title, summary, sitename);
        }

        public string GetCurrencyValue(int? currencyId)
        {
            var currency = UnitofWork.CurrencyRepository.FirstOrDefault(x => x.CurrencyID == currencyId);
            return currency.CurrencyValue;
        }

        public void UnitProperty(int id, string previewPathWithHost, dynamic email, Model.Models.Unit currentunit, string unitPicture)
        {
            var uri = Request.Url;
            if (uri == null) return;
            var host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
            var unitUrl = host + previewPathWithHost + id;
            email.UnitUrl = unitUrl;

            string title;
            if (String.IsNullOrEmpty(currentunit.Title))
            {
                title = (currentunit.Address + " , " + currentunit.State + " , " + currentunit.City);
                if (title.Length >= 50)
                {
                    title = title.Substring(0, 50);
                }
            }
            else
            {
                title = currentunit.Title;
                if (currentunit.Title.Length >= 50)
                {
                    title = currentunit.Title.Substring(0, 50);
                }
            }
            email.UnitTitle = title;
            email.UnitPath = host + "/" + unitPicture;
        }

        public void SendRequestToRequester(string requestername, string requesteremailaddress,string datepicker, int id)
        {
            dynamic email = new Email("RequestShowing/Sender/Multipart");
            var currentunit = UnitofWork.UnitRepository.FirstOrDefault(x=>x.UnitId == id);
            const string previewPathWithHost = @"/Unit/Preview";
            var unitPicture = currentunit.PrimaryPhoto;
            unitPicture = unitPicture.Replace("../../", "");

            email.To = requesteremailaddress;
            email.RequesterName = requestername;
            email.From = "postmaster@haithem-araissia.com";

            email.Title = string.Format("Confirmation of Request From {0}", requestername);

            email.ScheduleDate = datepicker;
            email.LinkConfirmation = "Confirmation to Poster Schedule Pending";
            UnitProperty(id, previewPathWithHost, email, currentunit, unitPicture);

            try
            {
                email.SendAsync();

            }
            catch (Exception)
            {
                //Write To Database Error
                //Output Message
                Response.Write("Fail");
                throw;
            }

        }

        public void SendRequestToReceiver(string requestername, string requesteremailaddress, string requestertelephone,string datepicker, int id)
        {

            dynamic email = new Email("RequestShowing/Receiver/Multipart");
            var unitposter = UserHelper.GetPoster(id) ?? UserHelper.PosterHelper.DefaultPoster;
            var currentunit = UnitofWork.UnitRepository.FirstOrDefault(x => x.UnitId == id);
            const string previewPathWithHost = @"/Unit/Preview";
            var unitPicture = currentunit.PrimaryPhoto;
            unitPicture = unitPicture.Replace("../../", "");

            email.To = unitposter.EmailAddress;
            email.ReceiverName = unitposter.FirstName;
            email.From = "postmaster@haithem-araissia.com";

            email.RequesterName = requestername;
            email.RequesterEmailAddress = requesteremailaddress;
            email.Title = string.Format("Request From {0}", requestername);

            email.ScheduleDate = datepicker;
            email.RequesterTelephone = requestertelephone;
            email.LinkConfirmation = "Confirmation to Poster Schedule Pending";
            UnitProperty(id, previewPathWithHost, email, currentunit, unitPicture);

            try
            {
                email.SendAsync();

            }
            catch (Exception)
            {
                //Write To Database Error

                //Output Message
                Response.Write("Fail");
                throw;
            }
        }

        public void InsertPendingShowingRequest(int id)
        {
            //Depending on the Poster role
            //Insert into PendingRequestWShowing.
            var unitposter = UserHelper.GetPoster(id) ?? UserHelper.PosterHelper.DefaultPoster;

            if (unitposter.Role == "owner")
            {
                //Pending OWner
                var pendingshowing = new OwnerPendingShowingCalendar
                    {
                        EventTitle = "Pending Showing Request From ",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        IsAllDay = false,
                        OwnerId = unitposter.PosterId
                    };
                UnitofWork.OwnerPendingShowingCalendarRepository.Add(pendingshowing);
                UnitofWork.Save();
            }


            if (unitposter.Role == "agent")
            {
                //Pending Agent
            }

        }

        public string UnitGoogleMap(UnitModelView unitModel)
        {
            return string.IsNullOrEmpty(unitModel.Unit.Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(unitModel.Unit.Address, unitModel.Unit.City, unitModel.Unit.CountryCode);
        }

        public void PreviewUnit(int id, bool? shareproperty, UnitModelView unitModel)
        {
            UserHelper.UnitHelper.ShareProperty(unitModel);
            ViewBag.UnitGoogleMap = UserHelper.UnitHelper.UnitGoogleMap(unitModel);
            var unitposter = UserHelper.GetPoster(id) ?? UserHelper.PosterHelper.DefaultPoster;
            ViewBag.PosterFirstName = unitposter.FirstName;
            ViewBag.PosterLastName = unitposter.LastName;
            ViewBag.PosterPictureProfile = unitposter.ProfilePicturePath;
            ViewBag.PosterProfileLink = unitposter.ProfileLink;
            if (shareproperty != null && shareproperty == true)
            {
                ViewBag.EmailSharedwithFriend = true;
                ViewBag.EmailSucessSharedwithFriend = new JNotfiyScriptQueryHelper().JNotifyConfirmationSharingEmail();
            }
        }

        public dynamic ComposeForwardToFriendEmail(string friendname, string friendemailaddress, string message, int id)
        {
            dynamic email = new Email("SendtoFriend/Multipart");
            var unitposter = UserHelper.GetPoster(id) ?? UserHelper.PosterHelper.DefaultPoster;
            var currentunit = UnitofWork.UnitRepository.FirstOrDefault(x => x.UnitId == id);
            const string previewPathWithHost = @"/Unit/Preview";
            var unitPicture = currentunit.PrimaryPhoto;
            unitPicture = unitPicture.Replace("../../", "");
            //../../Photo/Owner/Property/carrie/2/img_walle - Copy.jpg

            // Assign any view data to pass to the view.
            // It's dynamic, so you can put whatever you want here.

            email.To = friendemailaddress;
            email.FriendName = friendname;
            email.From = "postmaster@haithem-araissia.com";
            email.SenderFirstName = unitposter.FirstName;
            email.Title = string.Format("Request From {0}", unitposter.FirstName);
            email.Message = message;
            var uri = Request.Url;
            if (uri != null)
            {
                var host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
                var unitUrl = host + previewPathWithHost + id;
                email.UnitUrl = unitUrl;

                string title;
                if (String.IsNullOrEmpty(currentunit.Title))
                {
                    title = (currentunit.Address + " , " + currentunit.State + " , " + currentunit.City);
                    if (title.Length >= 50)
                    {
                        title = title.Substring(0, 50);
                    }
                }
                else
                {
                    title = currentunit.Title;
                    if (currentunit.Title.Length >= 50)
                    {
                        title = currentunit.Title.Substring(0, 50);
                    }
                }

                email.UnitTitle = title;
                // email.UnitPath = "http://www.haithem-araissia.com/images/property/home12.jpg";
                email.UnitPath = host + "/" + unitPicture;
            }
            return email;
        }

        public void RequestShowing(string yourname, string youremail, string yourtelephone, string datepicker, int id)
        {
            //Send Request to Requester
            SendRequestToRequester(yourname, youremail, datepicker, id);

            //Send Request to Receiver
            var unitposter = UserHelper.GetPoster(id) ?? UserHelper.PosterHelper.DefaultPoster;
            if (unitposter.Role != null)
            {
                SendRequestToReceiver(yourname, youremail, yourtelephone, datepicker, id);

            }
            //Insert into Confirmation of showing pending
            InsertPendingShowingRequest(id);

            //Jsucess
            //ViewBag.RequestShowing = true;
            //ViewBag.RequestShowingSucess = JNotifyRequestShowingSucess();
        } 
        
        #endregion

        #region Helper

        public void SetCurrencyViewBag(int? currencyId = null)
        {
            ViewData["currency"] = currencyId == null
                                       ? new SelectList(UnitofWork.CurrencyRepository.All, "CurrencyID", "CurrencyValue")
                                       : new SelectList(UnitofWork.CurrencyRepository.All.ToArray(), "CurrencyID", "CurrencyValue",
                                                        currencyId);
        }

        public SelectList GetCurrencySelectList()
        {

            var currencies = UnitofWork.CurrencyRepository.All;
            return new SelectList(currencies.ToArray(),
                                  "CurrencyID",
                                  "CurrencyValue");

        }

        //        public string JNotifyRequestShowingSucess()
        //        {

        //            var jNotifyConfirmationScript = string.Format(@"jSuccess('Your request has been sent successfully.")
        //                                            +
        //                                            @"',{
        //	                        autoHide : true, // added in v2.0
        //	  	                        clickOverlay : false, // added in v2.0
        //	  	                        MinWidth : 300,
        //	  	                        TimeShown : 3000,
        //	  	                        ShowTimeEffect : 200,
        //	  	                        HideTimeEffect : 200,
        //	  	                        LongTrip :10,
        //	  	                        HorizontalPosition : 'center',
        //	  	                        VerticalPosition : 'center',
        //	  	                        ShowOverlay : true,
        //  		  	                        ColorOverlay : '#000',
        //	  	                        OpacityOverlay : 0.3,
        //	  	                        onClosed : function(){ // added in v2.0
        //	   
        //	  	                        },
        //	  	                         onCompleted : function(){ // added in v2.0
        //	  	                        
        //	  	                          window.location.href = location.href.replace('?shareproperty=True','#send-to-friend'); 
        //	   
        //	  	                }
        //		             });
        //
        //";
        //            return jNotifyConfirmationScript;
        //        }


        //        public string JNotifyRequestShowingFailure()
        //        {

        //            var jNotifyConfirmationScript = string.Format(@"jError('Your request has not been sent successfully. PLease try again.")
        //                                            +
        //                                            @"',{
        //	                        autoHide : true, // added in v2.0
        //	  	                        clickOverlay : false, // added in v2.0
        //	  	                        MinWidth : 300,
        //	  	                        TimeShown : 3000,
        //	  	                        ShowTimeEffect : 200,
        //	  	                        HideTimeEffect : 200,
        //	  	                        LongTrip :10,
        //	  	                        HorizontalPosition : 'center',
        //	  	                        VerticalPosition : 'center',
        //	  	                        ShowOverlay : true,
        //  		  	                        ColorOverlay : '#000',
        //	  	                        OpacityOverlay : 0.3,
        //	  	                        onClosed : function(){ // added in v2.0
        //	   
        //	  	                        },
        //	  	                         onCompleted : function(){ // added in v2.0
        //	  	                        
        //	  	                          window.location.href = location.href.replace('?shareproperty=True','#send-to-friend'); 
        //	   
        //	  	                }
        //		             });
        //
        //";
        //            return jNotifyConfirmationScript;
        //        }

        #endregion

        #region ToComplete
        //////////////////////////// TO COMPLETE////////////////////////////////
        ////
        //// POST: /Test/Create

        //public JsonResult GetJsonData()
        //{

        //    //Think about how to know which Unit is being quered
        //    var persons = db.UnitGalleries.ToList();
        //    var p = persons.Select(d => new UnitPhoto { PathPath = d.Path }).ToList();

        //    foreach (var ph in p)
        //    {
        //        ph.PathPath = ph.PathPath.Replace(@"~\Photo", @"../../Photo").Replace("\\", "/");
        //    }
        //    return Json(p, JsonRequestBehavior.AllowGet);
        //}
        //////////////////////////// TO COMPLETE////////////////////////////////
        #endregion

    }
}