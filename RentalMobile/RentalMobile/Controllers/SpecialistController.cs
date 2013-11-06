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


        public ViewResult Index()
        {
            var specialist = db.Specialists.Find(UserHelper.GetSpecialistID());
            ViewBag.SpecialistProfile = specialist;
            ViewBag.SpecialistId = specialist.SpecialistId;
            ViewBag.SpecialistGoogleMap = specialist.GoogleMap;
            return View(specialist);
        }

        public ActionResult Edit(int id)
        {
            Specialist Specialist = db.Specialists.Find(id);
            return View(Specialist);
        }

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
















        ///////////////////////////TO DO///////////////////////////////////////////////
        /// <summary>
        /// Need to replace the call to this function with the call to the paramterized function
        /// </summary>
        /// <returns></returns>

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
	  	                        
	  	                          window.location.href = '/Specialist/ProviderInvitation'); 
	   
	  	                }
		             });

";
            return jNotifyConfirmationScript;
        }


        /// <summary>
        /// Used for Testing;
        /// Delete when no needed
        /// </summary>
        /// <returns></returns>
        public ActionResult Confirmation()
        {
            JNotify("Your request has been completed.", "/Specialist/CurrentProvider");
            return View();
        }

        ///////////////////////////TO DO///////////////////////////////////////////////









        //********************************************PROVIDER Tab Function****************************************************
        //*********************************************************************************************************************

        public ActionResult ProviderInvitation()
        {
            var specialistId = Helpers.UserHelper.GetSpecialistID();
            return specialistId == null ? null : View(db.SpecialistPendingTeamInvitations.Where(x => x.SpecialistID == specialistId).ToList());
        }

        public ActionResult AcceptInvitation(int id)
        {
            var invitation = db.SpecialistPendingTeamInvitations.Find(id);
            return View(invitation);

        }

        [HttpPost]
        public ActionResult AcceptInvitation(SpecialistPendingTeamInvitation sti)
        {
            var invitation =
                db.SpecialistPendingTeamInvitations.FirstOrDefault(x => x.PendingTeamInvitationID == sti.PendingTeamInvitationID);

            var mti = new MaintenanceTeamAssociation
                                                 {
                                                     TeamId = sti.TeamId,
                                                     TeamName = sti.TeamName,
                                                     MaintenanceProviderId = sti.MaintenanceProviderId,
                                                     SpecialistId = sti.SpecialistID,

                                                 };

            db.MaintenanceTeamAssociations.Add(mti);
            db.SpecialistPendingTeamInvitations.Remove(invitation);
            db.SaveChanges();

            JNotify("Your request has been completed.", "/Specialist/CurrentProvider");

            //JQuery Success
            return RedirectToAction("CurrentProvider");

        }

        public ActionResult DenyInvitation(int id)
        {
            var invitation = db.SpecialistPendingTeamInvitations.Find(id);
            return View(invitation);

        }

        [HttpPost]
        public ActionResult DenyInvitation(SpecialistPendingTeamInvitation sti)
        {
            var invitation =
                db.SpecialistPendingTeamInvitations.FirstOrDefault(x => x.PendingTeamInvitationID == sti.PendingTeamInvitationID);
            db.SpecialistPendingTeamInvitations.Remove(invitation);
            db.SaveChanges();
            JNotify("Your request has been completed.", "~/Specialist/ProviderInvitation");

            //JQuery Success
            return RedirectToAction("CurrentProvider");

        }

        public ActionResult CurrentProvider()
        {
            var specialistId = UserHelper.GetSpecialistID();

            return View(db.MaintenanceTeamAssociations.Where(x => x.SpecialistId == specialistId).ToList());
        }

        public ActionResult ManageProvider()
        {
            var specialistId = UserHelper.GetSpecialistID();
            return View(db.MaintenanceTeamAssociations.Where(x => x.SpecialistId == specialistId).ToList());
        }

        public ActionResult RemoveTeamAssociation(int id)
        {
            var maintenanceteamassociation = db.MaintenanceTeamAssociations.Find(id);
            return View(maintenanceteamassociation);
        }

        [HttpPost]
        public ActionResult RemoveTeamAssociation(MaintenanceTeamAssociation mta)
        {
            var maintenanceteamassociation = db.MaintenanceTeamAssociations.FirstOrDefault(x => x.TeamAssociationID == mta.TeamAssociationID);
            db.MaintenanceTeamAssociations.Remove(maintenanceteamassociation);
            db.SaveChanges();

            JNotify("Your request has been completed.", "~/Specialist/CurrentProvider");

            //JQuery Success
            return RedirectToAction("CurrentProvider");
        }

        //********************************************PROVIDER Tab Function****************************************************
        //*********************************************************************************************************************

        //***********************************************JQuery HELPER*********************************************************
        //*********************************************************************************************************************
        /// <summary>
        /// Parameterized JNotify Function
        /// </summary>
        /// <param name="successmessage"></param>
        /// <param name="navigateturlwhencompleted"></param>
        /// <returns></returns>

        public string JNotifyConfirmationMessage(string successmessage, string navigateturlwhencompleted)
        {

            var jNotifyConfirmationScript = @"jSuccess('" + successmessage
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
                                window.location.href = '" + navigateturlwhencompleted + @"' }});";
            return jNotifyConfirmationScript;
        }

        public void JNotify(string message = "", string url = "")
        {
            ViewBag.Confirmation = true;
            ViewBag.ConfirmationSuccess = JNotifyConfirmationMessage(message, url);
        }
        //***********************************************JQuery HELPER*********************************************************
        //*********************************************************************************************************************
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }















    }
}
