﻿using RentalMobile.Model.Models;

namespace RentalMobile.Model.ModelViews
{
    public class SpecialistMaintenanceProfile
    {
        public MaintenanceCompanyLookUp MaintenanceCompanyLookUp { get; set; }
        public MaintenanceCompany MaintenanceCompany { get; set; }
        public MaintenanceCompanySpecialization MaintenanceCompanySpecialization { get; set; }
        public MaintenanceCustomService MaintenanceCustomService { get; set; }
        public MaintenanceExterior MaintenanceExterior { get; set; }
        public MaintenanceInterior MaintenanceInterior { get; set; }
        public MaintenanceNewConstruction MaintenanceNewConstruction { get; set; }
        public MaintenanceRepair MaintenanceRepair { get; set; }
        public MaintenanceUtility MaintenanceUtility { get; set; }
    }
}