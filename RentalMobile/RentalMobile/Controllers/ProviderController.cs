using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using RentalMobile.Helpers;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalMobile.Process;
using RentalModel.Repository.Generic.UnitofWork;
using Email = Postal.Email;

namespace RentalMobile.Controllers
{
    [Authorize]
    public class ProviderController : BaseController
    {

        #region Main

        public ProviderController(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        public ViewResult Index()
        {
            var provider = UserHelper.ProviderPrivateProfileHelper.GetProvider();
            ViewBag.ProviderProfile = provider;
            ViewBag.ProviderId = provider.MaintenanceProviderId;
            var maintenanceTeamAssociation = UserHelper.ProviderPrivateProfileHelper.GetMaintenanceTeamAssociations();
            if (maintenanceTeamAssociation != null)
            {
                ViewBag.TeamId = maintenanceTeamAssociation.TeamId;
                ViewBag.TeamName = maintenanceTeamAssociation.TeamName;
            }
            ViewBag.ProviderGoogleMap = provider.GoogleMap;
            return View(provider);
        }

        #endregion

        #region Coverage

        //************************************************* Coverage *********************************************//
        /// <summary>
        /// Coverage Tab
        /// Finished and Clean
        /// </summary>

        public PartialViewResult _Coverage()
        {
            return PartialView(UserHelper.ProviderPrivateProfileHelper.GetMaintenanceProviderProfile());
        }

        public PartialViewResult _EditCoverage()
        {
            ViewBag.HasTeam = UserHelper.ProviderPrivateProfileHelper.DoesProviderHasTeam();
            return PartialView();
        }

        public PartialViewResult _EditZone()
        {
            int availableSpot;
            var totalZonesCount = UserHelper.ProviderPrivateProfileHelper.GetDistinctProviderZones().Count;
            if (totalZonesCount > 0)
            {
                availableSpot = UserHelper.ProviderPrivateProfileHelper.GetTotalAvailableZoneSpot() - totalZonesCount;
            }
            else
            {
                availableSpot = UserHelper.ProviderPrivateProfileHelper.GetTotalAvailableZoneSpot();
            }
            ViewBag.AvailableSpot = availableSpot;
            ViewBag.TotalAvailableZoneSpot = UserHelper.ProviderPrivateProfileHelper.GetTotalAvailableZoneSpot();
            return PartialView(UserHelper.ProviderPrivateProfileHelper.GetDistinctProviderZones());
        }

        public PartialViewResult _ViewZone()
        {
            return PartialView(UserHelper.ProviderPrivateProfileHelper.GetAllProviderZones());

        }

        public ViewResult AddZone()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddZone(MaintenanceProviderZone maintenanceProviderZone)
        {
            var maintenanceProviderZones = UnitofWork.MaintenanceProviderZoneRepository.
                    FindBy(x => x.MaintenanceProviderId == UserHelper.ProviderPrivateProfileHelper.
                    GetProvider().MaintenanceProviderId).ToList();
            if (UserHelper.ProviderPrivateProfileHelper.IsProviderZoneAlreadyExist(maintenanceProviderZone, maintenanceProviderZones))
            {
                ModelState.AddModelError("Zone Duplication ", @"Zone already exist in your list");
                JNotify("This Zone already exist in your list.", "#");
            }
            if (ModelState.IsValid)
            {
                UserHelper.ProviderPrivateProfileHelper.AddNewMaintenanceProviderZone(maintenanceProviderZone, maintenanceProviderZones);
                JNotify("Your zone has been added.", "/Provider/#coverage");
                return View();
            }
            return View(maintenanceProviderZone);
        }

        public ViewResult RemoveZoneList(int page = 1)
        {
            var providerId = UserHelper.ProviderPrivateProfileHelper.
                GetProvider().MaintenanceProviderId;
            return View(
                UnitofWork.MaintenanceProviderZoneRepository.
                    FindBy(x => x.MaintenanceProviderId == providerId)
                    .ToList()
                    .ToPagedList(page, 10));
        }

        public ActionResult RemoveZone(int id)
        {
            var maintenanceproviderzone =
                UnitofWork.MaintenanceProviderZoneRepository.
                    FirstOrDefault(x => x.MaintenanceProviderZoneId == id);
            return View(maintenanceproviderzone);
        }

        [HttpPost, ActionName("RemoveZone")]
        public ActionResult RemoveZoneConfirmed(int id)
        {
            var maintenanceproviderzone =
                    UnitofWork.MaintenanceProviderZoneRepository
                    .FirstOrDefault(x => x.MaintenanceProviderZoneId == id);
            if (UserHelper.ProviderPrivateProfileHelper.GetProvider().Zip == null) return null;
            var jNotifyMessage = UserHelper.ProviderPrivateProfileHelper.RemoveProviderZone(maintenanceproviderzone);
            JNotify(jNotifyMessage.Message, jNotifyMessage.RedirectUrl);
            return View(maintenanceproviderzone);
        }

        public ViewResult UpdateZoneList(int page = 1)
        {
            var test = UserHelper.ProviderPrivateProfileHelper.GetAllProviderZones()
                .ToList()
                .ToPagedList(page, 10);
            return View(test);
        }

        public ActionResult UpdateZone(int id)
        {
            return View(UnitofWork.MaintenanceProviderZoneRepository.FirstOrDefault(x => x.MaintenanceProviderZoneId == id));
        }

        [HttpPost, ActionName("UpdateZone")]
        public ActionResult UpdateZoneConfirmed(MaintenanceProviderZone maintenanceproviderzone)
        {
            var maintenanceProviderZones = UserHelper.ProviderPrivateProfileHelper.GetAllProviderZones();
            if (UserHelper.ProviderPrivateProfileHelper.IsProviderZoneAlreadyExist(maintenanceproviderzone, maintenanceProviderZones))
            {
                ModelState.AddModelError("Zone Duplication ", @"Zone already exist in your list");
                JNotify("This Zone already exist in your list.", "#");
            }
            if (ModelState.IsValid)
            {
                var jNotifyMessage = UserHelper.ProviderPrivateProfileHelper.UpdateZone(maintenanceproviderzone);
                JNotify(jNotifyMessage.Message, jNotifyMessage.RedirectUrl);
            }
            return View(maintenanceproviderzone);
        }

        public ActionResult ViewTeamInvitation(int page = 1)
        {
            return View(UserHelper.ProviderPrivateProfileHelper.GetAllSpecialistThatHasPendingTeamInvitation().
                OrderBy(x => x.PendingTeamInvitationID).ToPagedList(page, 10));

        }

        //************************************************* Coverage *********************************************//
        #endregion

        #region Account

        //****************************************************Account********************************************//
        /// <summary>
        /// Account Tab
        /// TODO  Complete:
        ///     -1-Delete All associated records
        /// </summary>

        public ActionResult CompleteProfile()
        {
            var providerId = UserHelper.GetProviderId();

            const int providerrole = 2;
            var lookUp =
                UnitofWork.MaintenanceCompanyLookUpRepository.FirstOrDefault(x => x.Role == providerrole && x.UserId == providerId);
            if (lookUp != null)
            {
                int companyId = lookUp.CompanyId;

                var mp = new ProviderMaintenanceProfile
                    {
                        MaintenanceProvider = UnitofWork.MaintenanceProviderRepository.FirstOrDefault(x => x.MaintenanceProviderId == providerId),
                        MaintenanceCompanyLookUp = UnitofWork.MaintenanceCompanyLookUpRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceCompany = UnitofWork.MaintenanceCompanyRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceCompanySpecialization = UnitofWork.MaintenanceCompanySpecializationRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceCustomService = UnitofWork.MaintenanceCustomServiceRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceExterior = UnitofWork.MaintenanceExteriorRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceInterior = UnitofWork.MaintenanceInteriorRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceNewConstruction = UnitofWork.MaintenanceNewConstructionRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceRepair = UnitofWork.MaintenanceRepairRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceUtility = UnitofWork.MaintenanceUtilityRepository.FirstOrDefault(x => x.CompanyId == companyId)
                    };

                return View(mp);
            }

            return null;
        }

        [HttpPost]
        public ActionResult CompleteProfile(ProviderMaintenanceProfile s)
        {
            if (ModelState.IsValid)
            {
                UserHelper.ProviderPrivateProfileHelper.CompleteProviderProfile(s);
                return RedirectToAction("Index");
            }
            return View(s);
        }

        public ActionResult Edit(int id)
        {
            var provider = UserHelper.ProviderPrivateProfileHelper.GetPrivateProfileProviderByProviderId(id);
            return View(provider);
        }

        [HttpPost]
        public ActionResult Edit(MaintenanceProvider provider)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.MaintenanceProviderRepository.Edit(provider);
                UnitofWork.Save();
                UserHelper.ProviderPrivateProfileHelper.UpdateProviderMaintenanceCompany();
                return RedirectToAction("Index");
            }
            return View(provider);
        }

