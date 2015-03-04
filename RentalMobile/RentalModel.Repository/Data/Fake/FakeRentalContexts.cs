using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeRentalContext
    { 
       public List<RentalContext> MyRentalContexts;

       public FakeRentalContext()
        {
            InitializeRentalContextList();
        }

       public void InitializeRentalContextList()
        {
            MyRentalContexts = new List<RentalContext> {
                FirstRentalContext(), 
                SecondRentalContext(),
                ThirdRentalContext()
            };
        }

       public RentalContext FirstRentalContext()
        {

            var firstRentalContext = new RentalContext {

//Skipping Agent Collection
//Skipping AgentAcceptedApplication Collection
//Skipping AgentAcceptedPostedProject Collection
//Skipping AgentPendingApplication Collection
//Skipping AgentPendingPostedProject Collection
//Skipping AgentProject Collection
//Skipping AgentRejectedApplication Collection
//Skipping AgentRejectedPostedProject Collection
//Skipping aspnet_Applications Collection
//Skipping aspnet_Membership Collection
//Skipping aspnet_Paths Collection
//Skipping aspnet_PersonalizationAllUsers Collection
//Skipping aspnet_PersonalizationPerUser Collection
//Skipping aspnet_Profile Collection
//Skipping aspnet_Roles Collection
//Skipping aspnet_SchemaVersions Collection
//Skipping aspnet_Users Collection
//Skipping aspnet_WebEvent_Events Collection
//Skipping Basement Collection
//Skipping Bathroom Collection
//Skipping Bed Collection
//Skipping Cooling Collection
//Skipping Currency Collection
//Skipping Floor Collection
//Skipping FloorCovering Collection
//Skipping Foundation Collection
//Skipping Garage Collection
//Skipping GeneratedRentalContract Collection
//Skipping Heating Collection
//Skipping MaintenanceCompany Collection
//Skipping MaintenanceCompanyLookUp Collection
//Skipping MaintenanceCompanySpecialization Collection
//Skipping MaintenanceCrew Collection
//Skipping MaintenanceCustomService Collection
//Skipping MaintenanceExterior Collection
//Skipping MaintenanceInterior Collection
//Skipping MaintenanceNewConstruction Collection
//Skipping MaintenanceOrder Collection
//Skipping MaintenancePhoto Collection
//Skipping MaintenanceProvider Collection
//Skipping MaintenanceProviderAcceptedJob Collection
//Skipping MaintenanceProviderNewJobOffer Collection
//Skipping MaintenanceProviderRejectedJob Collection
//Skipping MaintenanceProviderZone Collection
//Skipping MaintenanceRepair Collection
//Skipping MaintenanceTeam Collection
//Skipping MaintenanceTeamAssociation Collection
//Skipping MaintenanceUtility Collection
//Skipping Owner Collection
//Skipping OwnerAcceptedApplication Collection
//Skipping OwnerAcceptedPostedProject Collection
//Skipping OwnerMaintenance Collection
//Skipping OwnerPendingApplication Collection
//Skipping OwnerPendingPostedProject Collection
//Skipping OwnerPendingShowingCalendar Collection
//Skipping OwnerProject Collection
//Skipping OwnerRejectedApplication Collection
//Skipping OwnerRejectedPostedProject Collection
//Skipping OwnerShowingCalendar Collection
//Skipping Project Collection
//Skipping ProjectPhoto Collection
//Skipping ProviderProfileComment Collection
//Skipping ProviderWork Collection
//Skipping RentalApplication Collection
//Skipping ServiceType Collection
//Skipping Specialist Collection
//Skipping SpecialistPendingTeamInvitation Collection
//Skipping SpecialistProfileComment Collection
//Skipping SpecialistWork Collection
//Skipping Tenant Collection
//Skipping TenantFavorite Collection
//Skipping TenantMaintenance Collection
//Skipping TenantSavedSearch Collection
//Skipping TenantShowing Collection
//Skipping Unit Collection
//Skipping UnitAppliance Collection
//Skipping UnitCommunityAmenity Collection
//Skipping UnitExteriorAmenity Collection
//Skipping UnitFeature Collection
//Skipping UnitGallery Collection
//Skipping UnitInteriorAmenity Collection
//Skipping UnitLuxuryAmenity Collection
//Skipping UnitPricing Collection
//Skipping UnitType Collection
//Skipping UploadedContract Collection
//Skipping UrgencyType Collection
//Skipping ParkingSpace Collection
                 Database = new Database()
,
                 ChangeTracker = new DbChangeTracker()
,
                 Configuration = new DbContextConfiguration()

    
 };

            return firstRentalContext;
        }

       public RentalContext SecondRentalContext()
        {

            var secondRentalContext = new RentalContext {

//Skipping Agent Collection
//Skipping AgentAcceptedApplication Collection
//Skipping AgentAcceptedPostedProject Collection
//Skipping AgentPendingApplication Collection
//Skipping AgentPendingPostedProject Collection
//Skipping AgentProject Collection
//Skipping AgentRejectedApplication Collection
//Skipping AgentRejectedPostedProject Collection
//Skipping aspnet_Applications Collection
//Skipping aspnet_Membership Collection
//Skipping aspnet_Paths Collection
//Skipping aspnet_PersonalizationAllUsers Collection
//Skipping aspnet_PersonalizationPerUser Collection
//Skipping aspnet_Profile Collection
//Skipping aspnet_Roles Collection
//Skipping aspnet_SchemaVersions Collection
//Skipping aspnet_Users Collection
//Skipping aspnet_WebEvent_Events Collection
//Skipping Basement Collection
//Skipping Bathroom Collection
//Skipping Bed Collection
//Skipping Cooling Collection
//Skipping Currency Collection
//Skipping Floor Collection
//Skipping FloorCovering Collection
//Skipping Foundation Collection
//Skipping Garage Collection
//Skipping GeneratedRentalContract Collection
//Skipping Heating Collection
//Skipping MaintenanceCompany Collection
//Skipping MaintenanceCompanyLookUp Collection
//Skipping MaintenanceCompanySpecialization Collection
//Skipping MaintenanceCrew Collection
//Skipping MaintenanceCustomService Collection
//Skipping MaintenanceExterior Collection
//Skipping MaintenanceInterior Collection
//Skipping MaintenanceNewConstruction Collection
//Skipping MaintenanceOrder Collection
//Skipping MaintenancePhoto Collection
//Skipping MaintenanceProvider Collection
//Skipping MaintenanceProviderAcceptedJob Collection
//Skipping MaintenanceProviderNewJobOffer Collection
//Skipping MaintenanceProviderRejectedJob Collection
//Skipping MaintenanceProviderZone Collection
//Skipping MaintenanceRepair Collection
//Skipping MaintenanceTeam Collection
//Skipping MaintenanceTeamAssociation Collection
//Skipping MaintenanceUtility Collection
//Skipping Owner Collection
//Skipping OwnerAcceptedApplication Collection
//Skipping OwnerAcceptedPostedProject Collection
//Skipping OwnerMaintenance Collection
//Skipping OwnerPendingApplication Collection
//Skipping OwnerPendingPostedProject Collection
//Skipping OwnerPendingShowingCalendar Collection
//Skipping OwnerProject Collection
//Skipping OwnerRejectedApplication Collection
//Skipping OwnerRejectedPostedProject Collection
//Skipping OwnerShowingCalendar Collection
//Skipping Project Collection
//Skipping ProjectPhoto Collection
//Skipping ProviderProfileComment Collection
//Skipping ProviderWork Collection
//Skipping RentalApplication Collection
//Skipping ServiceType Collection
//Skipping Specialist Collection
//Skipping SpecialistPendingTeamInvitation Collection
//Skipping SpecialistProfileComment Collection
//Skipping SpecialistWork Collection
//Skipping Tenant Collection
//Skipping TenantFavorite Collection
//Skipping TenantMaintenance Collection
//Skipping TenantSavedSearch Collection
//Skipping TenantShowing Collection
//Skipping Unit Collection
//Skipping UnitAppliance Collection
//Skipping UnitCommunityAmenity Collection
//Skipping UnitExteriorAmenity Collection
//Skipping UnitFeature Collection
//Skipping UnitGallery Collection
//Skipping UnitInteriorAmenity Collection
//Skipping UnitLuxuryAmenity Collection
//Skipping UnitPricing Collection
//Skipping UnitType Collection
//Skipping UploadedContract Collection
//Skipping UrgencyType Collection
//Skipping ParkingSpace Collection
                 Database = new Database()
,
                 ChangeTracker = new DbChangeTracker()
,
                 Configuration = new DbContextConfiguration()

        
 };

            return secondRentalContext;
        }

       public RentalContext ThirdRentalContext()
        {

            var thirdRentalContext = new RentalContext {

//Skipping Agent Collection
//Skipping AgentAcceptedApplication Collection
//Skipping AgentAcceptedPostedProject Collection
//Skipping AgentPendingApplication Collection
//Skipping AgentPendingPostedProject Collection
//Skipping AgentProject Collection
//Skipping AgentRejectedApplication Collection
//Skipping AgentRejectedPostedProject Collection
//Skipping aspnet_Applications Collection
//Skipping aspnet_Membership Collection
//Skipping aspnet_Paths Collection
//Skipping aspnet_PersonalizationAllUsers Collection
//Skipping aspnet_PersonalizationPerUser Collection
//Skipping aspnet_Profile Collection
//Skipping aspnet_Roles Collection
//Skipping aspnet_SchemaVersions Collection
//Skipping aspnet_Users Collection
//Skipping aspnet_WebEvent_Events Collection
//Skipping Basement Collection
//Skipping Bathroom Collection
//Skipping Bed Collection
//Skipping Cooling Collection
//Skipping Currency Collection
//Skipping Floor Collection
//Skipping FloorCovering Collection
//Skipping Foundation Collection
//Skipping Garage Collection
//Skipping GeneratedRentalContract Collection
//Skipping Heating Collection
//Skipping MaintenanceCompany Collection
//Skipping MaintenanceCompanyLookUp Collection
//Skipping MaintenanceCompanySpecialization Collection
//Skipping MaintenanceCrew Collection
//Skipping MaintenanceCustomService Collection
//Skipping MaintenanceExterior Collection
//Skipping MaintenanceInterior Collection
//Skipping MaintenanceNewConstruction Collection
//Skipping MaintenanceOrder Collection
//Skipping MaintenancePhoto Collection
//Skipping MaintenanceProvider Collection
//Skipping MaintenanceProviderAcceptedJob Collection
//Skipping MaintenanceProviderNewJobOffer Collection
//Skipping MaintenanceProviderRejectedJob Collection
//Skipping MaintenanceProviderZone Collection
//Skipping MaintenanceRepair Collection
//Skipping MaintenanceTeam Collection
//Skipping MaintenanceTeamAssociation Collection
//Skipping MaintenanceUtility Collection
//Skipping Owner Collection
//Skipping OwnerAcceptedApplication Collection
//Skipping OwnerAcceptedPostedProject Collection
//Skipping OwnerMaintenance Collection
//Skipping OwnerPendingApplication Collection
//Skipping OwnerPendingPostedProject Collection
//Skipping OwnerPendingShowingCalendar Collection
//Skipping OwnerProject Collection
//Skipping OwnerRejectedApplication Collection
//Skipping OwnerRejectedPostedProject Collection
//Skipping OwnerShowingCalendar Collection
//Skipping Project Collection
//Skipping ProjectPhoto Collection
//Skipping ProviderProfileComment Collection
//Skipping ProviderWork Collection
//Skipping RentalApplication Collection
//Skipping ServiceType Collection
//Skipping Specialist Collection
//Skipping SpecialistPendingTeamInvitation Collection
//Skipping SpecialistProfileComment Collection
//Skipping SpecialistWork Collection
//Skipping Tenant Collection
//Skipping TenantFavorite Collection
//Skipping TenantMaintenance Collection
//Skipping TenantSavedSearch Collection
//Skipping TenantShowing Collection
//Skipping Unit Collection
//Skipping UnitAppliance Collection
//Skipping UnitCommunityAmenity Collection
//Skipping UnitExteriorAmenity Collection
//Skipping UnitFeature Collection
//Skipping UnitGallery Collection
//Skipping UnitInteriorAmenity Collection
//Skipping UnitLuxuryAmenity Collection
//Skipping UnitPricing Collection
//Skipping UnitType Collection
//Skipping UploadedContract Collection
//Skipping UrgencyType Collection
//Skipping ParkingSpace Collection
                 Database = new Database()
,
                 ChangeTracker = new DbChangeTracker()
,
                 Configuration = new DbContextConfiguration()

 
 };

            return thirdRentalContext;
        }

        ~FakeRentalContext()
        {
            MyRentalContexts = null;
        }
    }
}


    