using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeUnitAppliances
    { 
       public List<UnitAppliance> MyUnitAppliances;

       public FakeUnitAppliances()
        {
            InitializeUnitApplianceList();
        }

       public void InitializeUnitApplianceList()
        {
            MyUnitAppliances = new List<UnitAppliance> {
                FirstUnitAppliance(), 
                SecondUnitAppliance(),
                ThirdUnitAppliance()
            };
        }

       public UnitAppliance FirstUnitAppliance()
        {

            var firstUnitAppliance = new UnitAppliance {

                 UnitId = new Int32()
,
                 Range_Oven = new Boolean()
,
                 Full_Refrigerator = new Boolean()
,
                 Dishwasher = new Boolean()
,
                 Sink_Disposal = new Boolean()
,
                 Microwave = new Boolean()
,
                 Central_Vacuum = new Boolean()
,
                 Surround_Sound = new Boolean()
,
                 Wine_Fridge = new Boolean()
,
                 Washer___Dryer_in_Unit = new Boolean()
,
                 Washer_Dryer_Connections = new Boolean()
,
                 Shared_Laundry_Facility = new Boolean()
,
                 Unit = new Unit()

    
 };

            return firstUnitAppliance;
        }

       public UnitAppliance SecondUnitAppliance()
        {

            var secondUnitAppliance = new UnitAppliance {

                 UnitId = new Int32()
,
                 Range_Oven = new Boolean()
,
                 Full_Refrigerator = new Boolean()
,
                 Dishwasher = new Boolean()
,
                 Sink_Disposal = new Boolean()
,
                 Microwave = new Boolean()
,
                 Central_Vacuum = new Boolean()
,
                 Surround_Sound = new Boolean()
,
                 Wine_Fridge = new Boolean()
,
                 Washer___Dryer_in_Unit = new Boolean()
,
                 Washer_Dryer_Connections = new Boolean()
,
                 Shared_Laundry_Facility = new Boolean()
,
                 Unit = new Unit()

        
 };

            return secondUnitAppliance;
        }

       public UnitAppliance ThirdUnitAppliance()
        {

            var thirdUnitAppliance = new UnitAppliance {

                 UnitId = new Int32()
,
                 Range_Oven = new Boolean()
,
                 Full_Refrigerator = new Boolean()
,
                 Dishwasher = new Boolean()
,
                 Sink_Disposal = new Boolean()
,
                 Microwave = new Boolean()
,
                 Central_Vacuum = new Boolean()
,
                 Surround_Sound = new Boolean()
,
                 Wine_Fridge = new Boolean()
,
                 Washer___Dryer_in_Unit = new Boolean()
,
                 Washer_Dryer_Connections = new Boolean()
,
                 Shared_Laundry_Facility = new Boolean()
,
                 Unit = new Unit()

 
 };

            return thirdUnitAppliance;
        }

        ~FakeUnitAppliances()
        {
            MyUnitAppliances = null;
        }
    }
}


    