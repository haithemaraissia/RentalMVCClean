using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentalMobile.Controllers;
using RentalMobile.Helpers;
using RentalMobile.Model.Models;
using RentalMobile.Models;

namespace RentalMobile.Handler
{
    /// <summary>
    /// Summary description for RoutinePerformance
    /// </summary>
    public class RoutinePerformance : IHttpHandler
    {
        public RentalContext Db = new RentalContext();
        public void ProcessRequest(HttpContext context)
        {
            CoverageMaintenanceRoutineForProvider();
            context.Response.Write("Completed");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void CoverageMaintenanceRoutineForProvider()
        {

            foreach (var maintenanceProvider in Db.MaintenanceProviders.ToList())
            {
                var checkteamexistance = Db.MaintenanceTeamAssociations.FirstOrDefault(
                  x => x.MaintenanceProviderId == maintenanceProvider.MaintenanceProviderId);
                var allTeamAssociations =
                    Db.MaintenanceTeamAssociations.Where(x => x.MaintenanceProviderId == maintenanceProvider.MaintenanceProviderId)
                      .ToList();
                if (checkteamexistance == null) continue;
                var team = GetProviderTeam(allTeamAssociations);

                foreach (var teammate in team)
                {
                    CleanProviderCoverageMaintenance(maintenanceProvider.MaintenanceProviderId);
                    UpdateProviderCoverageMaintenance(maintenanceProvider.MaintenanceProviderId,
                                                      teammate.SpecialistId);
                }
            }
        }

        public void CleanProviderCoverageMaintenance(int maintenanceProviderId)
        {
            AddSpecialistZoneToProviderTeamZone(maintenanceProviderId,0);
            var teamcoverageUpdate = new UpdateCoverage(maintenanceProviderId,0);
            teamcoverageUpdate.CleanOutProvider();
        }

        public void UpdateProviderCoverageMaintenance(int maintenanceProviderId, int specialistId)
        {
            AddSpecialistZoneToProviderTeamZone(maintenanceProviderId, specialistId);
            //Db.SaveChanges();
            var teamcoverageUpdate = new UpdateCoverage(maintenanceProviderId, specialistId);
            teamcoverageUpdate.AddAllCoverageFromSpecialistToTeam();
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


    }
}