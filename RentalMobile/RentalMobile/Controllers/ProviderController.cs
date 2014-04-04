using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using PagedList;
using RentalMobile.Helpers;
using RentalMobile.ModelViews;
using RentalMobile.Models;
using Email = Postal.Email;

namespace RentalMobile.Controllers
{
    [Authorize]
    public class ProviderController : Controller
    {
        public DB_33736_rentalEntities Db = new DB_33736_rentalEntities();
        public string Username = UserHelper.GetUserName();
        public string RequestId;
        public static int SelectedTeam = 0;
        public static int SelectedProfessionalId = 0;

        public ViewResult Index()
        {
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderId());
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

        public PartialViewResult _Coverage()
        {
            var providerId = UserHelper.GetProviderId();
            if (providerId != null)
            {
                const int providerrole = 2;
                var lookUp =
                    Db.MaintenanceCompanyLookUps.FirstOrDefault(
                        x => x.Role == providerrole && x.UserId == providerId);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    var mp = new ProviderMaintenanceProfile
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

        /// <summary>
        /// Only 1 team can exist
        /// </summary>
        public PartialViewResult _Team()
        {
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderId());
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










       //********************************* WIP **********************************//
        public ActionResult CompleteProfile()
        {
            var providerId = UserHelper.GetProviderId();
            if (providerId != null)
            {
                const int providerrole = 2;
                var lookUp = Db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.Role == providerrole && x.UserId == providerId);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    var mp = new ProviderMaintenanceProfile
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
        public ActionResult CompleteProfile(ProviderMaintenanceProfile s)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var providerId = UserHelper.GetProviderId();
                    if (providerId != null)
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
                        UpdateproviderProfile((int)providerId, s.MaintenanceCompany);
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

        private void UpdateproviderProfile(int providerId, MaintenanceCompany m)
        {
            var provider = Db.MaintenanceProviders.FirstOrDefault(x => x.MaintenanceProviderId == providerId);

            if (provider == null) return;
            if (!string.IsNullOrEmpty(m.Address))
            {
                provider.Address = m.Address;
            }
            if (!string.IsNullOrEmpty(m.City))
            {
                provider.City = m.City;
            }
            if (!string.IsNullOrEmpty(m.Country))
            {
                provider.Country = m.Country;
            }
            if (!string.IsNullOrEmpty(m.Description))
            {
                provider.Description = m.Description;
            }
            if (!string.IsNullOrEmpty(m.Address))
            {
                provider.Address = m.Address;
            }
            if (!string.IsNullOrEmpty(m.Address))
            {
                provider.Address = m.Address;
            }
            if (!string.IsNullOrEmpty(m.Address))
            {
                provider.Address = m.Address;
            }
            if (!string.IsNullOrEmpty(m.Address))
            {
                provider.Address = m.Address;
            }
            provider.GoogleMap = m.GoogleMap = string.IsNullOrEmpty(m.Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(m.Address, m.City, m.Country);
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
            var providerId = UserHelper.GetProviderId();
            if (providerId == null) return;
            var currentprovider = Db.MaintenanceProviders.FirstOrDefault(x => x.MaintenanceProviderId == providerId);
            if (currentprovider != null)
                currentprovider.PercentageofCompletion = newprofilecompletionpercentage;
        }

        public decimal? GetProfessionalRate(int providerId)
        {
            var providerMaintenanceCompany = Db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.UserId == providerId);
            if (providerMaintenanceCompany != null)
            {
                var providercompanyid = providerMaintenanceCompany.CompanyId;
                var providercompany = Db.MaintenanceCompanySpecializations.FirstOrDefault(x => x.CompanyId == providercompanyid);

                if (providercompany != null)
                {

                    return (decimal)providercompany.Rate;
                }
                return null;
            }
            return null;
        }
        //********************************* WIP **********************************//













        //******************************************************************************************************//
        /// <summary>
        /// Account Tab
        /// To Complete:
        ///     -1-Delete All associated records
        /// </summary>
        public ActionResult Edit(int id)
        {
            var provider = Db.MaintenanceProviders.Find(id);
            return View(provider);
        }

        [HttpPost]
        public ActionResult Edit(MaintenanceProvider provider)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(provider).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provider);
        }

        public ActionResult ChangeAddress(int id)
        {
            var provider = Db.MaintenanceProviders.Find(id);
            return View(provider);
        }

        [HttpPost]
        public ActionResult ChangeAddress(MaintenanceProvider provider)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(provider).State = EntityState.Modified;
                provider.GoogleMap = string.IsNullOrEmpty(provider.Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(provider.Address, provider.City, provider.CountryCode);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provider);
        }

        public ActionResult Delete(int id)
        {
            MaintenanceProvider provider = Db.MaintenanceProviders.Find(id);
            return View(provider);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MaintenanceProvider provider = Db.MaintenanceProviders.Find(id);
            Db.MaintenanceProviders.Remove(provider);
            Db.SaveChanges();



            //TODO// Delete All associated records

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


        //******************************************************************************************************//
        /// <summary>
        /// Account Tab
        /// To Complete:
        ///     -1-Delete All associated records
        /// </summary>







        












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
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderId());

