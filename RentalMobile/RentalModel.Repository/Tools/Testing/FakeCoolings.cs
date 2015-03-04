using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeCooling
    { 
       public List<Cooling> MyCoolings;

       public FakeCooling()
        {
            InitializeCoolingList();
        }

       public void InitializeCoolingList()
        {
            MyCoolings = new List<Cooling> {
                FirstCooling(), 
                SecondCooling(),
                ThirdCooling()
            };
        }

       public Cooling FirstCooling()
        {

            var firstCooling = new Cooling {

                 CoolingID = new Int32()
,
                 CoolingValue = null
    
 };

            return firstCooling;
        }

       public Cooling SecondCooling()
        {

            var secondCooling = new Cooling {

                 CoolingID = new Int32()
,
                 CoolingValue = null
        
 };

            return secondCooling;
        }

       public Cooling ThirdCooling()
        {

            var thirdCooling = new Cooling {

                 CoolingID = new Int32()
,
                 CoolingValue = null
 
 };

            return thirdCooling;
        }

        ~FakeCooling()
        {
            MyCoolings = null;
        }
    }
}


    