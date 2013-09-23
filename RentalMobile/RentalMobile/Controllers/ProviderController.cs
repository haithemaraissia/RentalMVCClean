using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RentalMobile.Helpers;
using RentalMobile.ModelViews;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{ 
    public class ProviderController : Controller
    {
        private DB_33736_rentalEntities db = new DB_33736_rentalEntities();

        //
        // GET: /Provider/
        //GET: CurrentProvider

        public ViewResult Index()
        {
            var provider = db.MaintenanceProviders.Find(UserHelper.GetProviderID());

            var team = db.MaintenanceTeamAssociations.
                Where(x => x.MaintenanceProviderId == 2).ToList();

            var myTeam = (from i in team
                          let currentspecialist = db.Specialists.Find(i.SpecialistId)
                          select new Teammate
                              {
                                  SpecialistId = i.SpecialistId, 
                                  SpecialistName = currentspecialist.FirstName + currentspecialist.LastName, 
                                  YearofExperience = 3, 
                                  SpecialistImageProfile = currentspecialist.Photo
                              }).ToList();

            ViewBag.ProviderProfile = provider;
            ViewBag.ProviderId = provider.MaintenanceProviderId;
            ViewBag.ProviderGoogleMap = provider.GoogleMap;
            ViewBag.Team = myTeam;
            return View(provider);
        }


        // GET: /Provider/Edit/5

        public ActionResult Edit(int id)
        {
            MaintenanceProvider Provider = db.MaintenanceProviders.Find(id);
            return View(Provider);
        }

        //
        // POST: /Provider/Edit/5

        [HttpPost]
        public ActionResult Edit(MaintenanceProvider Provider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Provider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Provider);
        }


        //
        // GET: /Provider/Edit/5

        public ActionResult ChangeAddress(int id)
        {
            MaintenanceProvider Provider = db.MaintenanceProviders.Find(id);
            return View(Provider);
        }

        //
        // POST: /Provider/Edit/5

        [HttpPost]
        public ActionResult ChangeAddress(MaintenanceProvider Provider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Provider).State = EntityState.Modified;
                Provider.GoogleMap = string.IsNullOrEmpty(Provider.Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(Provider.Address, Provider.City, Provider.CountryCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Provider);
        }

        //
        // GET: /Provider/Delete/5

        public ActionResult Delete(int id)
        {
            MaintenanceProvider Provider = db.MaintenanceProviders.Find(id);
            return View(Provider);
        }

        //
        // POST: /Provider/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MaintenanceProvider Provider = db.MaintenanceProviders.Find(id);
            db.MaintenanceProviders.Remove(Provider);
            db.SaveChanges();



            //// Delete All associated records

            //var Providershowing = db.ProviderShowings.Where(x => x.ProviderId == id).ToList();
            //foreach (var x in Providershowing)
            //{
            //    db.ProviderShowings.Remove(x);
            //}
            //db.SaveChanges();




            //Delete from Membership

            if (Roles.GetRolesForUser(User.Identity.Name).Any())
            {
                Roles.RemoveUserFromRoles(User.Identity.Name, Roles.GetRolesForUser(User.Identity.Name));
            }
            Membership.DeleteUser(User.Identity.Name);
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }


        public ActionResult UpdateProfilePicture(int id)
        {
            return RedirectToAction("Upload", "Account", new { id });
        }


        //DETAIL OF Provider FAVORITE

        //public PartialViewResult FavoriteDetails(int id)
        //{

        //    var Providerfavorite =  db.ProviderFavorites.Where(x => x.ProviderId == 2 && x.FavoriteId == id).FirstOrDefault();
        //    //Provider Provider = db.ProviderFavorites.Where(Provider == 6 && )
        //    return PartialView("_ProviderFavDetail",Providerfavorite);
        //}





        //Continue from here like OWner for pendingm, accpeted and rejected
        public ActionResult NewJobOffer()
        {
            var provider = db.MaintenanceProviders.Find(UserHelper.GetProviderID());

            return View(db.MaintenanceProviderAcceptedJobs.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId).ToList());
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

          //  SavePictures(unitModelView.Unit);
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


        public ActionResult CompleteProfile()
        {
        return View();
        }


        [HttpPost]
        public ActionResult CompleteProfile(UnitModelView u)
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
                   // SavePictures(u.Unit);
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



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }









    }

    public class Teammate
    {
        public int SpecialistId { get; set; }
        public string SpecialistName { get; set; }
        public int YearofExperience { get; set; }
        public string SpecialistImageProfile { get; set; }
    }
}