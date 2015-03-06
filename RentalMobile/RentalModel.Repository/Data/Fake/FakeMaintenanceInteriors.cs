using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenanceInteriors
    { 
       public List<MaintenanceInterior> MyMaintenanceInteriors;

       public FakeMaintenanceInteriors()
        {
            InitializeMaintenanceInteriorList();
        }

       public void InitializeMaintenanceInteriorList()
        {
            MyMaintenanceInteriors = new List<MaintenanceInterior> {
                FirstMaintenanceInterior(), 
                SecondMaintenanceInterior(),
                ThirdMaintenanceInterior()
            };
        }

       public MaintenanceInterior FirstMaintenanceInterior()
        {

            var firstMaintenanceInterior = new MaintenanceInterior {

                 CompanyId = new Int32()
,
                 Basement_Lowering = new Boolean()
,
                 Basement_Remodeling = new Boolean()
,
                 Bathroom_Remodeling = new Boolean()
,
                 Cabinetry_and_Built_ins = new Boolean()
,
                 Carpenters = new Boolean()
,
                 Carpet_and_Vinyl_Floors = new Boolean()
,
                 Ceiling_Install_and_Repair = new Boolean()
,
                 Closets_Designing_Organizing = new Boolean()
,
                 Counter_Tops = new Boolean()
,
                 Remodeling = new Boolean()
,
                 Buffing___Polishing = new Boolean()
,
                 Drywall = new Boolean()
,
                 Carpet_Installation = new Boolean()
,
                 Fireplaces___Firewood = new Boolean()
,
                 Floor_Heating = new Boolean()
,
                 Framing = new Boolean()
,
                 Hardwood_and_Laminate_Flooring = new Boolean()
,
                 Hardwood_Floor_Refinishing = new Boolean()
,
                 Home_Theaters = new Boolean()
,
                 Hot_Tubs__Spas___Jacuzzis = new Boolean()
,
                 Insulation = new Boolean()
,
                 Decorating___Design = new Boolean()
,
                 Kitchen_Remodeling = new Boolean()
,
                 Non_Slip_Treatments = new Boolean()
,
                 Painting_Services = new Boolean()
,
                 Solariums_and_Sunrooms = new Boolean()
,
                 Tile___Tiling = new Boolean()
,
                 Asbestos_Removal = new Boolean()
,
                 Wallpaper___Wall_Coverings___Removal = new Boolean()
,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()

    
 };

            return firstMaintenanceInterior;
        }

       public MaintenanceInterior SecondMaintenanceInterior()
        {

            var secondMaintenanceInterior = new MaintenanceInterior {

                 CompanyId = new Int32()
,
                 Basement_Lowering = new Boolean()
,
                 Basement_Remodeling = new Boolean()
,
                 Bathroom_Remodeling = new Boolean()
,
                 Cabinetry_and_Built_ins = new Boolean()
,
                 Carpenters = new Boolean()
,
                 Carpet_and_Vinyl_Floors = new Boolean()
,
                 Ceiling_Install_and_Repair = new Boolean()
,
                 Closets_Designing_Organizing = new Boolean()
,
                 Counter_Tops = new Boolean()
,
                 Remodeling = new Boolean()
,
                 Buffing___Polishing = new Boolean()
,
                 Drywall = new Boolean()
,
                 Carpet_Installation = new Boolean()
,
                 Fireplaces___Firewood = new Boolean()
,
                 Floor_Heating = new Boolean()
,
                 Framing = new Boolean()
,
                 Hardwood_and_Laminate_Flooring = new Boolean()
,
                 Hardwood_Floor_Refinishing = new Boolean()
,
                 Home_Theaters = new Boolean()
,
                 Hot_Tubs__Spas___Jacuzzis = new Boolean()
,
                 Insulation = new Boolean()
,
                 Decorating___Design = new Boolean()
,
                 Kitchen_Remodeling = new Boolean()
,
                 Non_Slip_Treatments = new Boolean()
,
                 Painting_Services = new Boolean()
,
                 Solariums_and_Sunrooms = new Boolean()
,
                 Tile___Tiling = new Boolean()
,
                 Asbestos_Removal = new Boolean()
,
                 Wallpaper___Wall_Coverings___Removal = new Boolean()
,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()

        
 };

            return secondMaintenanceInterior;
        }

       public MaintenanceInterior ThirdMaintenanceInterior()
        {

            var thirdMaintenanceInterior = new MaintenanceInterior {

                 CompanyId = new Int32()
,
                 Basement_Lowering = new Boolean()
,
                 Basement_Remodeling = new Boolean()
,
                 Bathroom_Remodeling = new Boolean()
,
                 Cabinetry_and_Built_ins = new Boolean()
,
                 Carpenters = new Boolean()
,
                 Carpet_and_Vinyl_Floors = new Boolean()
,
                 Ceiling_Install_and_Repair = new Boolean()
,
                 Closets_Designing_Organizing = new Boolean()
,
                 Counter_Tops = new Boolean()
,
                 Remodeling = new Boolean()
,
                 Buffing___Polishing = new Boolean()
,
                 Drywall = new Boolean()
,
                 Carpet_Installation = new Boolean()
,
                 Fireplaces___Firewood = new Boolean()
,
                 Floor_Heating = new Boolean()
,
                 Framing = new Boolean()
,
                 Hardwood_and_Laminate_Flooring = new Boolean()
,
                 Hardwood_Floor_Refinishing = new Boolean()
,
                 Home_Theaters = new Boolean()
,
                 Hot_Tubs__Spas___Jacuzzis = new Boolean()
,
                 Insulation = new Boolean()
,
                 Decorating___Design = new Boolean()
,
                 Kitchen_Remodeling = new Boolean()
,
                 Non_Slip_Treatments = new Boolean()
,
                 Painting_Services = new Boolean()
,
                 Solariums_and_Sunrooms = new Boolean()
,
                 Tile___Tiling = new Boolean()
,
                 Asbestos_Removal = new Boolean()
,
                 Wallpaper___Wall_Coverings___Removal = new Boolean()
,
                 MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp()

 
 };

            return thirdMaintenanceInterior;
        }

        ~FakeMaintenanceInteriors()
        {
            MyMaintenanceInteriors = null;
        }
    }
}


    