        public ActionResult ChangeAddress(int id)
        {
            var provider = UserHelper.ProviderPrivateProfileHelper.GetPrivateProfileProviderByProviderId(id);
            return View(provider);
        }

        [HttpPost]
        public ActionResult ChangeAddress(MaintenanceProvider provider)
        {
            if (ModelState.IsValid)
            {
                provider.GoogleMap = UserHelper.ProviderPrivateProfileHelper.ProviderGoogleMap();
                UnitofWork.MaintenanceProviderRepository.Edit(provider);
                UnitofWork.Save();
                return RedirectToAction("Index");
            }
            return View(provider);
        }

        public ActionResult Delete(int id)
        {
            var provider = UserHelper.ProviderPrivateProfileHelper.GetPrivateProfileProviderByProviderId(id);
            return View(provider);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserHelper.ProviderPrivateProfileHelper.DeleteProviderRecords(id);
            UserHelper.ProviderPrivateProfileHelper.DeleteProviderMemebership();
            return RedirectToAction("Index", "Home");
        }
        //***************************************************Account*********************************************//
        #endregion

        #region Team

        //**************************************************** Team *********************************************//
        /// <summary>
        /// Team Tab
        /// Finished and Clean
        /// Only 1 team can exist
        /// </summary>

        public PartialViewResult _Team()
        {
            var provider = UserHelper.ProviderPrivateProfileHelper.GetProvider();
            var checkteamexistance =
                UnitofWork.MaintenanceTeamAssociationRepository.FirstOrDefault(
                    x => x.MaintenanceProviderId == provider.MaintenanceProviderId);
            var allTeamAssociations =
               UnitofWork.MaintenanceTeamAssociationRepository.FindBy(x => x.MaintenanceProviderId == provider.MaintenanceProviderId)
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
                          let currentspecialist = UnitofWork.SpecialistRepository.FirstOrDefault(x => x.SpecialistId == i.SpecialistId)
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
                UnitofWork.MaintenanceCompanyLookUpRepository.FirstOrDefault(x => x.Role == specialistrole && x.UserId == specialistId);
            return lookUp == null ? 0 : UnitofWork.MaintenanceCompanySpecializationRepository.FirstOrDefault(x => x.CompanyId == lookUp.CompanyId).Years_Experience;
        }

