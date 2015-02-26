using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using RentalMobile.Helpers;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using Email = Postal.Email;

namespace RentalMobile.Controllers
{
    public class UnitController : Controller
    {
        private readonly RentalContext db = new RentalContext();

        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View(db.Units.Include("UnitPricing").ToList());
        }

        //
        // GET: /Test/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Test/Create

        public ActionResult Create()
        {

            //CREATE YOUR OWN SELECTLIST
            // ViewBag.UnitId = new SelectList(db.Units, "UnitId", "Description");

            //var newunit = new UnitModelView();
            // SetCurrencyViewBag();
            return View();
        }












        [HttpPost]
        public ActionResult Create(UnitModelView u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Units.Add(u.Unit);
                    db.UnitPricings.Add(u.UnitPricing);
                    db.UnitFeatures.Add(u.UnitFeature);
                    db.UnitCommunityAmenities.Add(u.UnitCommunityAmenity);
                    db.UnitAppliances.Add(u.UnitAppliance);
                    db.UnitInteriorAmenities.Add(u.UnitInteriorAmenity);
                    db.UnitExteriorAmenities.Add(u.UnitExteriorAmenity);
                    db.UnitLuxuryAmenities.Add(u.UnitLuxuryAmenity);
                    ViewBag.CurrencyCode = u.Unit.CurrencyCode;
                    db.SaveChanges();
                    SavePictures(u.Unit);
                    return RedirectToAction("Index");
                }
                return View(u);
            }


            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                      eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                          ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }



        }




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


        //
        // GET: /Test/Edit/5

        public ActionResult Edit(int id)
        {
            var u = new UnitModelView
                        {
                            Unit = db.Units.Find(id),
                            UnitFeature = db.UnitFeatures.Find(id),
                            UnitAppliance = db.UnitAppliances.Find(id),
                            UnitCommunityAmenity = db.UnitCommunityAmenities.Find(id),
                            UnitPricing = db.UnitPricings.Find(id),
                            UnitInteriorAmenity = db.UnitInteriorAmenities.Find(id),
                            UnitExteriorAmenity = db.UnitExteriorAmenities.Find(id),
                            UnitLuxuryAmenity = db.UnitLuxuryAmenities.Find(id)

                        };
            ViewBag.CurrencyCode = u.Unit.CurrencyCode;

            TempData["UnitID"] = id;
            return View(u);
        }

        //
        // POST: /Test/Edit/5

        [HttpPost]
        public ActionResult Edit(UnitModelView u)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    db.Entry(u.Unit).State = EntityState.Modified;
                    db.Entry(u.UnitPricing).State = EntityState.Modified;
                    db.Entry(u.UnitFeature).State = EntityState.Modified;
                    db.Entry(u.UnitCommunityAmenity).State = EntityState.Modified;
                    db.Entry(u.UnitAppliance).State = EntityState.Modified;
                    db.Entry(u.UnitInteriorAmenity).State = EntityState.Modified;
                    db.Entry(u.UnitExteriorAmenity).State = EntityState.Modified;
                    db.Entry(u.UnitLuxuryAmenity).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(u);
            }


            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                      eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                          ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        //
        // GET: /Test/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Test/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }























        private void SetCurrencyViewBag(int? currencyId = null)
        {
            ViewData["currency"] = currencyId == null
                                       ? new SelectList(db.Currencies, "CurrencyID", "CurrencyValue")
                                       : new SelectList(db.Currencies.ToArray(), "CurrencyID", "CurrencyValue",
                                                        currencyId);
        }

        public SelectList GetCurrencySelectList()
        {

            var currencies = db.Currencies;
            return new SelectList(currencies.ToArray(),
                                  "CurrencyID",
                                  "CurrencyValue");

        }

















        private readonly RentalContext _db = new RentalContext();

        //MAKE SURE THAT USER ARE AUTHENTICATED
        public string Username = Membership.GetUser(System.Web.HttpContext.Current.User.Identity.Name).ToString();
        //MAKE SURE THAT USER ARE AUTHENTICATED

        public string TenantPhotoPath = "~/Photo/Tenant/Property";
        public string OwnerPhotoPath = "~/Photo/Owner/Property";
        public string AgentPhotoPath = "~/Photo/Agent/Property";
        public string ProviderPhotoPath = "~/Photo/Provider/Property";
        public string SpecialistPhotoPath = "~/Photo/Specialist/Property";
        public string RequestId;
        public string PhotoPath;


        public ActionResult Partial2(UnitModelView unitModelView)
        {


            var role = GetCurrentRole();
            if (role == "Tenant")
            {
                ViewBag.Id = UserHelper.GetTenantId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetTenantId();
            }

            if (role == "Owner")
            {
                ViewBag.Id = UserHelper.GetOwnerId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetOwnerId();
            }

            if (role == "Agent")
            {
                ViewBag.Id = UserHelper.GetAgentId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetAgentId();
            }

            if (role == "Specialist")
            {
                ViewBag.Id = UserHelper.GetSpecialistId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetSpecialistId();
            }
            if (role == "Provider")
            {
                ViewBag.Id = UserHelper.GetProviderId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetProviderId();
            }



            //RequestID = "5";
            //ViewBag.UserName = "Test";
            //ViewBag.Id = "10";
            //ViewBag.Type = "Requests";
            //TempData["Id"] = "5";

            // SavePictures(unitModelView.Unit);
            //ViewBag.Sript = FancyBox.Fancy(unitModelView.Unit.UnitId);
            return PartialView("_Partial2", unitModelView.UnitGallery);
        }

        public string GetCurrentRole()
        {
            var user = System.Web.HttpContext.Current.User;
            if (user.IsInRole("Tenant"))
            {
                PhotoPath = Server.MapPath(TenantPhotoPath);
                return "Tenant";
            }
            if (user.IsInRole("Owner"))
            {
                PhotoPath = Server.MapPath(OwnerPhotoPath);
                return "Owner";
            }
            if (user.IsInRole("Agent"))
            {
                PhotoPath = Server.MapPath(AgentPhotoPath);
            }
            if (user.IsInRole("Provider"))
            {
                PhotoPath = Server.MapPath(ProviderPhotoPath);
                return "Provider";
            }

            PhotoPath = Server.MapPath(SpecialistPhotoPath);
            return user.IsInRole("Specialist") ? "Specialist" : null;
        }

        public void SavePictures(Unit unit)
        {
            var imageStoragePath = Server.MapPath("~/UploadedImages");
            var directory = @"\" + Username + @"\" + "Property" + @"\" + TempData["UserID"] + @"\";
            var path = imageStoragePath + directory;
            var uploadDirectory = new DirectoryInfo(path);


            if (!Directory.Exists(path))
            {
                UploadHelper.CreateDirectoryIfNotExist(path);
            }


            var files = uploadDirectory.GetFiles();

            directory = @"\" + Username + @"\" + TempData["UserID"] + @"\";
            var newdirectory = PhotoPath + directory;
            if (!Directory.Exists(path))
            {
                UploadHelper.CreateDirectoryIfNotExist(newdirectory);
            }
            int counter = 0;
            var virtualdestinationdirectoryvirtualmapping = Server.MapPath("~/Photo");
            virtualdestinationdirectoryvirtualmapping += @"\Owner\Property" + directory;
            //var virtualdestinationFile =  @"~\Photo\Owner\Property" + directory;
            if (!Directory.Exists(virtualdestinationdirectoryvirtualmapping))
            {
                UploadHelper.CreateDirectoryIfNotExist(virtualdestinationdirectoryvirtualmapping);
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
            UploadHelper.DeleteDirectoryIfExist(path);
            DefaultPhoto(unit, files, newdirectory, virtualdestinationdirectoryvirtualmapping, directory);
        }

        public void DefaultPhoto(Unit unit, FileInfo[] files, string newdirectory,
                                 string virtualdestinationdirectoryvirtualmapping, string directory)
        {
            if (!files.Any()) return;
            var defaultpropertyphoto = Server.MapPath("~/UploadedImages/Default/Property/coming_soon.png");
            var defaultpropertyphotodestination = newdirectory + @"\" + "coming_soon.png";
            var defaultvirtualpropertyphotodestination = virtualdestinationdirectoryvirtualmapping + @"\Owner\Property" +
                                                         directory + "coming_soon.png";
            System.IO.File.Copy(defaultpropertyphoto, defaultpropertyphotodestination);
            AddPicture(unit, Convert.ToInt32(TempData["UserID"]), defaultvirtualpropertyphotodestination, 0);
        }

        public void AddPicture(Unit unit, int uploaderid, string photoPath, int rank)
        {

            var unitgallery = new UnitGallery
                                  {
                                      Path = photoPath,
                                      Caption = "",
                                      Rank = rank,
                                      Unit = unit
                                  };

            if (!ModelState.IsValid) return;
            _db.UnitGalleries.Add(unitgallery);
            _db.SaveChanges();

        }










        public ActionResult EditPictures()
        {

            var role = GetCurrentRole();
            if (role == "Tenant")
            {
                ViewBag.Id = UserHelper.GetTenantId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetTenantId();
            }

            if (role == "Owner")
            {
                ViewBag.Id = UserHelper.GetOwnerId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetOwnerId();
            }

            if (role == "Agent")
            {
                ViewBag.Id = UserHelper.GetAgentId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetAgentId();
            }

            if (role == "Specialist")
            {
                ViewBag.Id = UserHelper.GetSpecialistId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetSpecialistId();
            }
            if (role == "Provider")
            {
                ViewBag.Id = UserHelper.GetProviderId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetProviderId();
            }

            var unitGallery = db.UnitGalleries.Find(TempData["UnitID"]);
            return PartialView("_EditPictures", unitGallery);

        }

        [HttpPost]
        public ActionResult EditPictures(UnitModelView unitModelView)
        {
            EditPicture(unitModelView.Unit);
            return PartialView("_EditPictures", unitModelView.UnitGallery);
        }

        public void EditPicture(Unit unit)
        {
            var imageStoragePath = Server.MapPath("~/UploadedImages");
            var directory = @"\" + Username + @"\" + "Property" + @"\" + TempData["UserID"] + @"\";
            var path = imageStoragePath + directory;
            var uploadDirectory = new DirectoryInfo(path);


            if (!Directory.Exists(path))
            {
                UploadHelper.CreateDirectoryIfNotExist(path);
            }


            var files = uploadDirectory.GetFiles();

            directory = @"\" + Username + @"\" + TempData["UserID"] + @"\";
            var newdirectory = PhotoPath + directory;
            if (!Directory.Exists(path))
            {
                UploadHelper.CreateDirectoryIfNotExist(newdirectory);
            }
            int counter = 0;
            var virtualdestinationdirectoryvirtualmapping = Server.MapPath("~/Photo");
            virtualdestinationdirectoryvirtualmapping += @"\Owner\Property" + directory;
            //var virtualdestinationFile =  @"~\Photo\Owner\Property" + directory;
            if (!Directory.Exists(virtualdestinationdirectoryvirtualmapping))
            {
                UploadHelper.CreateDirectoryIfNotExist(virtualdestinationdirectoryvirtualmapping);
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
            UploadHelper.DeleteDirectoryIfExist(path);
            DefaultPhoto(unit, files, newdirectory, virtualdestinationdirectoryvirtualmapping, directory);
        }





        //public JavaScriptResult ShareonFacebook()
        //{
        //    Helpers.Facebook.CheckAuthorization();
        //    return JavaScript(JNotifyConfirmation("Facebook"));
        //}


        public string JNotifyConfirmation(string socialnetwork)
        {

            var jNotifyConfirmationScript = string.Format(@"jSuccess('Your post to {0} has been succesfully.",
                                                          "socialnetwork")
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
	   
	  	                }
		             });";
            return jNotifyConfirmationScript;
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


        public ActionResult Preview(int id, bool? shareproperty, bool? requestshowing)
        {
            var u = new UnitModelView
                        {
                            Unit = db.Units.Find(id),
                            UnitFeature = db.UnitFeatures.Find(id),
                            UnitAppliance = db.UnitAppliances.Find(id),
                            UnitCommunityAmenity = db.UnitCommunityAmenities.Find(id),
                            UnitPricing = db.UnitPricings.Find(id),
                            UnitInteriorAmenity = db.UnitInteriorAmenities.Find(id),
                            UnitExteriorAmenity = db.UnitExteriorAmenities.Find(id),
                            UnitLuxuryAmenity = db.UnitLuxuryAmenities.Find(id)
                        };

            ShareProperty(u);

            ViewBag.UnitGoogleMap = string.IsNullOrEmpty(u.Unit.Address)
                                        ? UserHelper.GetFormattedLocation("", "", "USA")
                                        : UserHelper.GetFormattedLocation(u.Unit.Address, u.Unit.City, "US");
            var poster = UserHelper.GetPoster(id) ?? UserHelper.DefaultPoster;
            ViewBag.PosterFirstName = poster.FirstName;
            ViewBag.PosterLastName = poster.LastName;
            ViewBag.PosterPictureProfile = poster.ProfilePicturePath;
            ViewBag.PosterProfileLink = poster.ProfileLink;


            if (shareproperty != null && shareproperty == true)
            {
                ViewBag.EmailSharedwithFriend = true;
                ViewBag.EmailSucessSharedwithFriend = JNotifyConfirmationSharingEmail();
            }

            return View(u);
        }

        public void ShareProperty(UnitModelView u)
        {
            if (Request.Url == null) return;
            var url = Request.Url.AbsoluteUri.ToString(CultureInfo.InvariantCulture);
            var primaryimagethumbnail = UserHelper.ResolveImageUrl(u.Unit.PrimaryPhoto);
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
            unitrentprice += UserHelper.GetCurrencyValue(u.Unit.CurrencyCode);
            var tweet = u.Unit.Title + ": " + unitrentprice + "--" + url;
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


        public ActionResult ForwardtoFriend(string friendname, string friendemailaddress, string message, int id)
        {
            dynamic email = new Email("SendtoFriend/Multipart");
            var poster = UserHelper.GetPoster(id) ?? UserHelper.DefaultPoster;
            var currentunit = db.Units.Find(id);
            const string previewPathWithHost = @"/Unit/Preview";
            var unitPicture = currentunit.PrimaryPhoto;
            unitPicture = unitPicture.Replace("../../", "");


            //../../Photo/Owner/Property/carrie/2/img_walle - Copy.jpg

            // Assign any view data to pass to the view.
            // It's dynamic, so you can put whatever you want here.

            email.To = friendemailaddress;
            email.FriendName = friendname;
            email.From = "postmaster@haithem-araissia.com";
            email.SenderFirstName = poster.FirstName;
            email.Title = string.Format("Request From {0}", poster.FirstName);
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

            //     return Content(string.Format("<script language='javascript' type='text/javascript'>{0}</script>", JNotifyConfirmation("Sharing Property")));



            // return Content(string.Format("<script language='javascript' type='text/javascript'>{0}</script>", "alert('dgdf'); return false;"));


            return RedirectToAction("Preview", new { id });


        }


















        public ActionResult RequestShowing(string yourname, string youremail, string yourtelephone, string datepicker,
                                           int id)
        {


            //COMPLETE THIS 


            try
            {


                //Send Request to Requester
                SendRequestToRequester(yourname, youremail, datepicker, id);


                //Send Request to Receiver
                var unitposter = UserHelper.GetPoster(id) ?? UserHelper.DefaultPoster;
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
            catch (Exception)
            {

                //Jfailure;
                //Try Again
                //ViewBag.RequestShowing = false;
                //ViewBag.RequestShowingFailure = JNotifyRequestShowingFailure();
                return RedirectToAction("Preview", new { id, requestshowing = false });
            }

            //Alert Confimration with JSucess
            return RedirectToAction("Preview", new { id, requestshowing = true });

        }






        public void UnitProperty(int id, string previewPathWithHost, dynamic email, Unit currentunit, string unitPicture)
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













        public void SendRequestToRequester(string requestername,
                   string requesteremailaddress,
                   string datepicker, int id)
        {
            dynamic email = new Email("RequestShowing/Sender/Multipart");
            var currentunit = db.Units.Find(id);
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




        public void SendRequestToReceiver(string requestername,
            string requesteremailaddress, string requestertelephone,
            string datepicker, int id)
        {

            dynamic email = new Email("RequestShowing/Receiver/Multipart");
            var unitposter = UserHelper.GetPoster(id) ?? UserHelper.DefaultPoster;
            var currentunit = db.Units.Find(id);
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


            var unitposter = UserHelper.GetPoster(id) ?? UserHelper.DefaultPoster;

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
                db.OwnerPendingShowingCalendars.Add(pendingshowing);
                db.SaveChanges();
            }


            if (unitposter.Role == "agent")
            {
                //Pending Agent
            }

        }


    }

    public class UnitPhoto
    {
        public string PathPath { get; set; }
    }


}