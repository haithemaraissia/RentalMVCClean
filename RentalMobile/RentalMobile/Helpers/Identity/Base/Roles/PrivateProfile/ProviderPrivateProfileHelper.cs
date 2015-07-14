using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Identity.Abstract.Roles.PrivateProfile;
using RentalMobile.Helpers.JQuery;
using RentalMobile.Helpers.JQuery.JNotify;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Identity.Base.Roles.PrivateProfile
{

    public class ProviderPrivateProfileHelper : BaseController , IProviderPrivateProfileHelper
    {

        public string RequestId;
        public int SelectedTeam = 0;
        public int SelectedProfessionalId = 0;

        #region Main

        public ProviderPrivateProfileHelper(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        public MaintenanceProvider GetProvider()
        {
            var providerId = UserHelper.UserIdentity.GetProviderId();
            return UnitofWork.MaintenanceProviderRepository.FindBy(x => x.MaintenanceProviderId == providerId).FirstOrDefault();

        }
       
        public MaintenanceProvider GetPrivateProfileProviderByProviderId(int id)
        {
            var providerId = UserHelper.UserIdentity.GetProviderId();
            return UnitofWork.MaintenanceProviderRepository.FindBy(x => x.MaintenanceProviderId == providerId).FirstOrDefault();
        }

        public MaintenanceTeamAssociation GetMaintenanceTeamAssociations()
        {
            var providerId = GetProvider().MaintenanceProviderId;
            return
                UnitofWork.MaintenanceTeamAssociationRepository.FirstOrDefault(
                    x => x.MaintenanceProviderId == providerId);

        }

        public string ProviderGoogleMap()
        {
            return string.IsNullOrEmpty(GetProvider().Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(GetProvider().Address, GetProvider().City, GetProvider().CountryCode);
        }


        #endregion

        #region Coverage

        public ProviderMaintenanceProfile GetMaintenanceProviderProfile()
        {
            var providerId = UserHelper.GetProviderId();
            if (providerId == 0) return null;
            const int providerrole = 2;
            var lookUp =
                UnitofWork.MaintenanceCompanyLookUpRepository.FirstOrDefault(
                    x => x.Role == providerrole && x.UserId == providerId);
            if (lookUp == null) return null;
            var companyId = lookUp.CompanyId;
            return GetMaintenanceProviderProfileByCompanyId(companyId);
        }

        public ProviderMaintenanceProfile GetMaintenanceProviderProfileByCompanyId(int companyId)
        {

            var providerId = GetProvider().MaintenanceProviderId;
            return new ProviderMaintenanceProfile
            {
            
              MaintenanceProvider = UnitofWork.MaintenanceProviderRepository.FirstOrDefault(x=>x.MaintenanceProviderId == providerId),
              MaintenanceCompanyLookUp = UnitofWork.MaintenanceCompanyLookUpRepository.FirstOrDefault(x => x.CompanyId == companyId),
              MaintenanceCompany = UnitofWork.MaintenanceCompanyRepository.FirstOrDefault(x => x.CompanyId == companyId),
              MaintenanceCompanySpecialization = UnitofWork.MaintenanceCompanySpecializationRepository.FirstOrDefault(x => x.CompanyId == companyId),
              MaintenanceCustomService = UnitofWork.MaintenanceCustomServiceRepository.FirstOrDefault(x => x.CompanyId == companyId),
              MaintenanceExterior = UnitofWork.MaintenanceExteriorRepository.FirstOrDefault(x => x.CompanyId == companyId),
              MaintenanceInterior = UnitofWork.MaintenanceInteriorRepository.FirstOrDefault(x => x.CompanyId == companyId),
              MaintenanceNewConstruction = UnitofWork.MaintenanceNewConstructionRepository.FirstOrDefault(x => x.CompanyId == companyId),
              MaintenanceRepair = UnitofWork.MaintenanceRepairRepository.FirstOrDefault(x => x.CompanyId == companyId),
              MaintenanceUtility = UnitofWork.MaintenanceUtilityRepository.FirstOrDefault(x => x.CompanyId == companyId),
            
            };
        }

        public string DoesProviderHasTeam()
        {
            var providerId = GetProvider().MaintenanceProviderId;
            return UnitofWork.MaintenanceTeamRepository.FindBy(
                x => x.MaintenanceProviderId == providerId).Any() ? "true" : "false;";
        }

        public int GetTotalAvailableZoneSpot()
        {
            var providerId = GetProvider().MaintenanceProviderId;
            return UnitofWork.MaintenanceTeamAssociationRepository.Count(x => x.MaintenanceProviderId == providerId) * 2;
        }

        public List<MaintenanceProviderZone> GetDistinctProviderZones()
        {
            var providerId = GetProvider().MaintenanceProviderId;
            ViewBag.TotalAvailableZoneSpot = UnitofWork.MaintenanceTeamAssociationRepository.Count(x => x.MaintenanceProviderId == providerId) * 2;
            var distinctMaintenanceProviderZones =
                UnitofWork.MaintenanceProviderZoneRepository
                   .FindBy(maitnenanceproviderzone => maitnenanceproviderzone.MaintenanceProviderId == providerId)
                  .GroupBy(maitnenanceproviderzone => maitnenanceproviderzone.ZipCode,
                           (key, group) => group.FirstOrDefault())
                  .OrderBy(filteredZone => filteredZone.ZipCode).
                   ToList();
            return distinctMaintenanceProviderZones;
        }

        public List<MaintenanceProviderZone> GetAllProviderZones()
        {
            var providerId = GetProvider().MaintenanceProviderId;
            return UnitofWork.MaintenanceProviderZoneRepository.FindBy(x => x.MaintenanceProviderId == providerId).ToList();
        }

        public int GetAllZonesUsedCount()
        {
            var providerId = GetProvider().MaintenanceProviderId;
            return UnitofWork.MaintenanceProviderZoneRepository.
                                                FindBy(
                                                    maitnenanceproviderzone =>
                                                    maitnenanceproviderzone.MaintenanceProviderId == providerId)
                                               .GroupBy(maitnenanceproviderzone => maitnenanceproviderzone.ZipCode,
                                                        (key, group) => group.FirstOrDefault())
                                               .OrderBy(filteredZone => filteredZone.ZipCode).
                                                Count();
        }

        public bool IsProviderZoneAlreadyExist(MaintenanceProviderZone maintenanceproviderzone, List<MaintenanceProviderZone> maintenanceProviderZones)
        {
            return maintenanceProviderZones.Exists(x => x.ZipCode == maintenanceproviderzone.ZipCode);
        }

        public void AddNewMaintenanceProviderZone(MaintenanceProviderZone maintenanceproviderzone, List<MaintenanceProviderZone> maintenanceProviderZones)
        {                
            var providerId = GetProvider().MaintenanceProviderId;
            var teamMemberCount = 0;
            if (maintenanceProviderZones.Any())
            {

                teamMemberCount =
                    UnitofWork.MaintenanceTeamAssociationRepository.Count(
                        x => x.MaintenanceProviderId == providerId);
            }
            //Validation To Not Exceed the allowed number of zones
            var availablezoneplaceholder =
                UnitofWork.MaintenanceTeamAssociationRepository.Count(x => x.MaintenanceProviderId == providerId)*2 + 1;
            var zoneplaceholderused = UserHelper.ProviderPrivateProfileHelper.GetAllZonesUsedCount();
            if (availablezoneplaceholder > zoneplaceholderused)
            {
                UnitofWork.MaintenanceProviderZoneRepository.Add(
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
            UnitofWork.Save();
        }

        public bool IsZipcodeBelongtoTeamMember(int providerId, string zipcode)
        {
            var teamList =
                UnitofWork.MaintenanceTeamAssociationRepository.FindBy(x => x.MaintenanceProviderId == providerId)
                  .Select(x => x.SpecialistId)
                  .ToList();
            var teamListZipCode = (from teammember in teamList
                                   select UnitofWork.SpecialistRepository.
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
            var providerId = provider;
            var maintenanceProviderZones =
                UnitofWork.MaintenanceProviderZoneRepository.FindBy(x => x.MaintenanceProviderId == providerId).ToList();
            return maintenanceProviderZones.Any()
                ? UnitofWork.MaintenanceTeamAssociationRepository.Count(x => x.MaintenanceProviderId == providerId)
                : 0;
        }

        public JNotifyMessage RemoveProviderZone(MaintenanceProviderZone maintenanceproviderzone)
        {
            if (IsZipcodeBelongtoTeamMember(GetProvider().MaintenanceProviderId, maintenanceproviderzone.ZipCode))
            {
                return new JNotifyMessage("Your can not delete your Team Member Zone. The Zone Coverage is based upon Team Member Profile", "#");
            }
            else
            {
                return DeleteMaintenanceProviderZone(maintenanceproviderzone);
            }
        }

        public JNotifyMessage DeleteMaintenanceProviderZone(MaintenanceProviderZone maintenanceproviderzone)
        {
            if (maintenanceproviderzone.ZipCode != GetProvider().Zip)
            {
                UnitofWork.MaintenanceProviderZoneRepository.Delete(maintenanceproviderzone);
                var teamMemberCount = GetmNumberofMembersInTeam();
                maintenanceproviderzone.TeamMemberCount = teamMemberCount - 1;
                UnitofWork.Save();
                return new JNotifyMessage("Your zone has been deleted.", "/Provider/#coverage");
            }
            else
            {
                return new JNotifyMessage("Your can not delete your own zone.Update your profile instead", "#");
            }
        }

        public JNotifyMessage UpdateZone(MaintenanceProviderZone maintenanceproviderzone)
        {
            // var currentMaintenanceProviderzone = UnitofWork.MaintenanceProviderZoneRepository.FirstOrDefault( x => x.MaintenanceProviderZoneId == maintenanceproviderzone.MaintenanceProviderZoneId);
            if (UserHelper.ProviderPrivateProfileHelper.IsZipcodeBelongtoTeamMember(UserHelper.ProviderPrivateProfileHelper.GetProvider().MaintenanceProviderId, maintenanceproviderzone.ZipCode))
            {
                //Zip exist in the team list zip
                ModelState.AddModelError("Zone Update ", @"Your can not update your Team Member Zone. The Zone Coverage is based upon Team Member Profile");
                return new JNotifyMessage("Your can not update your Team Member Zone. The Zone Coverage is based upon Team Member Profile", "/Provider/#coverage");

            }
            if (UserHelper.ProviderPrivateProfileHelper.GetProvider().Zip != null && UserHelper.ProviderPrivateProfileHelper.GetProvider().Zip == maintenanceproviderzone.ZipCode)
            {
                //same zip as the provider
                ModelState.AddModelError("Zone Update ", @"Your can not update your Team Member Zone. The Zone Coverage is based upon Team Member Profile");
                return new JNotifyMessage("Your can not update your Zone from this section. Please update your profile to reflect the new zone", "/Provider/#coverage");
            }
            //Update the Zone
            var oldzone = UnitofWork.MaintenanceProviderZoneRepository.First(x => x.MaintenanceProviderZoneId == maintenanceproviderzone.MaintenanceProviderZoneId);
            if (oldzone != null)
            {
                oldzone.CityName = maintenanceproviderzone.CityName;
                oldzone.ZipCode = maintenanceproviderzone.ZipCode;
                UnitofWork.Save();
            }
            return new JNotifyMessage("Your zone has been updated.", "/Provider/#coverage");
        }

        public List<TeamSpecialistInvitation> GetAllSpecialistThatHasPendingTeamInvitation()
        {
            var providerId = GetProvider().MaintenanceProviderId;
            var allteam = UnitofWork.MaintenanceTeamRepository.FindBy
                (x => x.MaintenanceProviderId == providerId)
                .Select(x => x.TeamId).ToList();
            var teamSpecialistPendingList = (from currenteam in allteam
                                             from specialistPendingTeamInvitation in
                                                 UnitofWork.SpecialistPendingTeamInvitationRepository.FindBy(
                                                     x => x.TeamId == currenteam)
                                             let currentspecialist =
                                                 UnitofWork.SpecialistRepository.FirstOrDefault(
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
            return teamSpecialistPendingList;
        }

        #endregion

        #region Account

        public void CompleteProviderProfile(ProviderMaintenanceProfile s)
        {
            s.MaintenanceCompanySpecialization.Currency = UserHelper.GetCurrencyValue(s.MaintenanceCompanySpecialization.CurrencyID);
            UnitofWork.MaintenanceProviderRepository.Edit(s.MaintenanceProvider);
            UnitofWork.MaintenanceCompanyRepository.Edit(s.MaintenanceCompany);
            UnitofWork.MaintenanceCompanyLookUpRepository.Edit(s.MaintenanceCompanyLookUp);
            UnitofWork.MaintenanceCompanySpecializationRepository.Edit(s.MaintenanceCompanySpecialization);
            UpdateProviderProfileCompletion(CalculateNewProviderProfileCompletionPercentage(s.MaintenanceCompany));
            UpdateproviderProfile(s.MaintenanceProvider, s.MaintenanceCompany);
            UpdateProviderZoneList(s.MaintenanceCompany.Zip, s.MaintenanceCompany.City);
            UnitofWork.Save();
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

        public void UpdateProviderZoneList(string providerCompanyZip = "", string providerCompanyZipCity = "")
        {
            if (providerCompanyZip == null) return;
            var provider = UserHelper.ProviderPrivateProfileHelper.GetProvider();
            var maintenanceProviderZonesList = UnitofWork.MaintenanceProviderZoneRepository.FindBy(x => x.MaintenanceProviderId == provider.MaintenanceProviderId).ToList();
            if (maintenanceProviderZonesList.Exists(x => x.ZipCode == providerCompanyZip.ToString(CultureInfo.InvariantCulture))) return;
            if (maintenanceProviderZonesList.Exists(x => x.ZipCode == provider.Zip))
            {
                maintenanceProviderZonesList.RemoveAll(x => x.ZipCode == provider.Zip);
            }
            if (providerCompanyZipCity != null)
                UnitofWork.MaintenanceProviderZoneRepository.Add(new MaintenanceProviderZone
                {
                    CityName = providerCompanyZipCity,
                    Country = "US",
                    MaintenanceProviderId = provider.MaintenanceProviderId,
                    ZipCode = providerCompanyZip,
                    TeamMemberCount = UserHelper.ProviderPrivateProfileHelper.GetmNumberofMembersInTeam()
                });
        }

        // ReSharper disable once FunctionComplexityOverflow
        public void UpdateproviderProfile(MaintenanceProvider p, MaintenanceCompany m)
        {
            var providerId = UserHelper.GetProviderId();
            var provider = UnitofWork.MaintenanceProviderRepository.FirstOrDefault(x => x.MaintenanceProviderId == providerId);
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
        public int CalculateNewProviderProfileCompletionPercentage(MaintenanceCompany m)
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

        public void UpdateProviderProfileCompletion(int newprofilecompletionpercentage)
        {
            var currentprovider = UserHelper.ProviderPrivateProfileHelper.GetProvider();
            if (currentprovider != null)
                currentprovider.PercentageofCompletion = newprofilecompletionpercentage;
        }

        public void DeleteProviderMemebership()
        {
            var username = UserHelper.GetUserName();
            if (MembershipService.GetRolesForUser(username).Any())
            {
                MembershipService.RemoveUserFromRoles(username,
                    MembershipService.GetRolesForUser(username));
            }
            MembershipService.DeleteUser(username);
            MembershipService.SignOut();
        }

        public void DeleteProviderRecords(int providerId)
        {
            //Provider
            UnitofWork.MaintenanceProviderRepository.Delete(GetPrivateProfileProviderByProviderId(providerId));

            //TODO// Delete All associated records
            //var ProviderProfilehowing = Db.ProviderProfilehowings.Where(x => x.ProviderId == id).ToList();
            //foreach (var x in ProviderProfilehowing)
            //{
            //    Db.ProviderProfilehowings.Remove(x);
            //}
            //Db.SaveChanges();

            UnitofWork.Save();
        }

        // ReSharper disable once FunctionComplexityOverflow
        public void UpdateProviderMaintenanceCompany()
        {
                var providerUserId = UserHelper.GetProviderId();
                const int providerrole = 2;
                var lookUp =UnitofWork.MaintenanceCompanyLookUpRepository.FirstOrDefault(x => x.Role == providerrole && x.UserId == providerUserId);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;
                    var maintenanceCompany = UnitofWork.MaintenanceCompanyRepository.FirstOrDefault(x=>x.CompanyId == companyId);
                    if (maintenanceCompany != null)
                    {
                        var provider = UserHelper.ProviderPrivateProfileHelper.GetProvider();
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

                        UnitofWork.Save();
                    }

                }
            
        }

        public decimal? GetProviderRate(int providerId)
        {
            var providerMaintenanceCompany = UnitofWork.MaintenanceCompanyLookUpRepository.FirstOrDefault(x => x.UserId == providerId);
            if (providerMaintenanceCompany != null)
            {
                var providercompanyid = providerMaintenanceCompany.CompanyId;
                var providercompany =
                    UnitofWork.MaintenanceCompanySpecializationRepository.FirstOrDefault(x => x.CompanyId == providercompanyid);

                if (providercompany != null)
                {

                    return (decimal)providercompany.Rate;
                }
                return null;
            }
            return null;
        }

        public List<MaintenanceCompany> GetProviderCompanies()
        {
            var providerMaintenanceCompanies = new List<MaintenanceCompany>();
            var providerMaintenanceCompanyLookup = UnitofWork.MaintenanceCompanyLookUpRepository.FindBy(x => x.UserId == UserHelper.GetProviderId());
            if (providerMaintenanceCompanyLookup != null)
            {
                providerMaintenanceCompanies.AddRange(providerMaintenanceCompanyLookup.
                                 Select(maintenanceCompanyLookUp =>
                                     UnitofWork.MaintenanceCompanyRepository.FirstOrDefault(
                                     x => x.CompanyId == maintenanceCompanyLookUp.CompanyId)).
                                 Where(currentMaintenanceCompany => currentMaintenanceCompany != null));
                return providerMaintenanceCompanies.ToList();
            }
            return null;
        }

        #endregion

        #region Team
        /// <summary/>
        /// Team Tab
        /// Finished and Clean
        /// Only 1 team can exist
        
        public IEnumerable<Specialist> GetAllSpecialistsWithoutExistingOrPendingTeamAssociationWithProvider(int specialistId, int maintenanceProviderId)
        {
            //Get all specialist that don't have pending association or all already associated with the Team
            var existingTeamAssociation = UnitofWork.MaintenanceTeamAssociationRepository.FindBy( x => x.SpecialistId == specialistId && x.MaintenanceProviderId == maintenanceProviderId).Select(x => x.SpecialistId).ToList();
            var pendingTeamAssociation = UnitofWork.SpecialistPendingTeamInvitationRepository.FindBy(x => x.SpecialistID == specialistId && x.MaintenanceProviderId == maintenanceProviderId).Select(x => x.SpecialistID).ToList();
            var mergedExistingandPendingTeamAssociation = new List<int>(existingTeamAssociation.Union(pendingTeamAssociation));
            var excludedSpecialistList = UnitofWork.SpecialistRepository.FindBy(x => mergedExistingandPendingTeamAssociation.Contains(x.SpecialistId));
            var filterSpecialistList = UnitofWork.SpecialistRepository.FindBy(x => x.SpecialistId == specialistId).Except(excludedSpecialistList).ToList();
            return filterSpecialistList;
        }

        public void AddNewPendingSpecialistInvitationToProviderTeam(Specialist specialist, int specialistId, int maintenanceProviderId)
        {
            var teamlist = UnitofWork.MaintenanceTeamAssociationRepository.FindBy(x => x.MaintenanceProviderId == maintenanceProviderId).ToList();
            var teamcount = UnitofWork.MaintenanceTeamAssociationRepository.Count(x => x.MaintenanceProviderId == maintenanceProviderId);
            switch (teamcount)
            {
                //if Provider has no team
                case 0:
                    //UI for Creating Team and renaming and deleting Team
                    //Redirect to create team
                    RedirectToAction("Create", "Team");
                    break;
                //If Provider has only 1 team then proceed
                case 1:
                    if (ModelState.IsValid)
                    {
                        var currentteam = teamlist.First();
                        var npti = new SpecialistPendingTeamInvitation
                        {
                            MaintenanceProviderId = maintenanceProviderId,
                            SpecialistID = specialistId,
                            TeamId = currentteam.TeamId,
                            TeamName = currentteam.TeamName
                        };
                        UnitofWork.SpecialistPendingTeamInvitationRepository.Add(npti);
                        UnitofWork.Save();
                    }
                    break;
                // Else if Provider has more than 1
                default:
                    if (teamcount > 1)
                    {
                        RedirectToAction("SelectTeam", "Team");
                        RedirectToAction("SelectTeam", "Team", new { id = specialistId });
                    }
                    break;
            }
        }

        #endregion

    }
}