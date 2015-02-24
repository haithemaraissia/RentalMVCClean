using System;
using System.Data.Entity;
using RentalMobile.Model.Models;
using RentalMobile.Models;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Generic.UnitofWork
{
    public partial class UnitofWork : IGenericUnitofWork
    {
        public  DbContext Context;

        public UnitofWork()
        {
            Context = new RentalContext();
        }

        public UnitofWork(DbContext context)
        {
            Context = context;
        }
 
        private IGenericRepository<Agent> _AgentRepository;

        public IGenericRepository<Agent> AgentRepository
        {
            get { return  _AgentRepository ?? ( _AgentRepository = new GenericRepository<Agent>(Context)); }
            set {  _AgentRepository = value; }
        }

    
        private IGenericRepository<AgentAcceptedApplication> _AgentAcceptedApplicationRepository;

        public IGenericRepository<AgentAcceptedApplication> AgentAcceptedApplicationRepository
        {
            get { return  _AgentAcceptedApplicationRepository ?? ( _AgentAcceptedApplicationRepository = new GenericRepository<AgentAcceptedApplication>(Context)); }
            set {  _AgentAcceptedApplicationRepository = value; }
        }

    
        private IGenericRepository<AgentAcceptedPostedProject> _AgentAcceptedPostedProjectRepository;

        public IGenericRepository<AgentAcceptedPostedProject> AgentAcceptedPostedProjectRepository
        {
            get { return  _AgentAcceptedPostedProjectRepository ?? ( _AgentAcceptedPostedProjectRepository = new GenericRepository<AgentAcceptedPostedProject>(Context)); }
            set {  _AgentAcceptedPostedProjectRepository = value; }
        }

    
        private IGenericRepository<AgentPendingApplication> _AgentPendingApplicationRepository;

        public IGenericRepository<AgentPendingApplication> AgentPendingApplicationRepository
        {
            get { return  _AgentPendingApplicationRepository ?? ( _AgentPendingApplicationRepository = new GenericRepository<AgentPendingApplication>(Context)); }
            set {  _AgentPendingApplicationRepository = value; }
        }

    
        private IGenericRepository<AgentPendingPostedProject> _AgentPendingPostedProjectRepository;

        public IGenericRepository<AgentPendingPostedProject> AgentPendingPostedProjectRepository
        {
            get { return  _AgentPendingPostedProjectRepository ?? ( _AgentPendingPostedProjectRepository = new GenericRepository<AgentPendingPostedProject>(Context)); }
            set {  _AgentPendingPostedProjectRepository = value; }
        }

    
        private IGenericRepository<AgentProject> _AgentProjectRepository;

        public IGenericRepository<AgentProject> AgentProjectRepository
        {
            get { return  _AgentProjectRepository ?? ( _AgentProjectRepository = new GenericRepository<AgentProject>(Context)); }
            set {  _AgentProjectRepository = value; }
        }

    
        private IGenericRepository<AgentRejectedApplication> _AgentRejectedApplicationRepository;

        public IGenericRepository<AgentRejectedApplication> AgentRejectedApplicationRepository
        {
            get { return  _AgentRejectedApplicationRepository ?? ( _AgentRejectedApplicationRepository = new GenericRepository<AgentRejectedApplication>(Context)); }
            set {  _AgentRejectedApplicationRepository = value; }
        }

    
        private IGenericRepository<AgentRejectedPostedProject> _AgentRejectedPostedProjectRepository;

        public IGenericRepository<AgentRejectedPostedProject> AgentRejectedPostedProjectRepository
        {
            get { return  _AgentRejectedPostedProjectRepository ?? ( _AgentRejectedPostedProjectRepository = new GenericRepository<AgentRejectedPostedProject>(Context)); }
            set {  _AgentRejectedPostedProjectRepository = value; }
        }

    
        private IGenericRepository<Basement> _BasementRepository;

        public IGenericRepository<Basement> BasementRepository
        {
            get { return  _BasementRepository ?? ( _BasementRepository = new GenericRepository<Basement>(Context)); }
            set {  _BasementRepository = value; }
        }

    
        private IGenericRepository<Bathroom> _BathroomRepository;

        public IGenericRepository<Bathroom> BathroomRepository
        {
            get { return  _BathroomRepository ?? ( _BathroomRepository = new GenericRepository<Bathroom>(Context)); }
            set {  _BathroomRepository = value; }
        }

    
        private IGenericRepository<Bed> _BedRepository;

        public IGenericRepository<Bed> BedRepository
        {
            get { return  _BedRepository ?? ( _BedRepository = new GenericRepository<Bed>(Context)); }
            set {  _BedRepository = value; }
        }

    
        private IGenericRepository<Cooling> _CoolingRepository;

        public IGenericRepository<Cooling> CoolingRepository
        {
            get { return  _CoolingRepository ?? ( _CoolingRepository = new GenericRepository<Cooling>(Context)); }
            set {  _CoolingRepository = value; }
        }

    
        private IGenericRepository<Currency> _CurrencyRepository;

        public IGenericRepository<Currency> CurrencyRepository
        {
            get { return  _CurrencyRepository ?? ( _CurrencyRepository = new GenericRepository<Currency>(Context)); }
            set {  _CurrencyRepository = value; }
        }

    
        private IGenericRepository<Floor> _FloorRepository;

        public IGenericRepository<Floor> FloorRepository
        {
            get { return  _FloorRepository ?? ( _FloorRepository = new GenericRepository<Floor>(Context)); }
            set {  _FloorRepository = value; }
        }

    
        private IGenericRepository<FloorCovering> _FloorCoveringRepository;

        public IGenericRepository<FloorCovering> FloorCoveringRepository
        {
            get { return  _FloorCoveringRepository ?? ( _FloorCoveringRepository = new GenericRepository<FloorCovering>(Context)); }
            set {  _FloorCoveringRepository = value; }
        }

    
        private IGenericRepository<Foundation> _FoundationRepository;

        public IGenericRepository<Foundation> FoundationRepository
        {
            get { return  _FoundationRepository ?? ( _FoundationRepository = new GenericRepository<Foundation>(Context)); }
            set {  _FoundationRepository = value; }
        }

    
        private IGenericRepository<Garage> _GarageRepository;

        public IGenericRepository<Garage> GarageRepository
        {
            get { return  _GarageRepository ?? ( _GarageRepository = new GenericRepository<Garage>(Context)); }
            set {  _GarageRepository = value; }
        }

    
        private IGenericRepository<GeneratedRentalContract> _GeneratedRentalContractRepository;

        public IGenericRepository<GeneratedRentalContract> GeneratedRentalContractRepository
        {
            get { return  _GeneratedRentalContractRepository ?? ( _GeneratedRentalContractRepository = new GenericRepository<GeneratedRentalContract>(Context)); }
            set {  _GeneratedRentalContractRepository = value; }
        }

    
        private IGenericRepository<Heating> _HeatingRepository;

        public IGenericRepository<Heating> HeatingRepository
        {
            get { return  _HeatingRepository ?? ( _HeatingRepository = new GenericRepository<Heating>(Context)); }
            set {  _HeatingRepository = value; }
        }

    
        private IGenericRepository<MaintenanceCompany> _MaintenanceCompanyRepository;

        public IGenericRepository<MaintenanceCompany> MaintenanceCompanyRepository
        {
            get { return  _MaintenanceCompanyRepository ?? ( _MaintenanceCompanyRepository = new GenericRepository<MaintenanceCompany>(Context)); }
            set {  _MaintenanceCompanyRepository = value; }
        }

    
        private IGenericRepository<MaintenanceCompanyLookUp> _MaintenanceCompanyLookUpRepository;

        public IGenericRepository<MaintenanceCompanyLookUp> MaintenanceCompanyLookUpRepository
        {
            get { return  _MaintenanceCompanyLookUpRepository ?? ( _MaintenanceCompanyLookUpRepository = new GenericRepository<MaintenanceCompanyLookUp>(Context)); }
            set {  _MaintenanceCompanyLookUpRepository = value; }
        }

    
        private IGenericRepository<MaintenanceCompanySpecialization> _MaintenanceCompanySpecializationRepository;

        public IGenericRepository<MaintenanceCompanySpecialization> MaintenanceCompanySpecializationRepository
        {
            get { return  _MaintenanceCompanySpecializationRepository ?? ( _MaintenanceCompanySpecializationRepository = new GenericRepository<MaintenanceCompanySpecialization>(Context)); }
            set {  _MaintenanceCompanySpecializationRepository = value; }
        }

    
        private IGenericRepository<MaintenanceCrew> _MaintenanceCrewRepository;

        public IGenericRepository<MaintenanceCrew> MaintenanceCrewRepository
        {
            get { return  _MaintenanceCrewRepository ?? ( _MaintenanceCrewRepository = new GenericRepository<MaintenanceCrew>(Context)); }
            set {  _MaintenanceCrewRepository = value; }
        }

    
        private IGenericRepository<MaintenanceCustomService> _MaintenanceCustomServiceRepository;

        public IGenericRepository<MaintenanceCustomService> MaintenanceCustomServiceRepository
        {
            get { return  _MaintenanceCustomServiceRepository ?? ( _MaintenanceCustomServiceRepository = new GenericRepository<MaintenanceCustomService>(Context)); }
            set {  _MaintenanceCustomServiceRepository = value; }
        }

    
        private IGenericRepository<MaintenanceExterior> _MaintenanceExteriorRepository;

        public IGenericRepository<MaintenanceExterior> MaintenanceExteriorRepository
        {
            get { return  _MaintenanceExteriorRepository ?? ( _MaintenanceExteriorRepository = new GenericRepository<MaintenanceExterior>(Context)); }
            set {  _MaintenanceExteriorRepository = value; }
        }

    
        private IGenericRepository<MaintenanceInterior> _MaintenanceInteriorRepository;

        public IGenericRepository<MaintenanceInterior> MaintenanceInteriorRepository
        {
            get { return  _MaintenanceInteriorRepository ?? ( _MaintenanceInteriorRepository = new GenericRepository<MaintenanceInterior>(Context)); }
            set {  _MaintenanceInteriorRepository = value; }
        }

    
        private IGenericRepository<MaintenanceNewConstruction> _MaintenanceNewConstructionRepository;

        public IGenericRepository<MaintenanceNewConstruction> MaintenanceNewConstructionRepository
        {
            get { return  _MaintenanceNewConstructionRepository ?? ( _MaintenanceNewConstructionRepository = new GenericRepository<MaintenanceNewConstruction>(Context)); }
            set {  _MaintenanceNewConstructionRepository = value; }
        }

    
        private IGenericRepository<MaintenanceOrder> _MaintenanceOrderRepository;

        public IGenericRepository<MaintenanceOrder> MaintenanceOrderRepository
        {
            get { return  _MaintenanceOrderRepository ?? ( _MaintenanceOrderRepository = new GenericRepository<MaintenanceOrder>(Context)); }
            set {  _MaintenanceOrderRepository = value; }
        }

    
        private IGenericRepository<MaintenancePhoto> _MaintenancePhotoRepository;

        public IGenericRepository<MaintenancePhoto> MaintenancePhotoRepository
        {
            get { return  _MaintenancePhotoRepository ?? ( _MaintenancePhotoRepository = new GenericRepository<MaintenancePhoto>(Context)); }
            set {  _MaintenancePhotoRepository = value; }
        }

    
        private IGenericRepository<MaintenanceProvider> _MaintenanceProviderRepository;

        public IGenericRepository<MaintenanceProvider> MaintenanceProviderRepository
        {
            get { return  _MaintenanceProviderRepository ?? ( _MaintenanceProviderRepository = new GenericRepository<MaintenanceProvider>(Context)); }
            set {  _MaintenanceProviderRepository = value; }
        }

    
        private IGenericRepository<MaintenanceProviderAcceptedJob> _MaintenanceProviderAcceptedJobRepository;

        public IGenericRepository<MaintenanceProviderAcceptedJob> MaintenanceProviderAcceptedJobRepository
        {
            get { return  _MaintenanceProviderAcceptedJobRepository ?? ( _MaintenanceProviderAcceptedJobRepository = new GenericRepository<MaintenanceProviderAcceptedJob>(Context)); }
            set {  _MaintenanceProviderAcceptedJobRepository = value; }
        }

    
        private IGenericRepository<MaintenanceProviderNewJobOffer> _MaintenanceProviderNewJobOfferRepository;

        public IGenericRepository<MaintenanceProviderNewJobOffer> MaintenanceProviderNewJobOfferRepository
        {
            get { return  _MaintenanceProviderNewJobOfferRepository ?? ( _MaintenanceProviderNewJobOfferRepository = new GenericRepository<MaintenanceProviderNewJobOffer>(Context)); }
            set {  _MaintenanceProviderNewJobOfferRepository = value; }
        }

    
        private IGenericRepository<MaintenanceProviderRejectedJob> _MaintenanceProviderRejectedJobRepository;

        public IGenericRepository<MaintenanceProviderRejectedJob> MaintenanceProviderRejectedJobRepository
        {
            get { return  _MaintenanceProviderRejectedJobRepository ?? ( _MaintenanceProviderRejectedJobRepository = new GenericRepository<MaintenanceProviderRejectedJob>(Context)); }
            set {  _MaintenanceProviderRejectedJobRepository = value; }
        }

    
        private IGenericRepository<MaintenanceProviderZone> _MaintenanceProviderZoneRepository;

        public IGenericRepository<MaintenanceProviderZone> MaintenanceProviderZoneRepository
        {
            get { return  _MaintenanceProviderZoneRepository ?? ( _MaintenanceProviderZoneRepository = new GenericRepository<MaintenanceProviderZone>(Context)); }
            set {  _MaintenanceProviderZoneRepository = value; }
        }

    
        private IGenericRepository<MaintenanceRepair> _MaintenanceRepairRepository;

        public IGenericRepository<MaintenanceRepair> MaintenanceRepairRepository
        {
            get { return  _MaintenanceRepairRepository ?? ( _MaintenanceRepairRepository = new GenericRepository<MaintenanceRepair>(Context)); }
            set {  _MaintenanceRepairRepository = value; }
        }

    
        private IGenericRepository<MaintenanceTeam> _MaintenanceTeamRepository;

        public IGenericRepository<MaintenanceTeam> MaintenanceTeamRepository
        {
            get { return  _MaintenanceTeamRepository ?? ( _MaintenanceTeamRepository = new GenericRepository<MaintenanceTeam>(Context)); }
            set {  _MaintenanceTeamRepository = value; }
        }

    
        private IGenericRepository<MaintenanceTeamAssociation> _MaintenanceTeamAssociationRepository;

        public IGenericRepository<MaintenanceTeamAssociation> MaintenanceTeamAssociationRepository
        {
            get { return  _MaintenanceTeamAssociationRepository ?? ( _MaintenanceTeamAssociationRepository = new GenericRepository<MaintenanceTeamAssociation>(Context)); }
            set {  _MaintenanceTeamAssociationRepository = value; }
        }

    
        private IGenericRepository<MaintenanceUtility> _MaintenanceUtilityRepository;

        public IGenericRepository<MaintenanceUtility> MaintenanceUtilityRepository
        {
            get { return  _MaintenanceUtilityRepository ?? ( _MaintenanceUtilityRepository = new GenericRepository<MaintenanceUtility>(Context)); }
            set {  _MaintenanceUtilityRepository = value; }
        }

    
        private IGenericRepository<Owner> _OwnerRepository;

        public IGenericRepository<Owner> OwnerRepository
        {
            get { return  _OwnerRepository ?? ( _OwnerRepository = new GenericRepository<Owner>(Context)); }
            set {  _OwnerRepository = value; }
        }

    
        private IGenericRepository<OwnerAcceptedApplication> _OwnerAcceptedApplicationRepository;

        public IGenericRepository<OwnerAcceptedApplication> OwnerAcceptedApplicationRepository
        {
            get { return  _OwnerAcceptedApplicationRepository ?? ( _OwnerAcceptedApplicationRepository = new GenericRepository<OwnerAcceptedApplication>(Context)); }
            set {  _OwnerAcceptedApplicationRepository = value; }
        }

    
        private IGenericRepository<OwnerAcceptedPostedProject> _OwnerAcceptedPostedProjectRepository;

        public IGenericRepository<OwnerAcceptedPostedProject> OwnerAcceptedPostedProjectRepository
        {
            get { return  _OwnerAcceptedPostedProjectRepository ?? ( _OwnerAcceptedPostedProjectRepository = new GenericRepository<OwnerAcceptedPostedProject>(Context)); }
            set {  _OwnerAcceptedPostedProjectRepository = value; }
        }

    
        private IGenericRepository<OwnerMaintenance> _OwnerMaintenanceRepository;

        public IGenericRepository<OwnerMaintenance> OwnerMaintenanceRepository
        {
            get { return  _OwnerMaintenanceRepository ?? ( _OwnerMaintenanceRepository = new GenericRepository<OwnerMaintenance>(Context)); }
            set {  _OwnerMaintenanceRepository = value; }
        }

    
        private IGenericRepository<OwnerPendingApplication> _OwnerPendingApplicationRepository;

        public IGenericRepository<OwnerPendingApplication> OwnerPendingApplicationRepository
        {
            get { return  _OwnerPendingApplicationRepository ?? ( _OwnerPendingApplicationRepository = new GenericRepository<OwnerPendingApplication>(Context)); }
            set {  _OwnerPendingApplicationRepository = value; }
        }

    
        private IGenericRepository<OwnerPendingPostedProject> _OwnerPendingPostedProjectRepository;

        public IGenericRepository<OwnerPendingPostedProject> OwnerPendingPostedProjectRepository
        {
            get { return  _OwnerPendingPostedProjectRepository ?? ( _OwnerPendingPostedProjectRepository = new GenericRepository<OwnerPendingPostedProject>(Context)); }
            set {  _OwnerPendingPostedProjectRepository = value; }
        }

    
        private IGenericRepository<OwnerPendingShowingCalendar> _OwnerPendingShowingCalendarRepository;

        public IGenericRepository<OwnerPendingShowingCalendar> OwnerPendingShowingCalendarRepository
        {
            get { return  _OwnerPendingShowingCalendarRepository ?? ( _OwnerPendingShowingCalendarRepository = new GenericRepository<OwnerPendingShowingCalendar>(Context)); }
            set {  _OwnerPendingShowingCalendarRepository = value; }
        }

    
        private IGenericRepository<OwnerProject> _OwnerProjectRepository;

        public IGenericRepository<OwnerProject> OwnerProjectRepository
        {
            get { return  _OwnerProjectRepository ?? ( _OwnerProjectRepository = new GenericRepository<OwnerProject>(Context)); }
            set {  _OwnerProjectRepository = value; }
        }

    
        private IGenericRepository<OwnerRejectedApplication> _OwnerRejectedApplicationRepository;

        public IGenericRepository<OwnerRejectedApplication> OwnerRejectedApplicationRepository
        {
            get { return  _OwnerRejectedApplicationRepository ?? ( _OwnerRejectedApplicationRepository = new GenericRepository<OwnerRejectedApplication>(Context)); }
            set {  _OwnerRejectedApplicationRepository = value; }
        }

    
        private IGenericRepository<OwnerRejectedPostedProject> _OwnerRejectedPostedProjectRepository;

        public IGenericRepository<OwnerRejectedPostedProject> OwnerRejectedPostedProjectRepository
        {
            get { return  _OwnerRejectedPostedProjectRepository ?? ( _OwnerRejectedPostedProjectRepository = new GenericRepository<OwnerRejectedPostedProject>(Context)); }
            set {  _OwnerRejectedPostedProjectRepository = value; }
        }

    
        private IGenericRepository<OwnerShowingCalendar> _OwnerShowingCalendarRepository;

        public IGenericRepository<OwnerShowingCalendar> OwnerShowingCalendarRepository
        {
            get { return  _OwnerShowingCalendarRepository ?? ( _OwnerShowingCalendarRepository = new GenericRepository<OwnerShowingCalendar>(Context)); }
            set {  _OwnerShowingCalendarRepository = value; }
        }

    
        private IGenericRepository<ParkingSpace> _ParkingSpaceRepository;

        public IGenericRepository<ParkingSpace> ParkingSpaceRepository
        {
            get { return  _ParkingSpaceRepository ?? ( _ParkingSpaceRepository = new GenericRepository<ParkingSpace>(Context)); }
            set {  _ParkingSpaceRepository = value; }
        }

    
        private IGenericRepository<Project> _ProjectRepository;

        public IGenericRepository<Project> ProjectRepository
        {
            get { return  _ProjectRepository ?? ( _ProjectRepository = new GenericRepository<Project>(Context)); }
            set {  _ProjectRepository = value; }
        }

    
        private IGenericRepository<ProjectPhoto> _ProjectPhotoRepository;

        public IGenericRepository<ProjectPhoto> ProjectPhotoRepository
        {
            get { return  _ProjectPhotoRepository ?? ( _ProjectPhotoRepository = new GenericRepository<ProjectPhoto>(Context)); }
            set {  _ProjectPhotoRepository = value; }
        }

    
        private IGenericRepository<ProviderProfileComment> _ProviderProfileCommentRepository;

        public IGenericRepository<ProviderProfileComment> ProviderProfileCommentRepository
        {
            get { return  _ProviderProfileCommentRepository ?? ( _ProviderProfileCommentRepository = new GenericRepository<ProviderProfileComment>(Context)); }
            set {  _ProviderProfileCommentRepository = value; }
        }

    
        private IGenericRepository<ProviderWork> _ProviderWorkRepository;

        public IGenericRepository<ProviderWork> ProviderWorkRepository
        {
            get { return  _ProviderWorkRepository ?? ( _ProviderWorkRepository = new GenericRepository<ProviderWork>(Context)); }
            set {  _ProviderWorkRepository = value; }
        }

    
        private IGenericRepository<RentalApplication> _RentalApplicationRepository;

        public IGenericRepository<RentalApplication> RentalApplicationRepository
        {
            get { return  _RentalApplicationRepository ?? ( _RentalApplicationRepository = new GenericRepository<RentalApplication>(Context)); }
            set {  _RentalApplicationRepository = value; }
        }

    
        private IGenericRepository<ServiceType> _ServiceTypeRepository;

        public IGenericRepository<ServiceType> ServiceTypeRepository
        {
            get { return  _ServiceTypeRepository ?? ( _ServiceTypeRepository = new GenericRepository<ServiceType>(Context)); }
            set {  _ServiceTypeRepository = value; }
        }

    
        private IGenericRepository<Specialist> _SpecialistRepository;

        public IGenericRepository<Specialist> SpecialistRepository
        {
            get { return  _SpecialistRepository ?? ( _SpecialistRepository = new GenericRepository<Specialist>(Context)); }
            set {  _SpecialistRepository = value; }
        }

    
        private IGenericRepository<SpecialistPendingTeamInvitation> _SpecialistPendingTeamInvitationRepository;

        public IGenericRepository<SpecialistPendingTeamInvitation> SpecialistPendingTeamInvitationRepository
        {
            get { return  _SpecialistPendingTeamInvitationRepository ?? ( _SpecialistPendingTeamInvitationRepository = new GenericRepository<SpecialistPendingTeamInvitation>(Context)); }
            set {  _SpecialistPendingTeamInvitationRepository = value; }
        }

    
        private IGenericRepository<SpecialistProfileComment> _SpecialistProfileCommentRepository;

        public IGenericRepository<SpecialistProfileComment> SpecialistProfileCommentRepository
        {
            get { return  _SpecialistProfileCommentRepository ?? ( _SpecialistProfileCommentRepository = new GenericRepository<SpecialistProfileComment>(Context)); }
            set {  _SpecialistProfileCommentRepository = value; }
        }

    
        private IGenericRepository<SpecialistWork> _SpecialistWorkRepository;

        public IGenericRepository<SpecialistWork> SpecialistWorkRepository
        {
            get { return  _SpecialistWorkRepository ?? ( _SpecialistWorkRepository = new GenericRepository<SpecialistWork>(Context)); }
            set {  _SpecialistWorkRepository = value; }
        }

    
        private IGenericRepository<Tenant> _TenantRepository;

        public IGenericRepository<Tenant> TenantRepository
        {
            get { return  _TenantRepository ?? ( _TenantRepository = new GenericRepository<Tenant>(Context)); }
            set {  _TenantRepository = value; }
        }

    
        private IGenericRepository<TenantFavorite> _TenantFavoriteRepository;

        public IGenericRepository<TenantFavorite> TenantFavoriteRepository
        {
            get { return  _TenantFavoriteRepository ?? ( _TenantFavoriteRepository = new GenericRepository<TenantFavorite>(Context)); }
            set {  _TenantFavoriteRepository = value; }
        }

    
        private IGenericRepository<TenantMaintenance> _TenantMaintenanceRepository;

        public IGenericRepository<TenantMaintenance> TenantMaintenanceRepository
        {
            get { return  _TenantMaintenanceRepository ?? ( _TenantMaintenanceRepository = new GenericRepository<TenantMaintenance>(Context)); }
            set {  _TenantMaintenanceRepository = value; }
        }

    
        private IGenericRepository<TenantSavedSearch> _TenantSavedSearchRepository;

        public IGenericRepository<TenantSavedSearch> TenantSavedSearchRepository
        {
            get { return  _TenantSavedSearchRepository ?? ( _TenantSavedSearchRepository = new GenericRepository<TenantSavedSearch>(Context)); }
            set {  _TenantSavedSearchRepository = value; }
        }

    
        private IGenericRepository<TenantShowing> _TenantShowingRepository;

        public IGenericRepository<TenantShowing> TenantShowingRepository
        {
            get { return  _TenantShowingRepository ?? ( _TenantShowingRepository = new GenericRepository<TenantShowing>(Context)); }
            set {  _TenantShowingRepository = value; }
        }

    
        private IGenericRepository<Unit> _UnitRepository;

        public IGenericRepository<Unit> UnitRepository
        {
            get { return  _UnitRepository ?? ( _UnitRepository = new GenericRepository<Unit>(Context)); }
            set {  _UnitRepository = value; }
        }

    
        private IGenericRepository<UnitAppliance> _UnitApplianceRepository;

        public IGenericRepository<UnitAppliance> UnitApplianceRepository
        {
            get { return  _UnitApplianceRepository ?? ( _UnitApplianceRepository = new GenericRepository<UnitAppliance>(Context)); }
            set {  _UnitApplianceRepository = value; }
        }

    
        private IGenericRepository<UnitCommunityAmenity> _UnitCommunityAmenityRepository;

        public IGenericRepository<UnitCommunityAmenity> UnitCommunityAmenityRepository
        {
            get { return  _UnitCommunityAmenityRepository ?? ( _UnitCommunityAmenityRepository = new GenericRepository<UnitCommunityAmenity>(Context)); }
            set {  _UnitCommunityAmenityRepository = value; }
        }

    
        private IGenericRepository<UnitExteriorAmenity> _UnitExteriorAmenityRepository;

        public IGenericRepository<UnitExteriorAmenity> UnitExteriorAmenityRepository
        {
            get { return  _UnitExteriorAmenityRepository ?? ( _UnitExteriorAmenityRepository = new GenericRepository<UnitExteriorAmenity>(Context)); }
            set {  _UnitExteriorAmenityRepository = value; }
        }

    
        private IGenericRepository<UnitFeature> _UnitFeatureRepository;

        public IGenericRepository<UnitFeature> UnitFeatureRepository
        {
            get { return  _UnitFeatureRepository ?? ( _UnitFeatureRepository = new GenericRepository<UnitFeature>(Context)); }
            set {  _UnitFeatureRepository = value; }
        }

    
        private IGenericRepository<UnitGallery> _UnitGalleryRepository;

        public IGenericRepository<UnitGallery> UnitGalleryRepository
        {
            get { return  _UnitGalleryRepository ?? ( _UnitGalleryRepository = new GenericRepository<UnitGallery>(Context)); }
            set {  _UnitGalleryRepository = value; }
        }

    
        private IGenericRepository<UnitInteriorAmenity> _UnitInteriorAmenityRepository;

        public IGenericRepository<UnitInteriorAmenity> UnitInteriorAmenityRepository
        {
            get { return  _UnitInteriorAmenityRepository ?? ( _UnitInteriorAmenityRepository = new GenericRepository<UnitInteriorAmenity>(Context)); }
            set {  _UnitInteriorAmenityRepository = value; }
        }

    
        private IGenericRepository<UnitLuxuryAmenity> _UnitLuxuryAmenityRepository;

        public IGenericRepository<UnitLuxuryAmenity> UnitLuxuryAmenityRepository
        {
            get { return  _UnitLuxuryAmenityRepository ?? ( _UnitLuxuryAmenityRepository = new GenericRepository<UnitLuxuryAmenity>(Context)); }
            set {  _UnitLuxuryAmenityRepository = value; }
        }

    
        private IGenericRepository<UnitPricing> _UnitPricingRepository;

        public IGenericRepository<UnitPricing> UnitPricingRepository
        {
            get { return  _UnitPricingRepository ?? ( _UnitPricingRepository = new GenericRepository<UnitPricing>(Context)); }
            set {  _UnitPricingRepository = value; }
        }

    
        private IGenericRepository<UnitType> _UnitTypeRepository;

        public IGenericRepository<UnitType> UnitTypeRepository
        {
            get { return  _UnitTypeRepository ?? ( _UnitTypeRepository = new GenericRepository<UnitType>(Context)); }
            set {  _UnitTypeRepository = value; }
        }

    
        private IGenericRepository<UploadedContract> _UploadedContractRepository;

        public IGenericRepository<UploadedContract> UploadedContractRepository
        {
            get { return  _UploadedContractRepository ?? ( _UploadedContractRepository = new GenericRepository<UploadedContract>(Context)); }
            set {  _UploadedContractRepository = value; }
        }

    
        private IGenericRepository<UrgencyType> _UrgencyTypeRepository;

        public IGenericRepository<UrgencyType> UrgencyTypeRepository
        {
            get { return  _UrgencyTypeRepository ?? ( _UrgencyTypeRepository = new GenericRepository<UrgencyType>(Context)); }
            set {  _UrgencyTypeRepository = value; }
        }

            public void Save()
        {
            Context.SaveChanges();
        }

        private bool _disposed;



        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }     
}

