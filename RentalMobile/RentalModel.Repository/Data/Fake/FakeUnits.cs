using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeUnits
    {
        public List<Unit> MyUnits;

        public Unit FirstUnit()
        {
            var firstUnitAppliance = new UnitAppliance
                {
                    UnitId = 1,
                    Range_Oven = true,
                    Full_Refrigerator = false,
                    Dishwasher = true,
                    Sink_Disposal = false,
                    Microwave = false,
                    Central_Vacuum = false,
                    Surround_Sound = false,
                    Wine_Fridge = false,
                    Washer___Dryer_in_Unit = false,
                    Washer_Dryer_Connections = false,
                    Shared_Laundry_Facility = false
                };
            var firstUnit = new Unit
                {
                    UnitId = 1,
                    Bed = 1,
                    Bathroom = 3,
                    SquareFoot = 2000,
                    Lot = null,
                    TypeId = 2,
                    YearBuilt = Convert.ToDateTime("5/5/2001"),
                    YearRemodeled = null,
                    Description = "First Home Ever",
                    PrimaryPhoto = "none",
                    Address = "Kansas Address",
                    GoogleMap = "",
                    Country = "USA",
                    State = "KS",
                    Region = "Overland Park",
                    City = "Olathe",
                    Zip = "",
                    CountryCode = "US",
                    NumberofPhoto = 0,
                    Price = 100,
                    Currency = "Dollars",
                    CurrencyCode = 1,
                    ParkingSpaceId = 1,
                    GarageSizeId = 1,
                    DaysOnSite = 2,
                    FloorId = null,
                    AvailableDate = Convert.ToDateTime("5/5/2001"),
                    PosterRole = "CUS",
                    PosterID = 100,
                    YouTubeVideo = true,
                    YouTubeVideoURL = "http://www.video.com",
                    VimeoVideo = true,
                    VimeoVideoURL = "http:sdfsd",
                    Title = "fist Home",
                    UnitCommunityAmenity = new UnitCommunityAmenity
                        {
                            UnitId = 1,
                            Neighborhood_Name = "No Name",
                            Elementary_School = "no Name",
                            High_School = "no Name",
                            School_District = "Shawnee",
                            Middle_School = "no",
                            County_Name = "Mission",
                            Assisted_Living_Community = false,
                            Over_55_Active_Community = false,
                            Disability_Access = false,
                            Controlled_Access = false,
                            Community_Pool = false
                        },
                    UnitFeature = new UnitFeature
                        {
                            UnitId = 1,
                            High_Speed_Internet_Access = false,
                            Internet_Included = false,
                            Wireless_Internet_Access = false,
                            Some_Paid_Utilities = false,
                            Covered_Parking = false,
                            Pets_allowed = false,
                            Cats_Allowed = false,
                            Small_Dogs = false,
                            Large_Dogs = false,
                            Alarm_system = false,
                            Near_Transportation = false,
                            Short_Term_Lease_Available = false,
                            RV_Parking = false,
                            Boat_Storage = false
                        },
                    UnitGalleries = new List<UnitGallery>()
                        {
                            new UnitGallery
                                {
                                    UnitGalleryId = 1,
                                    Path = "none",
                                    Caption = "none",
                                    Rank = 1,
                                    UnitId = 1,
                                },
                            new UnitGallery
                                {
                                    UnitGalleryId = 2,
                                    Path = "none",
                                    Caption = "none",
                                    Rank = 2,
                                    UnitId = 1,
                                }
                        },
                    UnitInteriorAmenity = new UnitInteriorAmenity
                        {
                            UnitId = 1,
                            CoolingTypeId = 1,
                            HeatingTypeId = 1,
                            Fireplace = false,
                            Hot_Tub_Spa = false,
                            Cable_Ready = false,
                            Attic = false,
                            BasementTypeId = 1,
                            Double_Pane_Storm_Windows = false,
                            FloorCoveringId = 1,
                            FoundationTypeId = 1,
                            Kitchen_Island = false,
                            Vaulted_Ceiling = false,
                            Ceiling_Fan = false,
                            Jetted_Tub = false,
                            Floor = 1
                        },
                    UnitLuxuryAmenity = new UnitLuxuryAmenity
                        {
                            UnitId = 1,
                            Tennis_Court = false,
                            Security_System = false,
                            Sports_Court = false,
                            Basketball_Court = false,
                            Fitness_Center = false,
                            Barbecue = false,
                            Elevator = false,
                            Porch = false,
                            Sauna = false,
                            Skylight = false,
                            Intercom = false,
                            Waterfront = false,
                            Wet_Bar = false,
                            Doorman = false,
                            Solar_Heat = false,
                            Solar_Plumbing = false,
                            Solar_Screens = false
                        },
                    UnitPricing = new UnitPricing
                        {
                            UnitId = 1,
                            Rent = 850,
                            CurrencyId = 1,
                            AvailableDate = DateTime.Today.Date,
                            Deposit = 850,
                            ApplicationFee = 35,
                            Section_8_Eligible = false
                        },
                    UnitExteriorAmenity = new UnitExteriorAmenity
                        {
                            UnitId = 1,
                            Pool = false,
                            Garden = false,
                            Gated_Entry = false,
                            Greenhouse = false,
                            Lawn = false,
                            Deck = false,
                            Dock = false,
                            Fenced_Yard = false,
                            Sprinkler_System = false,
                            Patio = false,
                            Pond = false
                        },
                    UnitAppliance = firstUnitAppliance
                };
            return firstUnit;
        }

        public Unit SecondUnit()
        {
            var secondUnitAppliance = new UnitAppliance
            {
                UnitId = 1,
                Range_Oven = true,
                Full_Refrigerator = false,
                Dishwasher = true,
                Sink_Disposal = false,
                Microwave = false,
                Central_Vacuum = false,
                Surround_Sound = false,
                Wine_Fridge = false,
                Washer___Dryer_in_Unit = false,
                Washer_Dryer_Connections = false,
                Shared_Laundry_Facility = false
            };
            var secondUnit = new Unit
            {
                UnitId = 1,
                Bed = 1,
                Bathroom = 3,
                SquareFoot = 2000,
                Lot = null,
                TypeId = 2,
                YearBuilt = Convert.ToDateTime("5/5/2001"),
                YearRemodeled = null,
                Description = "second Home Ever",
                PrimaryPhoto = "none",
                Address = "Kansas Address",
                GoogleMap = "",
                Country = "USA",
                State = "KS",
                Region = "Overland Park",
                City = "Olathe",
                Zip = "",
                CountryCode = "US",
                NumberofPhoto = 0,
                Price = 100,
                Currency = "Dollars",
                CurrencyCode = 1,
                ParkingSpaceId = 1,
                GarageSizeId = 1,
                DaysOnSite = 2,
                FloorId = null,
                AvailableDate = Convert.ToDateTime("5/5/2001"),
                PosterRole = "CUS",
                PosterID = 100,
                YouTubeVideo = true,
                YouTubeVideoURL = "http://www.video.com",
                VimeoVideo = true,
                VimeoVideoURL = "http:sdfsd",
                Title = "fist Home",
                UnitCommunityAmenity = new UnitCommunityAmenity
                {
                    UnitId = 1,
                    Neighborhood_Name = "No Name",
                    Elementary_School = "no Name",
                    High_School = "no Name",
                    School_District = "Shawnee",
                    Middle_School = "no",
                    County_Name = "Mission",
                    Assisted_Living_Community = false,
                    Over_55_Active_Community = false,
                    Disability_Access = false,
                    Controlled_Access = false,
                    Community_Pool = false
                },
                UnitFeature = new UnitFeature
                {
                    UnitId = 1,
                    High_Speed_Internet_Access = false,
                    Internet_Included = false,
                    Wireless_Internet_Access = false,
                    Some_Paid_Utilities = false,
                    Covered_Parking = false,
                    Pets_allowed = false,
                    Cats_Allowed = false,
                    Small_Dogs = false,
                    Large_Dogs = false,
                    Alarm_system = false,
                    Near_Transportation = false,
                    Short_Term_Lease_Available = false,
                    RV_Parking = false,
                    Boat_Storage = false
                },
                UnitGalleries = new List<UnitGallery>()
                        {
                            new UnitGallery
                                {
                                    UnitGalleryId = 1,
                                    Path = "none",
                                    Caption = "none",
                                    Rank = 1,
                                    UnitId = 1,
                                },
                            new UnitGallery
                                {
                                    UnitGalleryId = 2,
                                    Path = "none",
                                    Caption = "none",
                                    Rank = 2,
                                    UnitId = 1,
                                }
                        },
                UnitInteriorAmenity = new UnitInteriorAmenity
                {
                    UnitId = 1,
                    CoolingTypeId = 1,
                    HeatingTypeId = 1,
                    Fireplace = false,
                    Hot_Tub_Spa = false,
                    Cable_Ready = false,
                    Attic = false,
                    BasementTypeId = 1,
                    Double_Pane_Storm_Windows = false,
                    FloorCoveringId = 1,
                    FoundationTypeId = 1,
                    Kitchen_Island = false,
                    Vaulted_Ceiling = false,
                    Ceiling_Fan = false,
                    Jetted_Tub = false,
                    Floor = 1
                },
                UnitLuxuryAmenity = new UnitLuxuryAmenity
                {
                    UnitId = 1,
                    Tennis_Court = false,
                    Security_System = false,
                    Sports_Court = false,
                    Basketball_Court = false,
                    Fitness_Center = false,
                    Barbecue = false,
                    Elevator = false,
                    Porch = false,
                    Sauna = false,
                    Skylight = false,
                    Intercom = false,
                    Waterfront = false,
                    Wet_Bar = false,
                    Doorman = false,
                    Solar_Heat = false,
                    Solar_Plumbing = false,
                    Solar_Screens = false
                },
                UnitPricing = new UnitPricing
                {
                    UnitId = 1,
                    Rent = 850,
                    CurrencyId = 1,
                    AvailableDate = DateTime.Today.Date,
                    Deposit = 850,
                    ApplicationFee = 35,
                    Section_8_Eligible = false
                },
                UnitExteriorAmenity = new UnitExteriorAmenity
                {
                    UnitId = 1,
                    Pool = false,
                    Garden = false,
                    Gated_Entry = false,
                    Greenhouse = false,
                    Lawn = false,
                    Deck = false,
                    Dock = false,
                    Fenced_Yard = false,
                    Sprinkler_System = false,
                    Patio = false,
                    Pond = false
                },
                UnitAppliance = secondUnitAppliance
            };
            return secondUnit;
        }

        public FakeUnits()
        {
            InitializeUnitList();
        }

        public void InitializeUnitList()
        {
            MyUnits = new List<Unit> {FirstUnit(), SecondUnit()};
        }

        ~FakeUnits()
        {
            MyUnits = null;
        }
    }
}