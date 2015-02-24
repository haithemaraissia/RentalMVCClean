using System;
using RentalMobile.Model.Models;
using RentalMobile.Models;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Generic.UnitofWork
{
    public partial interface IGenericUnitofWork :IDisposable
    {
      IGenericRepository<Agent> AgentRepository {get;}
     IGenericRepository<AgentAcceptedApplication> AgentAcceptedApplicationRepository {get;}
     IGenericRepository<AgentAcceptedPostedProject> AgentAcceptedPostedProjectRepository {get;}
     IGenericRepository<AgentPendingApplication> AgentPendingApplicationRepository {get;}
     IGenericRepository<AgentPendingPostedProject> AgentPendingPostedProjectRepository {get;}
     IGenericRepository<AgentProject> AgentProjectRepository {get;}
     IGenericRepository<AgentRejectedApplication> AgentRejectedApplicationRepository {get;}
     IGenericRepository<AgentRejectedPostedProject> AgentRejectedPostedProjectRepository {get;}
     IGenericRepository<Basement> BasementRepository {get;}
     IGenericRepository<Bathroom> BathroomRepository {get;}
     IGenericRepository<Bed> BedRepository {get;}
     IGenericRepository<Cooling> CoolingRepository {get;}
     IGenericRepository<Currency> CurrencyRepository {get;}
     IGenericRepository<Floor> FloorRepository {get;}
     IGenericRepository<FloorCovering> FloorCoveringRepository {get;}
     IGenericRepository<Foundation> FoundationRepository {get;}
     IGenericRepository<Garage> GarageRepository {get;}
     IGenericRepository<GeneratedRentalContract> GeneratedRentalContractRepository {get;}
     IGenericRepository<Heating> HeatingRepository {get;}
     IGenericRepository<MaintenanceCompany> MaintenanceCompanyRepository {get;}
     IGenericRepository<MaintenanceCompanyLookUp> MaintenanceCompanyLookUpRepository {get;}
     IGenericRepository<MaintenanceCompanySpecialization> MaintenanceCompanySpecializationRepository {get;}
     IGenericRepository<MaintenanceCrew> MaintenanceCrewRepository {get;}
     IGenericRepository<MaintenanceCustomService> MaintenanceCustomServiceRepository {get;}
     IGenericRepository<MaintenanceExterior> MaintenanceExteriorRepository {get;}
     IGenericRepository<MaintenanceInterior> MaintenanceInteriorRepository {get;}
     IGenericRepository<MaintenanceNewConstruction> MaintenanceNewConstructionRepository {get;}
     IGenericRepository<MaintenanceOrder> MaintenanceOrderRepository {get;}
     IGenericRepository<MaintenancePhoto> MaintenancePhotoRepository {get;}
     IGenericRepository<MaintenanceProvider> MaintenanceProviderRepository {get;}
     IGenericRepository<MaintenanceProviderAcceptedJob> MaintenanceProviderAcceptedJobRepository {get;}
     IGenericRepository<MaintenanceProviderNewJobOffer> MaintenanceProviderNewJobOfferRepository {get;}
     IGenericRepository<MaintenanceProviderRejectedJob> MaintenanceProviderRejectedJobRepository {get;}
     IGenericRepository<MaintenanceProviderZone> MaintenanceProviderZoneRepository {get;}
     IGenericRepository<MaintenanceRepair> MaintenanceRepairRepository {get;}
     IGenericRepository<MaintenanceTeam> MaintenanceTeamRepository {get;}
     IGenericRepository<MaintenanceTeamAssociation> MaintenanceTeamAssociationRepository {get;}
     IGenericRepository<MaintenanceUtility> MaintenanceUtilityRepository {get;}
     IGenericRepository<Owner> OwnerRepository {get;}
     IGenericRepository<OwnerAcceptedApplication> OwnerAcceptedApplicationRepository {get;}
     IGenericRepository<OwnerAcceptedPostedProject> OwnerAcceptedPostedProjectRepository {get;}
     IGenericRepository<OwnerMaintenance> OwnerMaintenanceRepository {get;}
     IGenericRepository<OwnerPendingApplication> OwnerPendingApplicationRepository {get;}
     IGenericRepository<OwnerPendingPostedProject> OwnerPendingPostedProjectRepository {get;}
     IGenericRepository<OwnerPendingShowingCalendar> OwnerPendingShowingCalendarRepository {get;}
     IGenericRepository<OwnerProject> OwnerProjectRepository {get;}
     IGenericRepository<OwnerRejectedApplication> OwnerRejectedApplicationRepository {get;}
     IGenericRepository<OwnerRejectedPostedProject> OwnerRejectedPostedProjectRepository {get;}
     IGenericRepository<OwnerShowingCalendar> OwnerShowingCalendarRepository {get;}
     IGenericRepository<ParkingSpace> ParkingSpaceRepository {get;}
     IGenericRepository<Project> ProjectRepository {get;}
     IGenericRepository<ProjectPhoto> ProjectPhotoRepository {get;}
     IGenericRepository<ProviderProfileComment> ProviderProfileCommentRepository {get;}
     IGenericRepository<ProviderWork> ProviderWorkRepository {get;}
     IGenericRepository<RentalApplication> RentalApplicationRepository {get;}
     IGenericRepository<ServiceType> ServiceTypeRepository {get;}
     IGenericRepository<Specialist> SpecialistRepository {get;}
     IGenericRepository<SpecialistPendingTeamInvitation> SpecialistPendingTeamInvitationRepository {get;}
     IGenericRepository<SpecialistProfileComment> SpecialistProfileCommentRepository {get;}
     IGenericRepository<SpecialistWork> SpecialistWorkRepository {get;}
     IGenericRepository<Tenant> TenantRepository {get;}
     IGenericRepository<TenantFavorite> TenantFavoriteRepository {get;}
     IGenericRepository<TenantMaintenance> TenantMaintenanceRepository {get;}
     IGenericRepository<TenantSavedSearch> TenantSavedSearchRepository {get;}
     IGenericRepository<TenantShowing> TenantShowingRepository {get;}
     IGenericRepository<Unit> UnitRepository {get;}
     IGenericRepository<UnitAppliance> UnitApplianceRepository {get;}
     IGenericRepository<UnitCommunityAmenity> UnitCommunityAmenityRepository {get;}
     IGenericRepository<UnitExteriorAmenity> UnitExteriorAmenityRepository {get;}
     IGenericRepository<UnitFeature> UnitFeatureRepository {get;}
     IGenericRepository<UnitGallery> UnitGalleryRepository {get;}
     IGenericRepository<UnitInteriorAmenity> UnitInteriorAmenityRepository {get;}
     IGenericRepository<UnitLuxuryAmenity> UnitLuxuryAmenityRepository {get;}
     IGenericRepository<UnitPricing> UnitPricingRepository {get;}
     IGenericRepository<UnitType> UnitTypeRepository {get;}
     IGenericRepository<UploadedContract> UploadedContractRepository {get;}
     IGenericRepository<UrgencyType> UrgencyTypeRepository {get;}
    void Save();
    }
}

