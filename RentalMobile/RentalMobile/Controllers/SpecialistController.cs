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

        public DB_33736_rentalEntities DB = new DB_33736_rentalEntities();
        public string Username = UserHelper.GetUserName();
        public string TenantPhotoPath = "~/Photo/Tenant/Property";
        public string OwnerPhotoPath = "~/Photo/Owner/Property";
        public string AgentPhotoPath = "~/Photo/Agent/Property";
        public string ProviderPhotoPath = "~/Photo/Provider/Property";
        public string SpecialistPhotoPath = "~/Photo/Specialist/Property";
        public string RequestID;
        public string PhotoPath;

        public ViewResult Index()
        {
            var specialist = DB.Specialists.Find(UserHelper.GetSpecialistID());
            ViewBag.SpecialistProfile = specialist;
            ViewBag.SpecialistId = specialist.SpecialistId;
            ViewBag.SpecialistGoogleMap = specialist.GoogleMap;
            return View(specialist);
        }

        public ActionResult Edit(int id)
        {
            Specialist specialist = DB.Specialists.Find(id);
            return View(specialist);
        }

        [HttpPost]
        public ActionResult Edit(Specialist specialist)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(specialist).State = EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specialist);
        }

        public ActionResult ChangeAddress(int id)
        {
            Specialist Specialist = DB.Specialists.Find(id);
            return View(Specialist);
        }

        [HttpPost]
        public ActionResult ChangeAddress(Specialist Specialist)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(Specialist).State = EntityState.Modified;
                Specialist.GoogleMap = string.IsNullOrEmpty(Specialist.Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(Specialist.Address, Specialist.City, Specialist.CountryCode);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Specialist);
        }

        public ActionResult Delete(int id)
        {
            Specialist Specialist = DB.Specialists.Find(id);
            return View(Specialist);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Specialist Specialist = DB.Specialists.Find(id);
            DB.Specialists.Remove(Specialist);
            DB.SaveChanges();



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


        public ActionResult CompleteProfile()
        {
            var specialistId = UserHelper.GetSpecialistID();
            if (specialistId != null)
            {
                const int specialistrole = 1;
                var lookUp = DB.MaintenanceCompanyLookUps.FirstOrDefault(x => x.Role == specialistrole && x.UserId == specialistId);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    var mp = new SpecialistMaintenanceProfile
                                 {
                                     MaintenanceCompanyLookUp = DB.MaintenanceCompanyLookUps.Find(companyId),
                                     MaintenanceCompany = DB.MaintenanceCompanies.Find(companyId),
                                     MaintenanceCompanySpecialization = DB.MaintenanceCompanySpecializations.Find(companyId),
                                     MaintenanceCustomService = DB.MaintenanceCustomServices.Find(companyId),
                                     MaintenanceExterior = DB.MaintenanceExteriors.Find(companyId),
                                     MaintenanceInterior = DB.MaintenanceInteriors.Find(companyId),
                                     MaintenanceNewConstruction = DB.MaintenanceNewConstructions.Find(companyId),
                                     MaintenanceRepair = DB.MaintenanceRepairs.Find(companyId),
                                     MaintenanceUtility = DB.MaintenanceUtilities.Find(companyId),
                                 };

                    return View(mp);
                }

            }
            return null;




            //When CREATING NEW SPECIALIST
            //CREATE THE RECORDS

            //TO COMPLETE PROFILE
            //UPDATE RECORDS


            //            About
            //MaintenanceCompany
            //MaintenanceCompanySpecialization

            //Coverage
            //Exteriors
            //Interiors

            //Services
            //Maintenance and Repairs
            //Constructions

            //Feature
            //Custom Services
            //Utilities



            //var mp = new SpecialistMaintenanceProfile
            //    {
            //        MaintenanceCompanyLookUp = NotFiniteNumberException.
            //    }


            //                var u = new UnitModelView
            //            {
            //                Unit = db.Units.Find(id),
            //                UnitFeature = db.UnitFeatures.Find(id),
            //                UnitAppliance = db.UnitAppliances.Find(id),
            //                UnitCommunityAmenity = db.UnitCommunityAmenities.Find(id),
            //                UnitPricing = db.UnitPricings.Find(id),
            //                UnitInteriorAmenity = db.UnitInteriorAmenities.Find(id),
            //                UnitExteriorAmenity = db.UnitExteriorAmenities.Find(id),
            //                UnitLuxuryAmenity = db.UnitLuxuryAmenities.Find(id)

            //            };
            //ViewBag.CurrencyCode = u.Unit.CurrencyCode;

            //TempData["UnitID"] = id;
            //return View(u);
            return View();
        }


        [HttpPost]
        public ActionResult CompleteProfile(SpecialistMaintenanceProfile s)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var specialistId = UserHelper.GetSpecialistID();
                    if (specialistId != null)
                    {

                        s.MaintenanceCompanySpecialization.Currency =
                            UserHelper.GetCurrencyValue(s.MaintenanceCompanySpecialization.CurrencyID);


                        DB.Entry(s.MaintenanceCompany).State = EntityState.Modified;
                        DB.Entry(s.MaintenanceCompanyLookUp).State = EntityState.Modified;
                        DB.Entry(s.MaintenanceCompanySpecialization).State = EntityState.Modified;
                        DB.Entry(s.MaintenanceCustomService).State = EntityState.Modified;
                        DB.Entry(s.MaintenanceExterior).State = EntityState.Modified;
                        DB.Entry(s.MaintenanceInterior).State = EntityState.Modified;
                        DB.Entry(s.MaintenanceNewConstruction).State = EntityState.Modified;
                        DB.Entry(s.MaintenanceRepair).State = EntityState.Modified;
                        DB.Entry(s.MaintenanceUtility).State = EntityState.Modified;
                        DB.Entry(s.MaintenanceUtility).State = EntityState.Modified;
                        UpdateProfileCompletion(CalculateNewProfileCompletionPercentage(s.MaintenanceCompany));
                        UpdateSpecialistProfile((int)specialistId, s.MaintenanceCompany);
                        ;
                        DB.SaveChanges();

                        return RedirectToAction("Index");

                    }
                }
                return View(s);
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

        private void UpdateSpecialistProfile(int specialistId, MaintenanceCompany m)
        {
            var specialist = DB.Specialists.FirstOrDefault(x => x.SpecialistId == specialistId);

            if (specialist != null)
            {


                if (!string.IsNullOrEmpty(m.Address))
                {
                    specialist.Address = m.Address;
                }
                if (!string.IsNullOrEmpty(m.City))
                {
                    specialist.City = m.City;
                }
                if (!string.IsNullOrEmpty(m.Country))
                {
                    specialist.Country = m.Country;
                }
                if (!string.IsNullOrEmpty(m.Description))
                {
                    specialist.Description = m.Description;
                }
                if (!string.IsNullOrEmpty(m.Address))
                {
                    specialist.Address = m.Address;
                }
                if (!string.IsNullOrEmpty(m.Address))
                {
                    specialist.Address = m.Address;
                }
                if (!string.IsNullOrEmpty(m.Address))
                {
                    specialist.Address = m.Address;
                }
                if (!string.IsNullOrEmpty(m.Address))
                {
                    specialist.Address = m.Address;
                }




                specialist.GoogleMap = m.GoogleMap = string.IsNullOrEmpty(m.Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(m.Address, m.City, m.Country);


            }
        }


        public int CalculateNewProfileCompletionPercentage(MaintenanceCompany m)
        {
            //Calucation of Completion
            //description = 20 ; Other = 10

            //Members of formula 
            //Name 
            //Address 
            //EmailAddress 
            //Description 
            //Country 
            //Region 
            //City 
            //Zip 
            //CountryCode

            var initialValue = 0;

            if (!string.IsNullOrEmpty(m.Name))
            {
                initialValue += 10;
            }
            if (!string.IsNullOrEmpty(m.Address))
            {
                initialValue += 10;
            }
            if (!string.IsNullOrEmpty(m.EmailAddress))
            {
                initialValue += 30;
            }
            if (!string.IsNullOrEmpty(m.Description))
            {
                initialValue += 10;
            }
            if (!string.IsNullOrEmpty(m.Region))
            {
                initialValue += 10;
            }
            if (!string.IsNullOrEmpty(m.City))
            {
                initialValue += 10;
            }
            if (!string.IsNullOrEmpty(m.Zip))
            {
                initialValue += 10;
            }
            if (!string.IsNullOrEmpty(m.Country))
            {
                initialValue += 10;
            }
            m.GoogleMap = string.IsNullOrEmpty(m.Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(m.Address, m.City, m.Country);
            return initialValue >= 50 ? initialValue : 50;
        }


        public void UpdateProfileCompletion(int newprofilecompletionpercentage)
        {
            var specialistId = UserHelper.GetSpecialistID();
            if (specialistId == null) return;
            var currentspecialist = DB.Specialists.FirstOrDefault(x => x.SpecialistId == specialistId);
            if (currentspecialist != null)
                currentspecialist.PercentageofCompletion = newprofilecompletionpercentage;
        }

        public decimal? GetProfessionalRate(int specialistId)
        {
            var specialistMaintenanceCompany = DB.MaintenanceCompanyLookUps.FirstOrDefault(x => x.UserId == specialistId);
            if (specialistMaintenanceCompany != null)
            {
                var specialistcompanyid = specialistMaintenanceCompany.CompanyId;
                var specialistcompany = DB.MaintenanceCompanySpecializations.FirstOrDefault(x => x.CompanyId == specialistcompanyid);

                if (specialistcompany != null)
                {

                    return (decimal)specialistcompany.Rate;
                }
                return null;
            }
            return null;
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
            return specialistId == null ? null : View(DB.SpecialistPendingTeamInvitations.Where(x => x.SpecialistID == specialistId).ToList());
        }

        public ActionResult AcceptInvitation(int id)
        {
            var invitation = DB.SpecialistPendingTeamInvitations.Find(id);
            return View(invitation);

        }

        [HttpPost]
        public ActionResult AcceptInvitation(SpecialistPendingTeamInvitation sti)
        {
            var invitation =
                DB.SpecialistPendingTeamInvitations.FirstOrDefault(x => x.PendingTeamInvitationID == sti.PendingTeamInvitationID);

            var mti = new MaintenanceTeamAssociation
                                                 {
                                                     TeamId = sti.TeamId,
                                                     TeamName = sti.TeamName,
                                                     MaintenanceProviderId = sti.MaintenanceProviderId,
                                                     SpecialistId = sti.SpecialistID,

                                                 };

            DB.MaintenanceTeamAssociations.Add(mti);
            DB.SpecialistPendingTeamInvitations.Remove(invitation);
            DB.SaveChanges();

            JNotify("Your request has been completed.", "/Specialist/CurrentProvider");

            //JQuery Success
            return RedirectToAction("CurrentProvider");

        }

        public ActionResult DenyInvitation(int id)
        {
            var invitation = DB.SpecialistPendingTeamInvitations.Find(id);
            return View(invitation);

        }

        [HttpPost]
        public ActionResult DenyInvitation(SpecialistPendingTeamInvitation sti)
        {
            var invitation =
                DB.SpecialistPendingTeamInvitations.FirstOrDefault(x => x.PendingTeamInvitationID == sti.PendingTeamInvitationID);
            DB.SpecialistPendingTeamInvitations.Remove(invitation);
            DB.SaveChanges();
            JNotify("Your request has been completed.", "~/Specialist/ProviderInvitation");

            //JQuery Success
            return RedirectToAction("CurrentProvider");

        }

        public ActionResult CurrentProvider()
        {
            var specialistId = UserHelper.GetSpecialistID();

            return View(DB.MaintenanceTeamAssociations.Where(x => x.SpecialistId == specialistId).ToList());
        }

        public ActionResult ManageProvider()
        {
            var specialistId = UserHelper.GetSpecialistID();
            return View(DB.MaintenanceTeamAssociations.Where(x => x.SpecialistId == specialistId).ToList());
        }

        public ActionResult RemoveTeamAssociation(int id)
        {
            var maintenanceteamassociation = DB.MaintenanceTeamAssociations.Find(id);
            return View(maintenanceteamassociation);
        }

        [HttpPost]
        public ActionResult RemoveTeamAssociation(MaintenanceTeamAssociation mta)
        {
            var maintenanceteamassociation = DB.MaintenanceTeamAssociations.FirstOrDefault(x => x.TeamAssociationID == mta.TeamAssociationID);
            DB.MaintenanceTeamAssociations.Remove(maintenanceteamassociation);
            DB.SaveChanges();

            JNotify("Your request has been completed.", "~/Specialist/CurrentProvider");

            //JQuery Success
            return RedirectToAction("CurrentProvider");
        }

        //********************************************PROVIDER Tab Function****************************************************
        //*********************************************************************************************************************

        /// <summary>
        /// JQuery PUBLIC  HELPER
        /// </summary>
        /// <param name="message"></param>
        /// <param name="url"></param>
        public void JNotify(string message = "", string url = "")
        {
            ViewBag.Confirmation = true;
            ViewBag.ConfirmationSuccess = JNotfiyScriptQueryHelper.JNotifyConfirmationMessage(message, url);
        }


        protected override void Dispose(bool disposing)
        {
            DB.Dispose();
            base.Dispose(disposing);
        }















    }
}
