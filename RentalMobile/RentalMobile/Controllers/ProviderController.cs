using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PagedList;
using RentalMobile.Helpers;
using RentalMobile.ModelViews;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    [Authorize]
    public class ProviderController : Controller
    {
        public DB_33736_rentalEntities Db = new DB_33736_rentalEntities();
        public string Username = UserHelper.GetUserName();
        public string RequestId;
        public string PhotoPath;
        public static int SelectedTeam = 0;
        public static int SelectedProfessionalId = 0;

        public ViewResult Index()
        {
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderID());
            ViewBag.ProviderProfile = provider;
            ViewBag.ProviderId = provider.MaintenanceProviderId;
            var maintenanceTeamAssociation = Db.MaintenanceTeamAssociations.FirstOrDefault(x => x.MaintenanceProviderId == provider.MaintenanceProviderId);
            if (maintenanceTeamAssociation != null)
            {
                ViewBag.TeamId = maintenanceTeamAssociation.TeamId;
                ViewBag.TeamName = maintenanceTeamAssociation.TeamName;
            }
            ViewBag.ProviderGoogleMap = provider.GoogleMap;
            return View(provider);
        }


/// <summary>
/// Only 1 team can exist
/// </summary>
        public PartialViewResult _Team()
        {
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderID());
            var checkteamexistance =
                Db.MaintenanceTeamAssociations.FirstOrDefault(
                    x => x.MaintenanceProviderId == provider.MaintenanceProviderId);
            var allTeamAssociations = Db.MaintenanceTeamAssociations.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId).ToList();
            if (checkteamexistance != null)
            {
                ViewBag.TeamName = checkteamexistance.TeamName;
                var team = GetProviderTeam(allTeamAssociations);
                                return PartialView(team);
            }
            return null;
        }
       
        private List<Teammate> GetProviderTeam(IEnumerable<MaintenanceTeamAssociation> team)
        {
            var myTeam = (from i in team
                          let currentspecialist = Db.Specialists.Find(i.SpecialistId)
                           select new Teammate
                              {
                                  SpecialistId = i.SpecialistId,
                                  SpecialistName = currentspecialist.FirstName + currentspecialist.LastName,
                                  YearofExperience = GetSpecialistYearofExperience(i.SpecialistId),
                                  SpecialistImageProfile = currentspecialist.Photo
                              }).ToList();
            return myTeam;
        }

        public int GetSpecialistYearofExperience(int specialistId)
        {
            const int specialistrole = 1;
            var lookUp = Db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.Role == specialistrole && x.UserId == specialistId);
            return lookUp == null ? 0 : Db.MaintenanceCompanySpecializations.Find(lookUp.CompanyId).Years_Experience;
        }











        

        public ActionResult Edit(int id)
        {
            var provider = Db.MaintenanceProviders.Find(id);
            return View(provider);
        }

        //
        // POST: /Provider/Edit/5

        [HttpPost]
        public ActionResult Edit(MaintenanceProvider Provider)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(Provider).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Provider);
        }


        //
        // GET: /Provider/Edit/5

        public ActionResult ChangeAddress(int id)
        {
            MaintenanceProvider Provider = Db.MaintenanceProviders.Find(id);
            return View(Provider);
        }

        //
        // POST: /Provider/Edit/5

        [HttpPost]
        public ActionResult ChangeAddress(MaintenanceProvider Provider)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(Provider).State = EntityState.Modified;
                Provider.GoogleMap = string.IsNullOrEmpty(Provider.Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(Provider.Address, Provider.City, Provider.CountryCode);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Provider);
        }

        //
        // GET: /Provider/Delete/5

        public ActionResult Delete(int id)
        {
            MaintenanceProvider Provider = Db.MaintenanceProviders.Find(id);
            return View(Provider);
        }

        //
        // POST: /Provider/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MaintenanceProvider Provider = Db.MaintenanceProviders.Find(id);
            Db.MaintenanceProviders.Remove(Provider);
            Db.SaveChanges();



            //// Delete All associated records

            //var Providershowing = Db.ProviderShowings.Where(x => x.ProviderId == id).ToList();
            //foreach (var x in Providershowing)
            //{
            //    Db.ProviderShowings.Remove(x);
            //}
            //Db.SaveChanges();




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

        //    var Providerfavorite =  Db.ProviderFavorites.Where(x => x.ProviderId == 2 && x.FavoriteId == id).FirstOrDefault();
        //    //Provider Provider = Db.ProviderFavorites.Where(Provider == 6 && )
        //    return PartialView("_ProviderFavDetail",Providerfavorite);
        //}





        //Continue from here like OWner for pendingm, accpeted and rejected
        public ActionResult NewJobOffer()
        {
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderID());

            return View(Db.MaintenanceProviderAcceptedJobs.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId).ToList());
        }















        /// <summary>
        /// ADDITION OF ADDMEMBER THE NEW WAY
        /// </summary>
        /// <returns></returns>


        public ActionResult AddTeamMember(int page = 1)
        {
            //Get all specialist that don't have pending association or all already associated with the Team

            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderID());
            var existingTeamAssociation = Db.MaintenanceTeamAssociations.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId).Select(x => x.SpecialistId).ToList();
            var pendingTeamAssociation = Db.SpecialistPendingTeamInvitations.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId).Select(x => x.SpecialistID).ToList();
            var mergedExistingandPendingTeamAssociation = new List<int>(existingTeamAssociation.Union(pendingTeamAssociation));
            var excludedSpecialistList = Db.Specialists.Where(x => mergedExistingandPendingTeamAssociation.Contains(x.SpecialistId));
            var filterSpecialistList = Db.Specialists.Except(excludedSpecialistList).OrderBy(x=>x.SpecialistId).ToPagedList(page, 10);

            return View(filterSpecialistList);

        }



        public ActionResult SelectedTeamMember(int id)
        {


            SelectedTeam = id;

            //Get all specialist that don't have pending association or all already associated with the Team

            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderID());
            var teamcount = Db.MaintenanceTeams.Count(x => x.MaintenanceProviderId == provider.MaintenanceProviderId);
            if (teamcount == 0)
            {
                return RedirectToAction("Create", "Team");
            }
            else
            {
                return RedirectToAction("SelectTeam", "Provider", new { id });
            }


        }









        public ActionResult SelectTeam(int id, int page = 1 )
        {
            SelectedProfessionalId = id;
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderID());
            var currentTeam =
                Db.MaintenanceTeams.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId).OrderBy(x => x.TeamId).ToPagedList(page, 10);
            return View(currentTeam);
        }

        public ActionResult ChosenTeam(int id)
        {
            SelectedTeam = id;
            return RedirectToAction("InviteTeamMember");
        }



        public ActionResult InviteTeamMember()
        {
            var test = SelectedProfessionalId;
            var test2 = SelectedTeam;
            return View(Db.MaintenanceTeams.Where(x => x.TeamId == SelectedTeam));
        }


        //Problem TeamID and Team Name are not passed yet
        [HttpPost]
        public ActionResult InviteTeamMember(MaintenanceTeam team)
        {
            var tid = SelectedTeam;
            var selectedteam = Db.MaintenanceTeams.FirstOrDefault(x => x.TeamId == tid);
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderID());

            var proid = provider.MaintenanceProviderId;
            if (selectedteam != null)
            {
                var npti = new SpecialistPendingTeamInvitation
                    {

                        MaintenanceProviderId = proid,
                        SpecialistID = SelectedProfessionalId,
                        TeamId = selectedteam.TeamId,
                        TeamName = selectedteam.TeamName
                    };
                Db.SpecialistPendingTeamInvitations.Add(npti);
            }
            Db.SaveChanges();


            //Send Confirmation to the Specialist 
            //JQuery Helper for Success
            JNotify("Your request has been completed.", "/Specialist/CurrentProvider");
            return View();
        }

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









        //[HttpPost]
        // public ActionResult AddTeamMember(Specialist specialist)
        // {
        //     //Get all specialist that don't have pending association or all already associated with the Team

        //     var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderID());
        //     var teamcount = Db.MaintenanceTeams.Count(x => x.MaintenanceProviderId == provider.MaintenanceProviderId);
        //     if (teamcount == 0)
        //     {
        //         return RedirectToAction("Create", "Team");
        //     }
        //     else
        //     {
        //         return RedirectToAction("SelectTeam", "Provider", new {id =  specialist.SpecialistId });
        //     }



        // }







        private readonly DB_33736_rentalEntities _db = new DB_33736_rentalEntities();

        //MAKE SURE THAT USER ARE AUTHENTICATED
      
        
     //   public string Username = Membership.GetUser(System.Web.HttpContext.Current.User.Identity.Name).ToString();
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
                    Db.Units.Add(u.Unit);
                    Db.UnitPricings.Add(u.UnitPricing);
                    Db.UnitFeatures.Add(u.UnitFeature);
                    Db.UnitCommunityAmenities.Add(u.UnitCommunityAmenity);
                    Db.UnitAppliances.Add(u.UnitAppliance);
                    Db.UnitInteriorAmenities.Add(u.UnitInteriorAmenity);
                    Db.UnitExteriorAmenities.Add(u.UnitExteriorAmenity);
                    Db.UnitLuxuryAmenities.Add(u.UnitLuxuryAmenity);
                    //Think if tyou need or not because of the upload control
                    //Db.UnitGalleries.Add(u.UnitGallery);
                    Db.SaveChanges();
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
            Db.Dispose();
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