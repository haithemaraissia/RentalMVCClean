using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeUnits
    { 
       public List<Unit> MyUnits;

       public FakeUnits()
        {
            InitializeUnitList();
        }

       public void InitializeUnitList()
        {
            MyUnits = new List<Unit> {
                FirstUnit(), 
                SecondUnit(),
                ThirdUnit()
            };
        }

       public Unit FirstUnit()
       {
           var firstUnitId = new Int32();

            var firstUnit = new Unit {

                UnitId = firstUnitId
,
                 Bed = new Int32()
,
                 Bathroom = new Double()
,
                 SquareFoot = new Double()
,
                 Lot = new Double(),
                 TypeId = new Int32(),
                 YearBuilt = new DateTime(),
                 YearRemodeled = new DateTime(),
                 Description = null,
                 PrimaryPhoto = null,
                 Address = null,
                 GoogleMap = null,
                 Country = null,
                 State = null,
                 Region = null,
                 City = null,
                 Zip = null,
                 CountryCode = null,
                 NumberofPhoto = new Int32(),
                 Price = new Double(),
                 Currency = null,
                 CurrencyCode = new Int32(),
                 ParkingSpaceId = new Int32(),
                 GarageSizeId = new Int32(),
                 DaysOnSite = new Int32(),
                 FloorId = new Int32(),
                 AvailableDate = new DateTime(),
                 PosterRole = null,
                 PosterID = new Int32(),
                 YouTubeVideo = new Boolean(),
                 YouTubeVideoURL = null,
                 VimeoVideo = new Boolean(),
                 VimeoVideoURL = null,
                 Title = null,
                 UnitAppliance = new UnitAppliance()
,
                 UnitCommunityAmenity = new UnitCommunityAmenity()
,
                 UnitExteriorAmenity = new UnitExteriorAmenity()
,
                 UnitFeature = new UnitFeature()
,
//Skipping UnitGallery Collection
                 UnitInteriorAmenity = new UnitInteriorAmenity()
,
                 UnitLuxuryAmenity = new UnitLuxuryAmenity()
,
                 UnitPricing = new UnitPricing
                 {
                     UnitId = firstUnitId,
                     Rent = 50
                     
                 }

    
 };

            return firstUnit;
        }

       public Unit SecondUnit()
        {

            var secondUnit = new Unit {

                 UnitId = 2
,
                 Bed = 4
,
                 Bathroom = new Double()
,
                 SquareFoot = new Double()
,
                 Lot = new Double(),
                 TypeId = new Int32(),
                 YearBuilt = new DateTime(),
                 YearRemodeled = new DateTime(),
                 Description = null,
                 PrimaryPhoto = null,
                 Address = null,
                 GoogleMap = null,
                 Country = null,
                 State = null,
                 Region = null,
                 City = null,
                 Zip = null,
                 CountryCode = null,
                 NumberofPhoto = new Int32(),
                 Price = new Double(),
                 Currency = null,
                 CurrencyCode = new Int32(),
                 ParkingSpaceId = new Int32(),
                 GarageSizeId = new Int32(),
                 DaysOnSite = new Int32(),
                 FloorId = new Int32(),
                 AvailableDate = new DateTime(),
                 PosterRole = null,
                 PosterID = new Int32(),
                 YouTubeVideo = new Boolean(),
                 YouTubeVideoURL = null,
                 VimeoVideo = new Boolean(),
                 VimeoVideoURL = null,
                 Title = null,
                 UnitAppliance = new UnitAppliance()
,
                 UnitCommunityAmenity = new UnitCommunityAmenity()
,
                 UnitExteriorAmenity = new UnitExteriorAmenity()
,
                 UnitFeature = new UnitFeature()
,
//Skipping UnitGallery Collection
                 UnitInteriorAmenity = new UnitInteriorAmenity()
,
                 UnitLuxuryAmenity = new UnitLuxuryAmenity()
,
                 UnitPricing = new UnitPricing()

        
 };

            return secondUnit;
        }

       public Unit ThirdUnit()
        {

            var thirdUnit = new Unit {

                 UnitId = new Int32()
,
                 Bed = new Int32()
,
                 Bathroom = new Double()
,
                 SquareFoot = new Double()
,
                 Lot = new Double(),
                 TypeId = new Int32(),
                 YearBuilt = new DateTime(),
                 YearRemodeled = new DateTime(),
                 Description = null,
                 PrimaryPhoto = null,
                 Address = null,
                 GoogleMap = null,
                 Country = null,
                 State = null,
                 Region = null,
                 City = null,
                 Zip = null,
                 CountryCode = null,
                 NumberofPhoto = new Int32(),
                 Price = new Double(),
                 Currency = null,
                 CurrencyCode = new Int32(),
                 ParkingSpaceId = new Int32(),
                 GarageSizeId = new Int32(),
                 DaysOnSite = new Int32(),
                 FloorId = new Int32(),
                 AvailableDate = new DateTime(),
                 PosterRole = null,
                 PosterID = new Int32(),
                 YouTubeVideo = new Boolean(),
                 YouTubeVideoURL = null,
                 VimeoVideo = new Boolean(),
                 VimeoVideoURL = null,
                 Title = null,
                 UnitAppliance = new UnitAppliance()
,
                 UnitCommunityAmenity = new UnitCommunityAmenity()
,
                 UnitExteriorAmenity = new UnitExteriorAmenity()
,
                 UnitFeature = new UnitFeature()
,
//Skipping UnitGallery Collection
                 UnitInteriorAmenity = new UnitInteriorAmenity()
,
                 UnitLuxuryAmenity = new UnitLuxuryAmenity()
,
                 UnitPricing = new UnitPricing()

 
 };

            return thirdUnit;
        }

        ~FakeUnits()
        {
            MyUnits = null;
        }
    }
}


    