        public ActionResult AddTeamMember(int page = 1)
        {
            var provider = UserHelper.ProviderPrivateProfileHelper.GetProvider();
            var providerId = provider.MaintenanceProviderId;
            var existingTeamAssociation =
                UnitofWork.MaintenanceTeamAssociationRepository.FindBy(x => x.MaintenanceProviderId == providerId)
                  .Select(x => x.SpecialistId)
                  .ToList();
            var pendingTeamAssociation =
                UnitofWork.SpecialistPendingTeamInvitationRepository.FindBy(x => x.MaintenanceProviderId == providerId)
                  .Select(x => x.SpecialistID)
                  .ToList();
            var mergedExistingandPendingTeamAssociation =
                new List<int>(existingTeamAssociation.Union(pendingTeamAssociation));
            IEnumerable<Specialist> excludedSpecialistList =
                UnitofWork.SpecialistRepository.FindBy(x => mergedExistingandPendingTeamAssociation.Contains(x.SpecialistId));
            var allSpecialists = UnitofWork.SpecialistRepository.All;
            var filterSpecialistList =
                allSpecialists.Except(excludedSpecialistList)
                .OrderBy(x => x.SpecialistId).ToPagedList(page, 10);
            return View(filterSpecialistList);
        }

        public ActionResult SelectTeam(int pid, int page = 1)
        {
            var provider = UserHelper.ProviderPrivateProfileHelper.GetProvider();
            var providerId = provider.MaintenanceProviderId;
            ViewBag.SelectedSpecialistId = pid;
            var currentTeam =
                UnitofWork.MaintenanceTeamRepository.FindBy(x => x.MaintenanceProviderId == providerId)
                  .OrderBy(x => x.TeamId)
                  .ToPagedList(page, 10);
            return View(currentTeam);
        }

