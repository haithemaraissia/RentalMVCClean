using System;
using System.Collections.Generic;
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
    public class UnitTestController : Controller
    {
        private DB_33736_rentalEntities db = new DB_33736_rentalEntities();

        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View(db.Units.ToList());
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
                    //Think if tyou need or not because of the upload control
                    //db.UnitGalleries.Add(u.UnitGallery);
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
                    db.Units.Add(u.Unit);
                    db.UnitPricings.Add(u.UnitPricing);
                    db.UnitFeatures.Add(u.UnitFeature);
                    db.UnitCommunityAmenities.Add(u.UnitCommunityAmenity);
                    db.UnitAppliances.Add(u.UnitAppliance);
                    db.UnitInteriorAmenities.Add(u.UnitInteriorAmenity);
                    db.UnitExteriorAmenities.Add(u.UnitExteriorAmenity);
                    db.UnitLuxuryAmenities.Add(u.UnitLuxuryAmenity);
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

            SavePictures(unitModelView.Unit);
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

            return View(u);
        }


  }


        public class UnitPhoto
        {
            public string PathPath { get; set; }
        }

  
}