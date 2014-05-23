using System;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using RentalMobile.Helpers;
using RentalMobile.ModelViews;
using RentalMobile.Models;
using PagedList;

namespace RentalMobile.Controllers
{
    [Authorize]
    public class SpecialistController : Controller
    {

        public DB_33736_rentalEntities Db = new DB_33736_rentalEntities();
        public string Username = UserHelper.GetUserName();
        public string RequestId;
        public string PhotoPath;

        public ViewResult Index()
        {
            var specialist = Db.Specialists.Find(UserHelper.GetSpecialistId());
            ViewBag.SpecialistProfile = specialist;
            ViewBag.SpecialistId = specialist.SpecialistId;
            ViewBag.SpecialistGoogleMap = specialist.GoogleMap;
            return View(specialist);
        }

        public ActionResult Edit(int id)
        {
            var specialist = Db.Specialists.Find(id);
            return View(specialist);
        }

        [HttpPost]
        public ActionResult Edit(Specialist specialist)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(specialist).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specialist);
        }

        public ActionResult ChangeAddress(int id)
        {
            var specialist = Db.Specialists.Find(id);
            return View(specialist);
        }

        [HttpPost]
        public ActionResult ChangeAddress(Specialist specialist)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(specialist).State = EntityState.Modified;
                specialist.GoogleMap = string.IsNullOrEmpty(specialist.Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(specialist.Address, specialist.City, specialist.CountryCode);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specialist);
        }

        public ActionResult Delete(int id)
        {
            var specialist = Db.Specialists.Find(id);
            return View(specialist);
        }




        /// TODO ///
        //Not Completed
        ////////////////////////More Work Needed////////////////////////
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var specialist = Db.Specialists.Find(id);
            Db.Specialists.Remove(specialist);
            Db.SaveChanges();



            //// Delete All associated records
            //var Specialistshowing = db.SpecialistShowings.Where(x => x.SpecialistId == id).ToList();
            //foreach (var x in Specialistshowing)
            //{
            //    db.SpecialistShowings.Remove(x);
            //}
            //db.SaveChanges();


            if (Roles.GetRolesForUser(User.Identity.Name).Any())
            {
                Roles.RemoveUserFromRoles(User.Identity.Name, Roles.GetRolesForUser(User.Identity.Name));
            }
            Membership.DeleteUser(User.Identity.Name);
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        /// TODO ///
        /// NOT Complete, wrong
        public ActionResult UpdateProfilePicture(int id)
        {
            return RedirectToAction("Upload", "Account", new { id });
        }
        /// TODO ///
        /// NOT Complete, wrong
        public ActionResult UploadPhoto(UnitModelView unitModelView)
        {

            var role = UserHelper.GetCurrentRole(out PhotoPath);
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

            //  SavePictures(unitModelView.Unit);
            //ViewBag.Sript = FancyBox.Fancy(unitModelView.Unit.UnitId);
            return PartialView("_UploadPhoto", unitModelView.UnitGallery);
        }

        ////////////////////////More Work Needed///////////////////////






        public ActionResult CompleteProfile()
        {
            var specialistId = UserHelper.GetSpecialistId();
            if (specialistId != null)
            {
                const int specialistrole = 1;
                var lookUp = Db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.Role == specialistrole && x.UserId == specialistId);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    var mp = new SpecialistMaintenanceProfile
                                 {
                                     MaintenanceCompanyLookUp = Db.MaintenanceCompanyLookUps.Find(companyId),
                                     MaintenanceCompany = Db.MaintenanceCompanies.Find(companyId),
                                     MaintenanceCompanySpecialization = Db.MaintenanceCompanySpecializations.Find(companyId),
                                     MaintenanceCustomService = Db.MaintenanceCustomServices.Find(companyId),
                                     MaintenanceExterior = Db.MaintenanceExteriors.Find(companyId),
                                     MaintenanceInterior = Db.MaintenanceInteriors.Find(companyId),
                                     MaintenanceNewConstruction = Db.MaintenanceNewConstructions.Find(companyId),
                                     MaintenanceRepair = Db.MaintenanceRepairs.Find(companyId),
                                     MaintenanceUtility = Db.MaintenanceUtilities.Find(companyId),
                                 };

                    return View(mp);
                }

            }
            return null;
        }

        [HttpPost]
        public ActionResult CompleteProfile(SpecialistMaintenanceProfile s)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var specialistId = UserHelper.GetSpecialistId();
                    if (specialistId != null)
                    {

                        s.MaintenanceCompanySpecialization.Currency =
                            UserHelper.GetCurrencyValue(s.MaintenanceCompanySpecialization.CurrencyID);
                        Db.Entry(s.MaintenanceCompany).State = EntityState.Modified;
                        Db.Entry(s.MaintenanceCompanyLookUp).State = EntityState.Modified;
                        Db.Entry(s.MaintenanceCompanySpecialization).State = EntityState.Modified;
                        Db.Entry(s.MaintenanceCustomService).State = EntityState.Modified;
                        Db.Entry(s.MaintenanceExterior).State = EntityState.Modified;
                        Db.Entry(s.MaintenanceInterior).State = EntityState.Modified;
                        Db.Entry(s.MaintenanceNewConstruction).State = EntityState.Modified;
                        Db.Entry(s.MaintenanceRepair).State = EntityState.Modified;
                        Db.Entry(s.MaintenanceUtility).State = EntityState.Modified;
                        Db.Entry(s.MaintenanceUtility).State = EntityState.Modified;
                        UpdateProfileCompletion(CalculateNewProfileCompletionPercentage(s.MaintenanceCompany));
                        UpdateSpecialistProfile((int)specialistId, s.MaintenanceCompany);
                        Db.SaveChanges();
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
            var specialist = Db.Specialists.FirstOrDefault(x => x.SpecialistId == specialistId);

            if (specialist == null) return;
            if (!string.IsNullOrEmpty(m.Address))
            {
                specialist.Address = m.Address;
            }
            if (!string.IsNullOrEmpty(m.Zip))
            {
                specialist.Zip = m.Zip;
            }

            if (!string.IsNullOrEmpty(m.City))
            {
                specialist.City = m.City;
            }
            if (!string.IsNullOrEmpty(m.Region))
            {
                specialist.Region = m.Region;
            }
            if (!string.IsNullOrEmpty(m.Country))
            {
                specialist.Country = m.Country;
            }
            if (!string.IsNullOrEmpty(m.Description))
            {
                specialist.Description = m.Description;
            }
            specialist.GoogleMap = m.GoogleMap = string.IsNullOrEmpty(m.Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(m.Address, m.City, m.Country);
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
            var specialistId = UserHelper.GetSpecialistId();
            if (specialistId == null) return;
            var currentspecialist = Db.Specialists.FirstOrDefault(x => x.SpecialistId == specialistId);
            if (currentspecialist != null)
                currentspecialist.PercentageofCompletion = newprofilecompletionpercentage;
        }

        public decimal? GetProfessionalRate(int specialistId)
        {
            var specialistMaintenanceCompany = Db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.UserId == specialistId);
            if (specialistMaintenanceCompany != null)
            {
                var specialistcompanyid = specialistMaintenanceCompany.CompanyId;
                var specialistcompany = Db.MaintenanceCompanySpecializations.FirstOrDefault(x => x.CompanyId == specialistcompanyid);

                if (specialistcompany != null)
                {

                    return (decimal)specialistcompany.Rate;
                }
                return null;
            }
            return null;
        }

        //********************************************PROVIDER Tab Function****************************************************
        //*********************************************************************************************************************

        public ActionResult ProviderInvitation(int page = 1)
        {
            var specialistId = UserHelper.GetSpecialistId();
            return specialistId == null ? null : View(
                Db.SpecialistPendingTeamInvitations.Where(x => x.SpecialistID == specialistId).OrderBy(x=>x.SpecialistID).
                ToPagedList(page, 10 ));
        }

        public ActionResult AcceptInvitation(int id)
        {
            var invitation = Db.SpecialistPendingTeamInvitations.Find(id);
            return View(invitation);

        }

        [HttpPost]
        public ActionResult AcceptInvitation(SpecialistPendingTeamInvitation sti)
        {
            var invitation =
                Db.SpecialistPendingTeamInvitations.FirstOrDefault(x => x.PendingTeamInvitationID == sti.PendingTeamInvitationID);

            var mti = new MaintenanceTeamAssociation
                                                 {
                                                     TeamId = sti.TeamId,
                                                     TeamName = sti.TeamName,
                                                     MaintenanceProviderId = sti.MaintenanceProviderId,
                                                     SpecialistId = sti.SpecialistID,

                                                 };

            Db.MaintenanceTeamAssociations.Add(mti);
            Db.SpecialistPendingTeamInvitations.Remove(invitation);
            AddSpecialistZoneToProviderTeamZone(sti.MaintenanceProviderId, sti.SpecialistID);
            Db.SaveChanges();
            var teamcoverageUpdate = new UpdateCoverage(sti.MaintenanceProviderId, sti.SpecialistID);
            teamcoverageUpdate.AddAllCoverageFromSpecialistToTeam();
            JNotify("Your request has been completed.", "/Specialist/CurrentProvider");
            return RedirectToAction("CurrentProvider");

        }

        public void AddSpecialistZoneToProviderTeamZone(int providerId, int specialistId)
        {
            var specialist = Db.Specialists.FirstOrDefault(x => x.SpecialistId == specialistId);
            {
                var teamMemberCount = 0;
                var maintenanceProviderZones = Db.MaintenanceProviderZones.Where(x => x.MaintenanceProviderId == providerId).ToList();
                if (maintenanceProviderZones.Exists(x => specialist != null && x.ZipCode == specialist.Zip))
                {
                    return;
                }
                if (maintenanceProviderZones.Any())
                {
                    teamMemberCount =
                        Db.MaintenanceTeamAssociations.Count(x => x.MaintenanceProviderId == providerId);
                }
                if (specialist != null)
                    Db.MaintenanceProviderZones.Add(
                        new MaintenanceProviderZone
                            {
                                CityName = specialist.City,
                                Country = specialist.Country,
                                MaintenanceProviderId = providerId,
                                ZipCode = specialist.Zip,
                                TeamMemberCount = teamMemberCount + 1

                            }
                        );
                Db.SaveChanges();
            }
        }

        public ActionResult DenyInvitation(int id)
        {
            var invitation = Db.SpecialistPendingTeamInvitations.Find(id);
            return View(invitation);

        }

        [HttpPost]
        public ActionResult DenyInvitation(SpecialistPendingTeamInvitation sti)
        {
            var invitation =
                Db.SpecialistPendingTeamInvitations.FirstOrDefault(x => x.PendingTeamInvitationID == sti.PendingTeamInvitationID);
            Db.SpecialistPendingTeamInvitations.Remove(invitation);
            Db.SaveChanges();
            JNotify("Your request has been completed.", "~/Specialist/ProviderInvitation");
            return RedirectToAction("CurrentProvider");

        }

        public ActionResult CurrentProvider(int page = 1)
        {
            var specialistId = UserHelper.GetSpecialistId();
            return View(Db.MaintenanceTeamAssociations.Where(x => x.SpecialistId == specialistId).OrderBy(x => x.SpecialistId).
                ToPagedList(page, 10));
        }

        public ActionResult ManageProvider(int page = 1)
        {
            var specialistId = UserHelper.GetSpecialistId();
            return View(Db.MaintenanceTeamAssociations.Where(x => x.SpecialistId == specialistId).OrderBy(x => x.SpecialistId).
                ToPagedList(page, 10));
        }

        public ActionResult RemoveTeamAssociation(int id)
        {
            var maintenanceteamassociation = Db.MaintenanceTeamAssociations.Find(id);
            return View(maintenanceteamassociation);
        }

        [HttpPost]
        public ActionResult RemoveTeamAssociation(MaintenanceTeamAssociation mta)
        {
            var maintenanceteamassociation = Db.MaintenanceTeamAssociations.FirstOrDefault(x => x.TeamAssociationID == mta.TeamAssociationID);
            Db.MaintenanceTeamAssociations.Remove(maintenanceteamassociation);
            Db.SaveChanges();

            JNotify("Your request has been completed.", "~/Specialist/CurrentProvider");

            //JQuery Success
            return RedirectToAction("CurrentProvider");
        }

        //********************************************PROVIDER Tab Function****************************************************
        //*********************************************************************************************************************


        //********************************************COVERAGE Tab Function****************************************************
        //*********************************************************************************************************************

        public PartialViewResult  _Coverage()
        {
            var specialistId = UserHelper.GetSpecialistId();
            if (specialistId != null)
            {
                const int specialistrole = 1;
                var lookUp =
                    Db.MaintenanceCompanyLookUps.FirstOrDefault(
                        x => x.Role == specialistrole && x.UserId == specialistId);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    var mp = new SpecialistMaintenanceProfile
                        {
                            MaintenanceCompanyLookUp = Db.MaintenanceCompanyLookUps.Find(companyId),
                            MaintenanceCompany = Db.MaintenanceCompanies.Find(companyId),
                            MaintenanceCompanySpecialization = Db.MaintenanceCompanySpecializations.Find(companyId),
                            MaintenanceCustomService = Db.MaintenanceCustomServices.Find(companyId),
                            MaintenanceExterior = Db.MaintenanceExteriors.Find(companyId),
                            MaintenanceInterior = Db.MaintenanceInteriors.Find(companyId),
                            MaintenanceNewConstruction = Db.MaintenanceNewConstructions.Find(companyId),
                            MaintenanceRepair = Db.MaintenanceRepairs.Find(companyId),
                            MaintenanceUtility = Db.MaintenanceUtilities.Find(companyId),
                        };

                    return PartialView(mp);
                }
            }
            return null;
        }

        //********************************************COVERAGE Tab Function****************************************************
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

        public ActionResult Confirmation()
        {
            JNotify("Your request has been completed.", "/Specialist/CurrentProvider");
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            Db.Dispose();
            base.Dispose(disposing);
        }










        //////////////Maybe Needed for Future Option///////////
        //DETAIL OF Specialist FAVORITE

        //public PartialViewResult FavoriteDetails(int id)
        //{

        //    var Specialistfavorite =  db.SpecialistFavorites.Where(x => x.SpecialistId == 2 && x.FavoriteId == id).FirstOrDefault();
        //    //Specialist Specialist = db.SpecialistFavorites.Where(Specialist == 6 && )
        //    return PartialView("_SpecialistFavDetail",Specialistfavorite);
        //}

        //////////////Maybe Needed for Future Option///////////

    }
}