        public ActionResult InviteTeamMember(int stid, int pid)
        {
            ViewBag.SelectedSpecialistId = pid;
            ViewBag.SelectedTeamId = stid;
            return View(UnitofWork.MaintenanceTeamRepository.FindBy(x => x.TeamId == stid));
        }

        [HttpPost]
        public ActionResult InviteTeamMember(MaintenanceTeam team)
        {
            if (Request.Params["stid"] == null || Request.Params["pid"] == null)
            {
                return RedirectToAction("AddTeamMember");
            }
            var tid = Convert.ToInt32(Request.Params["stid"]);
            var selectedteam = UnitofWork.MaintenanceTeamRepository.
                FirstOrDefault(x => x.TeamId == tid);
            var provider = UserHelper.ProviderPrivateProfileHelper.GetProvider();
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
                UnitofWork.SpecialistPendingTeamInvitationRepository.Add(npti);
            }
            UnitofWork.Save();
            InviteSpecialist(Convert.ToInt32(Request.Params["stid"]), Convert.ToInt32(Request.Params["pid"]));
            JNotify("Your request has been completed.", "/Provider/#team");
            return View();
        }

        public void InviteSpecialist(int stid, int pid)
        {
            dynamic email = new Email("InviteSpecialistToJoinTeam/Multipart");
            var poster = UserHelper.GetSendtoFriendPoster() ?? UserHelper.PosterHelper.DefaultPoster;
            var selectedspecialist = UnitofWork.SpecialistRepository.FirstOrDefault(x => x.SpecialistId == pid);
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
            var provider = UserHelper.ProviderPrivateProfileHelper.GetProvider();
            var existingTeamAssociation =
                UnitofWork.MaintenanceTeamAssociationRepository.FindBy(x => x.MaintenanceProviderId == provider.MaintenanceProviderId)
                  .Select(x => x.SpecialistId)
                  .ToList();
            var mergedExistingandPendingTeamAssociation = UnitofWork.SpecialistRepository.
                                                             FindBy(x => existingTeamAssociation.Contains(x.SpecialistId));
            var filterSpecialistList =
                mergedExistingandPendingTeamAssociation.OrderBy(x => x.SpecialistId).ToPagedList(page, 10);
            return View(filterSpecialistList);
        }

        public ActionResult RemoveFromTeam(int pid, int page = 1)
        {
            var provider = UserHelper.ProviderPrivateProfileHelper.GetProvider();
            ViewBag.SelectedSpecialistId = pid;
            var currentTeam =
                UnitofWork.MaintenanceTeamAssociationRepository.FindBy(
                    x => x.MaintenanceProviderId == provider.MaintenanceProviderId && x.SpecialistId == pid)
                  .OrderBy(x => x.TeamId)
                  .ToPagedList(page, 10);
            return View(currentTeam);
        }

        public ActionResult RemoveMember(int stid, int pid)
        {
            ViewBag.SelectedSpecialistId = pid;
            ViewBag.SelectedTeamId = stid;
            return View(UnitofWork.MaintenanceTeamRepository.
                FindBy(x => x.TeamId == stid));
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
            var provider = UserHelper.ProviderPrivateProfileHelper.GetProvider();
            var currentspecialist = UnitofWork.MaintenanceTeamAssociationRepository.FirstOrDefault(
                x => x.MaintenanceProviderId == provider.MaintenanceProviderId
                     && x.SpecialistId == pid
                     && x.TeamId == sid);
            if (currentspecialist != null)
            {
                UnitofWork.MaintenanceTeamAssociationRepository.Delete(currentspecialist);
                UnitofWork.Save();
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
            var currenteamcount =
                UnitofWork.MaintenanceTeamAssociationRepository.
                Count(x => x.MaintenanceProviderId == providerId);
            var updatedteamcount = currenteamcount == 0 ? 0 : currenteamcount + 1;
            var specialist =
                UserHelper.SpecialistPrivateProfileHelper.GetPrivateProfileSpecialistBySpecialistId(specialistId);
            var specialistzone = UnitofWork.MaintenanceProviderZoneRepository.
                                    FirstOrDefault(
                                        x => x.MaintenanceProviderId == providerId && x.ZipCode == specialist.Zip);
            var providerZones = UnitofWork.MaintenanceProviderZoneRepository.FindBy(x => x.MaintenanceProviderId == providerId).ToList();
            foreach (var providerZone in providerZones)
            {
                providerZone.TeamMemberCount = updatedteamcount;
            }
            if (providerZones.Any())
            {
                UnitofWork.MaintenanceProviderZoneRepository.Delete(specialistzone);
                UnitofWork.Save();
            }
        }

        public ProviderMaintenanceProfile GetProviderCoverage()
        {
            var provider = UserHelper.ProviderPrivateProfileHelper.GetProvider();
            const int providerrole = 2;
            var lookUp =
                UnitofWork.MaintenanceCompanyLookUpRepository.FirstOrDefault(
                    x => x.Role == providerrole && x.UserId == provider.MaintenanceProviderId);
            if (lookUp != null)
            {
                int companyId = lookUp.CompanyId;

                return new ProviderMaintenanceProfile
                    {
                        MaintenanceProvider = UnitofWork.MaintenanceProviderRepository.FirstOrDefault(x => x.MaintenanceProviderId == provider.MaintenanceProviderId),
                        MaintenanceCompanyLookUp = UnitofWork.MaintenanceCompanyLookUpRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceCompany = UnitofWork.MaintenanceCompanyRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceCompanySpecialization = UnitofWork.MaintenanceCompanySpecializationRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceCustomService = UnitofWork.MaintenanceCustomServiceRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceExterior = UnitofWork.MaintenanceExteriorRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceInterior = UnitofWork.MaintenanceInteriorRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceNewConstruction = UnitofWork.MaintenanceNewConstructionRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceRepair = UnitofWork.MaintenanceRepairRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceUtility = UnitofWork.MaintenanceUtilityRepository.FirstOrDefault(x => x.CompanyId == companyId)
                    };


            }

            return null;

        }

        public SpecialistMaintenanceProfile GetSpecialistCoverage(int specialistId)
        {
            const int specialistrole = 1;
            var specialistlookUp =
                UnitofWork.MaintenanceCompanyLookUpRepository.FirstOrDefault(x => x.Role == specialistrole && x.UserId == specialistId);
            if (specialistlookUp != null)
            {
                int companyId = specialistlookUp.CompanyId;

                return new SpecialistMaintenanceProfile
                    {
                        MaintenanceCompanyLookUp = UnitofWork.MaintenanceCompanyLookUpRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceCompany = UnitofWork.MaintenanceCompanyRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceCompanySpecialization = UnitofWork.MaintenanceCompanySpecializationRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceCustomService = UnitofWork.MaintenanceCustomServiceRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceExterior = UnitofWork.MaintenanceExteriorRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceInterior = UnitofWork.MaintenanceInteriorRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceNewConstruction = UnitofWork.MaintenanceNewConstructionRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceRepair = UnitofWork.MaintenanceRepairRepository.FirstOrDefault(x => x.CompanyId == companyId),
                        MaintenanceUtility = UnitofWork.MaintenanceUtilityRepository.FirstOrDefault(x => x.CompanyId == companyId)
                    };
            }
            return null;
        }

        public void RemoveSpecialist(int stid, int pid)
        {
            dynamic email = new Email("RemoveSpecialistForTeam/Multipart");
            var poster = UserHelper.GetSendtoFriendPoster() ?? UserHelper.PosterHelper.DefaultPoster;
            var selectedspecialist = UnitofWork.SpecialistRepository.FirstOrDefault(x => x.SpecialistId == pid);
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

        //************************************************** Team *************************************************//
        //*******************************************************************************************************//
        //*******************************************************************************************************//
        #endregion

        #region WIP

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

        //Continue from here like Owner for pending, accepted and rejected
        public ActionResult NewJobOffer()
        {
            var provider = UserHelper.ProviderPrivateProfileHelper.GetProvider();
            return View(UnitofWork.MaintenanceProviderAcceptedJobRepository.FindBy(x => x.MaintenanceProviderId == provider.MaintenanceProviderId).ToList());
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
        #endregion

        #region Common
        public void JNotify(string message = "", string url = "")
        {
            ViewBag.Confirmation = true;
            ViewBag.ConfirmationSuccess = new JNotfiyScriptQueryHelper().JNotifyConfirmationMessage(message, url);
        }
        #endregion

    }
}