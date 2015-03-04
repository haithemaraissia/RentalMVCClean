using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenanceCompanySpecialization
    { 
       public List<MaintenanceCompanySpecialization> MyMaintenanceCompanySpecializations;

       public FakeMaintenanceCompanySpecialization()
        {
            InitializeMaintenanceCompanySpecializationList();
        }

       public void InitializeMaintenanceCompanySpecializationList()
        {
            MyMaintenanceCompanySpecializations = new List<MaintenanceCompanySpecialization> {
                FirstMaintenanceCompanySpecialization(), 
                SecondMaintenanceCompanySpecialization(),
                ThirdMaintenanceCompanySpecialization()
            };
        }

       public MaintenanceCompanySpecialization FirstMaintenanceCompanySpecialization()
        {

            var firstMaintenanceCompanySpecialization = new MaintenanceCompanySpecialization {

                 CompanyId = new Int32()
,
                 Years_Experience = new Int32()
,
                 NumberofEmployee = new Int32()
,
                 NumberofCertifitedEmplyee = new Int32()
,
                 Air_Conditioning = new Boolean()
,
                 Electrical = new Boolean()
,
                 Kitchen_Remodeling = new Boolean()
,
                 Architects = new Boolean()
,
                 Flooring = new Boolean()
,
                 Landscaping = new Boolean()
,
                 Asphalt_Paving = new Boolean()
,
                 General_Contracting = new Boolean()
,
                 Painting = new Boolean()
,
                 Basement_Finishing = new Boolean()
,
                 Handyman_Services = new Boolean()
,
                 Plumbing = new Boolean()
,
                 Bathroom_Remodeling = new Boolean()
,
                 Heating = new Boolean()
,
                 Roofing = new Boolean()
,
                 Concrete = new Boolean()
,
                 Home_Addition_Construction = new Boolean()
,
                 Siding = new Boolean()
,
                 Deck_Construction = new Boolean()
,
                 Home_Construction = new Boolean()
,
                 Tiling = new Boolean()
,
                 IsInsured = new Boolean()
,
                 Rate = new Double()
,
                 Currency = null,
                 CurrencyID = new Int32()

    
 };

            return firstMaintenanceCompanySpecialization;
        }

       public MaintenanceCompanySpecialization SecondMaintenanceCompanySpecialization()
        {

            var secondMaintenanceCompanySpecialization = new MaintenanceCompanySpecialization {

                 CompanyId = new Int32()
,
                 Years_Experience = new Int32()
,
                 NumberofEmployee = new Int32()
,
                 NumberofCertifitedEmplyee = new Int32()
,
                 Air_Conditioning = new Boolean()
,
                 Electrical = new Boolean()
,
                 Kitchen_Remodeling = new Boolean()
,
                 Architects = new Boolean()
,
                 Flooring = new Boolean()
,
                 Landscaping = new Boolean()
,
                 Asphalt_Paving = new Boolean()
,
                 General_Contracting = new Boolean()
,
                 Painting = new Boolean()
,
                 Basement_Finishing = new Boolean()
,
                 Handyman_Services = new Boolean()
,
                 Plumbing = new Boolean()
,
                 Bathroom_Remodeling = new Boolean()
,
                 Heating = new Boolean()
,
                 Roofing = new Boolean()
,
                 Concrete = new Boolean()
,
                 Home_Addition_Construction = new Boolean()
,
                 Siding = new Boolean()
,
                 Deck_Construction = new Boolean()
,
                 Home_Construction = new Boolean()
,
                 Tiling = new Boolean()
,
                 IsInsured = new Boolean()
,
                 Rate = new Double()
,
                 Currency = null,
                 CurrencyID = new Int32()

        
 };

            return secondMaintenanceCompanySpecialization;
        }

       public MaintenanceCompanySpecialization ThirdMaintenanceCompanySpecialization()
        {

            var thirdMaintenanceCompanySpecialization = new MaintenanceCompanySpecialization {

                 CompanyId = new Int32()
,
                 Years_Experience = new Int32()
,
                 NumberofEmployee = new Int32()
,
                 NumberofCertifitedEmplyee = new Int32()
,
                 Air_Conditioning = new Boolean()
,
                 Electrical = new Boolean()
,
                 Kitchen_Remodeling = new Boolean()
,
                 Architects = new Boolean()
,
                 Flooring = new Boolean()
,
                 Landscaping = new Boolean()
,
                 Asphalt_Paving = new Boolean()
,
                 General_Contracting = new Boolean()
,
                 Painting = new Boolean()
,
                 Basement_Finishing = new Boolean()
,
                 Handyman_Services = new Boolean()
,
                 Plumbing = new Boolean()
,
                 Bathroom_Remodeling = new Boolean()
,
                 Heating = new Boolean()
,
                 Roofing = new Boolean()
,
                 Concrete = new Boolean()
,
                 Home_Addition_Construction = new Boolean()
,
                 Siding = new Boolean()
,
                 Deck_Construction = new Boolean()
,
                 Home_Construction = new Boolean()
,
                 Tiling = new Boolean()
,
                 IsInsured = new Boolean()
,
                 Rate = new Double()
,
                 Currency = null,
                 CurrencyID = new Int32()

 
 };

            return thirdMaintenanceCompanySpecialization;
        }

        ~FakeMaintenanceCompanySpecialization()
        {
            MyMaintenanceCompanySpecializations = null;
        }
    }
}


    