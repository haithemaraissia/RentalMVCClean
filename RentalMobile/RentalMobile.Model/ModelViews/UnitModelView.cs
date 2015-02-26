using RentalMobile.Model.Models;

namespace RentalMobile.Model.ModelViews
{
    public class UnitModelView
    {
        public Unit Unit { get; set; }
        public UnitFeature UnitFeature { get; set; }
        public UnitCommunityAmenity UnitCommunityAmenity { get; set; }
        public UnitAppliance UnitAppliance { get; set; }
        public UnitInteriorAmenity UnitInteriorAmenity { get; set; }
        public UnitExteriorAmenity UnitExteriorAmenity { get; set; }
        public UnitLuxuryAmenity UnitLuxuryAmenity { get; set; }
        public UnitPricing UnitPricing { get; set; }
        public UnitGallery UnitGallery { get; set; }
        public Currency Currency { get; set; }
    }
}