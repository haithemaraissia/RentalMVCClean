using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RentalMobile.Helpers;
using RentalMobile.ModelViews;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    public class UnitController : Controller
    {
        private DB_33736_rentalEntities db = new DB_33736_rentalEntities();

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
            ViewData["currency"] = currencyId == null ? new SelectList(db.Currencies, "CurrencyID", "CurrencyValue") : 
                new SelectList(db.Currencies.ToArray(), "CurrencyID", "CurrencyValue", currencyId);
        }

        public SelectList GetCurrencySelectList()
        {

            var currencies = db.Currencies;
            return new SelectList(currencies.ToArray(),
                                "CurrencyID",
                                "CurrencyValue");

        }

















        private readonly DB_33736_rentalEntities _db = new DB_33736_rentalEntities();

        //MAKE SURE THAT USER ARE AUTHENTICATED
        public string Username = Membership.GetUser(System.Web.HttpContext.Current.User.Identity.Name).ToString();
        //MAKE SURE THAT USER ARE AUTHENTICATED

        public string TenantPhotoPath = "~/Photo/Tenant/Property";
        public string OwnerPhotoPath = "~/Photo/Owner/Property";
        public string AgentPhotoPath = "~/Photo/Agent/Property";
        public string ProviderPhotoPath = "~/Photo/Provider/Property";
        public string SpecialistPhotoPath = "~/Photo/Specialist/Property";
        public string RequestID;
        public string photoPath;


        public ActionResult Partial2(UnitModelView unitModelView)
        {


            var role = GetCurrentRole();
            if (role == "Tenant")
            {
                ViewBag.Id = UserHelper.GetTenantID();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetTenantID();
            }

            if (role == "Owner")
            {
                ViewBag.Id = UserHelper.GetOwnerID();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetOwnerID();
            }

            if (role == "Agent")
            {
                ViewBag.Id = UserHelper.GetAgentID();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetAgentID();
            }

            if (role == "Specialist")
            {
                ViewBag.Id = UserHelper.GetSpecialistID();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetSpecialistID();
            }
            if (role == "Provider")
            {
                ViewBag.Id = UserHelper.GetProviderID();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetProviderID();
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
                photoPath = Server.MapPath(TenantPhotoPath);
                return "Tenant";
            }
            if (user.IsInRole("Owner"))
            {
                photoPath = Server.MapPath(OwnerPhotoPath);
                return "Owner";
            }
            if (user.IsInRole("Agent"))
            {
                photoPath = Server.MapPath(AgentPhotoPath);
            }
            if (user.IsInRole("Provider"))
            {
                photoPath = Server.MapPath(ProviderPhotoPath);
                return "Provider";
            }

            photoPath = Server.MapPath(SpecialistPhotoPath);
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
            var newdirectory = photoPath + directory;
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
                ViewBag.Id = UserHelper.GetTenantID();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetTenantID();
            }

            if (role == "Owner")
            {
                ViewBag.Id = UserHelper.GetOwnerID();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetOwnerID();
            }

            if (role == "Agent")
            {
                ViewBag.Id = UserHelper.GetAgentID();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetAgentID();
            }

            if (role == "Specialist")
            {
                ViewBag.Id = UserHelper.GetSpecialistID();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetSpecialistID();
            }
            if (role == "Provider")
            {
                ViewBag.Id = UserHelper.GetProviderID();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetProviderID();
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
            var newdirectory = photoPath + directory;
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

            var jNotifyConfirmationScript = string.Format(@"jSuccess('Your post to {0} has been succesfully.", "socialnetwork")
            + @"{
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






        public ActionResult Preview(int id)
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


            ViewBag.Sript = FancyBox.Fancy(id);
            ViewBag.FaceBook = SocialHelper.FacebookShare();
            ViewBag.Twitter = SocialHelper.TwitterShare();
            ViewBag.GooglePlusShare = SocialHelper.GooglePlusShare();
            ViewBag.LinkedIn = SocialHelper.LinkedInShare();

            ViewBag.UnitGoogleMap = string.IsNullOrEmpty(u.Unit.Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(u.Unit.Address, u.Unit.City, "US");



            ViewBag.Poster = "Owner";
            return View(u);
        }


    }


    public class UnitPhoto
    {
        public string PathPath { get; set; }
    }


}