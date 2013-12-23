//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Unit
    {
        public Unit()
        {
            this.UnitGalleries = new HashSet<UnitGallery>();
        }
    
        public int UnitId { get; set; }
        public int Bed { get; set; }
        public double Bathroom { get; set; }
        public double SquareFoot { get; set; }
        public Nullable<double> Lot { get; set; }
        public Nullable<int> TypeId { get; set; }
        public Nullable<System.DateTime> YearBuilt { get; set; }
        public Nullable<System.DateTime> YearRemodeled { get; set; }
        public string Description { get; set; }
        public string PrimaryPhoto { get; set; }
        public string Address { get; set; }
        public string GoogleMap { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string CountryCode { get; set; }
        public Nullable<int> NumberofPhoto { get; set; }
        public Nullable<double> Price { get; set; }
        public string Currency { get; set; }
        public Nullable<int> CurrencyCode { get; set; }
        public Nullable<int> ParkingSpaceId { get; set; }
        public Nullable<int> GarageSizeId { get; set; }
        public Nullable<int> DaysOnSite { get; set; }
        public Nullable<int> FloorId { get; set; }
        public Nullable<System.DateTime> AvailableDate { get; set; }
        public string PosterRole { get; set; }
        public Nullable<int> PosterID { get; set; }
        public Nullable<bool> YouTubeVideo { get; set; }
        public string YouTubeVideoURL { get; set; }
        public Nullable<bool> VimeoVideo { get; set; }
        public string VimeoVideoURL { get; set; }
        public string Title { get; set; }
    
        public virtual UnitAppliance UnitAppliance { get; set; }
        public virtual UnitCommunityAmenity UnitCommunityAmenity { get; set; }
        public virtual UnitFeature UnitFeature { get; set; }
        public virtual ICollection<UnitGallery> UnitGalleries { get; set; }
        public virtual UnitInteriorAmenity UnitInteriorAmenity { get; set; }
        public virtual UnitLuxuryAmenity UnitLuxuryAmenity { get; set; }
        public virtual UnitPricing UnitPricing { get; set; }
        public virtual UnitExteriorAmenity UnitExteriorAmenity { get; set; }
    }
}
