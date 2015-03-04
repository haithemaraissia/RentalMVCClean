using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeUnitFeature
    { 
       public List<UnitFeature> MyUnitFeatures;

       public FakeUnitFeature()
        {
            InitializeUnitFeatureList();
        }

       public void InitializeUnitFeatureList()
        {
            MyUnitFeatures = new List<UnitFeature> {
                FirstUnitFeature(), 
                SecondUnitFeature(),
                ThirdUnitFeature()
            };
        }

       public UnitFeature FirstUnitFeature()
        {

            var firstUnitFeature = new UnitFeature {

                 UnitId = new Int32()
,
                 High_Speed_Internet_Access = new Boolean()
,
                 Internet_Included = new Boolean()
,
                 Wireless_Internet_Access = new Boolean()
,
                 Some_Paid_Utilities = new Boolean()
,
                 Covered_Parking = new Boolean()
,
                 Pets_allowed = new Boolean()
,
                 Cats_Allowed = new Boolean()
,
                 Small_Dogs = new Boolean()
,
                 Large_Dogs = new Boolean()
,
                 Alarm_system = new Boolean()
,
                 Near_Transportation = new Boolean()
,
                 Short_Term_Lease_Available = new Boolean()
,
                 RV_Parking = new Boolean()
,
                 Boat_Storage = new Boolean()
,
                 Unit = new Unit()

    
 };

            return firstUnitFeature;
        }

       public UnitFeature SecondUnitFeature()
        {

            var secondUnitFeature = new UnitFeature {

                 UnitId = new Int32()
,
                 High_Speed_Internet_Access = new Boolean()
,
                 Internet_Included = new Boolean()
,
                 Wireless_Internet_Access = new Boolean()
,
                 Some_Paid_Utilities = new Boolean()
,
                 Covered_Parking = new Boolean()
,
                 Pets_allowed = new Boolean()
,
                 Cats_Allowed = new Boolean()
,
                 Small_Dogs = new Boolean()
,
                 Large_Dogs = new Boolean()
,
                 Alarm_system = new Boolean()
,
                 Near_Transportation = new Boolean()
,
                 Short_Term_Lease_Available = new Boolean()
,
                 RV_Parking = new Boolean()
,
                 Boat_Storage = new Boolean()
,
                 Unit = new Unit()

        
 };

            return secondUnitFeature;
        }

       public UnitFeature ThirdUnitFeature()
        {

            var thirdUnitFeature = new UnitFeature {

                 UnitId = new Int32()
,
                 High_Speed_Internet_Access = new Boolean()
,
                 Internet_Included = new Boolean()
,
                 Wireless_Internet_Access = new Boolean()
,
                 Some_Paid_Utilities = new Boolean()
,
                 Covered_Parking = new Boolean()
,
                 Pets_allowed = new Boolean()
,
                 Cats_Allowed = new Boolean()
,
                 Small_Dogs = new Boolean()
,
                 Large_Dogs = new Boolean()
,
                 Alarm_system = new Boolean()
,
                 Near_Transportation = new Boolean()
,
                 Short_Term_Lease_Available = new Boolean()
,
                 RV_Parking = new Boolean()
,
                 Boat_Storage = new Boolean()
,
                 Unit = new Unit()

 
 };

            return thirdUnitFeature;
        }

        ~FakeUnitFeature()
        {
            MyUnitFeatures = null;
        }
    }
}


    