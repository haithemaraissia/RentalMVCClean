using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeUnitLuxuryAmenitys
    { 
       public List<UnitLuxuryAmenity> MyUnitLuxuryAmenitys;

       public FakeUnitLuxuryAmenitys()
        {
            InitializeUnitLuxuryAmenityList();
        }

       public void InitializeUnitLuxuryAmenityList()
        {
            MyUnitLuxuryAmenitys = new List<UnitLuxuryAmenity> {
                FirstUnitLuxuryAmenity(), 
                SecondUnitLuxuryAmenity(),
                ThirdUnitLuxuryAmenity()
            };
        }

       public UnitLuxuryAmenity FirstUnitLuxuryAmenity()
        {

            var firstUnitLuxuryAmenity = new UnitLuxuryAmenity {

                 UnitId = new Int32()
,
                 Tennis_Court = new Boolean()
,
                 Security_System = new Boolean()
,
                 Sports_Court = new Boolean()
,
                 Basketball_Court = new Boolean()
,
                 Fitness_Center = new Boolean()
,
                 Barbecue = new Boolean()
,
                 Elevator = new Boolean()
,
                 Porch = new Boolean()
,
                 Sauna = new Boolean()
,
                 Skylight = new Boolean()
,
                 Intercom = new Boolean()
,
                 Waterfront = new Boolean()
,
                 Wet_Bar = new Boolean()
,
                 Doorman = new Boolean()
,
                 Solar_Heat = new Boolean()
,
                 Solar_Plumbing = new Boolean()
,
                 Solar_Screens = new Boolean()
,
                 Unit = new Unit()

    
 };

            return firstUnitLuxuryAmenity;
        }

       public UnitLuxuryAmenity SecondUnitLuxuryAmenity()
        {

            var secondUnitLuxuryAmenity = new UnitLuxuryAmenity {

                 UnitId = new Int32()
,
                 Tennis_Court = new Boolean()
,
                 Security_System = new Boolean()
,
                 Sports_Court = new Boolean()
,
                 Basketball_Court = new Boolean()
,
                 Fitness_Center = new Boolean()
,
                 Barbecue = new Boolean()
,
                 Elevator = new Boolean()
,
                 Porch = new Boolean()
,
                 Sauna = new Boolean()
,
                 Skylight = new Boolean()
,
                 Intercom = new Boolean()
,
                 Waterfront = new Boolean()
,
                 Wet_Bar = new Boolean()
,
                 Doorman = new Boolean()
,
                 Solar_Heat = new Boolean()
,
                 Solar_Plumbing = new Boolean()
,
                 Solar_Screens = new Boolean()
,
                 Unit = new Unit()

        
 };

            return secondUnitLuxuryAmenity;
        }

       public UnitLuxuryAmenity ThirdUnitLuxuryAmenity()
        {

            var thirdUnitLuxuryAmenity = new UnitLuxuryAmenity {

                 UnitId = new Int32()
,
                 Tennis_Court = new Boolean()
,
                 Security_System = new Boolean()
,
                 Sports_Court = new Boolean()
,
                 Basketball_Court = new Boolean()
,
                 Fitness_Center = new Boolean()
,
                 Barbecue = new Boolean()
,
                 Elevator = new Boolean()
,
                 Porch = new Boolean()
,
                 Sauna = new Boolean()
,
                 Skylight = new Boolean()
,
                 Intercom = new Boolean()
,
                 Waterfront = new Boolean()
,
                 Wet_Bar = new Boolean()
,
                 Doorman = new Boolean()
,
                 Solar_Heat = new Boolean()
,
                 Solar_Plumbing = new Boolean()
,
                 Solar_Screens = new Boolean()
,
                 Unit = new Unit()

 
 };

            return thirdUnitLuxuryAmenity;
        }

        ~FakeUnitLuxuryAmenitys()
        {
            MyUnitLuxuryAmenitys = null;
        }
    }
}


    