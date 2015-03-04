using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeUnitInteriorAmenity
    { 
       public List<UnitInteriorAmenity> MyUnitInteriorAmenitys;

       public FakeUnitInteriorAmenity()
        {
            InitializeUnitInteriorAmenityList();
        }

       public void InitializeUnitInteriorAmenityList()
        {
            MyUnitInteriorAmenitys = new List<UnitInteriorAmenity> {
                FirstUnitInteriorAmenity(), 
                SecondUnitInteriorAmenity(),
                ThirdUnitInteriorAmenity()
            };
        }

       public UnitInteriorAmenity FirstUnitInteriorAmenity()
        {

            var firstUnitInteriorAmenity = new UnitInteriorAmenity {

                 UnitId = new Int32()
,
                 CoolingTypeId = new Int32()
,
                 HeatingTypeId = new Int32()
,
                 Fireplace = new Boolean()
,
                 Hot_Tub_Spa = new Boolean()
,
                 Cable_Ready = new Boolean()
,
                 Attic = new Boolean()
,
                 BasementTypeId = new Int32()
,
                 Double_Pane_Storm_Windows = new Boolean()
,
                 FloorCoveringId = new Int32()
,
                 FoundationTypeId = new Int32()
,
                 Kitchen_Island = new Boolean()
,
                 Vaulted_Ceiling = new Boolean()
,
                 Ceiling_Fan = new Boolean()
,
                 Jetted_Tub = new Boolean()
,
                 Floor = new Int32()
,
                 Unit = new Unit()

    
 };

            return firstUnitInteriorAmenity;
        }

       public UnitInteriorAmenity SecondUnitInteriorAmenity()
        {

            var secondUnitInteriorAmenity = new UnitInteriorAmenity {

                 UnitId = new Int32()
,
                 CoolingTypeId = new Int32()
,
                 HeatingTypeId = new Int32()
,
                 Fireplace = new Boolean()
,
                 Hot_Tub_Spa = new Boolean()
,
                 Cable_Ready = new Boolean()
,
                 Attic = new Boolean()
,
                 BasementTypeId = new Int32()
,
                 Double_Pane_Storm_Windows = new Boolean()
,
                 FloorCoveringId = new Int32()
,
                 FoundationTypeId = new Int32()
,
                 Kitchen_Island = new Boolean()
,
                 Vaulted_Ceiling = new Boolean()
,
                 Ceiling_Fan = new Boolean()
,
                 Jetted_Tub = new Boolean()
,
                 Floor = new Int32()
,
                 Unit = new Unit()

        
 };

            return secondUnitInteriorAmenity;
        }

       public UnitInteriorAmenity ThirdUnitInteriorAmenity()
        {

            var thirdUnitInteriorAmenity = new UnitInteriorAmenity {

                 UnitId = new Int32()
,
                 CoolingTypeId = new Int32()
,
                 HeatingTypeId = new Int32()
,
                 Fireplace = new Boolean()
,
                 Hot_Tub_Spa = new Boolean()
,
                 Cable_Ready = new Boolean()
,
                 Attic = new Boolean()
,
                 BasementTypeId = new Int32()
,
                 Double_Pane_Storm_Windows = new Boolean()
,
                 FloorCoveringId = new Int32()
,
                 FoundationTypeId = new Int32()
,
                 Kitchen_Island = new Boolean()
,
                 Vaulted_Ceiling = new Boolean()
,
                 Ceiling_Fan = new Boolean()
,
                 Jetted_Tub = new Boolean()
,
                 Floor = new Int32()
,
                 Unit = new Unit()

 
 };

            return thirdUnitInteriorAmenity;
        }

        ~FakeUnitInteriorAmenity()
        {
            MyUnitInteriorAmenitys = null;
        }
    }
}


    