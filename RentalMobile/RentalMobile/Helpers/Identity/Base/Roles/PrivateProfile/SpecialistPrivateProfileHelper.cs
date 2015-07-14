using System.Linq;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Identity.Abstract.Roles.PrivateProfile;
using RentalMobile.Helpers.JQuery.JNotify;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalMobile.Process;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Identity.Base.Roles.PrivateProfile
{

    public class SpecialistPrivateProfileHelper : BaseController, ISpecialistPrivateProfileHelper
    {

        public string RequestId;
        public string PhotoPath;

        #region SpecialistHelper Constructor
        /// SpecialistHelper

        public SpecialistPrivateProfileHelper(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        public Specialist GetSpecialist()
        {
            var specialistId = UserHelper.UserIdentity.GetSpecialistId();
            return UnitofWork.SpecialistRepository.FindBy(x => x.SpecialistId == specialistId).FirstOrDefault();
        }

        public Specialist GetPrivateProfileSpecialistBySpecialistId(int id)
        {
            var specialistId = UserHelper.UserIdentity.GetSpecialistId();
            return UnitofWork.SpecialistRepository.FindBy(x => x.SpecialistId == specialistId).FirstOrDefault();
        }

        public string SpecialistGoogleMap()
        {
            return string.IsNullOrEmpty(GetSpecialist().Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(GetSpecialist().Address, GetSpecialist().City, GetSpecialist().CountryCode);
        }

        public void DeleteSpecialistMemebership()
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

        /// TODO ///
        /// NOT Complete, wrong
        public void UploadPhoto()
        {
                ViewBag.Id = UserHelper.UserIdentity.GetSpecialistId();
                ViewBag.UserName = UserHelper.GetUserName();
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetSpecialistId();

        }

        public void CompleteSpecialistMaitenanceProfile(SpecialistMaintenanceProfile spf)
        {
            EditSpecialistMaintenanceProfile(spf);
            SpecialistPrivateUpdateProfileCompletion(SpecialistPrivateCalculateNewProfileCompletionPercentage(spf.MaintenanceCompany));
            UpdateSpecialistProfile(spf.MaintenanceCompany);
            UnitofWork.Save();
        }

        public void EditSpecialistMaintenanceProfile(SpecialistMaintenanceProfile spf)
        {
            spf.MaintenanceCompanySpecialization.Currency = UserHelper.GetCurrencyValue(spf.MaintenanceCompanySpecialization.CurrencyID);

            UnitofWork.MaintenanceCompanyRepository.Edit(spf.MaintenanceCompany);
            UnitofWork.MaintenanceCompanyLookUpRepository.Edit(spf.MaintenanceCompanyLookUp);
            UnitofWork.MaintenanceCompanySpecializationRepository.Edit(spf.MaintenanceCompanySpecialization);
            UnitofWork.MaintenanceCustomServiceRepository.Edit(spf.MaintenanceCustomService);
            UnitofWork.MaintenanceExteriorRepository.Edit(spf.MaintenanceExterior);
            UnitofWork.MaintenanceInteriorRepository.Edit(spf.MaintenanceInterior);
            UnitofWork.MaintenanceNewConstructionRepository.Edit(spf.MaintenanceNewConstruction);
            UnitofWork.MaintenanceRepairRepository.Edit(spf.MaintenanceRepair);
            UnitofWork.MaintenanceUtilityRepository.Edit(spf.MaintenanceUtility);
        }

        public void UpdateSpecialistProfile(MaintenanceCompany m)
        {
            var specialist = GetSpecialist();

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
            specialist.GoogleMap = m.GoogleMap = SpecialistGoogleMap();
        }

        public int SpecialistPrivateCalculateNewProfileCompletionPercentage(MaintenanceCompany m)
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

        public void SpecialistPrivateUpdateProfileCompletion(int newprofilecompletionpercentage)
        {
            var specialistId = UserHelper.GetSpecialistId();
            if (specialistId == 0) return;
            var currentspecialist = UnitofWork.SpecialistRepository.FirstOrDefault(x => x.SpecialistId == specialistId);
            if (currentspecialist != null)
                currentspecialist.PercentageofCompletion = newprofilecompletionpercentage;
        }

        public decimal? GetProfessionalRate(int specialistId)
        {
            var specialistMaintenanceCompany = UnitofWork.MaintenanceCompanyLookUpRepository.FirstOrDefault(x => x.UserId == specialistId);
            if (specialistMaintenanceCompany != null)
            {
                var specialistcompanyid = specialistMaintenanceCompany.CompanyId;
                var specialistcompany = UnitofWork.MaintenanceCompanySpecializationRepository.FirstOrDefault(x => x.CompanyId == specialistcompanyid);
                if (specialistcompany != null)
                {
                    return (decimal)specialistcompany.Rate;
                }
                return null;
            }
            return null;
        }
        
        #endregion

        #region Provider Tab
        /// Provider Tab
        /// 
        /// 

        public SpecialistMaintenanceProfile GetSpecialistMaitenanceProfile()
        {
            var specialistId = UserHelper.GetSpecialistId();
            if (specialistId == 0) return null;
            const int specialistrole = 1;
            var lookUp =
                UnitofWork.MaintenanceCompanyLookUpRepository.FirstOrDefault(
                    x => x.Role == specialistrole && x.UserId == specialistId);
            if (lookUp == null) return null;
            var companyId = lookUp.CompanyId;
            return GetSpecialistMaintenanceProfileByCompanyId(companyId);
        }

        public SpecialistMaintenanceProfile GetSpecialistMaintenanceProfileByCompanyId(int companyId)
        {
            return new SpecialistMaintenanceProfile
            {
                MaintenanceCompanyLookUp = UnitofWork.MaintenanceCompanyLookUpRepository.FirstOrDefault(x=>x.CompanyId == companyId),
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

        public void AcceptInvitation(SpecialistPendingTeamInvitation sti)
        {
            var invitation =
                UnitofWork.SpecialistPendingTeamInvitationRepository.FirstOrDefault(
                    x => x.PendingTeamInvitationID == sti.PendingTeamInvitationID);
            var mti = new MaintenanceTeamAssociation
            {
                TeamId = sti.TeamId,
                TeamName = sti.TeamName,
                MaintenanceProviderId = sti.MaintenanceProviderId,
                SpecialistId = sti.SpecialistID
            };
            UnitofWork.MaintenanceTeamAssociationRepository.Add(mti);
            UnitofWork.SpecialistPendingTeamInvitationRepository.Delete(invitation);
            AddSpecialistZoneToProviderTeamZone(sti.MaintenanceProviderId, sti.SpecialistID);
            UnitofWork.Save();
            var teamcoverageUpdate = new UpdateCoverage(sti.MaintenanceProviderId, sti.SpecialistID);
            teamcoverageUpdate.AddAllCoverageFromSpecialistToTeam();
            new JNotfiyScriptQueryHelper().JNotifyConfirmationMessage("Your request has been completed.", "/Specialist/CurrentProvider");
        }

        public void AddSpecialistZoneToProviderTeamZone(int providerId, int specialistId)
        {
            var specialist = UserHelper.SpecialistPrivateProfileHelper.GetPrivateProfileSpecialistBySpecialistId(specialistId);
            {
                var teamMemberCount = 0;
                var maintenanceProviderZones = 
                    UnitofWork.MaintenanceProviderRepository.FindBy(x => x.MaintenanceProviderId == providerId).ToList();
                if (maintenanceProviderZones.Exists(x => specialist != null && x.Zip == specialist.Zip))
                {
                    return;
                }
                if (maintenanceProviderZones.Any())
                {
                    teamMemberCount =
                        UnitofWork.MaintenanceTeamAssociationRepository.Count(x => x.MaintenanceProviderId == providerId);
                }
                if (specialist != null)
                    UnitofWork.MaintenanceProviderZoneRepository.Add(
                        new MaintenanceProviderZone
                        {
                            CityName = specialist.City,
                            Country = specialist.Country,
                            MaintenanceProviderId = providerId,
                            ZipCode = specialist.Zip,
                            TeamMemberCount = teamMemberCount + 1

                        }
                        );
               UnitofWork.Save();
            }
        }

        public void DenyInvitation(SpecialistPendingTeamInvitation sti)
        {
            var invitation =
                UnitofWork.SpecialistPendingTeamInvitationRepository.FirstOrDefault(
                    x => x.PendingTeamInvitationID == sti.PendingTeamInvitationID);
            UnitofWork.SpecialistPendingTeamInvitationRepository.Delete(invitation);
            UnitofWork.Save();
            new JNotfiyScriptQueryHelper().JNotifyConfirmationMessage("Your request has been completed.", "~/Specialist/ProviderInvitation");
        }

        public void RemoveTeamAssociation(MaintenanceTeamAssociation mta)
        {
            var maintenanceteamassociation = UnitofWork.MaintenanceTeamAssociationRepository.FirstOrDefault(x => x.TeamAssociationID == mta.TeamAssociationID);
            UnitofWork.MaintenanceTeamAssociationRepository.Delete(maintenanceteamassociation);
            UnitofWork.Save();
            ViewBag.Confirmation = true;
            ViewBag.ConfirmationSuccess = new JNotfiyScriptQueryHelper().JNotifyConfirmationMessage("Your request has been completed.", "~/Specialist/CurrentProvider");
        }

     #endregion


        #region Coverage Tab
        /// Region Tab
        /// 
        /// 


        #endregion

    }
}