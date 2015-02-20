using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using RentalMobile.Models;

namespace TestProject.Model
{
    public class FakeDbContext : DbContext
    {

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public DbSet<TenantShowing> TenantShowings { get; set; }

    public DbSet<Tenant> Tenants { get; set; }

    public DbSet<TenantFavorite> TenantFavorites { get; set; }

    public DbSet<TenantSavedSearch> TenantSavedSearches { get; set; }

    public DbSet<MaintenanceOrder> MaintenanceOrders { get; set; }

    public DbSet<MaintenancePhoto> MaintenancePhotoes { get; set; }

    public DbSet<OwnerMaintenance> OwnerMaintenances { get; set; }

    public DbSet<ServiceType> ServiceTypes { get; set; }

    public DbSet<sysdiagram> sysdiagrams { get; set; }

    public DbSet<UrgencyType> UrgencyTypes { get; set; }

    public DbSet<TenantMaintenance> TenantMaintenances { get; set; }

    public DbSet<Agent> Agents { get; set; }

    public DbSet<Owner> Owners { get; set; }

    public DbSet<Specialist> Specialists { get; set; }

    public DbSet<RentalApplication> RentalApplications { get; set; }

    public DbSet<OwnerPendingApplication> OwnerPendingApplications { get; set; }

    public DbSet<AgentAcceptedApplication> AgentAcceptedApplications { get; set; }

    public DbSet<AgentPendingApplication> AgentPendingApplications { get; set; }

    public DbSet<AgentRejectedApplication> AgentRejectedApplications { get; set; }

    public DbSet<OwnerAcceptedApplication> OwnerAcceptedApplications { get; set; }

    public DbSet<OwnerRejectedApplication> OwnerRejectedApplications { get; set; }

    public DbSet<AgentAcceptedPostedProject> AgentAcceptedPostedProjects { get; set; }

    public DbSet<AgentPendingPostedProject> AgentPendingPostedProjects { get; set; }

    public DbSet<AgentProject> AgentProjects { get; set; }

    public DbSet<AgentRejectedPostedProject> AgentRejectedPostedProjects { get; set; }

    public DbSet<OwnerAcceptedPostedProject> OwnerAcceptedPostedProjects { get; set; }

    public DbSet<OwnerPendingPostedProject> OwnerPendingPostedProjects { get; set; }

    public DbSet<OwnerProject> OwnerProjects { get; set; }

    public DbSet<OwnerRejectedPostedProject> OwnerRejectedPostedProjects { get; set; }

    public DbSet<MaintenanceProviderAcceptedJob> MaintenanceProviderAcceptedJobs { get; set; }

    public DbSet<MaintenanceProviderNewJobOffer> MaintenanceProviderNewJobOffers { get; set; }

    public DbSet<MaintenanceProviderRejectedJob> MaintenanceProviderRejectedJobs { get; set; }

    public DbSet<Project> Projects { get; set; }

    public DbSet<ProjectPhoto> ProjectPhotoes { get; set; }

    public DbSet<GeneratedRentalContract> GeneratedRentalContracts { get; set; }

    public DbSet<UploadedContract> UploadedContracts { get; set; }

    public DbSet<UnitFeature> UnitFeatures { get; set; }

    public DbSet<UnitInteriorAmenity> UnitInteriorAmenities { get; set; }

    public DbSet<UnitLuxuryAmenity> UnitLuxuryAmenities { get; set; }

    public DbSet<UnitPricing> UnitPricings { get; set; }

    public DbSet<UnitCommunityAmenity> UnitCommunityAmenities { get; set; }

    public DbSet<UnitAppliance> UnitAppliances { get; set; }

    public DbSet<UnitGallery> UnitGalleries { get; set; }

    public DbSet<Currency> Currencies { get; set; }

    public DbSet<Unit> Units { get; set; }

    public DbSet<Basement> Basements { get; set; }

    public DbSet<Cooling> Coolings { get; set; }

    public DbSet<Floor> Floors { get; set; }

    public DbSet<FloorCovering> FloorCoverings { get; set; }

    public DbSet<Foundation> Foundations { get; set; }

    public DbSet<Garage> Garages { get; set; }

    public DbSet<Heating> Heatings { get; set; }

    public DbSet<ParkingSpace> ParkingSpaces { get; set; }

    public DbSet<UnitType> UnitTypes { get; set; }

    public DbSet<Bathroom> Bathrooms { get; set; }

    public DbSet<Bed> Beds { get; set; }

    public DbSet<OwnerShowingCalendar> OwnerShowingCalendars { get; set; }

    public DbSet<OwnerPendingShowingCalendar> OwnerPendingShowingCalendars { get; set; }

    public DbSet<SpecialistPendingTeamInvitation> SpecialistPendingTeamInvitations { get; set; }

    public DbSet<MaintenanceTeamAssociation> MaintenanceTeamAssociations { get; set; }

    public DbSet<MaintenanceCompany> MaintenanceCompanies { get; set; }

    public DbSet<MaintenanceTeam> MaintenanceTeams { get; set; }

    public DbSet<MaintenanceCompanyLookUp> MaintenanceCompanyLookUps { get; set; }

    public DbSet<MaintenanceCrew> MaintenanceCrews { get; set; }

    public DbSet<UnitExteriorAmenity> UnitExteriorAmenities { get; set; }

    public DbSet<MaintenanceRepair> MaintenanceRepairs { get; set; }

    public DbSet<MaintenanceCompanySpecialization> MaintenanceCompanySpecializations { get; set; }

    public DbSet<MaintenanceCustomService> MaintenanceCustomServices { get; set; }

    public DbSet<MaintenanceExterior> MaintenanceExteriors { get; set; }

    public DbSet<MaintenanceInterior> MaintenanceInteriors { get; set; }

    public DbSet<MaintenanceNewConstruction> MaintenanceNewConstructions { get; set; }

    public DbSet<MaintenanceUtility> MaintenanceUtilities { get; set; }

    public DbSet<SpecialistWork> SpecialistWorks { get; set; }

    public DbSet<SpecialistProfileComment> SpecialistProfileComments { get; set; }

    public DbSet<ProviderWork> ProviderWorks { get; set; }

    public DbSet<MaintenanceProvider> MaintenanceProviders { get; set; }

    public DbSet<MaintenanceProviderZone> MaintenanceProviderZones { get; set; }

    public DbSet<ProviderProfileComment> ProviderProfileComments { get; set; }

    }
}
