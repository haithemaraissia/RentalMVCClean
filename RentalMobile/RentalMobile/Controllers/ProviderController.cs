using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using PagedList;
using RentalMobile.Helpers;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using Email = Postal.Email;

namespace RentalMobile.Controllers
{
    [Authorize]
    public class ProviderController : Controller
    {
        public RentalContext Db = new RentalContext();
        public string Username = UserHelper.GetUserName();
        public string RequestId;
        public static int SelectedTeam = 0;
        public static int SelectedProfessionalId = 0;

        public ViewResult Index()
        {
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderId());
            ViewBag.ProviderProfile = provider;
            ViewBag.ProviderId = provider.MaintenanceProviderId;
            var maintenanceTeamAssociation =
                Db.MaintenanceTeamAssociations.FirstOrDefault(
                    x => x.MaintenanceProviderId == provider.MaintenanceProviderId);
            if (maintenanceTeamAssociation != null)
            {
                ViewBag.TeamId = maintenanceTeamAssociation.TeamId;
                ViewBag.TeamName = maintenanceTeamAssociation.TeamName;
            }
            ViewBag.ProviderGoogleMap = provider.GoogleMap;
            return View(provider);
        }

        //************************************************* Coverage *********************************************//
        /// <summary>
        /// Coverage Tab
        /// Finished and Clean
        /// </summary>

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
                            MaintenanceProvider = Db.MaintenanceProviders.Find(providerId),
                            MaintenanceCompanyLookUp = Db.MaintenanceCompanyLookUps.Find(companyId),
                            MaintenanceCompany = Db.MaintenanceCompanies.Find(companyId),
                            MaintenanceCompanySpecialization = Db.MaintenanceCompanySpecializations.Find(companyId),
                            MaintenanceCustomService = Db.MaintenanceCustomServices.Find(companyId),
                            MaintenanceExterior = Db.MaintenanceExteriors.Find(companyId),
                            MaintenanceInterior = Db.MaintenanceInteriors.Find(companyId),
                            MaintenanceNewConstruction = Db.MaintenanceNewConstructions.Find(companyId),
                            MaintenanceRepair = Db.MaintenanceRepairs.Find(companyId),
                            MaintenanceUtility = Db.MaintenanceUtilities.Find(companyId)
                        };

                    return PartialView(mp);
                }
            }
            return null;
        }

        public PartialViewResult _EditCoverage()
        {
            var providerId = UserHelper.GetProviderId();
            if (providerId != null)
            {
                if (Db.MaintenanceTeams.Any(x => x.MaintenanceProviderId == providerId))
                {
                    ViewBag.HasTeam = "true";
                }
            }
            else
            {
                ViewBag.HasTeam = "false";
            }

            return PartialView();
        }

        public PartialViewResult _EditZone()
        {
            var id = UserHelper.GetProviderId();
            if (id != null)
            {
                var providerId = (int) id;
                ViewBag.TotalAvailableZoneSpot =
                    Db.MaintenanceTeamAssociations.Count(x => x.MaintenanceProviderId == providerId)*2;
                var distinctMaintenanceProviderZones =
                    Db.MaintenanceProviderZones.
                       Where(maitnenanceproviderzone => maitnenanceproviderzone.MaintenanceProviderId == providerId)
                      .GroupBy(maitnenanceproviderzone => maitnenanceproviderzone.ZipCode,
                               (key, group) => group.FirstOrDefault())
                      .OrderBy(filteredZone => filteredZone.ZipCode).
                       ToList();
                return PartialView(distinctMaintenanceProviderZones);
            }
            return null;
        }

        public PartialViewResult _ViewZone()
        {
            var id = UserHelper.GetProviderId();
            return id != null
                       ? PartialView(Db.MaintenanceProviderZones.Where(x => x.MaintenanceProviderId == id).ToList())
                       : null;
        }

        public ViewResult AddZone()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddZone(MaintenanceProviderZone maintenanceproviderzone)
        {
            var provider = UserHelper.GetProviderId();
            if (provider != null)
            {
                var providerId = (int) provider;
                var teamMemberCount = 0;
                var maintenanceProviderZones =
                    Db.MaintenanceProviderZones.Where(x => x.MaintenanceProviderId == providerId).ToList();
                if (maintenanceProviderZones.Exists(x => x.ZipCode == maintenanceproviderzone.ZipCode))
                {
                    ModelState.AddModelError("Zone Duplication ", "Zone already exist in your list");
                    JNotify("This Zone already exist in your list.", "#");
                }
                if (ModelState.IsValid)
                {
                    if (maintenanceProviderZones.Any())
                    {
                        teamMemberCount =
                            Db.MaintenanceTeamAssociations.Count(x => x.MaintenanceProviderId == providerId);
                    }
                    //Validation To Not Exceed the allowed number of zones
                    var availablezoneplaceholder =
                        Db.MaintenanceTeamAssociations.Count(x => x.MaintenanceProviderId == providerId)*2 + 1;
                    var zoneplaceholderused = Db.MaintenanceProviderZones.
                                                 Where(
                                                     maitnenanceproviderzone =>
                                                     maitnenanceproviderzone.MaintenanceProviderId == providerId)
                                                .GroupBy(maitnenanceproviderzone => maitnenanceproviderzone.ZipCode,
                                                         (key, group) => group.FirstOrDefault())
                                                .OrderBy(filteredZone => filteredZone.ZipCode).
                                                 Count();
                    if (availablezoneplaceholder > zoneplaceholderused)
                    {
                        Db.MaintenanceProviderZones.Add(
                            new MaintenanceProviderZone
                                {
                                    CityName = maintenanceproviderzone.CityName,
                                    Country = "US",
                                    MaintenanceProviderId = providerId,
                                    ZipCode = maintenanceproviderzone.ZipCode,
                                    TeamMemberCount = teamMemberCount + 1

                                }
                            );
                    }
                    Db.SaveChanges();
                    JNotify("Your zone has been added.", "/Provider/#coverage");
                    return View();
                }
            }
            return View(maintenanceproviderzone);
        }

        public ViewResult RemoveZoneList(int page = 1)
        {
            var id = UserHelper.GetProviderId();
            return id != null
                       ? View(
                           Db.MaintenanceProviderZones.Where(x => x.MaintenanceProviderId == id)
                             .ToList()
                             .ToPagedList(page, 10))
                       : null;
        }

        public ActionResult RemoveZone(int id)
        {
            MaintenanceProviderZone maintenanceproviderzone = Db.MaintenanceProviderZones.Find(id);
            return View(maintenanceproviderzone);
        }

        [HttpPost, ActionName("RemoveZone")]
        public ActionResult RemoveZoneConfirmed(int id)
        {
            var maintenanceproviderzone = Db.MaintenanceProviderZones.Find(id);
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderId());
            if (provider.Zip != null)
            {
                var providerId = UserHelper.GetProviderId();
                if (providerId != null && IsZipcodeBelongtoTeamMember((int) providerId, maintenanceproviderzone.ZipCode))
                {
                    JNotify(
                        "Your can not delete your Team Member Zone. The Zone Coverage is based upon Team Member Profile",
                        "#");
                }
                else
                {
                    if (maintenanceproviderzone.ZipCode != provider.Zip)
                    {
                        Db.MaintenanceProviderZones.Remove(maintenanceproviderzone);
                        var teamMemberCount = GetmNumberofMembersInTeam();
                        maintenanceproviderzone.TeamMemberCount = teamMemberCount - 1;
                        JNotify("Your zone has been deleted.", "/Provider/#coverage");
                        Db.SaveChanges();
                    }
                    else
                    {
                        JNotify("Your can not delete your own zone.Update your profile instead", "#");
                    }
                }
            }

            return View(maintenanceproviderzone);
        }

        public bool IsZipcodeBelongtoTeamMember(int providerId, string zipcode)
        {
            var teamList =
                Db.MaintenanceTeamAssociations.Where(x => x.MaintenanceProviderId == providerId)
                  .Select(x => x.SpecialistId)
                  .ToList();
            var teamListZipCode = (from teammember in teamList
                                   select Db.Specialists.
                                             FirstOrDefault(x => x.SpecialistId == teammember)
                                   into specialist
                                   where specialist != null
                                   where specialist.Zip != null
                                   select specialist.Zip).
                ToList();
            return teamListZipCode.Any(x => x == zipcode);
        }

        public int GetmNumberofMembersInTeam()
        {
            var provider = UserHelper.GetProviderId();
            if (provider != null)
            {
                var providerId = (int) provider;

                var maintenanceProviderZones =
                    Db.MaintenanceProviderZones.Where(x => x.MaintenanceProviderId == providerId).ToList();
                return maintenanceProviderZones.Any()
                           ? Db.MaintenanceTeamAssociations.Count(x => x.MaintenanceProviderId == providerId)
                           : 0;
            }
            return 0;
        }

        public ViewResult UpdateZoneList(int page = 1)
        {
            var id = UserHelper.GetProviderId();
            return id != null
                       ? View(
                           Db.MaintenanceProviderZones.Where(x => x.MaintenanceProviderId == id)
                             .ToList()
                             .ToPagedList(page, 10))
                       : null;
        }

        public ActionResult UpdateZone(int id)
        {
            MaintenanceProviderZone maintenanceproviderzone = Db.MaintenanceProviderZones.Find(id);
            return View(maintenanceproviderzone);
        }

        [HttpPost, ActionName("UpdateZone")]
        public ActionResult UpdateZoneConfirmed(MaintenanceProviderZone maintenanceproviderzone)
        {
            var provider = UserHelper.GetProviderId();

            var maintenanceProvider = Db.MaintenanceProviders.FirstOrDefault(x => x.MaintenanceProviderId == provider);
            if (maintenanceProvider != null)
            {
                var providerMaintenanceProviderZip = maintenanceProvider.Zip;

                if (provider != null)
                {
                    var providerId = (int) provider;
                    var maintenanceProviderZones =
                        Db.MaintenanceProviderZones.Where(x => x.MaintenanceProviderId == providerId).ToList();
                    if (maintenanceProviderZones.Exists(x => x.ZipCode == maintenanceproviderzone.ZipCode))
                    {
                        JNotify("Zone already exist in your list", "#");

                        ModelState.AddModelError("Zone Duplication ", "Zone already exist in your list");

                    }
                    if (ModelState.IsValid)
                    {
                        var currentmaintenanceproviderzone =
                            Db.MaintenanceProviderZones.Find(maintenanceproviderzone.MaintenanceProviderZoneId);
                        if (IsZipcodeBelongtoTeamMember(providerId, currentmaintenanceproviderzone.ZipCode))
                        {
                            JNotify(
                                "Your can not update your Team Member Zone. The Zone Coverage is based upon Team Member Profile",
                                "/Provider/#coverage");
                            ModelState.AddModelError("Zone Update ",
                                                     "Your can not update your Team Member Zone. The Zone Coverage is based upon Team Member Profile");

                        }
                        else if (providerMaintenanceProviderZip == currentmaintenanceproviderzone.ZipCode)
                        {
                            JNotify(
                                "Your can not update your Zone from this section. Please update your profile to reflect the new zone",
                                "/Provider/#coverage");
                            ModelState.AddModelError("Zone Update ",
                                                     "Your can not update your Team Member Zone. The Zone Coverage is based upon Team Member Profile");
                        }
                        else
                        {
                            var maintenanceproviderzone2 =
                                Db.MaintenanceProviderZones.First(
                                    x =>
                                    x.MaintenanceProviderZoneId == maintenanceproviderzone.MaintenanceProviderZoneId);
                            maintenanceproviderzone2.CityName = maintenanceproviderzone.CityName;
                            maintenanceproviderzone2.ZipCode = maintenanceproviderzone.ZipCode;
                            Db.SaveChanges();
                            JNotify("Your zone has been updated.", "/Provider/#coverage");
                        }

                        return View(maintenanceproviderzone);
                    }
                }
            }
            return View(maintenanceproviderzone);
        }

        ///<summary>
        ///Find the new Zip code of the company
        ///     If the new Zip code does not match any zip
        ///          Add the new Zip code to the list
        ///     If previous Zip code exist
        ///         Don't Update
        /// </summary>
        /// <param name="providerCompanyZip"></param>
        /// <param name="providerCompanyZipCity"></param>
        private void UpdateProviderZoneList(string providerCompanyZip = "", string providerCompanyZipCity = "")
        {
            if (providerCompanyZip == null) return;
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderId());
            var maintenanceProviderZonesList =
                Db.MaintenanceProviderZones.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId)
                  .ToList();
            if (
                maintenanceProviderZonesList.Exists(
                    x => x.ZipCode == providerCompanyZip.ToString(CultureInfo.InvariantCulture))) return;
            if (maintenanceProviderZonesList.Exists(x => x.ZipCode == provider.Zip))
            {
                maintenanceProviderZonesList.RemoveAll(x => x.ZipCode == provider.Zip);
            }
            if (providerCompanyZipCity != null)
                Db.MaintenanceProviderZones.Add(new MaintenanceProviderZone
                    {
                        CityName = providerCompanyZipCity,
                        Country = "US",
                        MaintenanceProviderId = provider.MaintenanceProviderId,
                        ZipCode = providerCompanyZip,
                        TeamMemberCount = GetmNumberofMembersInTeam()
                    });
        }

        private void UpdateproviderProfile(MaintenanceProvider p, MaintenanceCompany m)
        {
            var providerId = UserHelper.GetProviderId();
            if (providerId == null) return;
            var provider = Db.MaintenanceProviders.FirstOrDefault(x => x.MaintenanceProviderId == providerId);
            if (provider == null) return;
            if (!string.IsNullOrEmpty(m.VCard))
            {
                provider.VCard = m.VCard;
            }
            if (!string.IsNullOrEmpty(m.Skype))
            {
                provider.Skype = m.Skype;
            }
            if (!string.IsNullOrEmpty(m.Twitter))
            {
                provider.Twitter = m.Twitter;
            }
            if (!string.IsNullOrEmpty(m.LinkedIn))
            {
                provider.LinkedIn = m.LinkedIn;
            }
            if (!string.IsNullOrEmpty(m.GooglePlus))
            {
                provider.GooglePlus = m.GooglePlus;
            }

            if (!string.IsNullOrEmpty(m.Address))
            {
                provider.Address = m.Address;
            }
            if (!string.IsNullOrEmpty(m.Country))
            {
                provider.Country = m.Country;
            }
            if (!string.IsNullOrEmpty(m.Region))
            {
                provider.City = m.Region;
            }
            if (!string.IsNullOrEmpty(m.City))
            {
                provider.City = m.City;
            }
            if (!string.IsNullOrEmpty(m.Zip))
            {
                provider.Zip = m.Zip;
            }
            if (!string.IsNullOrEmpty(m.Description))
            {
                provider.Description = m.Description;
            }
            provider.GoogleMap =
                m.GoogleMap =
                string.IsNullOrEmpty(m.Address)
                    ? UserHelper.GetFormattedLocation("", "", "USA")
                    : UserHelper.GetFormattedLocation(m.Address, m.City, m.Country);
            provider.YouTubeVideo = p.YouTubeVideo;
            provider.YouTubeVideoURL = p.YouTubeVideoURL;
            provider.VimeoVideo = p.VimeoVideo;
            provider.VimeoVideoURL = p.VimeoVideoURL;
        }

        public ActionResult ViewTeamInvitation(int page = 1)
        {
            var providerId = UserHelper.GetProviderId();
            if (providerId != null)
            {
                var allteam = Db.MaintenanceTeams.Where
                    (x => x.MaintenanceProviderId == providerId)
                                .Select(x => x.TeamId).ToList();
                var teamSpecialistPendingList = (from currenteam in allteam
                                                 from specialistPendingTeamInvitation in
                                                     Db.SpecialistPendingTeamInvitations.Where(
                                                         x => x.TeamId == currenteam)
                                                 let currentspecialist =
                                                     Db.Specialists.FirstOrDefault(
                                                         x =>
                                                         x.SpecialistId == specialistPendingTeamInvitation.SpecialistID)
                                                 where currentspecialist != null
                                                 select new TeamSpecialistInvitation
                                                     {
                                                         PendingTeamInvitationID =
                                                             specialistPendingTeamInvitation.PendingTeamInvitationID,
                                                         TeamId = specialistPendingTeamInvitation.TeamId,
                                                         TeamName = specialistPendingTeamInvitation.TeamName,
                                                         MaintenanceProviderId =
                                                             specialistPendingTeamInvitation.MaintenanceProviderId,
                                                         SpecialistID = specialistPendingTeamInvitation.SpecialistID,
                                                         SpecialistPhoto = currentspecialist.Photo,
                                                         SpecialistFirstName = currentspecialist.FirstName,
                                                         SpecialistLastName = currentspecialist.LastName,
                                                         SpecialistAddress = currentspecialist.Address,
                                                         SpecialistRegion = currentspecialist.Region,
                                                         SpecialistCity = currentspecialist.City,
                                                         SpecialistCountryCode = currentspecialist.CountryCode,
                                                         SpecialistDescription = currentspecialist.Description
                                                     }).ToList();

                return View(teamSpecialistPendingList.OrderBy(x => x.PendingTeamInvitationID).ToPagedList(page, 10));
            }
            return null;
        }

        //************************************************* Coverage *********************************************//
        //*******************************************************************************************************//
        //*******************************************************************************************************//

        //****************************************************Account********************************************//
        /// <summary>
        /// Account Tab
        /// TODO  Complete:
        ///     -1-Delete All associated records
        /// </summary>

        public ActionResult CompleteProfile()
        {
            var providerId = UserHelper.GetProviderId();
            if (providerId != null)
            {
                const int providerrole = 2;
                var lookUp =
                    Db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.Role == providerrole && x.UserId == providerId);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    var mp = new ProviderMaintenanceProfile
                        {
                            MaintenanceProvider = Db.MaintenanceProviders.Find(providerId),
                            MaintenanceCompanyLookUp = Db.MaintenanceCompanyLookUps.Find(companyId),
                            MaintenanceCompany = Db.MaintenanceCompanies.Find(companyId),
                            MaintenanceCompanySpecialization = Db.MaintenanceCompanySpecializations.Find(companyId),
                            MaintenanceCustomService = Db.MaintenanceCustomServices.Find(companyId),
                            MaintenanceExterior = Db.MaintenanceExteriors.Find(companyId),
                            MaintenanceInterior = Db.MaintenanceInteriors.Find(companyId),
                            MaintenanceNewConstruction = Db.MaintenanceNewConstructions.Find(companyId),
                            MaintenanceRepair = Db.MaintenanceRepairs.Find(companyId),
                            MaintenanceUtility = Db.MaintenanceUtilities.Find(companyId)
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
                        Db.Entry(s.MaintenanceProvider).State = EntityState.Modified;
                        Db.Entry(s.MaintenanceCompany).State = EntityState.Modified;
                        Db.Entry(s.MaintenanceCompanyLookUp).State = EntityState.Modified;
                        Db.Entry(s.MaintenanceCompanySpecialization).State = EntityState.Modified;
                        UpdateProfileCompletion(CalculateNewProfileCompletionPercentage(s.MaintenanceCompany));
                        UpdateproviderProfile(s.MaintenanceProvider, s.MaintenanceCompany);
                        UpdateProviderZoneList(s.MaintenanceCompany.Zip, s.MaintenanceCompany.City);
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

        public void UpdateProviderMaintenanceCompany()
        {
            var providerUserId = UserHelper.GetProviderId();
            if (providerUserId != null)
            {
                const int providerrole = 2;
                var lookUp =
                    Db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.Role == providerrole && x.UserId == providerUserId);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    var maintenanceCompany = Db.MaintenanceCompanies.Find(companyId);
                    if ( maintenanceCompany != null)
                    {
                          var providerId = (int) providerUserId;
                          var provider = Db.MaintenanceProviders.Find(providerId);


                        //reverse the Assignment

                          if (!string.IsNullOrEmpty(provider.VCard))
                          {
                              maintenanceCompany.VCard = provider.VCard;
                          }
                          if (!string.IsNullOrEmpty(provider.Skype))
                          {
                              maintenanceCompany.Skype = provider.Skype;
                          }
                          if (!string.IsNullOrEmpty(provider.Twitter))
                          {
                              maintenanceCompany.Twitter = provider.Twitter;
                          }
                          if (!string.IsNullOrEmpty(provider.LinkedIn))
                          {
                              maintenanceCompany.LinkedIn = provider.LinkedIn;
                          }
                          if (!string.IsNullOrEmpty(provider.GooglePlus))
                          {
                              maintenanceCompany.GooglePlus = provider.GooglePlus;
                          }

                          if (!string.IsNullOrEmpty(provider.Address))
                          {
                              maintenanceCompany.Address = provider.Address;
                          }
                          if (!string.IsNullOrEmpty(provider.Country))
                          {
                              maintenanceCompany.Country = provider.Country;
                          }
                          if (!string.IsNullOrEmpty(provider.Region))
                          {
                              maintenanceCompany.Region = provider.Region;
                          }
                          if (!string.IsNullOrEmpty(provider.City))
                          {
                              maintenanceCompany.City = provider.City;
                          }
                          if (!string.IsNullOrEmpty(provider.Zip))
                          {
                              maintenanceCompany.Zip = provider.Zip;
                          }
                          if (!string.IsNullOrEmpty(provider.Description))
                          {
                              maintenanceCompany.Description = provider.Description;
                          }
                          maintenanceCompany.GoogleMap =
                              provider.GoogleMap =
                              string.IsNullOrEmpty(provider.Address)
                                  ? UserHelper.GetFormattedLocation("", "", "USA")
                                  : UserHelper.GetFormattedLocation(provider.Address, provider.City, provider.Country);

                          Db.SaveChanges();
                    }

                }
            }
        }

        /// <summary>
                /// Calculation of Completion
                /// description = 20 ; Other = 10
                /// 
                /// Members of formula 
                /// Name 
                /// Address 
                /// EmailAddress 
                /// Description 
                /// Country 
                /// Region 
                /// City 
                /// Zip 
                /// CountryCode
                /// </summary>
        public int CalculateNewProfileCompletionPercentage(MaintenanceCompany m)
        {
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
            m.GoogleMap = string.IsNullOrEmpty(m.Address)
                              ? UserHelper.GetFormattedLocation("", "", "USA")
                              : UserHelper.GetFormattedLocation(m.Address, m.City, m.Country);
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

        public decimal? GetProviderRate(int providerId)
        {
            var providerMaintenanceCompany = Db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.UserId == providerId);
            if (providerMaintenanceCompany != null)
            {
                var providercompanyid = providerMaintenanceCompany.CompanyId;
                var providercompany =
                    Db.MaintenanceCompanySpecializations.FirstOrDefault(x => x.CompanyId == providercompanyid);

                if (providercompany != null)
                {

                    return (decimal) providercompany.Rate;
                }
                return null;
            }
            return null;
        }

        public List<MaintenanceCompany> GetProviderCompanies()
        {
            var providerMaintenanceCompanies = new List<MaintenanceCompany>();
            var providerMaintenanceCompanyLookup =
                Db.MaintenanceCompanyLookUps.Where(x => x.UserId == UserHelper.GetProviderId());
            if (providerMaintenanceCompanyLookup.Any())
            {
                providerMaintenanceCompanies.
                    AddRange(providerMaintenanceCompanyLookup.
                                 Select(maintenanceCompanyLookUp => Db.MaintenanceCompanies.
                                                                       FirstOrDefault(
                                                                           x =>
                                                                           x.CompanyId ==
                                                                           maintenanceCompanyLookUp.CompanyId)).
                                 Where(currentMaintenanceCompany => currentMaintenanceCompany != null));


                return providerMaintenanceCompanies.ToList();
            }
            return null;
        }

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
                UpdateProviderMaintenanceCompany();
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
                provider.GoogleMap = string.IsNullOrEmpty(provider.Address)
                                         ? UserHelper.GetFormattedLocation("", "", "USA")
                                         : UserHelper.GetFormattedLocation(provider.Address, provider.City,
                                                                           provider.CountryCode);
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

        //***************************************************Account*********************************************//
        //*******************************************************************************************************//
        //*******************************************************************************************************//

        //**************************************************** Team *********************************************//
        /// <summary>
        /// Team Tab
        /// Finished and Clean
        /// Only 1 team can exist
        /// </summary>

        public PartialViewResult _Team()
        {
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderId());
            var checkteamexistance =
                Db.MaintenanceTeamAssociations.FirstOrDefault(
                    x => x.MaintenanceProviderId == provider.MaintenanceProviderId);
            var allTeamAssociations =
                Db.MaintenanceTeamAssociations.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId)
                  .ToList();
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
            var lookUp =
                Db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.Role == specialistrole && x.UserId == specialistId);
            return lookUp == null ? 0 : Db.MaintenanceCompanySpecializations.Find(lookUp.CompanyId).Years_Experience;
        }

        public ActionResult AddTeamMember(int page = 1)
        {
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderId());
            var existingTeamAssociation =
                Db.MaintenanceTeamAssociations.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId)
                  .Select(x => x.SpecialistId)
                  .ToList();
            var pendingTeamAssociation =
                Db.SpecialistPendingTeamInvitations.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId)
                  .Select(x => x.SpecialistID)
                  .ToList();
            var mergedExistingandPendingTeamAssociation =
                new List<int>(existingTeamAssociation.Union(pendingTeamAssociation));
            var excludedSpecialistList =
                Db.Specialists.Where(x => mergedExistingandPendingTeamAssociation.Contains(x.SpecialistId));
            var filterSpecialistList =
                Db.Specialists.Except(excludedSpecialistList).OrderBy(x => x.SpecialistId).ToPagedList(page, 10);
            return View(filterSpecialistList);
        }

        public ActionResult SelectTeam(int pid, int page = 1)
        {
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderId());
            ViewBag.SelectedSpecialistId = pid;
            var currentTeam =
                Db.MaintenanceTeams.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId)
                  .OrderBy(x => x.TeamId)
                  .ToPagedList(page, 10);
            return View(currentTeam);
        }

        public ActionResult InviteTeamMember(int stid, int pid)
        {
            ViewBag.SelectedSpecialistId = pid;
            ViewBag.SelectedTeamId = stid;
            return View(Db.MaintenanceTeams.Where(x => x.TeamId == stid));
        }

        [HttpPost]
        public ActionResult InviteTeamMember(MaintenanceTeam team)
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
                        SpecialistID = Convert.ToInt32(Request.Params["pid"]),
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
            var existingTeamAssociation =
                Db.MaintenanceTeamAssociations.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId)
                  .Select(x => x.SpecialistId)
                  .ToList();
            var mergedExistingandPendingTeamAssociation = Db.Specialists.
                                                             Where(x => existingTeamAssociation.Contains(x.SpecialistId));
            var filterSpecialistList =
                mergedExistingandPendingTeamAssociation.OrderBy(x => x.SpecialistId).ToPagedList(page, 10);
            return View(filterSpecialistList);
        }

        public ActionResult RemoveFromTeam(int pid, int page = 1)
        {
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderId());
            ViewBag.SelectedSpecialistId = pid;
            var currentTeam =
                Db.MaintenanceTeamAssociations.Where(
                    x => x.MaintenanceProviderId == provider.MaintenanceProviderId && x.SpecialistId == pid)
                  .OrderBy(x => x.TeamId)
                  .ToPagedList(page, 10);
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
                     && x.SpecialistId == pid
                     && x.TeamId == sid);
            if (currentspecialist != null)
            {
                Db.MaintenanceTeamAssociations.Remove(currentspecialist);
                Db.SaveChanges();
            }
            RemoveSpecialistZoneFromProviderTeamZone(Convert.ToInt32(Request.Params["pid"]),
                                                     Convert.ToInt32(Request.Params["stid"]));
            var teamcoverageUpdate = new UpdateCoverage(Convert.ToInt32(Request.Params["pid"]), Convert.ToInt32(Request.Params["stid"]));
            teamcoverageUpdate.RemoveAllCoverageFromSpecialistToTeam();
            RemoveSpecialist(Convert.ToInt32(Request.Params["stid"]), Convert.ToInt32(Request.Params["pid"]));
            JNotify("Your request has been completed.", "/Provider/#team");
            return View();
        }

        public void RemoveSpecialistZoneFromProviderTeamZone(int providerId, int specialistId)
        {

            var currenteamcount = Db.MaintenanceTeamAssociations.Count(x => x.MaintenanceProviderId == providerId);
            var updatedteamcount = currenteamcount == 0 ? 0 : currenteamcount + 1;
            var specialist = Db.Specialists.FirstOrDefault(x => x.SpecialistId == specialistId);
            var specialistzone = Db.MaintenanceProviderZones.
                                    FirstOrDefault(
                                        x => x.MaintenanceProviderId == providerId && x.ZipCode == specialist.Zip);
            var providerZones = Db.MaintenanceProviderZones.Where(x => x.MaintenanceProviderId == providerId).ToList();
            foreach (var providerZone in providerZones)
            {
                providerZone.TeamMemberCount = updatedteamcount;
            }
            if (providerZones.Any())
            {
            Db.MaintenanceProviderZones.Remove(specialistzone);
            Db.SaveChanges();
            }
        }

        public ProviderMaintenanceProfile GetProviderCoverage()
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

                    return new ProviderMaintenanceProfile
                        {
                            MaintenanceProvider = Db.MaintenanceProviders.Find(providerId),
                            MaintenanceCompanyLookUp = Db.MaintenanceCompanyLookUps.Find(companyId),
                            MaintenanceCompany = Db.MaintenanceCompanies.Find(companyId),
                            MaintenanceCompanySpecialization = Db.MaintenanceCompanySpecializations.Find(companyId),
                            MaintenanceCustomService = Db.MaintenanceCustomServices.Find(companyId),
                            MaintenanceExterior = Db.MaintenanceExteriors.Find(companyId),
                            MaintenanceInterior = Db.MaintenanceInteriors.Find(companyId),
                            MaintenanceNewConstruction = Db.MaintenanceNewConstructions.Find(companyId),
                            MaintenanceRepair = Db.MaintenanceRepairs.Find(companyId),
                            MaintenanceUtility = Db.MaintenanceUtilities.Find(companyId)
                        };
                }
            }
            return null;

        }

        public SpecialistMaintenanceProfile GetSpecialistCoverage(int specialistId)
        {
            const int specialistrole = 1;
            var specialistlookUp =
                Db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.Role == specialistrole && x.UserId == specialistId);
            if (specialistlookUp != null)
            {
                int companyId = specialistlookUp.CompanyId;

                return new SpecialistMaintenanceProfile
                    {
                        MaintenanceCompanyLookUp = Db.MaintenanceCompanyLookUps.Find(companyId),
                        MaintenanceCompany = Db.MaintenanceCompanies.Find(companyId),
                        MaintenanceCompanySpecialization = Db.MaintenanceCompanySpecializations.Find(companyId),
                        MaintenanceCustomService = Db.MaintenanceCustomServices.Find(companyId),
                        MaintenanceExterior = Db.MaintenanceExteriors.Find(companyId),
                        MaintenanceInterior = Db.MaintenanceInteriors.Find(companyId),
                        MaintenanceNewConstruction = Db.MaintenanceNewConstructions.Find(companyId),
                        MaintenanceRepair = Db.MaintenanceRepairs.Find(companyId),
                        MaintenanceUtility = Db.MaintenanceUtilities.Find(companyId)
                    };
            }
            return null;
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

        public void JNotify(string message = "", string url = "")
        {
            ViewBag.Confirmation = true;
            ViewBag.ConfirmationSuccess = JNotfiyScriptQueryHelper.JNotifyConfirmationMessage(message, url);
        }
        //************************************************** Team *************************************************//
        //*******************************************************************************************************//
        //*******************************************************************************************************//









        //*************************************** WIP and WORK NOT COMPLETED***************************************//
        //*************************************************************************************************//
        //*************************************************************************************************//


        public ActionResult _Property()
        {
            return PartialView();
        }
        public ActionResult UpdateProfilePicture(int id)
        {
            return RedirectToAction("Upload", "Account", new { id });
        }

        //Continue from here like Owner for pending, accpeted and rejected
        public ActionResult NewJobOffer()
        {
            var provider = Db.MaintenanceProviders.Find(UserHelper.GetProviderId());

            return View(Db.MaintenanceProviderAcceptedJobs.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId).ToList());
        }

        public ActionResult Partial2(UnitModelView unitModelView)
        {

            var photoHelper = new PhotoHelper();
            var role = photoHelper.Role;
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

        //*************************************** WORK NOT COMPLETED***************************************//
        //*************************************************************************************************//
        //*************************************************************************************************//

        protected override void Dispose(bool disposing)
        {
            Db.Dispose();
            base.Dispose(disposing);
        }

    }
}