            return View(Db.MaintenanceProviderAcceptedJobs.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId).ToList());
        }














        //******************************************************************************************************//
        /// <summary>
        /// Team Tab
        /// Finished and Clean
        /// </summary>
        public ActionResult AddTeamMember(int page = 1)
        {
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderId());
            var existingTeamAssociation = Db.MaintenanceTeamAssociations.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId).Select(x => x.SpecialistId).ToList();
            var pendingTeamAssociation = Db.SpecialistPendingTeamInvitations.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId).Select(x => x.SpecialistID).ToList();
            var mergedExistingandPendingTeamAssociation = new List<int>(existingTeamAssociation.Union(pendingTeamAssociation));
            var excludedSpecialistList = Db.Specialists.Where(x => mergedExistingandPendingTeamAssociation.Contains(x.SpecialistId));
            var filterSpecialistList = Db.Specialists.Except(excludedSpecialistList).OrderBy(x=>x.SpecialistId).ToPagedList(page, 10);
            return View(filterSpecialistList);
        }

        public ActionResult SelectTeam(int pid, int page = 1)
        {
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderId());
            ViewBag.SelectedSpecialistId = pid;
            var currentTeam =
                Db.MaintenanceTeams.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId).OrderBy(x => x.TeamId).ToPagedList(page, 10);
            return View(currentTeam);
        }

        public ActionResult InviteTeamMember(int stid, int pid)
        {
            ViewBag.SelectedSpecialistId = pid;
            ViewBag.SelectedTeamId = stid;
            return View(Db.MaintenanceTeams.Where(x => x.TeamId == stid));
        }

        [HttpPost]
        public ActionResult InviteTeamMember( MaintenanceTeam team)
        {
            if (Request.Params["stid"] == null || Request.Params["pid"] == null)
            {
                return RedirectToAction("AddTeamMember");
            }
            var tid = Convert.ToInt32(Request.Params["stid"]);
            var selectedteam = Db.MaintenanceTeams.FirstOrDefault(x => x.TeamId == tid);
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderId());
            var proid = provider.MaintenanceProviderId;
            if (selectedteam != null)
            {
                var npti = new SpecialistPendingTeamInvitation
                    {
                        MaintenanceProviderId = proid,
                        SpecialistID =  Convert.ToInt32(Request.Params["pid"]),
                        TeamId = selectedteam.TeamId,
                        TeamName = selectedteam.TeamName
                    };
                Db.SpecialistPendingTeamInvitations.Add(npti);
            }
            Db.SaveChanges();
            InviteSpecialist(Convert.ToInt32(Request.Params["stid"]), Convert.ToInt32(Request.Params["pid"]));
            JNotify("Your request has been completed.", "/Provider/#team");
            return View();
        }

        public void InviteSpecialist(int stid, int pid)
        {
            dynamic email = new Email("InviteSpecialistToJoinTeam/Multipart");
            var poster = UserHelper.GetSendtoFriendPoster() ?? UserHelper.DefaultPoster;
            var selectedspecialist = Db.Specialists.FirstOrDefault(x => x.SpecialistId == pid);
            if (selectedspecialist == null) return;
            email.To = selectedspecialist.EmailAddress;
            email.From = "postmaster@haithem-araissia.com";
            email.SenderFirstName = poster.FirstName;
            email.Title = string.Format("Invitation From {0}", poster.FirstName);
            email.SubTitle = "Invitation from ";
            email.ProviderProfileUrl = poster.ProfileLink;
            email.ProviderFirstName = poster.FirstName;
            email.SpecialistFirstName = selectedspecialist.FirstName;
            email.InvitationNote = " invite you to join the team.";
            email.FooterNote = "Check out this invitation";
            try
            {
                email.SendAsync();
            }
            catch (Exception)
            {
                RedirectToAction("AddTeamMember");
            }
        }

        public ActionResult RemoveTeamMember(int page = 1)
        {
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderId());
            var existingTeamAssociation = Db.MaintenanceTeamAssociations.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId).Select(x => x.SpecialistId).ToList();
            var mergedExistingandPendingTeamAssociation = Db.Specialists.
                                          Where(x => existingTeamAssociation.Contains(x.SpecialistId));
            var filterSpecialistList = mergedExistingandPendingTeamAssociation.OrderBy(x => x.SpecialistId).ToPagedList(page, 10);
            return View(filterSpecialistList);
        }

        public ActionResult RemoveFromTeam(int pid, int page = 1)
        {
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderId());
            ViewBag.SelectedSpecialistId = pid;
            var currentTeam =
                Db.MaintenanceTeamAssociations.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId && x.SpecialistId == pid).OrderBy(x => x.TeamId).ToPagedList(page, 10);
            return View(currentTeam);
        }

        public ActionResult RemoveMember(int stid, int pid)
        {
            ViewBag.SelectedSpecialistId = pid;
            ViewBag.SelectedTeamId = stid;
            return View(Db.MaintenanceTeams.Where(x => x.TeamId == stid));
        }

        [HttpPost]
        public ActionResult RemoveMember(MaintenanceTeam team)
        {
            if (Request.Params["stid"] == null || Request.Params["pid"] == null)
            {
                return RedirectToAction("AddTeamMember");
            }
            int pid = Convert.ToInt32(Request.Params["pid"]);
            int sid = Convert.ToInt32(Request.Params["stid"]);
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderId());
            var currentspecialist = Db.MaintenanceTeamAssociations.FirstOrDefault(
                                    x => x.MaintenanceProviderId == provider.MaintenanceProviderId 
                                &&  x.SpecialistId == pid 
                                &&  x.TeamId == sid);
            if (currentspecialist != null)
            {
                Db.MaintenanceTeamAssociations.Remove(currentspecialist);
                Db.SaveChanges();
            }
            RemoveSpecialist(Convert.ToInt32(Request.Params["stid"]), Convert.ToInt32(Request.Params["pid"]));
            JNotify("Your request has been completed.", "/Provider/#team");
            return View();
        }

        public void RemoveSpecialist(int stid, int pid)
        {
            dynamic email = new Email("RemoveSpecialistForTeam/Multipart");
            var poster = UserHelper.GetSendtoFriendPoster() ?? UserHelper.DefaultPoster;
            var selectedspecialist = Db.Specialists.FirstOrDefault(x => x.SpecialistId == pid);
            if (selectedspecialist == null) return;
            email.To = selectedspecialist.EmailAddress;
            email.From = "postmaster@haithem-araissia.com";
            email.SenderFirstName = poster.FirstName;
            email.Title = string.Format("Notification From {0}", poster.FirstName);
            email.SubTitle = "Notification from ";
            email.ProviderProfileUrl = poster.ProfileLink;
            email.ProviderFirstName = poster.FirstName;
            email.SpecialistFirstName = selectedspecialist.FirstName;
            email.InvitationNote = " invite you to join the team.";
            email.FooterNote = "Check out this invitation";
            try
            {
                email.SendAsync();
            }
            catch (Exception)
            {
                RedirectToAction("RemoveTeamMember");
            }
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
        //******************************************************************************************************//
        /// <summary>
        /// Team Tab
        /// Finished and Clean
        /// </summary>










        //*************************************** WORK NOT COMPLETED***************************************//
        //*************************************************************************************************//
        //*************************************************************************************************//


        //MAKE SURE THAT USER ARE AUTHENTICATED
      
        
     //   public string Username = Membership.GetUser(System.Web.HttpContext.Current.User.Identity.Name).ToString();
        //MAKE SURE THAT USER ARE AUTHENTICATED

        public string TenantPhotoPath = "~/Photo/Tenant/Property";
        public string OwnerPhotoPath = "~/Photo/Owner/Property";
        public string AgentPhotoPath = "~/Photo/Agent/Property";
        public string ProviderPhotoPath = "~/Photo/Provider/Property";
        public string SpecialistPhotoPath = "~/Photo/Specialist/Property";
        public string RequestID;
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

        //public ActionResult CompleteProfile()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public ActionResult CompleteProfile(UnitModelView u)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            Db.Units.Add(u.Unit);
        //            Db.UnitPricings.Add(u.UnitPricing);
        //            Db.UnitFeatures.Add(u.UnitFeature);
        //            Db.UnitCommunityAmenities.Add(u.UnitCommunityAmenity);
        //            Db.UnitAppliances.Add(u.UnitAppliance);
        //            Db.UnitInteriorAmenities.Add(u.UnitInteriorAmenity);
        //            Db.UnitExteriorAmenities.Add(u.UnitExteriorAmenity);
        //            Db.UnitLuxuryAmenities.Add(u.UnitLuxuryAmenity);
        //            //Think if tyou need or not because of the upload control
        //            //Db.UnitGalleries.Add(u.UnitGallery);
        //            Db.SaveChanges();
        //            // SavePictures(u.Unit);
        //            return RedirectToAction("Index");
        //        }
        //        return View(u);
        //    }


        //    catch (DbEntityValidationException e)
        //    {
        //        foreach (var eve in e.EntityValidationErrors)
        //        {
        //            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
        //                              eve.Entry.Entity.GetType().Name, eve.Entry.State);
        //            foreach (var ve in eve.ValidationErrors)
        //            {
        //                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
        //                                  ve.PropertyName, ve.ErrorMessage);
        //            }
        //        }
        //        throw;
        //    }



        //}

        //*************************************** WORK NOT COMPLETED***************************************//
        //*************************************************************************************************//
        //*************************************************************************************************//







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