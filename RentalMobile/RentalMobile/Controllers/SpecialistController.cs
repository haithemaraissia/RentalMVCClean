using System;
using System.Collections.Generic;
using System.Data;
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
    [Authorize]
    public class SpecialistController : Controller
    {

        public DB_33736_rentalEntities db = new DB_33736_rentalEntities();

        //
        // GET: /Specialist/
        //GET: CurrentSpecialist

        public ViewResult Index()
        {
            var specialist = db.Specialists.Find(UserHelper.GetSpecialistID());
            ViewBag.SpecialistProfile = specialist;
            ViewBag.SpecialistId = specialist.SpecialistId;
            ViewBag.SpecialistGoogleMap = specialist.GoogleMap;
            return View(specialist);
        }


        // GET: /Specialist/Edit/5

        public ActionResult Edit(int id)
        {
            Specialist Specialist = db.Specialists.Find(id);
            return View(Specialist);
        }

        //
        // POST: /Specialist/Edit/5

        [HttpPost]
        public ActionResult Edit(Specialist Specialist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Specialist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Specialist);
        }


        //
        // GET: /Specialist/Edit/5

        public ActionResult ChangeAddress(int id)
        {
            Specialist Specialist = db.Specialists.Find(id);
            return View(Specialist);
        }

        //
        // POST: /Specialist/Edit/5

        [HttpPost]
        public ActionResult ChangeAddress(Specialist Specialist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Specialist).State = EntityState.Modified;
                Specialist.GoogleMap = string.IsNullOrEmpty(Specialist.Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(Specialist.Address, Specialist.City, Specialist.CountryCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Specialist);
        }

        //
        // GET: /Specialist/Delete/5

        public ActionResult Delete(int id)
        {
            Specialist Specialist = db.Specialists.Find(id);
            return View(Specialist);
        }

        //
        // POST: /Specialist/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Specialist Specialist = db.Specialists.Find(id);
            db.Specialists.Remove(Specialist);
            db.SaveChanges();



            //// Delete All associated records

            //var Specialistshowing = db.SpecialistShowings.Where(x => x.SpecialistId == id).ToList();
            //foreach (var x in Specialistshowing)
            //{
            //    db.SpecialistShowings.Remove(x);
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


        //DETAIL OF Specialist FAVORITE

        //public PartialViewResult FavoriteDetails(int id)
        //{

        //    var Specialistfavorite =  db.SpecialistFavorites.Where(x => x.SpecialistId == 2 && x.FavoriteId == id).FirstOrDefault();
        //    //Specialist Specialist = db.SpecialistFavorites.Where(Specialist == 6 && )
        //    return PartialView("_SpecialistFavDetail",Specialistfavorite);
        //}


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












        //Provider Pending Invitation

        public ActionResult ProviderInvitation()
        {

           return View(db.SpecialistPendingTeamInvitations.ToList());

        }

        public ActionResult AcceptInvitation(int id)
        {
            var invitation = db.SpecialistPendingTeamInvitations.Find(id);
            var currentinvitation =
                    db.MaintenanceTeamAssociations.FirstOrDefault(x => x.MaintenanceProviderId == invitation.MaintenanceProviderId &&
                                                                       x.SpecialistId == invitation.SpecialistID);

            return View(currentinvitation);

        }



        [HttpPost]
        public ActionResult AcceptInvitation(MaintenanceTeamAssociation mta)
        {
            var invitation =
                db.SpecialistPendingTeamInvitations.FirstOrDefault(x => x.SpecialistID == mta.SpecialistId && x.MaintenanceProviderId == mta.MaintenanceProviderId);

            db.MaintenanceTeamAssociations.Add(mta);
            db.SpecialistPendingTeamInvitations.Remove(invitation);
            db.SaveChanges();

            ViewBag.Confirmation = true;
            ViewBag.ConfirmationSuccess = JNotifyConfirmationSharingEmail();
     
            //JQuery Success
            return View();

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




        public ActionResult DenyInvitation(int id)
        {
            var invitation = db.SpecialistPendingTeamInvitations.Find(id);
            var currentinvitation =
                    db.MaintenanceTeamAssociations.FirstOrDefault(x => x.MaintenanceProviderId == invitation.MaintenanceProviderId &&
                                                                       x.SpecialistId == invitation.SpecialistID);
            return View(currentinvitation);

        }

        [HttpPost]
        public ActionResult DenyInvitation(MaintenanceTeamAssociation mta)
        {
            var invitation =
                db.SpecialistPendingTeamInvitations.FirstOrDefault(x => x.SpecialistID == mta.SpecialistId && x.MaintenanceProviderId == mta.MaintenanceProviderId);
            db.SpecialistPendingTeamInvitations.Remove(invitation);
            db.SaveChanges();

            //JQuery Success
            return View();

        }







        //Current Provider

        public ActionResult CurrentProvider()
        {
            var ownerId = UserHelper.GetOwnerID();

            return View(db.SpecialistPendingTeamInvitations.Where(x=>x.MaintenanceProviderId == ownerId).ToList());
        }


        // Manage Provider

        public ActionResult ManageProvider()
        {
            return View(db.SpecialistPendingTeamInvitations.ToList());
        }


        public ActionResult RemoveTeamAssociation()
        {
            return View();
        }








        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }















    }
}
