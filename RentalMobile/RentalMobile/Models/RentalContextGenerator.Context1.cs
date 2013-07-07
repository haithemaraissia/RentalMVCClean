﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentalMobile.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_33736_rentalEntities : DbContext
    {
        public DB_33736_rentalEntities()
            : base("name=DB_33736_rentalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<UnitGallery> UnitGalleries { get; set; }
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
        public DbSet<UnitAppliance> UnitAppliances { get; set; }
        public DbSet<UnitCommunityAmenity> UnitCommunityAmenities { get; set; }
        public DbSet<UnitExteriorAmenity> UnitExteriorAmenities { get; set; }
        public DbSet<UnitInteriorAmenity> UnitInteriorAmenities { get; set; }
        public DbSet<UnitLuxuryAmenity> UnitLuxuryAmenities { get; set; }
        public DbSet<UnitPricing> UnitPricings { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitFeature> UnitFeatures { get; set; }
        public DbSet<MaintenanceProvider> MaintenanceProviders { get; set; }
        public DbSet<MaintenanceExterior> MaintenanceExteriors { get; set; }
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
    }
}
