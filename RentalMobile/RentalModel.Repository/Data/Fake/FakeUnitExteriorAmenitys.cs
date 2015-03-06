using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeUnitExteriorAmenitys
    { 
       public List<UnitExteriorAmenity> MyUnitExteriorAmenitys;

       public FakeUnitExteriorAmenitys()
        {
            InitializeUnitExteriorAmenityList();
        }

       public void InitializeUnitExteriorAmenityList()
        {
            MyUnitExteriorAmenitys = new List<UnitExteriorAmenity> {
                FirstUnitExteriorAmenity(), 
                SecondUnitExteriorAmenity(),
                ThirdUnitExteriorAmenity()
            };
        }

       public UnitExteriorAmenity FirstUnitExteriorAmenity()
        {

            var firstUnitExteriorAmenity = new UnitExteriorAmenity {

                 UnitId = new Int32()
,
                 Pool = new Boolean()
,
                 Garden = new Boolean()
,
                 Gated_Entry = new Boolean()
,
                 Greenhouse = new Boolean()
,
                 Lawn = new Boolean()
,
                 Deck = new Boolean()
,
                 Dock = new Boolean()
,
                 Fenced_Yard = new Boolean()
,
                 Sprinkler_System = new Boolean()
,
                 Patio = new Boolean()
,
                 Pond = new Boolean()
,
                 Unit = new Unit()

    
 };

            return firstUnitExteriorAmenity;
        }

       public UnitExteriorAmenity SecondUnitExteriorAmenity()
        {

            var secondUnitExteriorAmenity = new UnitExteriorAmenity {

                 UnitId = new Int32()
,
                 Pool = new Boolean()
,
                 Garden = new Boolean()
,
                 Gated_Entry = new Boolean()
,
                 Greenhouse = new Boolean()
,
                 Lawn = new Boolean()
,
                 Deck = new Boolean()
,
                 Dock = new Boolean()
,
                 Fenced_Yard = new Boolean()
,
                 Sprinkler_System = new Boolean()
,
                 Patio = new Boolean()
,
                 Pond = new Boolean()
,
                 Unit = new Unit()

        
 };

            return secondUnitExteriorAmenity;
        }

       public UnitExteriorAmenity ThirdUnitExteriorAmenity()
        {

            var thirdUnitExteriorAmenity = new UnitExteriorAmenity {

                 UnitId = new Int32()
,
                 Pool = new Boolean()
,
                 Garden = new Boolean()
,
                 Gated_Entry = new Boolean()
,
                 Greenhouse = new Boolean()
,
                 Lawn = new Boolean()
,
                 Deck = new Boolean()
,
                 Dock = new Boolean()
,
                 Fenced_Yard = new Boolean()
,
                 Sprinkler_System = new Boolean()
,
                 Patio = new Boolean()
,
                 Pond = new Boolean()
,
                 Unit = new Unit()

 
 };

            return thirdUnitExteriorAmenity;
        }

        ~FakeUnitExteriorAmenitys()
        {
            MyUnitExteriorAmenitys = null;
        }
    }
}


    